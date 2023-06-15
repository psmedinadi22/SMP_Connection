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
using System.Text;
using System.Windows.Forms;
using Gateway.Api.Api;
using Gateway.Api.Client;
using Gateway.Api.Model;

namespace Gateway.Api.Sample
{
    public partial class BasicCommissioningTool : Form
    {
		IEnumerable<DataInstanceV1> m_instances = null;     // All point users (Instances).
        IEnumerable<DataPointV1> m_points = null;                // All points with all information.
        ListBox.SelectedObjectCollection m_pointsNameList = null;   // Selected points name list from the list box.
		EDataPointV1Type? m_selectedPointType = null;                            // The selected point type.
        const String m_ListOfPointsPerInstance = "List of points per instance : ";
        const String m_SelectedPoints = "Selected Points : ";
        const String m_InstanceBehavior = "Instance behaviour : ";
		private ApiClient m_client = null;                          // Settings for the APIs.
        
        public BasicCommissioningTool()
        {
            InitializeComponent();

            comboBoxInstanceBehavior.Items.Add("No simulation allowed");
            comboBoxInstanceBehavior.Items.Add("Simulation allowed");
            comboBoxInstanceBehavior.Items.Add("Simulate device");
            labelWarning.Text = "";
        }

        private DataPointsV1Set createSetPointObject()
		{
            var setPoint = new DataPointsV1Set();

            // Setup the object with the selected controls.
            if (m_selectedPointType == EDataPointV1Type.AnalogInput)
            {
                setPoint.Simulate = new DataPointsV1SetSimulate();
                switch (comboBoxValue.SelectedItem.ToString())
                {
                    case "ValueRaw":
                        setPoint.Simulate.RawValue = int.Parse(textBoxValue.Text);
                        break;
                    case "Value":
                        setPoint.Simulate.Value = float.Parse(textBoxValue.Text);
                        break;
                }
            }
            else if (m_selectedPointType == EDataPointV1Type.AnalogOutput)
            {
                setPoint.Control = new DataPointsV1SetControl();
                switch (comboBoxControl.SelectedItem.ToString())
                {
                    case "Direct Execute":
                        setPoint.Control.Type = DataPointsV1SetControl.EType.DirectExecute;
                        break;
                    case "Select":
                        setPoint.Control.Type = DataPointsV1SetControl.EType.Select;
                        break;
                    case "Execute":
                        setPoint.Control.Type = DataPointsV1SetControl.EType.Execute;
                        break;
                }

                switch (comboBoxValue.SelectedItem.ToString())
                {
                    case "ValueRaw":
                        setPoint.Control.RawValue = int.Parse(textBoxValue.Text);
                        break;
                    case "Value":
                        setPoint.Control.Value = float.Parse(textBoxValue.Text);
                        break;
                }
            }
            else if (m_selectedPointType == EDataPointV1Type.BinaryInput)
            {
                setPoint.Simulate = new DataPointsV1SetSimulate();
                switch (comboBoxValue.SelectedItem.ToString())
                {
                    case "0":
                        setPoint.Simulate.State = false;
                        break;
                    case "1":
                        setPoint.Simulate.State = true;
                        break;
                }
            }
            else if (m_selectedPointType == EDataPointV1Type.BinaryOutput)
            {
                setPoint.Control = new DataPointsV1SetControl();
                switch (comboBoxControl.SelectedItem.ToString())
                {
                    case "Direct Execute":
                        setPoint.Control.Type = DataPointsV1SetControl.EType.DirectExecute;
                        break;
                    case "Select":
                        setPoint.Control.Type = DataPointsV1SetControl.EType.Select;
                        break;
                    case "Execute":
                        setPoint.Control.Type = DataPointsV1SetControl.EType.Execute;
                        break;
                }

                switch (comboBoxValue.SelectedItem.ToString())
                {
                    case "Open":
                        setPoint.Control.State = false;
                        break;
                    case "Close":
                        setPoint.Control.State = true;
                        break;
                    case "Pulse":
                        setPoint.Control.Pulse = int.Parse(textBoxValue.Text);
                        break;
                }
            }

           		return setPoint;
		}

