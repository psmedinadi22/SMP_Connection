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
using System.Text;
using System.Windows.Forms;
using Gateway.Api.Api;
using Gateway.Api.Client;
using Gateway.Api.Model;

namespace Gateway.Api.Sample
{
	public partial class Nameplate : Form
	{
		public Nameplate()
		{
			InitializeComponent();
		}

		private void buttonGet_Click(object sender, EventArgs e)
		{
            // Configuring the username and password for the opening of the session.
			var configuration = new Configuration(	username: textBoxUsername.Text, 
													password: textBoxPassword.Text);

            // Setting the base URL and the configuration for the API client.
			var client = new ApiClient(configuration, "https://" + textBoxIPAddress.Text);
			var factory = new ApiFactory(client);

            // Initialize a Dashboard Name Plate Informations API with the previous settings.
			var api = factory.CreateApiDashboardNameplateInformationsV1();

            // Execute a Get on the current Dashboard Name Plate Informations.
			var response = api.Get("current");

            // Print the response data to the text box.
			textBoxOutput.Paste(DataToString(response.Data));
		}

		private static String DataToString(DashboardNamePlateInformationsGetV1 info)
		{
			var sb = new StringBuilder();

            sb.Append("\r\nID :\t\t").Append(info.Informations.ID);
            sb.Append("\r\nName :\t\t").Append(info.Informations.Settings.Name);
            sb.Append("\r\nCompany :\t").Append(info.Informations.Settings.Company);
            sb.Append("\r\nRegion :\t\t").Append(info.Informations.Settings.Region);
            sb.Append("\r\nSubstation :\t").Append(info.Informations.Settings.Substation);
            sb.Append("\r\nDescription :\t").Append(info.Informations.Settings.Description);
            sb.Append("\r\nFile name :\t").Append(info.Informations.Settings.Filename);
            sb.Append("\r\nApplication Version :").Append(info.Informations.Firmware.ApplicationVersion);
            sb.Append("\r\nBootstrap Version :\t").Append(info.Informations.Firmware.BootstrapVersion);
            sb.Append("\r\nOS Version :\t").Append(info.Informations.Firmware.OsVersion);
            sb.Append("\r\nModel :\t\t").Append(info.Informations.Hardware.Model);
            sb.Append("\r\nSerial Number :\t").Append(info.Informations.Hardware.SerialNumber);
			sb.Append("\r\n");

			return sb.ToString();
		}
	}
}
