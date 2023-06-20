namespace Gateway.Api.Sample
{
    partial class ReadPoint
    {

        private System.ComponentModel.IContainer components = null;

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
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.buttonGetPoint = new System.Windows.Forms.Button();
            this.textBoxPointInfo = new System.Windows.Forms.TextBox();
            this.textBoxSelectedPoints = new System.Windows.Forms.TextBox();
            this.radioButtonStaticData = new System.Windows.Forms.RadioButton();
            this.radioButtonDynamicData = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 70);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(67, 13);
            this.labelPassword.TabIndex = 13;
            this.labelPassword.Text = "Contraseña :";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(12, 43);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(49, 13);
            this.labelUser.TabIndex = 12;
            this.labelUser.Text = "Usuario :";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(83, 67);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(242, 20);
            this.textBoxPassword.TabIndex = 11;
            this.textBoxPassword.Text = "aasa1234";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(83, 40);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(242, 20);
            this.textBoxUsername.TabIndex = 10;
            this.textBoxUsername.Text = "Administrator";
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(83, 13);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(242, 20);
            this.textBoxIPAddress.TabIndex = 9;
            this.textBoxIPAddress.Text = "192.168.7.70";
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(12, 16);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(71, 13);
            this.labelIPAddress.TabIndex = 8;
            this.labelIPAddress.Text = "Dirección IP :";
            // 
            // buttonGetPoint
            // 
            this.buttonGetPoint.Location = new System.Drawing.Point(15, 230);
            this.buttonGetPoint.Name = "buttonGetPoint";
            this.buttonGetPoint.Size = new System.Drawing.Size(310, 23);
            this.buttonGetPoint.TabIndex = 14;
            this.buttonGetPoint.Text = "Obtener";
            this.buttonGetPoint.UseVisualStyleBackColor = true;
            this.buttonGetPoint.Click += new System.EventHandler(this.buttonGetPoint_Click);
            // 
            // textBoxPointInfo
            // 
            this.textBoxPointInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBoxPointInfo.Location = new System.Drawing.Point(12, 270);
            this.textBoxPointInfo.Multiline = true;
            this.textBoxPointInfo.Name = "textBoxPointInfo";
            this.textBoxPointInfo.ReadOnly = true;
            this.textBoxPointInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPointInfo.Size = new System.Drawing.Size(313, 254);
            this.textBoxPointInfo.TabIndex = 15;
            // 
            // textBoxSelectedPoints
            // 
            this.textBoxSelectedPoints.Location = new System.Drawing.Point(12, 95);
            this.textBoxSelectedPoints.Multiline = true;
            this.textBoxSelectedPoints.Name = "textBoxSelectedPoints";
            this.textBoxSelectedPoints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSelectedPoints.Size = new System.Drawing.Size(313, 80);
            this.textBoxSelectedPoints.TabIndex = 16;
            this.textBoxSelectedPoints.Text = "_smp___clockSecond;_smp___clockMinute;_smp___clockHour";
            this.textBoxSelectedPoints.TextChanged += new System.EventHandler(this.textBoxSelectedPoints_TextChanged);
            // 
            // radioButtonStaticData
            // 
            this.radioButtonStaticData.AutoSize = true;
            this.radioButtonStaticData.Checked = true;
            this.radioButtonStaticData.Location = new System.Drawing.Point(26, 191);
            this.radioButtonStaticData.Name = "radioButtonStaticData";
            this.radioButtonStaticData.Size = new System.Drawing.Size(63, 17);
            this.radioButtonStaticData.TabIndex = 17;
            this.radioButtonStaticData.TabStop = true;
            this.radioButtonStaticData.Text = "Detalles";
            this.radioButtonStaticData.UseVisualStyleBackColor = true;
            // 
            // radioButtonDynamicData
            // 
            this.radioButtonDynamicData.AutoSize = true;
            this.radioButtonDynamicData.Location = new System.Drawing.Point(105, 191);
            this.radioButtonDynamicData.Name = "radioButtonDynamicData";
            this.radioButtonDynamicData.Size = new System.Drawing.Size(79, 17);
            this.radioButtonDynamicData.TabIndex = 18;
            this.radioButtonDynamicData.Text = "Sin detalles";
            this.radioButtonDynamicData.UseVisualStyleBackColor = true;
            this.radioButtonDynamicData.CheckedChanged += new System.EventHandler(this.radioButtonDynamicData_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(340, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ReadPoint
            // 
            this.AcceptButton = this.buttonGetPoint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.radioButtonDynamicData);
            this.Controls.Add(this.radioButtonStaticData);
            this.Controls.Add(this.textBoxSelectedPoints);
            this.Controls.Add(this.textBoxPointInfo);
            this.Controls.Add(this.buttonGetPoint);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxIPAddress);
            this.Controls.Add(this.labelIPAddress);
            this.Name = "ReadPoint";
            this.Text = "Sample .Net";
            this.Load += new System.EventHandler(this.ReadPoint_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.Button buttonGetPoint;
        private System.Windows.Forms.TextBox textBoxPointInfo;
        private System.Windows.Forms.TextBox textBoxSelectedPoints;
        private System.Windows.Forms.RadioButton radioButtonStaticData;
        private System.Windows.Forms.RadioButton radioButtonDynamicData;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