        private void clearAll()
        {
            // Reset fields.
            textBoxPointInfo.Clear();
            listBoxPointPerInstance.Items.Clear();
            labelPointsListOfInstance.Text = m_ListOfPointsPerInstance;
            labelSelectedPoints.Text = m_SelectedPoints;
            labelInstanceBehavior.Text = m_InstanceBehavior;
            buttonCommissioning.Enabled = true;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {	
            try
            {
                buttonConnect.Text = "Connecting...";
                buttonConnect.Enabled = false;

				var configuration = new Configuration(username: textBoxUsername.Text, password: textBoxPassword.Text);

				m_client = new ApiClient(configuration, "https://" + textBoxIPAddress.Text);
			    var factory = new ApiFactory(m_client);

                // Initialize a Point Users API with the m_client settings.
			    var api = factory.CreateApiDataInstancesV1();

                // List all point users.
			    m_instances = api.List(true).Data.Instances.EmptyIfNull();

			    groupBoxAuthentication.Enabled = false;
			    groupBoxCommissioning.Enabled = true;
			    groupBoxPoints.Enabled = true;

                if (!comboBoxInstanceCommissioning.Items.Contains("All"))
                {
                    // Add "All" for all point users.
                    comboBoxInstanceCommissioning.Items.Add("All");
                    comboBoxInstancePoints.Items.Add("All");
                }

                // Add point users in the two combo box,
                foreach (var item in m_instances)
                {
                    if (item.ProducedPointCount > 0)
                    {
                        if (comboBoxInstanceCommissioning.Items.Contains(item.FriendlyName))
                        {
                            comboBoxInstanceCommissioning.Items.Remove(item.FriendlyName);
                            comboBoxInstancePoints.Items.Remove(item.FriendlyName);
                        }

                        comboBoxInstanceCommissioning.Items.Add(item.FriendlyName);
                        comboBoxInstancePoints.Items.Add(item.FriendlyName);
                    }
                }
                clearAll();
                buttonConnect.Text = "Connected";
            }
            catch (Exception)
            {
                buttonConnect.Text = "Connect";
                buttonConnect.Enabled = true;
            }
        }

        private void buttonCommissioning_Click(object sender, EventArgs e)
        {
            if (buttonCommissioning.Text == "Activate Commissioning")
            {
                try
                {
                    var factory = new ApiFactory(m_client);
                    var api = factory.CreateApiDataCommissioningV1();

                    // Activate the commissioning.
                    api.ActivateAndWait();
                }
                catch (ApiException ex)
                {
                    toolStripStatusLabel.Text = ex.ErrorContent;
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel.Text = ex.Message;
                }
                buttonSession.Enabled = true;
                buttonCommissioning.Text = "Deactivate Commissioning";
            }
            else
            {
				var factory = new ApiFactory(m_client);

                try
                {
					var api = factory.CreateApiDataCommissioningV1();

                    // Deactivate the commissioning.
					api.DeactivateAndWait();
                }
                catch (ApiException ex)
                {
                    toolStripStatusLabel.Text = ex.ErrorContent;
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel.Text = ex.Message;
                }

                buttonSession.Enabled = false;
                comboBoxInstanceBehavior.Enabled = false;
                buttonSession.Text = "Start Session";
                buttonCommissioning.Text = "Activate Commissioning";
            }
        }

        private void buttonSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonSession.Text == "Start Session")
                {
                    try
                    {
					    var factory = new ApiFactory(m_client);
					    var api = factory.CreateApiDataCommissioningV1();

                        // Start Session for the commissioning tool.
					    api.JoinAndWait();
                    }
                    catch (ApiException ex)
                    {
                        toolStripStatusLabel.Text = ex.ErrorContent;
                    }
                    catch (Exception ex)
                    {
                        toolStripStatusLabel.Text = ex.Message;
                    }
                    comboBoxInstanceBehavior.Enabled = true;                     
                    buttonSession.Text = "Stop Session";
                }
                else
                {
                    try
                    {
					    var factory = new ApiFactory(m_client);
					    var api = factory.CreateApiDataCommissioningV1();

                        // Stop Session for the commissioning tool.
					    api.LeaveAndWait();
                    }
                    catch (ApiException ex)
                    {
                        toolStripStatusLabel.Text = ex.ErrorContent;
                    }
                    catch (Exception ex)
                    {
                        toolStripStatusLabel.Text = ex.Message;
                    }

                    comboBoxInstanceBehavior.Enabled = false;
                    comboBoxInstanceBehavior.Text = "No simulation allowed";
                    buttonSession.Text = "Start Session";
                }
            }
            catch (Exception)
            {

            }
        }

        private void comboBoxInstanceCommissioning_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Print the selected instance for the commissioning tool.
            labelInstanceBehavior.Text = m_InstanceBehavior + comboBoxInstanceCommissioning.SelectedItem.ToString();
        }

        private void comboBoxInstanceBehavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var factory = new ApiFactory(m_client);

                // Initialize a Point Users API with the m_client settings.
                var api = factory.CreateApiDataInstancesV1();

                DataInstancesV1Set set = new DataInstancesV1Set()
                {
                    Behavior = new DataInstancesV1SetBehavior(),
                };

                // Set the new simulation behavior for the command.
                switch (comboBoxInstanceBehavior.SelectedItem.ToString())
                {
                    case "No simulation allowed":
                        set.Behavior.NewValue = EDataInstancesV1Behavior.NoSimulationAllowed;
                        break;
                    case "Simulation allowed":
                        set.Behavior.NewValue = EDataInstancesV1Behavior.SimulationAllowed;
                        break;
                    case "Simulate device":
                        set.Behavior.NewValue = EDataInstancesV1Behavior.SimulateDevice;
                        break;
                }

                if (comboBoxInstanceCommissioning.SelectedItem.ToString() == "All")
                {
                    api.SetAll(set);
                }
                else
                {
                    var currentInstanceInfos = api.GetByName(comboBoxInstanceCommissioning.SelectedItem.ToString()).Data;
                    set.Behavior.OldValue = currentInstanceInfos == null || currentInstanceInfos.Simulation == null ? EDataInstancesV1Behavior.NoSimulationAllowed : currentInstanceInfos.Simulation.Behavior;
                    api.SetByID(currentInstanceInfos.ID, set);
                }
            }
            catch (Exception)
            { 

            }
        }

        private void comboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  if (comboBoxValue.SelectedItem.ToString() == "Pulse")
                textBoxValue.Enabled = true; // Only available for Pulse Control.
            else
                textBoxValue.Enabled = false;*/
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {   
            try
            {
				var factory = new ApiFactory(m_client);

                // Initialize a Points API with the m_client settings.
				var api = factory.CreateApiDataPointsV1();

                // Set the first selected point with the selected controls.
                api.SetByName(m_pointsNameList[0].ToString(), createSetPointObject());
                toolStripStatusLabel.Text = "OK";
            }
            catch (ApiException ex)
            {
                toolStripStatusLabel.Text = ex.ErrorContent;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = ex.Message;
            }
        }

        private void comboBoxInstancePoints_SelectedIndexChanged(object sender, EventArgs e)
        {
			var factory = new ApiFactory(m_client);

            // Initialize a Points API with the m_client settings.
			var api = factory.CreateApiDataPointsV1();

            // Get all information for all points
            m_points = api.ListAll(details: true); 

            listBoxPointPerInstance.Items.Clear();

            if (comboBoxInstancePoints.SelectedItem.ToString() == "All")
            {
                labelPointsListOfInstance.Text = m_ListOfPointsPerInstance + "All";
                
                // Only simulable point users.
                var simulableUsers = m_instances.Where(p => p.ProducedPointCount > 0).ToDictionary(i => i.ID.Value);
                foreach (var point in m_points.Where(p => p.Producer != null && simulableUsers.GetValue(p.ID.Value) != null))
				{
					listBoxPointPerInstance.Items.Add(point.Name); // Add the name of the point to the list.
				}
            }
            else
            {
                // ID of the selected point user.
                var selectedPointUserID = m_instances.FirstOrDefault(p => p.FriendlyName == comboBoxInstancePoints.SelectedItem.ToString()).ID;
                labelPointsListOfInstance.Text = m_ListOfPointsPerInstance + m_instances.FirstOrDefault(p => p.ID == selectedPointUserID).FriendlyName;

                foreach (DataPointV1 item in m_points)
                {
                    if (item.Producer.ID == selectedPointUserID) // Point from the selected producer ?
                        listBoxPointPerInstance.Items.Add(item.Name); // Add the name of the point to the list box.
                }
            }
        }

        private void listBoxPointPerInstance_SelectedIndexChanged(object sender, EventArgs e)
		{
            try
            {
			    var factory = new ApiFactory(m_client);

                // Initialize a Point Users API with the m_client settings.
			    var api = factory.CreateApiDataInstancesV1();

                groupBoxControl.Enabled = false;
                // List all point users.
                var pointUsersTemp = api.List(true);
                // List all point users in simulation.
                var pointUsersSimulated = pointUsersTemp.Data.Instances.EmptyIfNull().Where(p => p.Simulation != null && p.Simulation.Behavior != EDataInstancesV1Behavior.NoSimulationAllowed);

                labelSelectedPoints.Text = m_SelectedPoints;

                // Selected points name from the list.
                m_pointsNameList = listBoxPointPerInstance.SelectedItems;
                foreach (object item in m_pointsNameList)
                {
                    labelSelectedPoints.Text = labelSelectedPoints.Text + item.ToString() + ", ";
                }

                var point = m_points.FirstOrDefault(p => p.Name == m_pointsNameList[0].ToString());
                foreach (var user in pointUsersSimulated)
                {
                    if (point.Producer.ID == user.ID) // Enable the group box of controls if is producer is in simulation.
                        groupBoxControl.Enabled = true;
                }

                if (groupBoxControl.Enabled)
                {
                    // Reset fields.
                    m_selectedPointType = point.Type;
                    comboBoxControl.Items.Clear();
                    comboBoxValue.Items.Clear();
                    textBoxValue.Clear();
                    toolStripStatusLabel.Text = "";
                    labelWarning.Text = "";

                    // Setup the controls for each point type.
                    if (point.Type == EDataPointV1Type.AnalogInput)
                    {
                        textBoxValue.Enabled = true;
                        comboBoxControl.Enabled = false;
                        comboBoxValue.Items.Add("Value");
                        comboBoxValue.Items.Add("ValueRaw");
                    }
                    else if (point.Type == EDataPointV1Type.AnalogOutput)
                    {
                        textBoxValue.Enabled = true;
                        comboBoxControl.Enabled = true;
                        comboBoxControl.Items.Add("Direct Execute");
                        comboBoxControl.Items.Add("Select");
                        comboBoxControl.Items.Add("Execute");
                        comboBoxValue.Items.Add("ValueRaw");
                        comboBoxValue.Items.Add("Value");
                    }
                    else if (point.Type == EDataPointV1Type.BinaryInput)
                    {
                        textBoxValue.Enabled = true;
                        comboBoxControl.Enabled = false;
                        comboBoxValue.Items.Add(1);
                        comboBoxValue.Items.Add(0);
                    }
                    else if (point.Type == EDataPointV1Type.BinaryOutput)
                    {
                        textBoxValue.Enabled = false;
                        comboBoxControl.Enabled = true;
                        comboBoxControl.Items.Add("Direct Execute");
                        comboBoxControl.Items.Add("Select");
                        comboBoxControl.Items.Add("Execute");
                        comboBoxValue.Items.Add("Open");
                        comboBoxValue.Items.Add("Close");
                        comboBoxValue.Items.Add("Pulse");
                    }
                }
                else
                {
                    labelWarning.Text = "The instance of this point is not simulated.";
                }
            }
            catch(Exception)
            {
            }
        }

        private void buttonGetValue_Click(object sender, EventArgs e)
        {
			var factory = new ApiFactory(m_client);

            // Initialize a Points API with the m_client settings.
			var api = factory.CreateApiDataPointsV1();

            if (m_pointsNameList != null)
            {
				var filters = new DataPointsV1Filters()
					{
						Names = new List<string>(),
					};

                // Make a list of ID from the selected points name in the list box.
				foreach (object item in m_pointsNameList)
                {
					filters.Names.Add(item.ToString());
                }

				// Get the changed information for the selected points.
                var selectedPointsInfo = api.Filter(filters, details: true).Data.Points.EmptyIfNull(); 

                textBoxPointInfo.Clear();
                foreach (var point in selectedPointsInfo)
                {
                    textBoxPointInfo.Paste(point.toStringDynamic()); 
                }
            }
            else
                toolStripStatusLabel.Text = "Must select a point!";

        }


    }
}

