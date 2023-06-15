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
using System.Windows.Forms;
using Gateway.Api.Api;
using Gateway.Api.Client;
using Gateway.Api.Model;


using Gateway.Api;

namespace Gateway.Api.Sample
{
	public partial class SetPoint : Form
	{
		IEnumerable<DataPointV1> m_staticPoints = null;    // All points with all information.
		EDataPointV1Type? m_pointType = EDataPointV1Type.BinaryOutput;                      // The specified point type.
		private ApiClient m_client = null;              // Settings for the APIs.

		public SetPoint()
		{
			InitializeComponent();

			// Initialize controls for the type BO.
			textBoxPulseValue.Enabled = false;
            comboBoxControl.Enabled = false;
            comboBoxValue.Enabled = false;
            comboBoxPointsList.Enabled = false;
			toolStripStatusLabel.Text = "";
			comboBoxControl.Items.Add("Direct Execute");
			comboBoxControl.Items.Add("Select");
			comboBoxControl.Items.Add("Execute");
			comboBoxValue.Items.Add("Open");
			comboBoxValue.Items.Add("Close");
			comboBoxValue.Items.Add("Pulse");
            buttonSet.Enabled = false;
		}

		private DataPointsV1Set createSetPointObject()
        {
			var setPointControl = new DataPointsV1Set()
			// Setup the object with the selected controls.
			{
											Control = new DataPointsV1SetControl(),
										}; // Only for Binary/Analog Output (BO/AO)

				switch (comboBoxControl.SelectedItem.ToString())
				{
					case "Direct Execute":
					setPointControl.Control.Type = DataPointsV1SetControl.EType.DirectExecute;
						break;
					case "Select":
					setPointControl.Control.Type = DataPointsV1SetControl.EType.Select;
						break;
					case "Execute":
					setPointControl.Control.Type = DataPointsV1SetControl.EType.Execute;
						break;
				}

			// Setup the object with the selected controls.
			if (m_pointType == EDataPointV1Type.AnalogOutput)
			{
                switch (comboBoxValue.SelectedItem.ToString())
                {
                    case "ValueRaw":
						setPointControl.Control.RawValue = int.Parse(textBoxPulseValue.Text);
                        break;
                    case "Value":
						setPointControl.Control.Value = float.Parse(textBoxPulseValue.Text);
                        break;
                }
            }
			else if (m_pointType == EDataPointV1Type.BinaryOutput)
            {
                switch (comboBoxValue.SelectedItem.ToString())
                {
                    case "Open":
						setPointControl.Control.State = false;
                        break;
                    case "Close":
						setPointControl.Control.State = true;
                        break;
                    case "Pulse":
						setPointControl.Control.Pulse = int.Parse(textBoxPulseValue.Text);
                        break;
                }
            }

            return setPointControl;
        }

		private void buttonSet_Click(object sender, EventArgs e)
		{
                        // Configuring the username and password for the opening of the session.
                        // Setting the base URL and the configuration for the API client.
                    // Make a list of points name from the specified points name in the text box.
            var factory = new ApiFactory(m_client);

                        // Initialize a Points API with the m_client settings.
						var api = factory.CreateApiDataPointsV1();

            // Find all information about the specfied point.
            var point = m_staticPoints.FirstOrDefault(p => p.Name == comboBoxPointsList.SelectedItem.ToString());

                        // Set the specified point with the selected control.
						api.SetByName(comboBoxPointsList.SelectedItem.ToString(), createSetPointObject());
                        toolStripStatusLabel.Text = "OK";
		}

        private void comboBoxSelectedPoints_TextChanged(object sender, EventArgs e)
		{
			// Find all information about the specfied point.
            var point = m_staticPoints.FirstOrDefault(p => p.Name == comboBoxPointsList.SelectedItem.ToString());

            toolStripStatusLabel.Text = point.Type.ToString();

			comboBoxControl.Items.Clear();
			comboBoxValue.Items.Clear();
			textBoxPulseValue.Clear();

			// Setup the controls for each point type.
			if (point.Type == EDataPointV1Type.AnalogOutput)
			{
                    textBoxPulseValue.Enabled = true;
                    comboBoxControl.Enabled = true;
                    comboBoxValue.Enabled = true;
                    toolStripStatusLabel.Text = "";
                    comboBoxControl.Items.Add("Direct Execute");
                    comboBoxControl.Items.Add("Select");
                    comboBoxControl.Items.Add("Execute");
                    comboBoxValue.Items.Add("ValueRaw");
                    comboBoxValue.Items.Add("Value");
           		    buttonSet.Enabled = true;
            }
			else if (point.Type == EDataPointV1Type.BinaryOutput)
            {
                    textBoxPulseValue.Enabled = false;
                    comboBoxControl.Enabled = true;
                    comboBoxValue.Enabled = true;
                    toolStripStatusLabel.Text = "";
                    comboBoxControl.Items.Add("Direct Execute");
                    comboBoxControl.Items.Add("Select");
                    comboBoxControl.Items.Add("Execute");
                    comboBoxValue.Items.Add("Open");
                    comboBoxValue.Items.Add("Close");
                    comboBoxValue.Items.Add("Pulse");
                buttonSet.Enabled = true;
            }
            else
            {
                toolStripStatusLabel.Text = "Can be simulated only by Commissioning Tool";
                    textBoxPulseValue.Enabled = false;
                    comboBoxControl.Enabled = false;
                    comboBoxValue.Enabled = false;
                buttonSet.Enabled = false;
			}
			m_pointType = point.Type;
		}

		private void comboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxValue.Text == "Pulse")
				textBoxPulseValue.Enabled = true; // Only available for Pulse Control.
			else
				textBoxPulseValue.Enabled = false;
		}

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (textBoxIPAddress.Text == "" || textBoxUsername.Text == "" || textBoxPassword.Text == "")
                toolStripStatusLabel.Text = "Missing IP Address, Username and/or Password.";
            else
            {
                if (m_client == null)
                {
                    // Configuring the username and password for the opening of the session.
                    var configuration = new Configuration(username: textBoxUsername.Text, password: textBoxPassword.Text);
                    // Setting the base URL and the configuration for the API client.
                    m_client = new ApiClient(configuration, "https://" + textBoxIPAddress.Text);
                }

                try
                {
                    var factory = new ApiFactory(m_client);

                    // Initialize a Points API with the m_client settings.
                    var api = factory.CreateApiDataPointsV1();

                    // Get all information for all points
                    m_staticPoints = api.ListAll();

                    toolStripStatusLabel.Text = "Working...";

                    foreach (var point in m_staticPoints)
                    {
                        // Set the specified point with the selected control.
                        comboBoxPointsList.Items.Add(point.Name);
                    }

                    toolStripStatusLabel.Text = "Connected";

                    textBoxIPAddress.Enabled = false;
                    textBoxUsername.Enabled = false;
                    textBoxPassword.Enabled = false;
                    buttonConnect.Enabled = false;
                    comboBoxControl.Enabled = true;
                    comboBoxPointsList.Enabled = true;
                    comboBoxValue.Enabled = true;
                }
                catch (ApiException ex)
                {
                    toolStripStatusLabel.Text = ex.ErrorContent;
                }
            }
        }
	}
}