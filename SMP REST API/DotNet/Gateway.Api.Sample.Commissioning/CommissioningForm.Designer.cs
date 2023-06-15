namespace Gateway.Api.Sample
{
    partial class BasicCommissioningTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPointInfo = new System.Windows.Forms.TextBox();
            this.labelPointsListOfInstance = new System.Windows.Forms.Label();
            this.labelSelectedPoints = new System.Windows.Forms.Label();
            this.buttonGetValue = new System.Windows.Forms.Button();
            this.comboBoxInstanceBehavior = new System.Windows.Forms.ComboBox();
            this.labelInstanceBehavior = new System.Windows.Forms.Label();
            this.buttonSession = new System.Windows.Forms.Button();
            this.buttonCommissioning = new System.Windows.Forms.Button();
            this.labelValue = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.labelValueType = new System.Windows.Forms.Label();
            this.comboBoxValue = new System.Windows.Forms.ComboBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.labelControlType = new System.Windows.Forms.Label();
            this.comboBoxControl = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBoxPointPerInstance = new System.Windows.Forms.ListBox();
            this.groupBoxPoints = new System.Windows.Forms.GroupBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxInstancePoints = new System.Windows.Forms.ComboBox();
            this.groupBoxAuthentication = new System.Windows.Forms.GroupBox();
            this.groupBoxCommissioning = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxInstanceCommissioning = new System.Windows.Forms.ComboBox();
            this.statusStrip.SuspendLayout();
            this.groupBoxPoints.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.groupBoxAuthentication.SuspendLayout();
            this.groupBoxCommissioning.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(28, 104);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(290, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(25, 21);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(64, 13);
            this.labelIPAddress.TabIndex = 2;
            this.labelIPAddress.Text = "IP Address :";
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(96, 18);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(222, 20);
            this.textBoxIPAddress.TabIndex = 3;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(96, 45);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(222, 20);
            this.textBoxUsername.TabIndex = 4;
            this.textBoxUsername.Text = "Security";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(96, 72);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(222, 20);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.Text = "Security8*";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(25, 48);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(35, 13);
            this.labelUser.TabIndex = 6;
            this.labelUser.Text = "User :";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(25, 75);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(59, 13);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Password :";
            // 
            // textBoxPointInfo
            // 
            this.textBoxPointInfo.Location = new System.Drawing.Point(28, 327);
            this.textBoxPointInfo.Multiline = true;
            this.textBoxPointInfo.Name = "textBoxPointInfo";
            this.textBoxPointInfo.ReadOnly = true;
            this.textBoxPointInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPointInfo.Size = new System.Drawing.Size(612, 268);
            this.textBoxPointInfo.TabIndex = 8;
            // 
            // labelPointsListOfInstance
            // 
            this.labelPointsListOfInstance.AutoSize = true;
            this.labelPointsListOfInstance.Location = new System.Drawing.Point(30, 76);
            this.labelPointsListOfInstance.Name = "labelPointsListOfInstance";
            this.labelPointsListOfInstance.Size = new System.Drawing.Size(133, 13);
            this.labelPointsListOfInstance.TabIndex = 10;
            this.labelPointsListOfInstance.Text = "List of points per instance :";
            // 
            // labelSelectedPoints
            // 
            this.labelSelectedPoints.AutoSize = true;
            this.labelSelectedPoints.Location = new System.Drawing.Point(30, 258);
            this.labelSelectedPoints.Name = "labelSelectedPoints";
            this.labelSelectedPoints.Size = new System.Drawing.Size(90, 13);
            this.labelSelectedPoints.TabIndex = 11;
            this.labelSelectedPoints.Text = "Selected Points : ";
            // 
            // buttonGetValue
            // 
            this.buttonGetValue.Location = new System.Drawing.Point(33, 286);
            this.buttonGetValue.Name = "buttonGetValue";
            this.buttonGetValue.Size = new System.Drawing.Size(130, 23);
            this.buttonGetValue.TabIndex = 12;
            this.buttonGetValue.Text = "Get Value";
            this.buttonGetValue.UseVisualStyleBackColor = true;
            this.buttonGetValue.Click += new System.EventHandler(this.buttonGetValue_Click);
            // 
            // comboBoxInstanceBehavior
            // 
            this.comboBoxInstanceBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInstanceBehavior.Enabled = false;
            this.comboBoxInstanceBehavior.FormattingEnabled = true;
            this.comboBoxInstanceBehavior.Location = new System.Drawing.Point(22, 106);
            this.comboBoxInstanceBehavior.Name = "comboBoxInstanceBehavior";
            this.comboBoxInstanceBehavior.Size = new System.Drawing.Size(270, 21);
            this.comboBoxInstanceBehavior.TabIndex = 14;
            this.comboBoxInstanceBehavior.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstanceBehavior_SelectedIndexChanged);
            // 
            // labelInstanceBehavior
            // 
            this.labelInstanceBehavior.AutoSize = true;
            this.labelInstanceBehavior.Location = new System.Drawing.Point(22, 90);
            this.labelInstanceBehavior.Name = "labelInstanceBehavior";
            this.labelInstanceBehavior.Size = new System.Drawing.Size(104, 13);
            this.labelInstanceBehavior.TabIndex = 15;
            this.labelInstanceBehavior.Text = "Instance behaviour :";
            // 
            // buttonSession
            // 
            this.buttonSession.Enabled = false;
            this.buttonSession.Location = new System.Drawing.Point(175, 21);
            this.buttonSession.Name = "buttonSession";
            this.buttonSession.Size = new System.Drawing.Size(117, 23);
            this.buttonSession.TabIndex = 16;
            this.buttonSession.Text = "Start Session";
            this.buttonSession.UseVisualStyleBackColor = true;
            this.buttonSession.Click += new System.EventHandler(this.buttonSession_Click);
            // 
            // buttonCommissioning
            // 
            this.buttonCommissioning.Enabled = false;
            this.buttonCommissioning.Location = new System.Drawing.Point(22, 21);
            this.buttonCommissioning.Name = "buttonCommissioning";
            this.buttonCommissioning.Size = new System.Drawing.Size(147, 23);
            this.buttonCommissioning.TabIndex = 17;
            this.buttonCommissioning.Text = "Activate Commissioning";
            this.buttonCommissioning.UseVisualStyleBackColor = true;
            this.buttonCommissioning.Click += new System.EventHandler(this.buttonCommissioning_Click);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(18, 104);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(40, 13);
            this.labelValue.TabIndex = 39;
            this.labelValue.Text = "Value :";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Enabled = false;
            this.textBoxValue.Location = new System.Drawing.Point(90, 101);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(145, 20);
            this.textBoxValue.TabIndex = 38;
            // 
            // labelValueType
            // 
            this.labelValueType.AutoSize = true;
            this.labelValueType.Location = new System.Drawing.Point(18, 76);
            this.labelValueType.Name = "labelValueType";
            this.labelValueType.Size = new System.Drawing.Size(66, 13);
            this.labelValueType.TabIndex = 37;
            this.labelValueType.Text = "Value type : ";
            // 
            // comboBoxValue
            // 
            this.comboBoxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValue.FormattingEnabled = true;
            this.comboBoxValue.Location = new System.Drawing.Point(90, 73);
            this.comboBoxValue.Name = "comboBoxValue";
            this.comboBoxValue.Size = new System.Drawing.Size(145, 21);
            this.comboBoxValue.TabIndex = 35;
            this.comboBoxValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxValue_SelectedIndexChanged);
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(90, 133);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(145, 23);
            this.buttonSet.TabIndex = 33;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // labelControlType
            // 
            this.labelControlType.AutoSize = true;
            this.labelControlType.Location = new System.Drawing.Point(18, 48);
            this.labelControlType.Name = "labelControlType";
            this.labelControlType.Size = new System.Drawing.Size(72, 13);
            this.labelControlType.TabIndex = 36;
            this.labelControlType.Text = "Control type : ";
            // 
            // comboBoxControl
            // 
            this.comboBoxControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxControl.Enabled = false;
            this.comboBoxControl.FormattingEnabled = true;
            this.comboBoxControl.Location = new System.Drawing.Point(90, 45);
            this.comboBoxControl.Name = "comboBoxControl";
            this.comboBoxControl.Size = new System.Drawing.Size(145, 21);
            this.comboBoxControl.TabIndex = 34;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 824);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(718, 22);
            this.statusStrip.TabIndex = 40;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(23, 17);
            this.toolStripStatusLabel.Text = "OK";
            // 
            // listBoxPointPerInstance
            // 
            this.listBoxPointPerInstance.FormattingEnabled = true;
            this.listBoxPointPerInstance.Location = new System.Drawing.Point(28, 95);
            this.listBoxPointPerInstance.Name = "listBoxPointPerInstance";
            this.listBoxPointPerInstance.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxPointPerInstance.Size = new System.Drawing.Size(290, 147);
            this.listBoxPointPerInstance.TabIndex = 42;
            this.listBoxPointPerInstance.SelectedIndexChanged += new System.EventHandler(this.listBoxPointPerInstance_SelectedIndexChanged);
            // 
            // groupBoxPoints
            // 
            this.groupBoxPoints.Controls.Add(this.labelWarning);
            this.groupBoxPoints.Controls.Add(this.groupBoxControl);
            this.groupBoxPoints.Controls.Add(this.label2);
            this.groupBoxPoints.Controls.Add(this.comboBoxInstancePoints);
            this.groupBoxPoints.Controls.Add(this.listBoxPointPerInstance);
            this.groupBoxPoints.Controls.Add(this.textBoxPointInfo);
            this.groupBoxPoints.Controls.Add(this.labelPointsListOfInstance);
            this.groupBoxPoints.Controls.Add(this.labelSelectedPoints);
            this.groupBoxPoints.Controls.Add(this.buttonGetValue);
            this.groupBoxPoints.Enabled = false;
            this.groupBoxPoints.Location = new System.Drawing.Point(31, 164);
            this.groupBoxPoints.Name = "groupBoxPoints";
            this.groupBoxPoints.Size = new System.Drawing.Size(671, 616);
            this.groupBoxPoints.TabIndex = 43;
            this.groupBoxPoints.TabStop = false;
            this.groupBoxPoints.Text = "Points";
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(367, 34);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(85, 13);
            this.labelWarning.TabIndex = 40;
            this.labelWarning.Text = "Warning label";
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.labelControlType);
            this.groupBoxControl.Controls.Add(this.comboBoxValue);
            this.groupBoxControl.Controls.Add(this.comboBoxControl);
            this.groupBoxControl.Controls.Add(this.labelValueType);
            this.groupBoxControl.Controls.Add(this.buttonSet);
            this.groupBoxControl.Controls.Add(this.textBoxValue);
            this.groupBoxControl.Controls.Add(this.labelValue);
            this.groupBoxControl.Enabled = false;
            this.groupBoxControl.Location = new System.Drawing.Point(370, 50);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(270, 192);
            this.groupBoxControl.TabIndex = 45;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Simulate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Show points for instance :";
            // 
            // comboBoxInstancePoints
            // 
            this.comboBoxInstancePoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInstancePoints.FormattingEnabled = true;
            this.comboBoxInstancePoints.Location = new System.Drawing.Point(28, 50);
            this.comboBoxInstancePoints.Name = "comboBoxInstancePoints";
            this.comboBoxInstancePoints.Size = new System.Drawing.Size(290, 21);
            this.comboBoxInstancePoints.TabIndex = 43;
            this.comboBoxInstancePoints.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstancePoints_SelectedIndexChanged);
            // 
            // groupBoxAuthentication
            // 
            this.groupBoxAuthentication.Controls.Add(this.textBoxUsername);
            this.groupBoxAuthentication.Controls.Add(this.buttonConnect);
            this.groupBoxAuthentication.Controls.Add(this.labelIPAddress);
            this.groupBoxAuthentication.Controls.Add(this.textBoxIPAddress);
            this.groupBoxAuthentication.Controls.Add(this.textBoxPassword);
            this.groupBoxAuthentication.Controls.Add(this.labelUser);
            this.groupBoxAuthentication.Controls.Add(this.labelPassword);
            this.groupBoxAuthentication.Location = new System.Drawing.Point(31, 21);
            this.groupBoxAuthentication.Name = "groupBoxAuthentication";
            this.groupBoxAuthentication.Size = new System.Drawing.Size(342, 137);
            this.groupBoxAuthentication.TabIndex = 44;
            this.groupBoxAuthentication.TabStop = false;
            this.groupBoxAuthentication.Text = "Authentication";
            // 
            // groupBoxCommissioning
            // 
            this.groupBoxCommissioning.Controls.Add(this.label1);
            this.groupBoxCommissioning.Controls.Add(this.comboBoxInstanceCommissioning);
            this.groupBoxCommissioning.Controls.Add(this.comboBoxInstanceBehavior);
            this.groupBoxCommissioning.Controls.Add(this.labelInstanceBehavior);
            this.groupBoxCommissioning.Controls.Add(this.buttonCommissioning);
            this.groupBoxCommissioning.Controls.Add(this.buttonSession);
            this.groupBoxCommissioning.Enabled = false;
            this.groupBoxCommissioning.Location = new System.Drawing.Point(379, 21);
            this.groupBoxCommissioning.Name = "groupBoxCommissioning";
            this.groupBoxCommissioning.Size = new System.Drawing.Size(323, 137);
            this.groupBoxCommissioning.TabIndex = 45;
            this.groupBoxCommissioning.TabStop = false;
            this.groupBoxCommissioning.Text = "Commissioning";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Instances :";
            // 
            // comboBoxInstanceCommissioning
            // 
            this.comboBoxInstanceCommissioning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInstanceCommissioning.FormattingEnabled = true;
            this.comboBoxInstanceCommissioning.Location = new System.Drawing.Point(22, 65);
            this.comboBoxInstanceCommissioning.Name = "comboBoxInstanceCommissioning";
            this.comboBoxInstanceCommissioning.Size = new System.Drawing.Size(270, 21);
            this.comboBoxInstanceCommissioning.TabIndex = 18;
            this.comboBoxInstanceCommissioning.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstanceCommissioning_SelectedIndexChanged);
            // 
            // BasicCommissioningTool
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 846);
            this.Controls.Add(this.groupBoxCommissioning);
            this.Controls.Add(this.groupBoxAuthentication);
            this.Controls.Add(this.groupBoxPoints);
            this.Controls.Add(this.statusStrip);
            this.Name = "BasicCommissioningTool";
            this.Text = "Points Sample .Net";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxPoints.ResumeLayout(false);
            this.groupBoxPoints.PerformLayout();
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            this.groupBoxAuthentication.ResumeLayout(false);
            this.groupBoxAuthentication.PerformLayout();
            this.groupBoxCommissioning.ResumeLayout(false);
            this.groupBoxCommissioning.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPointInfo;
        private System.Windows.Forms.Label labelPointsListOfInstance;
        private System.Windows.Forms.Label labelSelectedPoints;
        private System.Windows.Forms.Button buttonGetValue;
        private System.Windows.Forms.ComboBox comboBoxInstanceBehavior;
        private System.Windows.Forms.Label labelInstanceBehavior;
        private System.Windows.Forms.Button buttonSession;
        private System.Windows.Forms.Button buttonCommissioning;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label labelValueType;
        private System.Windows.Forms.ComboBox comboBoxValue;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Label labelControlType;
        private System.Windows.Forms.ComboBox comboBoxControl;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ListBox listBoxPointPerInstance;
        private System.Windows.Forms.GroupBox groupBoxPoints;
        private System.Windows.Forms.GroupBox groupBoxAuthentication;
        private System.Windows.Forms.GroupBox groupBoxCommissioning;
        private System.Windows.Forms.ComboBox comboBoxInstanceCommissioning;
        private System.Windows.Forms.ComboBox comboBoxInstancePoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.Label labelWarning;
    }
}

