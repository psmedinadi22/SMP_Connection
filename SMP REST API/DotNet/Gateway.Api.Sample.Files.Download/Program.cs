using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gateway.Api.Api;
using Gateway.Api.Client;

namespace Gateway.Api.Sample.Files.Download
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
                //args[4] : local path
                
                var configuration = new Configuration(username: args[0], password: args[1]);

                // Setting the base URL and the configuration for the API client.
                var client = new ApiClient(configuration, "https://" + args[2]);
                var factory = new ApiFactory(client);

                // Initialize a Dashboard Name Plate Informations API with the previous settings.
                var api = factory.CreateApiSystemFilesV1();

                var response = api.List(args[3]);
                foreach (var file in response.Data.Files)
                {
                    string serverFilePathName = args[3] + "/" + file.Name;
                    string localFilePathName = args[4] + "/" + file.Name;

                    using (var streamRemote = api.GetFile(serverFilePathName).Data)
                    {
                        using (var streamLocal = new FileStream(localFilePathName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            streamRemote.CopyTo(streamLocal);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            
		}
	}
}
