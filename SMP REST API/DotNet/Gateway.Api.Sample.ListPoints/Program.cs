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
using System.Linq;
using System.Net;
using System.Text;
using Gateway.Api.Api;
using Gateway.Api.Client;
using Gateway.Api.Model;
using Gateway.Api.Sample.ListPoints.Properties;

namespace Gateway.Api.Sample.ListPoints
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("--------------------------------------------------------------");
			Console.Write("{0,-10} [{1, -25}] : ", "URI", AppSettings.Default.URI);
			var uri = Console.ReadLine();
			if (string.IsNullOrEmpty(uri))
				uri = AppSettings.Default.URI;
			else if (!uri.StartsWith("http://") && !uri.StartsWith("https://"))
				uri = "https://" + uri;

			Console.Write("{0,-10} [{1, -25}] : ", "Username", AppSettings.Default.Username);
			var username = Console.ReadLine();
			if (string.IsNullOrEmpty(username))
				username = AppSettings.Default.Username;

			Console.Write("{0,-10} [{1, -25}] : ", "Password", "***********");
			var password = Console.ReadLine();
			if (string.IsNullOrEmpty(password))
				password = AppSettings.Default.Password;

            // Configuring the username and password for the opening of the session.
			var configuration = new Configuration(username: username, password: password);

            // Setting the base URL and the configuration for the API client.
			var client = new ApiClient(configuration, uri);

			var factory = new ApiFactory(client);

            // Initialize a Points API with the previous settings.
			var api = factory.CreateApiDataPointsV1();

			Console.WriteLine("--------------------------------------------------------------");
			Console.WriteLine("{0,-20} : {1}", "URI", client.BaseUrl);
			Console.WriteLine("{0,-20} : {1}", "Username", client.Configuration.Username);
			Console.WriteLine("{0,-20} : {1}", "Password", "**************");
			Console.WriteLine("--------------------------------------------------------------");

			var pointByIDs = api.ListAll(details: true).ToDictionary(p => p.ID.Value);

			Console.WriteLine("{0,5}   {1,-30}   {2,-10}", "ID", "Name", "Value");
			Console.WriteLine("--------------------------------------------------------------");

			int nPoint = 0;
			foreach (var point in pointByIDs.Values)
			{
				Console.WriteLine("{0,5}   {1,-30}   {2,-10}", point.ID.Value.ToString("00000"), point.Name ?? "", point.Value == null ? "---" : point.Value.ToString());

				if (++nPoint % 100 == 0)
				{
					Console.WriteLine("-----------PRESS ANY KEY TO CONTINUE or Q to QUIT-----------");
					if (Console.ReadKey(true).Key == ConsoleKey.Q)
						return;
				}
			}

			Console.WriteLine("--------------------------------------------------------------");
			Console.WriteLine("Press ENTER to get only some points.");
			Console.WriteLine("--------------------------------------------------------------");

			Console.ReadLine();

			var filters = new DataPointsV1Filters() 
								{ 
									Names = (new [] 
													{
														"_smp___clockYear",
														"_smp___clockMonth", 
														"_smp___clockDay",
														"_smp___clockHour",
														"_smp___clockMinute",
														"_smp___clockSecond"
													}
											).ToList()													
								};

			long? changeID = null;	// null first time will force to send current values.
			do
			{                
				var data = api.Filter(filters, changeID: changeID, details: true).Data;
				changeID = data.ChangeID;
				
				var updates = data.Points.EmptyIfNull();

				Console.Clear();
				Console.WriteLine("--------------------------------------------------------------");
				Console.WriteLine("{0,5}   {1,-30}   {2,-10}   {3,-10}", "ID", "Name", "Value", "State");
				Console.WriteLine("--------------------------------------------------------------");
				foreach (var point in updates)
				{
					Console.WriteLine("{0,5}   {1,-30}   {2,-10}   {3,-10}", point.ID.Value.ToString("00000"), point.Name ?? "", point.Value == null ? "---" : point.Value.Value.ToString("0.000000"), point.State == null ? "---" : point.State.Value.ToString());
				}

				Console.WriteLine("--------------------------------------------------------------");
				Console.WriteLine("ChangeID --> {0}", data.ChangeID == null ? "null" : data.ChangeID.Value.ToString());
				Console.WriteLine("Press Q to quit or any other key to refresh.");
				Console.WriteLine("--------------------------------------------------------------");
			}
			while (Console.ReadKey(true).Key != ConsoleKey.Q);
		}
	}
}
