/**
 * Licensed to the Apache Software Foundation (ASF) under one 
 * or more contributor license agreements.  See the NOTICE file 
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Gateway.Api.Api;
using Gateway.Api.Client;

namespace Gateway.Api.Sample.Files.SmpFTP
{
	class Program
	{
		private class Command
		{
			public string Name { get; set; }
			public string Description { get; set; }
			public string Usage { get; set; }
			public Func<IEnumerable<string>, bool> Execute { get; set; }
			public Func<IEnumerable<string>, bool> Help { get; set; }
		}

		private static bool m_continue = true;
		private static string[] m_currentRemotePath = new string[] { };
		private static string[] m_currentLocalPath = Environment.CurrentDirectory.Split('\\', '/');

		private static Command[] m_commands = new Command[]
			{
				new Command
				{
					Name = "help",
					Description = "Show this help or the help of a command.",
					Usage = "help [command]",
					Execute = (arguments) =>
						{
							if (arguments.Any())
							{
								var command = m_commands.SingleOrDefault(c => string.Equals(c.Name, arguments.FirstOrDefault(), StringComparison.InvariantCultureIgnoreCase));
								if (command != null)
								{
									if (command.Help != null)
									{
										command.Help(arguments.Skip(0));
									}
									else
									{
										Console.WriteLine("");
										Console.WriteLine("Command:     {0}", string.Join(", ", command.Name));

										if (!command.Description.IsEmptyOrNull())
											Console.WriteLine("{0}", command.Description);

										if (!command.Usage.IsEmptyOrNull())
											Console.WriteLine("{0}", command.Usage);

										Console.WriteLine("");
									}
									return true;
								}
							}

							Console.WriteLine("");
							Console.WriteLine("Usage: smpftp [uri] [username] [password] [command [options]]");
							Console.WriteLine("Commands:");
							foreach (var command in m_commands.OrderBy(c => c.Name.FirstOrDefault()))
							{
								var descriptions = command.Description.EmptyIfNull().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
								Console.WriteLine("   {0,-20} {1}", string.Join(", ", command.Name), descriptions.FirstOrDefault());
								foreach (var description in descriptions.Skip(1))
								{
									Console.WriteLine("   {0,-20} {1}", string.Empty, description);
								}

								if (!command.Usage.IsEmptyOrNull())
								{
									Console.WriteLine("   {0,-20} {1}", string.Empty, command.Usage);
								}
								Console.WriteLine("");
							}
							Console.WriteLine("");
							return true;
						},
					//Help = (arguments) =>
					//	{
					//		Console.WriteLine("");
					//		Console.WriteLine("Command:      {0}", string.Join(", ", command.Names));
					//		Console.WriteLine("Description:  {0}", command.Description);
					//		Console.WriteLine("");

					//		return true;
					//	},
				},
				new Command
				{
					Name = "quit",
					Description = "Quit the shell mode.",
					Execute = (arguments) =>
						{
							Console.WriteLine("");
							m_continue = false;
							return true;
						},
				},
				new Command
				{
					Name = "uri",
					Description = "Set the base uri.",
					Usage = "uri https://127.0.0.1",
					Execute = (arguments) =>
						{
							var uri = arguments.FirstOrDefault();
							if (!string.IsNullOrEmpty(uri) && !uri.StartsWith("http://") && !uri.StartsWith("https://"))
								uri = "https://" + uri;

							ApiClient.Default.BaseUrl = new Uri(uri);

							Console.WriteLine("URI set.");
							return true;
						},
				},
				new Command
				{
					Name = "username",
					Description = "Set the username.",
					Usage = "username technician",
					Execute = (arguments) =>
						{
							if (arguments.Any())
							{
								ApiClient.Default.Configuration.Username = arguments.FirstOrDefault();

								Console.WriteLine("Username set.");
							}
							return true;
						},
				},
				new Command
				{
					Name = "password",
					Description = "Set the password.",
					Usage = "password Tech123*",
					Execute = (arguments) =>
						{
							if (arguments.Any())
							{
								ApiClient.Default.Configuration.Password = arguments.FirstOrDefault();

								Console.WriteLine("Password set.");
							}
							return true;
						},
				},
				new Command
				{
					Name = "dir",
					Description = "List the remote files and folders.",
					Usage = "dir [path]",
					Execute = (arguments) =>
						{
							Console.WriteLine();

							var api = ApiFactory.Default.CreateApiSystemFilesV1();

							var path = string.Join("/", m_currentRemotePath);

							if (arguments.Any())
								path += "/" + string.Join(" ", arguments);

							var data = api.List(path).Data;

							var format = "{0,-16} {1,-50} {2,10}";
							Console.WriteLine(format, " Date / Time ", " Name ", " Size ");
							Console.WriteLine(format, "================", "==================================================", "==========");

							foreach (var folder in data.Folders.EmptyIfNull().OrderBy(f => f.Name))
							{
								Console.WriteLine(format, "", folder.Name, "");
							}

							foreach (var file in data.Files.EmptyIfNull().OrderBy(f => f.Name))
							{
								Console.WriteLine(format,	file.LastWriteTime == null? string.Empty : file.LastWriteTime.Value.ToString("yyyy-MM-dd hh:mm"),
															file.Name, 
															(file.Size ?? 0).ToString());
							}
						
							Console.WriteLine();

							return true;
						},
				},
				new Command
				{
					Name = "ldir",
					Description = "List the local files and folders.",
					Usage = "ldir [folder_path]",
					Execute = (arguments) =>
						{
							Console.WriteLine();

							var path = string.Join("\\", m_currentLocalPath);

							if (arguments.Any())
								path += "\\" + string.Join(" ", arguments);

							var format = "{0,-60} {1,10}";
							Console.WriteLine(format, " Name", "Size ");
							Console.WriteLine(format, "============================================================", "==========");

							foreach (var folder in Directory.GetDirectories(path).OrderBy(f => f))
							{
								Console.WriteLine(format, folder, "");
							}

							foreach (var file in Directory.GetFiles(path).OrderBy(f => f).Select(f => new FileInfo(f)))
							{
								Console.WriteLine(format, file.Name, file.Length.ToString());
							}
						
							Console.WriteLine();

							return true;
						},
				},
				new Command
				{
					Name = "cd",
					Description = "Change the current folder on the smp.",
					Usage = "cd [path]",
					Execute = (arguments) =>
						{
							var api = ApiFactory.Default.CreateApiSystemFilesV1();

							if (string.Equals("..", arguments.FirstOrDefault().EmptyIfNull()))
							{
								if (m_currentRemotePath.Any())
									m_currentRemotePath = m_currentRemotePath.Take(m_currentRemotePath.Count() - 1).ToArray();
								
								return true;
							}
							else if (arguments.Any())
							{
								string path = string.Empty;
								if (!arguments.FirstOrDefault().EmptyIfNull().StartsWith("/"))
								{
									path = string.Join("/", m_currentRemotePath);
									path += "/";
								}

								path += string.Join(" ", arguments);

								api.List(path);

								m_currentRemotePath = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
							}
							Console.WriteLine("/{0}", string.Join("/", m_currentRemotePath));
							Console.WriteLine();

							return true;
						},
				},
				new Command
				{
					Name = "lcd",
					Description = "Change the current folder (local).",
					Usage = "lcd [path]",
					Execute = (arguments) =>
						{
							if (string.Equals("..", arguments.FirstOrDefault().EmptyIfNull()))
							{
								if (m_currentLocalPath.Any())
									m_currentLocalPath = m_currentLocalPath.Take(m_currentLocalPath.Count() - 1).ToArray();
								
								return true;
							}
							else if (arguments.Any())
							{
								var path = string.Join("\\", m_currentLocalPath);
									path += "\\" + string.Join(" ", arguments);

								if (Directory.Exists(path))
								{
									m_currentLocalPath = path.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
								}
							}
							Console.WriteLine("{0}", string.Join("\\", m_currentLocalPath));
							Console.WriteLine();
							return true;
						},
				},
				new Command
				{
					Name = "get",
					Description = "Get a remote file to the current local folder.",
					Usage = "get file_path",
					Execute = (arguments) =>
						{
							var api = ApiFactory.Default.CreateApiSystemFilesV1();

							var remotePath = string.Join("/", m_currentRemotePath);

							if (!arguments.Any())
								return ExecuteCommand(new[] { "help", "get" });
							{
								remotePath += "/" + string.Join(" ", arguments);
							}

							var filename = remotePath.Split('/').Last();
							var localPath = string.Join("\\", m_currentLocalPath);
							localPath += "\\" + filename;

							using (var streamRemote = api.GetFile(remotePath).Data)
							{								
								using (var streamLocal = new FileStream(localPath, FileMode.Create, FileAccess.Write, FileShare.None))
								{
									streamRemote.CopyTo(streamLocal);
								}
							}

							Console.WriteLine();
							Console.WriteLine("{0} downloaded to {1}", remotePath, localPath);
							Console.WriteLine();

							return true;
						},
				},
				new Command
				{
					Name = "put",
					Description = "Send a file to the smp.",
					Usage = "put local_file_path",
					Execute = (arguments) =>
						{
							if (!arguments.Any())
								return ExecuteCommand(new[] { "help", "put" });

							var api = ApiFactory.Default.CreateApiSystemFilesV1();

							var localPath = arguments.FirstOrDefault();
							var remotePath = arguments.Skip(1).FirstOrDefault();

							if (remotePath == null)
								remotePath = string.Join("/", m_currentRemotePath);

							using (var streamLocal = new FileStream(localPath, FileMode.Open, FileAccess.Read, FileShare.Read))
							{
								api.SendFile(remotePath, streamLocal);
							}

							Console.WriteLine();
							Console.WriteLine("{0} uploaded to {1}", localPath, remotePath);
							Console.WriteLine();

							return true;
						},
				},
				new Command
				{
					Name = "del",
					Description = "Delete a remote file or folder (without removing it).",
					Usage = "del remote_path",
					Execute = (arguments) =>
						{
							var api = ApiFactory.Default.CreateApiSystemFilesV1();

							if (!arguments.Any())
								return ExecuteCommand(new[] { "help", "del" });

							var path = string.Join("/", m_currentRemotePath);
							path += "/" + string.Join(" ", arguments);

							api.Delete(path, true);

							Console.WriteLine("{0} deleted.", path);
							Console.WriteLine();

							return true;
						},
				},
				new Command
				{
					Name = "mkdir",
					Description = "Create a remote folder.",
					Usage = "mkdir folder_name",
					Execute = (arguments) =>
						{
							if (!arguments.Any())
								return ExecuteCommand(new[] { "help", "mkdir" });

							var api = ApiFactory.Default.CreateApiSystemFilesV1();

							string path = string.Empty;
							if (!arguments.FirstOrDefault().EmptyIfNull().StartsWith("/"))
							{
								path = string.Join("/", m_currentRemotePath);
								path += "/";
							}

							path += arguments.FirstOrDefault();

							api.CreateFolder(path, true);

							Console.WriteLine();
							Console.WriteLine("{0} created", path);
							Console.WriteLine();

							return true;
						},
				},
				new Command
				{
					Name = "rmdir",
					Description = "Remove a remote folder (recursive)",
					Usage = "rmdir folder_path",
					Execute = (arguments) =>
						{
							var api = ApiFactory.Default.CreateApiSystemFilesV1();

							if (!arguments.Any())
								return ExecuteCommand(new[] { "help", "del" });

							var path = string.Join("/", m_currentRemotePath);
							path += "/" + string.Join(" ", arguments);

							api.Delete(path, true, true);

							Console.WriteLine("{0} deleted.", path);
							Console.WriteLine();

							return true;
						},
				},
				new Command
				{
					Name = "cls",
					Description = "Clear the screen.",
					Execute = arguments =>
						{
							Console.Clear();
							return true;
						},
				},
				new Command
				{
					Name = "script",
					Description = "Execute a list of commands from a file.",
					Usage = "script local_filename",
					Execute = (arguments) =>
						{
							Console.WriteLine();

							var path = string.Join(" ", arguments);
							Console.WriteLine("SCRIPT: {0}", path);

							foreach(var line in File.ReadAllLines(path))
							{
								if (!m_continue)
									break;

								Console.WriteLine("   {0}", line);
								ExecuteCommand(line);
							}

							Console.WriteLine();

							return true;
						},
				},
			};

		static bool ExecuteCommand(string arguments)
		{
			return ExecuteCommand(arguments.SplitQuoted().ToList());
		}

		static bool ExecuteCommand(IEnumerable<string> arguments)
		{
			var commandName = arguments.FirstOrDefault();
			if (!commandName.IsEmptyOrNull())
			{
				var command = m_commands.SingleOrDefault(c => string.Equals(c.Name, commandName, StringComparison.InvariantCultureIgnoreCase));
				if (command != null && command.Execute != null)
				{
					try
					{
						return command.Execute(arguments.Skip(1));
					}
					catch (ApiException ex)
					{
                        Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine();
						Console.WriteLine("{0}", ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
						return true; // found one.
					}
				}

				Console.WriteLine("Unknown command.");
			}

			return false;
		}

		static void Main(string[] args)
		{
			var arguments = args.EmptyIfNull();
			if (!arguments.Any())
			{
				arguments = new[] { Properties.Settings.Default.DefaultUri, Properties.Settings.Default.DefaultUsername, Properties.Settings.Default.DefaultPassword };
			}

			var uri = arguments.Skip(0).FirstOrDefault();
			if (!string.IsNullOrEmpty(uri) && !uri.StartsWith("http://") && !uri.StartsWith("https://"))
				uri = "https://" + uri;

			ApiClient.Default.BaseUrl = new Uri(uri);
			ApiClient.Default.Configuration.Username = arguments.Skip(1).FirstOrDefault();
			ApiClient.Default.Configuration.Password = arguments.Skip(2).FirstOrDefault();

			if (ExecuteCommand(arguments.Skip(3)))
				return;

			ExecuteCommand(new[] { "help" });

			while (m_continue)
			{
				Console.Write("/{0}> ", string.Join("/", m_currentRemotePath));

				var line = Console.ReadLine();

				if (line.IsEmptyOrNull())
					continue;

				ExecuteCommand(line);
			}
		}
	}
}
