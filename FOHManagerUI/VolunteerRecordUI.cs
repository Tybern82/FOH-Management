using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FOHBackend.Roster;

namespace FOHManagerUI {
    public partial class VolunteerRecordUI : Form {

        public VolunteerRecord baseRecord { get; }

        public VolunteerRecordUI(VolunteerRecord record) {
            InitializeComponent();
            this.baseRecord = (record != null) ? record : new VolunteerRecord();
            this.volunteerRecordBindingSource.DataSource = baseRecord;
        }

        public VolunteerRecordUI() : this(new VolunteerRecord()) {}

        private void bUpdate_Click(Object sender, EventArgs e) {            
            this.Close();
        }

        private void bCancel_Click(Object sender, EventArgs e) {
            this.Close();
        }
    }
}
