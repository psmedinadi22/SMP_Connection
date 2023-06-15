using Gateway.Api.Api;
using Gateway.Api.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Api.Sample.Files.List
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				//------------------------------------------------------
				//NOTE : This is sample code, there is no error handling
				//------------------------------------------------------                
				//Usage :
				//args[0] : user
				//args[1] : password
				//args[2] : IP           
				//args[3] : remote path 
				var configuration = new Configuration(username: args[0], password: args[1]);

				// Setting the base URL and the configuration for the API client.
				var client = new ApiClient(configuration, "https://" + args[2]);
				var factory = new ApiFactory(client);

				// Initialize a Dashboard Name Plate Informations API with the previous settings.
				var api = factory.CreateApiSystemFilesV1();

				Console.WriteLine();
				var path = "/";
				if (args.Length >= 4)
				{
					path = args[3];
				}
				
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
					Console.WriteLine(format,
										file.LastWriteTime == null ? string.Empty : file.LastWriteTime.Value.ToString("yyyy-MM-dd hh:mm"),
										file.Name,
										(file.Size ?? 0).ToString());
				}

				Console.WriteLine();
			}
			catch (Exception e)
			{
				Console.Write(e.Message);
			}

		}
	}

}
