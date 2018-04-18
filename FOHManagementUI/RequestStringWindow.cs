using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOHManagerUI {
    public partial class RequestStringWindow : Form {
        public RequestStringWindow(string msg, string suggestedText) {
            InitializeComponent();
            lblMessage.Text = msg;
            txtString.Text = suggestedText;
        }

        public string getText() {
            return txtString.Text;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
