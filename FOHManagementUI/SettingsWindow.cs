using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FOHBackend;

namespace FOHManagerUI {
    public partial class SettingsWindow : Form {

        Settingsv2 localSettings;

        public SettingsWindow() {
            InitializeComponent();
            localSettings = Settingsv2.Active.copy();

            txtTryBookingUName.Text = localSettings.TryBooking.Username;
            txtTryBookingPassword.Text = localSettings.TryBooking.Password;

            txtSMTPUName.Text = localSettings.SMTP.Username;
            txtSMTPPassword.Text = localSettings.SMTP.Password;
            txtSMTPServer.Text = localSettings.SMTP.SMTPServer;
            nSMTPPort.Value = localSettings.SMTP.SMTPPort;

            chkMarkSeats.Checked = localSettings.MarkThroughSeats;

            txtSenderName.Text = localSettings.SenderAddress.Name;
            txtSenderEMail.Text = localSettings.SenderAddress.EMail;
            if (String.IsNullOrWhiteSpace(txtSenderEMail.Text)) txtSenderEMail.Text = txtSMTPUName.Text;
        }

        private void bCancel_Click(Object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bSave_Click(Object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            Settingsv2.Active.copyFrom(localSettings);
            try {
                Settingsv2.saveSettings();
            } catch (Exception) {
                MessageBox.Show("Error saving settings");
            } finally {
                this.Close();
            }
        }

        private void txtTryBookingUName_TextChanged(Object sender, EventArgs e) {
            if (localSettings.TryBooking.Username != txtTryBookingUName.Text)
                localSettings.TryBooking.Username = txtTryBookingUName.Text;
        }

        private void txtTryBookingPassword_TextChanged(Object sender, EventArgs e) {
            if (localSettings.TryBooking.Password != txtTryBookingPassword.Text)
                localSettings.TryBooking.Password = txtTryBookingPassword.Text;
        }

        private void txtSMTPPassword_TextChanged(Object sender, EventArgs e) {
            if (localSettings.SMTP.Password != txtSMTPPassword.Text)
                localSettings.SMTP.Password = txtSMTPPassword.Text;
        }

        private void txtSMTPUName_TextChanged(Object sender, EventArgs e) {
            if (localSettings.SMTP.Username != txtSMTPUName.Text)
                localSettings.SMTP.Username = txtSMTPUName.Text;
        }

        private void txtSMTPServer_TextChanged(Object sender, EventArgs e) {
            if (localSettings.SMTP.SMTPServer != txtSMTPServer.Text)
                localSettings.SMTP.SMTPServer = txtSMTPServer.Text;
        }

        private void nSMTPPort_ValueChanged(Object sender, EventArgs e) {
            if (localSettings.SMTP.SMTPPort != (UInt16)nSMTPPort.Value) {
                localSettings.SMTP.SMTPPort = (UInt16)nSMTPPort.Value;
            }
        }

        private void chkMarkSeats_CheckedChanged(Object sender, EventArgs e) {
            if (localSettings.MarkThroughSeats != chkMarkSeats.Checked) {
                localSettings.MarkThroughSeats = chkMarkSeats.Checked;
            }
        }

        private void txtSenderName_TextChanged(Object sender, EventArgs e) {
            if (localSettings.SenderAddress.Name != txtSenderName.Text)
                localSettings.SenderAddress.Name = txtSenderName.Text;
        }

        private void txtSenderEMail_TextChanged(Object sender, EventArgs e) {
            if (localSettings.SenderAddress.EMail != txtSenderEMail.Text)
                localSettings.SenderAddress.EMail = txtSenderEMail.Text;
        }
    }
}
