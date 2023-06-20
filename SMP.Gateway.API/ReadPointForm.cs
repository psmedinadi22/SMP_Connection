using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gateway.Api.Api;
using Gateway.Api.Client;
using Gateway.Api.Model;

using Gateway.Api;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Gateway.Api.Sample
{
    public partial class ReadPoint : Form
    {     
		private bool RefreshOnly
		{
			get
			{
				return radioButtonDynamicData.Checked;
			}
			set
			{
				radioButtonDynamicData.Checked = value;
				radioButtonStaticData.Checked = !value;
			}
		}
		
        IDictionary<int, DataPointV1> m_pointsByID = null;    // All points with all information.

        public ReadPoint()
        {
            InitializeComponent();
        }

        private void buttonGetPoint_Click(object sender, EventArgs e)
        {
            // Configuring the username and password for the opening of the session if exists
           // if(PublicKeyToken!=null)
           
            var configuration = new Configuration(username: textBoxUsername.Text, password: textBoxPassword.Text);

            textBoxPointInfo.Clear();
            if (textBoxIPAddress.Text == "" || textBoxUsername.Text == "" || textBoxPassword.Text == "")
                toolStripStatusLabel.Text = "Falta dirección IP, nombre de usuario y/o contraseña.";
            else
            {
                // Setting the base URL and the configuration for the API client.
                var client = new ApiClient(configuration, "https://" + textBoxIPAddress.Text);
                var factory = new ApiFactory(client);

                // Initialize a Points API with the previous settings.
                var api = factory.CreateApiDataPointsV1();

                if (m_pointsByID == null)
                {
                    // Get information for all points
					m_pointsByID = api.ListAll(true).ToDictionary(p => p.ID.Value);

                    textBoxIPAddress.Enabled = false;
                    textBoxUsername.Enabled = false;
                    textBoxPassword.Enabled = false;					
                }

                // Make a list of points name from the specified points name in the text box.
				var namesList = textBoxSelectedPoints.Text.IsEmptyOrNull() ? new string []{} : textBoxSelectedPoints.Text.Split(';');
				var namesSet = new HashSet<string>(namesList);

				if (namesSet.Count == 0 || (namesSet.Count == 1 && namesSet.First().Trim().IsEmptyOrNull()))
				{
					MessageBox.Show("Debes especificar al menos un punto.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (this.RefreshOnly)  // "Only Dynamic Data" radio button is selected.
                {
					var filters = new DataPointsV1Filters()
									{
										Names = namesSet.ToList(),
									};
                   
                    // Get the specified points from the text box.
                    var updates = api.Filter(filters, false).Data.Points.EmptyIfNull();                     

                    foreach (var update in updates)
                    {                 
                        var point = m_pointsByID.GetValue(update.ID.Value);
						
                        if (point != null)
						{
							point.Value = update.Value;
							point.Date = update.Date;
							point.Status = update.Status;

							// Print only information that have changed about the point in the text box.
							textBoxPointInfo.Paste(point.toStringDynamic()); 
						}
                    }
                    toolStripStatusLabel.Text = "Echo";
                }
				else // "All (Static and Dynamic) Data" radio button selected.
                {
					var filters = new DataPointsV1Filters()
					{
						Names = namesSet.ToList(),
					};

					// Get the specified points from the text box.
					var query = api.Filter(filters, true).Data.Points.EmptyIfNull();    

                                          
                    foreach (var point in query)
                    {
                        textBoxPointInfo.Paste(point.toString()); // Print all information about the point in the text box.
                    }  
                    toolStripStatusLabel.Text = "Echo";
                }
            }
        }

        private void radioButtonDynamicData_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSelectedPoints_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReadPoint_Load(object sender, EventArgs e)
        {

        }
    }
}
