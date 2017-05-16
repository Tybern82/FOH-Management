namespace FOHManagerUI {
    partial class VolunteerRecordUI {
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
            this.components = new System.ComponentModel.Container();
            this.bCancel = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.txtHomePhone = new System.Windows.Forms.TextBox();
            this.txtMobilePhone = new System.Windows.Forms.TextBox();
            this.lblEMail = new System.Windows.Forms.Label();
            this.lblHomePhone = new System.Windows.Forms.Label();
            this.lblMobilePhone = new System.Windows.Forms.Label();
            this.chkTicketSelling = new System.Windows.Forms.CheckBox();
            this.chkKitchen = new System.Windows.Forms.CheckBox();
            this.chkBar = new System.Windows.Forms.CheckBox();
            this.chkMaint = new System.Windows.Forms.CheckBox();
            this.chkBlueCard = new System.Windows.Forms.CheckBox();
            this.chkRSA = new System.Windows.Forms.CheckBox();
            this.chkFHC = new System.Windows.Forms.CheckBox();
            this.chkFirstAid = new System.Windows.Forms.CheckBox();
            this.chkFridayMorning = new System.Windows.Forms.CheckBox();
            this.chkFridayNight = new System.Windows.Forms.CheckBox();
            this.chkSaturdayMatinee = new System.Windows.Forms.CheckBox();
            this.chkSaturdayNight = new System.Windows.Forms.CheckBox();
            this.chkSundayMatinees = new System.Windows.Forms.CheckBox();
            this.gPreferredPosition = new System.Windows.Forms.GroupBox();
            this.gCertificates = new System.Windows.Forms.GroupBox();
            this.gPreferredHours = new System.Windows.Forms.GroupBox();
            this.volunteerRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gPreferredPosition.SuspendLayout();
            this.gCertificates.SuspendLayout();
            this.gPreferredHours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volunteerRecordBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(477, 526);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "&Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bUpdate.Location = new System.Drawing.Point(396, 525);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(75, 23);
            this.bUpdate.TabIndex = 0;
            this.bUpdate.Text = "&Update";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.volunteerRecordBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtName.Location = new System.Drawing.Point(129, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(422, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(70, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 22);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // txtEMail
            // 
            this.txtEMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEMail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.volunteerRecordBindingSource, "EMail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtEMail.Location = new System.Drawing.Point(128, 39);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(423, 20);
            this.txtEMail.TabIndex = 4;
            // 
            // txtHomePhone
            // 
            this.txtHomePhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHomePhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.volunteerRecordBindingSource, "HomePhone", true));
            this.txtHomePhone.Location = new System.Drawing.Point(129, 66);
            this.txtHomePhone.Name = "txtHomePhone";
            this.txtHomePhone.Size = new System.Drawing.Size(423, 20);
            this.txtHomePhone.TabIndex = 5;
            // 
            // txtMobilePhone
            // 
            this.txtMobilePhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobilePhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.volunteerRecordBindingSource, "MobilePhone", true));
            this.txtMobilePhone.Location = new System.Drawing.Point(129, 93);
            this.txtMobilePhone.Name = "txtMobilePhone";
            this.txtMobilePhone.Size = new System.Drawing.Size(423, 20);
            this.txtMobilePhone.TabIndex = 6;
            // 
            // lblEMail
            // 
            this.lblEMail.AutoSize = true;
            this.lblEMail.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEMail.Location = new System.Drawing.Point(12, 36);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(111, 22);
            this.lblEMail.TabIndex = 7;
            this.lblEMail.Text = "EMail Address:";
            // 
            // lblHomePhone
            // 
            this.lblHomePhone.AutoSize = true;
            this.lblHomePhone.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomePhone.Location = new System.Drawing.Point(15, 63);
            this.lblHomePhone.Name = "lblHomePhone";
            this.lblHomePhone.Size = new System.Drawing.Size(108, 22);
            this.lblHomePhone.TabIndex = 8;
            this.lblHomePhone.Text = "Phone - Home:";
            // 
            // lblMobilePhone
            // 
            this.lblMobilePhone.AutoSize = true;
            this.lblMobilePhone.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobilePhone.Location = new System.Drawing.Point(7, 90);
            this.lblMobilePhone.Name = "lblMobilePhone";
            this.lblMobilePhone.Size = new System.Drawing.Size(116, 22);
            this.lblMobilePhone.TabIndex = 9;
            this.lblMobilePhone.Text = "Phone - Mobile:";
            // 
            // chkTicketSelling
            // 
            this.chkTicketSelling.AutoSize = true;
            this.chkTicketSelling.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "TicketSelling", true));
            this.chkTicketSelling.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTicketSelling.Location = new System.Drawing.Point(6, 30);
            this.chkTicketSelling.Name = "chkTicketSelling";
            this.chkTicketSelling.Size = new System.Drawing.Size(121, 26);
            this.chkTicketSelling.TabIndex = 11;
            this.chkTicketSelling.Text = "Ticket Selling";
            this.chkTicketSelling.UseVisualStyleBackColor = true;
            // 
            // chkKitchen
            // 
            this.chkKitchen.AutoSize = true;
            this.chkKitchen.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "Kitchen", true));
            this.chkKitchen.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKitchen.Location = new System.Drawing.Point(6, 62);
            this.chkKitchen.Name = "chkKitchen";
            this.chkKitchen.Size = new System.Drawing.Size(80, 26);
            this.chkKitchen.TabIndex = 12;
            this.chkKitchen.Text = "Kitchen";
            this.chkKitchen.UseVisualStyleBackColor = true;
            // 
            // chkBar
            // 
            this.chkBar.AutoSize = true;
            this.chkBar.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "Bar", true));
            this.chkBar.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBar.Location = new System.Drawing.Point(6, 94);
            this.chkBar.Name = "chkBar";
            this.chkBar.Size = new System.Drawing.Size(52, 26);
            this.chkBar.TabIndex = 13;
            this.chkBar.Text = "Bar";
            this.chkBar.UseVisualStyleBackColor = true;
            // 
            // chkMaint
            // 
            this.chkMaint.AutoSize = true;
            this.chkMaint.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "Maintenance", true));
            this.chkMaint.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMaint.Location = new System.Drawing.Point(6, 126);
            this.chkMaint.Name = "chkMaint";
            this.chkMaint.Size = new System.Drawing.Size(113, 26);
            this.chkMaint.TabIndex = 14;
            this.chkMaint.Text = "Maintenance";
            this.chkMaint.UseVisualStyleBackColor = true;
            // 
            // chkBlueCard
            // 
            this.chkBlueCard.AutoSize = true;
            this.chkBlueCard.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "BlueCard", true));
            this.chkBlueCard.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBlueCard.Location = new System.Drawing.Point(6, 30);
            this.chkBlueCard.Name = "chkBlueCard";
            this.chkBlueCard.Size = new System.Drawing.Size(188, 26);
            this.chkBlueCard.TabIndex = 16;
            this.chkBlueCard.Text = "Blue Card (Child Safety)";
            this.chkBlueCard.UseVisualStyleBackColor = true;
            // 
            // chkRSA
            // 
            this.chkRSA.AutoSize = true;
            this.chkRSA.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "RSA", true));
            this.chkRSA.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRSA.Location = new System.Drawing.Point(6, 62);
            this.chkRSA.Name = "chkRSA";
            this.chkRSA.Size = new System.Drawing.Size(275, 26);
            this.chkRSA.TabIndex = 17;
            this.chkRSA.Text = "RSA (Responsible Service of Alcohol)";
            this.chkRSA.UseVisualStyleBackColor = true;
            // 
            // chkFHC
            // 
            this.chkFHC.AutoSize = true;
            this.chkFHC.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "FHC", true));
            this.chkFHC.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFHC.Location = new System.Drawing.Point(6, 94);
            this.chkFHC.Name = "chkFHC";
            this.chkFHC.Size = new System.Drawing.Size(244, 26);
            this.chkFHC.TabIndex = 18;
            this.chkFHC.Text = "FHC (Food Handling Certificate)";
            this.chkFHC.UseVisualStyleBackColor = true;
            // 
            // chkFirstAid
            // 
            this.chkFirstAid.AutoSize = true;
            this.chkFirstAid.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "FirstAid", true));
            this.chkFirstAid.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFirstAid.Location = new System.Drawing.Point(6, 126);
            this.chkFirstAid.Name = "chkFirstAid";
            this.chkFirstAid.Size = new System.Drawing.Size(191, 26);
            this.chkFirstAid.TabIndex = 19;
            this.chkFirstAid.Text = "First Aid / CPR Training";
            this.chkFirstAid.UseVisualStyleBackColor = true;
            // 
            // chkFridayMorning
            // 
            this.chkFridayMorning.AutoSize = true;
            this.chkFridayMorning.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "FridayMornings", true));
            this.chkFridayMorning.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFridayMorning.Location = new System.Drawing.Point(6, 30);
            this.chkFridayMorning.Name = "chkFridayMorning";
            this.chkFridayMorning.Size = new System.Drawing.Size(303, 26);
            this.chkFridayMorning.TabIndex = 21;
            this.chkFridayMorning.Text = "Friday Mornings (Ticket Selling and Info)";
            this.chkFridayMorning.UseVisualStyleBackColor = true;
            // 
            // chkFridayNight
            // 
            this.chkFridayNight.AutoSize = true;
            this.chkFridayNight.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "FridayNight", true));
            this.chkFridayNight.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFridayNight.Location = new System.Drawing.Point(6, 62);
            this.chkFridayNight.Name = "chkFridayNight";
            this.chkFridayNight.Size = new System.Drawing.Size(170, 26);
            this.chkFridayNight.TabIndex = 22;
            this.chkFridayNight.Text = "Friday Night (Shows)";
            this.chkFridayNight.UseVisualStyleBackColor = true;
            // 
            // chkSaturdayMatinee
            // 
            this.chkSaturdayMatinee.AutoSize = true;
            this.chkSaturdayMatinee.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "SaturdayMatinee", true));
            this.chkSaturdayMatinee.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaturdayMatinee.Location = new System.Drawing.Point(6, 94);
            this.chkSaturdayMatinee.Name = "chkSaturdayMatinee";
            this.chkSaturdayMatinee.Size = new System.Drawing.Size(206, 26);
            this.chkSaturdayMatinee.TabIndex = 23;
            this.chkSaturdayMatinee.Text = "Saturday Matinees (Shows)";
            this.chkSaturdayMatinee.UseVisualStyleBackColor = true;
            // 
            // chkSaturdayNight
            // 
            this.chkSaturdayNight.AutoSize = true;
            this.chkSaturdayNight.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "SaturdayNight", true));
            this.chkSaturdayNight.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaturdayNight.Location = new System.Drawing.Point(6, 126);
            this.chkSaturdayNight.Name = "chkSaturdayNight";
            this.chkSaturdayNight.Size = new System.Drawing.Size(184, 26);
            this.chkSaturdayNight.TabIndex = 24;
            this.chkSaturdayNight.Text = "Saturday Night (Shows)";
            this.chkSaturdayNight.UseVisualStyleBackColor = true;
            // 
            // chkSundayMatinees
            // 
            this.chkSundayMatinees.AutoSize = true;
            this.chkSundayMatinees.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.volunteerRecordBindingSource, "SundayMatinee", true));
            this.chkSundayMatinees.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSundayMatinees.Location = new System.Drawing.Point(6, 158);
            this.chkSundayMatinees.Name = "chkSundayMatinees";
            this.chkSundayMatinees.Size = new System.Drawing.Size(196, 26);
            this.chkSundayMatinees.TabIndex = 25;
            this.chkSundayMatinees.Text = "Sunday Matinees (Shows)";
            this.chkSundayMatinees.UseVisualStyleBackColor = true;
            // 
            // gPreferredPosition
            // 
            this.gPreferredPosition.Controls.Add(this.chkTicketSelling);
            this.gPreferredPosition.Controls.Add(this.chkKitchen);
            this.gPreferredPosition.Controls.Add(this.chkBar);
            this.gPreferredPosition.Controls.Add(this.chkMaint);
            this.gPreferredPosition.Font = new System.Drawing.Font("Showcard Gothic", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gPreferredPosition.Location = new System.Drawing.Point(19, 130);
            this.gPreferredPosition.Name = "gPreferredPosition";
            this.gPreferredPosition.Size = new System.Drawing.Size(236, 167);
            this.gPreferredPosition.TabIndex = 26;
            this.gPreferredPosition.TabStop = false;
            this.gPreferredPosition.Text = "Preferred Position";
            // 
            // gCertificates
            // 
            this.gCertificates.Controls.Add(this.chkBlueCard);
            this.gCertificates.Controls.Add(this.chkRSA);
            this.gCertificates.Controls.Add(this.chkFHC);
            this.gCertificates.Controls.Add(this.chkFirstAid);
            this.gCertificates.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gCertificates.Location = new System.Drawing.Point(261, 130);
            this.gCertificates.Name = "gCertificates";
            this.gCertificates.Size = new System.Drawing.Size(290, 167);
            this.gCertificates.TabIndex = 27;
            this.gCertificates.TabStop = false;
            this.gCertificates.Text = "Certificates";
            // 
            // gPreferredHours
            // 
            this.gPreferredHours.Controls.Add(this.chkFridayMorning);
            this.gPreferredHours.Controls.Add(this.chkFridayNight);
            this.gPreferredHours.Controls.Add(this.chkSaturdayMatinee);
            this.gPreferredHours.Controls.Add(this.chkSundayMatinees);
            this.gPreferredHours.Controls.Add(this.chkSaturdayNight);
            this.gPreferredHours.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gPreferredHours.Location = new System.Drawing.Point(19, 303);
            this.gPreferredHours.Name = "gPreferredHours";
            this.gPreferredHours.Size = new System.Drawing.Size(386, 199);
            this.gPreferredHours.TabIndex = 28;
            this.gPreferredHours.TabStop = false;
            this.gPreferredHours.Text = "Preferred Days / Nights (for FOH)";
            // 
            // volunteerRecordBindingSource
            // 
            this.volunteerRecordBindingSource.AllowNew = true;
            this.volunteerRecordBindingSource.DataSource = typeof(FOHBackend.Roster.VolunteerRecord);
            // 
            // VolunteerRecordUI
            // 
            this.AcceptButton = this.bUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 561);
            this.Controls.Add(this.gPreferredHours);
            this.Controls.Add(this.gCertificates);
            this.Controls.Add(this.gPreferredPosition);
            this.Controls.Add(this.lblMobilePhone);
            this.Controls.Add(this.lblHomePhone);
            this.Controls.Add(this.lblEMail);
            this.Controls.Add(this.txtMobilePhone);
            this.Controls.Add(this.txtHomePhone);
            this.Controls.Add(this.txtEMail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bCancel);
            this.MinimumSize = new System.Drawing.Size(580, 600);
            this.Name = "VolunteerRecordUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Volunteer Profile Record";
            this.gPreferredPosition.ResumeLayout(false);
            this.gPreferredPosition.PerformLayout();
            this.gCertificates.ResumeLayout(false);
            this.gCertificates.PerformLayout();
            this.gPreferredHours.ResumeLayout(false);
            this.gPreferredHours.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volunteerRecordBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.TextBox txtHomePhone;
        private System.Windows.Forms.TextBox txtMobilePhone;
        private System.Windows.Forms.Label lblEMail;
        private System.Windows.Forms.Label lblHomePhone;
        private System.Windows.Forms.Label lblMobilePhone;
        private System.Windows.Forms.CheckBox chkTicketSelling;
        private System.Windows.Forms.CheckBox chkKitchen;
        private System.Windows.Forms.CheckBox chkBar;
        private System.Windows.Forms.CheckBox chkMaint;
        private System.Windows.Forms.CheckBox chkBlueCard;
        private System.Windows.Forms.CheckBox chkRSA;
        private System.Windows.Forms.CheckBox chkFHC;
        private System.Windows.Forms.CheckBox chkFirstAid;
        private System.Windows.Forms.CheckBox chkFridayMorning;
        private System.Windows.Forms.CheckBox chkFridayNight;
        private System.Windows.Forms.CheckBox chkSaturdayMatinee;
        private System.Windows.Forms.CheckBox chkSaturdayNight;
        private System.Windows.Forms.CheckBox chkSundayMatinees;
        private System.Windows.Forms.GroupBox gPreferredPosition;
        private System.Windows.Forms.GroupBox gCertificates;
        private System.Windows.Forms.GroupBox gPreferredHours;
        private System.Windows.Forms.BindingSource volunteerRecordBindingSource;
    }
}