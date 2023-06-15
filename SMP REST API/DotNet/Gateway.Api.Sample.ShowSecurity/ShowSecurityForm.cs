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
using System.Windows.Forms;
using Gateway.Api.Api;
using Gateway.Api.Client;

namespace Gateway.Api.Sample.ShowSecurity
{
	public partial class ShowSecurityForm : Form
	{
		public ShowSecurityForm()
		{
			InitializeComponent();

			toolStripStatusLabel.Text = "";
		}

		private void buttonGet_Click(object sender, EventArgs e)
		{
            ApiResponse<Model.SecurityLocalSettingsV1> response = null;
			textBoxInfo.Clear();

			if (textBoxIPAddress.Text == "" || textBoxUsername.Text == "" || textBoxPassword.Text == "")
				toolStripStatusLabel.Text = "Missing IP Address, Username and/or Password.";
			else
			{
                // Configuring the username and password for the opening of the session.
				var configuration = new Configuration(username: textBoxUsername.Text, password: textBoxPassword.Text);
                
                // Setting the base URL and the configuration for the API client.
				var client = new ApiClient(configuration, "https://" + textBoxIPAddress.Text);
				var factory = new ApiFactory(client);

                // Initialize a Security Local Settings API with the previous settings.
				var api = factory.CreateApiSecurityLocalSettingsV1();

                try
                {
                    // Execute a Get on the current Security Local Settings.
				    response = api.Get("current");
                }
                catch (ApiException ex)
                {
                    toolStripStatusLabel.Text = ex.ErrorContent.ToString();
                }
                if (response != null)
                {
                    // The security local settings data from the response.
                    var securityLocalSettings = response.Data;

                    // Print the security local settings data to the text box.
                    textBoxInfo.Paste(securityLocalSettings.toString());
                    toolStripStatusLabel.Text = "OK";

                    textBoxIPAddress.Enabled = false;
                    textBoxUsername.Enabled = false;
                    textBoxPassword.Enabled = false;
                }
			}
		}
	}
}
