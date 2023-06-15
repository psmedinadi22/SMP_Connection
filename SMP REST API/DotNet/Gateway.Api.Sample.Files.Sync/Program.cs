using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gateway.Api.Api;
using Gateway.Api.Client;

namespace Gateway.Api.Sample.Files.Sync
{
    //------------------------------------------------------
    //NOTE : This is sample code, there is no error handling
    //------------------------------------------------------                
	class Program
	{
		static private void ShowUsage()
		{
            Console.WriteLine("Gateway.Api.Sample.Files.Sync [username] [password] [ip] [remote folder] [local folder]");
		}

		static void Main(string[] args)
		{
			if (args.Count() != 5)
			{
				Console.WriteLine("Invalid parameter!");
				ShowUsage();
				return;
			}

			if (!Directory.Exists(args[4]))
			{
				Console.WriteLine("The directory " + args[4] + " does not exist");
				return;
			}

			try
			{
				// Configuring the username and password for the opening of the session.
				var configuration = new Configuration(username: args[0], password: args[1]);

				var client = new ApiClient(configuration, "https://" + args[2]);
				var factory = new ApiFactory(client);
				var api = factory.CreateApiSystemFilesV1();

				var response = api.List(args[3]);

				string[] downloadedFileNames = { };
				try
				{
					downloadedFileNames = File.ReadAllLines(args[4] + "//downloadedFileNames.txt");
				}
				catch (Exception) { }


				var files = response.Data.Files.Select(x => x.Name);
				var filteredFiles = files.Except(downloadedFileNames);
				if (filteredFiles.Count() == 0)
				{
					Console.WriteLine("No new file to download");
					return;
				}

				foreach (var file in filteredFiles)
				{
                    try
				    {
					    string serverFilePathName = args[3] + "\\" + file;
					    string localFilePathName = args[4] + "\\" + file;

					    using (var streamRemote = api.GetFile(serverFilePathName).Data)
					    {
						    using (var streamLocal = new FileStream(localFilePathName, FileMode.Create, FileAccess.Write, FileShare.None))
						    {
							    Console.Write("Downloading file " + localFilePathName + "...");

							    streamRemote.CopyTo(streamLocal);

							    Console.WriteLine("OK");
						    }
					    }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
				}


				//All files have been dowloaded, we can now persist the file so the next time those new files won't be downloaded.                
				File.WriteAllLines(args[4] + "//downloadedFileNames.txt", files);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
