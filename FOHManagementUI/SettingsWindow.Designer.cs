namespace FOHManagerUI {
    partial class SettingsWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtTryBookingUName = new System.Windows.Forms.TextBox();
            this.lblTryBookingUName = new System.Windows.Forms.Label();
            this.grpTryBooking = new System.Windows.Forms.GroupBox();
            this.txtTryBookingPassword = new System.Windows.Forms.TextBox();
            this.lblTryBookingPassword = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.grpSMTP = new System.Windows.Forms.GroupBox();
            this.nSMTPPort = new System.Windows.Forms.NumericUpDown();
            this.lblSMTPPort = new System.Windows.Forms.Label();
            this.txtSMTPServer = new System.Windows.Forms.TextBox();
            this.lblSMTPServer = new System.Windows.Forms.Label();
            this.txtSMTPPassword = new System.Windows.Forms.TextBox();
            this.txtSMTPUName = new System.Windows.Forms.TextBox();
            this.lblSMTPPassword = new System.Windows.Forms.Label();
            this.lblSMTPUName = new System.Windows.Forms.Label();
            this.chkMarkSeats = new System.Windows.Forms.CheckBox();
            this.gSenderAddress = new System.Windows.Forms.GroupBox();
            this.txtSenderEMail = new System.Windows.Forms.TextBox();
            this.lblSenderEMail = new System.Windows.Forms.Label();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.lblSenderName = new System.Windows.Forms.Label();
            this.grpTryBooking.SuspendLayout();
            this.grpSMTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSMTPPort)).BeginInit();
            this.gSenderAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTryBookingUName
            // 
            this.txtTryBookingUName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTryBookingUName.Location = new System.Drawing.Point(106, 19);
            this.txtTryBookingUName.Name = "txtTryBookingUName";
            this.txtTryBookingUName.Size = new System.Drawing.Size(350, 20);
            this.txtTryBookingUName.TabIndex = 0;
            this.txtTryBookingUName.Text = "Username";
            this.txtTryBookingUName.TextChanged += new System.EventHandler(this.txtTryBookingUName_TextChanged);
            // 
            // lblTryBookingUName
            // 
            this.lblTryBookingUName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTryBookingUName.AutoSize = true;
            this.lblTryBookingUName.Location = new System.Drawing.Point(42, 22);
            this.lblTryBookingUName.Name = "lblTryBookingUName";
            this.lblTryBookingUName.Size = new System.Drawing.Size(58, 13);
            this.lblTryBookingUName.TabIndex = 1;
            this.lblTryBookingUName.Text = "Username:";
            this.lblTryBookingUName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpTryBooking
            // 
            this.grpTryBooking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTryBooking.Controls.Add(this.txtTryBookingPassword);
            this.grpTryBooking.Controls.Add(this.lblTryBookingPassword);
            this.grpTryBooking.Controls.Add(this.txtTryBookingUName);
            this.grpTryBooking.Controls.Add(this.lblTryBookingUName);
            this.grpTryBooking.Location = new System.Drawing.Point(12, 12);
            this.grpTryBooking.Name = "grpTryBooking";
            this.grpTryBooking.Size = new System.Drawing.Size(463, 82);
            this.grpTryBooking.TabIndex = 2;
            this.grpTryBooking.TabStop = false;
            this.grpTryBooking.Text = "Try Booking";
            // 
            // txtTryBookingPassword
            // 
            this.txtTryBookingPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTryBookingPassword.Location = new System.Drawing.Point(106, 45);
            this.txtTryBookingPassword.Name = "txtTryBookingPassword";
            this.txtTryBookingPassword.Size = new System.Drawing.Size(350, 20);
            this.txtTryBookingPassword.TabIndex = 2;
            this.txtTryBookingPassword.Text = "Password";
            this.txtTryBookingPassword.TextChanged += new System.EventHandler(this.txtTryBookingPassword_TextChanged);
            // 
            // lblTryBookingPassword
            // 
            this.lblTryBookingPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTryBookingPassword.AutoSize = true;
            this.lblTryBookingPassword.Location = new System.Drawing.Point(42, 48);
            this.lblTryBookingPassword.Name = "lblTryBookingPassword";
            this.lblTryBookingPassword.Size = new System.Drawing.Size(56, 13);
            this.lblTryBookingPassword.TabIndex = 3;
            this.lblTryBookingPassword.Text = "Password:";
            this.lblTryBookingPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(400, 378);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Location = new System.Drawing.Point(319, 377);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // grpSMTP
            // 
            this.grpSMTP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSMTP.Controls.Add(this.nSMTPPort);
            this.grpSMTP.Controls.Add(this.lblSMTPPort);
            this.grpSMTP.Controls.Add(this.txtSMTPServer);
            this.grpSMTP.Controls.Add(this.lblSMTPServer);
            this.grpSMTP.Controls.Add(this.txtSMTPPassword);
            this.grpSMTP.Controls.Add(this.txtSMTPUName);
            this.grpSMTP.Controls.Add(this.lblSMTPPassword);
            this.grpSMTP.Controls.Add(this.lblSMTPUName);
            this.grpSMTP.Location = new System.Drawing.Point(13, 101);
            this.grpSMTP.Name = "grpSMTP";
            this.grpSMTP.Size = new System.Drawing.Size(462, 134);
            this.grpSMTP.TabIndex = 5;
            this.grpSMTP.TabStop = false;
            this.grpSMTP.Text = "SMTP";
            // 
            // nSMTPPort
            // 
            this.nSMTPPort.Location = new System.Drawing.Point(105, 98);
            this.nSMTPPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nSMTPPort.Name = "nSMTPPort";
            this.nSMTPPort.Size = new System.Drawing.Size(120, 20);
            this.nSMTPPort.TabIndex = 11;
            this.nSMTPPort.Value = new decimal(new int[] {
            587,
            0,
            0,
            0});
            this.nSMTPPort.ValueChanged += new System.EventHandler(this.nSMTPPort_ValueChanged);
            // 
            // lblSMTPPort
            // 
            this.lblSMTPPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSMTPPort.AutoSize = true;
            this.lblSMTPPort.Location = new System.Drawing.Point(37, 100);
            this.lblSMTPPort.Name = "lblSMTPPort";
            this.lblSMTPPort.Size = new System.Drawing.Size(62, 13);
            this.lblSMTPPort.TabIndex = 10;
            this.lblSMTPPort.Text = "SMTP Port:";
            this.lblSMTPPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSMTPServer
            // 
            this.txtSMTPServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMTPServer.Location = new System.Drawing.Point(105, 71);
            this.txtSMTPServer.Name = "txtSMTPServer";
            this.txtSMTPServer.Size = new System.Drawing.Size(350, 20);
            this.txtSMTPServer.TabIndex = 8;
            this.txtSMTPServer.Text = "smtp.gmail.com";
            this.txtSMTPServer.TextChanged += new System.EventHandler(this.txtSMTPServer_TextChanged);
            // 
            // lblSMTPServer
            // 
            this.lblSMTPServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSMTPServer.AutoSize = true;
            this.lblSMTPServer.Location = new System.Drawing.Point(25, 74);
            this.lblSMTPServer.Name = "lblSMTPServer";
            this.lblSMTPServer.Size = new System.Drawing.Size(74, 13);
            this.lblSMTPServer.TabIndex = 9;
            this.lblSMTPServer.Text = "SMTP Server:";
            this.lblSMTPServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSMTPPassword
            // 
            this.txtSMTPPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMTPPassword.Location = new System.Drawing.Point(105, 45);
            this.txtSMTPPassword.Name = "txtSMTPPassword";
            this.txtSMTPPassword.Size = new System.Drawing.Size(350, 20);
            this.txtSMTPPassword.TabIndex = 6;
            this.txtSMTPPassword.Text = "Password";
            this.txtSMTPPassword.TextChanged += new System.EventHandler(this.txtSMTPPassword_TextChanged);
            // 
            // txtSMTPUName
            // 
            this.txtSMTPUName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMTPUName.Location = new System.Drawing.Point(105, 19);
            this.txtSMTPUName.Name = "txtSMTPUName";
            this.txtSMTPUName.Size = new System.Drawing.Size(350, 20);
            this.txtSMTPUName.TabIndex = 4;
            this.txtSMTPUName.Text = "Username";
            this.txtSMTPUName.TextChanged += new System.EventHandler(this.txtSMTPUName_TextChanged);
            // 
            // lblSMTPPassword
            // 
            this.lblSMTPPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSMTPPassword.AutoSize = true;
            this.lblSMTPPassword.Location = new System.Drawing.Point(41, 48);
            this.lblSMTPPassword.Name = "lblSMTPPassword";
            this.lblSMTPPassword.Size = new System.Drawing.Size(56, 13);
            this.lblSMTPPassword.TabIndex = 7;
            this.lblSMTPPassword.Text = "Password:";
            this.lblSMTPPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSMTPUName
            // 
            this.lblSMTPUName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSMTPUName.AutoSize = true;
            this.lblSMTPUName.Location = new System.Drawing.Point(41, 22);
            this.lblSMTPUName.Name = "lblSMTPUName";
            this.lblSMTPUName.Size = new System.Drawing.Size(58, 13);
            this.lblSMTPUName.TabIndex = 5;
            this.lblSMTPUName.Text = "Username:";
            this.lblSMTPUName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkMarkSeats
            // 
            this.chkMarkSeats.AutoSize = true;
            this.chkMarkSeats.Location = new System.Drawing.Point(118, 329);
            this.chkMarkSeats.Name = "chkMarkSeats";
            this.chkMarkSeats.Size = new System.Drawing.Size(162, 17);
            this.chkMarkSeats.TabIndex = 6;
            this.chkMarkSeats.Text = "Strike-through Booked Seats";
            this.chkMarkSeats.UseVisualStyleBackColor = true;
            this.chkMarkSeats.CheckedChanged += new System.EventHandler(this.chkMarkSeats_CheckedChanged);
            // 
            // gSenderAddress
            // 
            this.gSenderAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gSenderAddress.Controls.Add(this.txtSenderEMail);
            this.gSenderAddress.Controls.Add(this.lblSenderEMail);
            this.gSenderAddress.Controls.Add(this.txtSenderName);
            this.gSenderAddress.Controls.Add(this.lblSenderName);
            this.gSenderAddress.Location = new System.Drawing.Point(13, 241);
            this.gSenderAddress.Name = "gSenderAddress";
            this.gSenderAddress.Size = new System.Drawing.Size(463, 82);
            this.gSenderAddress.TabIndex = 4;
            this.gSenderAddress.TabStop = false;
            this.gSenderAddress.Text = "eMail Sender Address";
            // 
            // txtSenderEMail
            // 
            this.txtSenderEMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSenderEMail.Location = new System.Drawing.Point(106, 45);
            this.txtSenderEMail.Name = "txtSenderEMail";
            this.txtSenderEMail.Size = new System.Drawing.Size(350, 20);
            this.txtSenderEMail.TabIndex = 2;
            this.txtSenderEMail.Text = "eMail";
            this.txtSenderEMail.TextChanged += new System.EventHandler(this.txtSenderEMail_TextChanged);
            // 
            // lblSenderEMail
            // 
            this.lblSenderEMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSenderEMail.AutoSize = true;
            this.lblSenderEMail.Location = new System.Drawing.Point(59, 48);
            this.lblSenderEMail.Name = "lblSenderEMail";
            this.lblSenderEMail.Size = new System.Drawing.Size(35, 13);
            this.lblSenderEMail.TabIndex = 3;
            this.lblSenderEMail.Text = "eMail:";
            this.lblSenderEMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSenderName
            // 
            this.txtSenderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSenderName.Location = new System.Drawing.Point(106, 19);
            this.txtSenderName.Name = "txtSenderName";
            this.txtSenderName.Size = new System.Drawing.Size(350, 20);
            this.txtSenderName.TabIndex = 0;
            this.txtSenderName.Text = "FOH Management App";
            this.txtSenderName.TextChanged += new System.EventHandler(this.txtSenderName_TextChanged);
            // 
            // lblSenderName
            // 
            this.lblSenderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSenderName.AutoSize = true;
            this.lblSenderName.Location = new System.Drawing.Point(59, 22);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(38, 13);
            this.lblSenderName.TabIndex = 1;
            this.lblSenderName.Text = "Name:";
            this.lblSenderName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 413);
            this.Controls.Add(this.gSenderAddress);
            this.Controls.Add(this.chkMarkSeats);
            this.Controls.Add(this.grpSMTP);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.grpTryBooking);
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            this.grpTryBooking.ResumeLayout(false);
            this.grpTryBooking.PerformLayout();
            this.grpSMTP.ResumeLayout(false);
            this.grpSMTP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSMTPPort)).EndInit();
            this.gSenderAddress.ResumeLayout(false);
            this.gSenderAddress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTryBookingUName;
        private System.Windows.Forms.Label lblTryBookingUName;
        private System.Windows.Forms.GroupBox grpTryBooking;
        private System.Windows.Forms.TextBox txtTryBookingPassword;
        private System.Windows.Forms.Label lblTryBookingPassword;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.GroupBox grpSMTP;
        private System.Windows.Forms.TextBox txtSMTPPassword;
        private System.Windows.Forms.TextBox txtSMTPUName;
        private System.Windows.Forms.Label lblSMTPPassword;
        private System.Windows.Forms.Label lblSMTPUName;
        private System.Windows.Forms.TextBox txtSMTPServer;
        private System.Windows.Forms.Label lblSMTPServer;
        private System.Windows.Forms.NumericUpDown nSMTPPort;
        private System.Windows.Forms.Label lblSMTPPort;
        private System.Windows.Forms.CheckBox chkMarkSeats;
        public System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.GroupBox gSenderAddress;
        private System.Windows.Forms.TextBox txtSenderEMail;
        private System.Windows.Forms.Label lblSenderEMail;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.Label lblSenderName;
    }
}