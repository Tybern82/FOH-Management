using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FOHBackend.DoorList;

namespace FOHManager {
    public partial class MainWindow : Form {

        public MainWindow() {
            InitializeComponent();
        }

        private void bDoorList_onClick(Object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK) {
                try {
                    List<DoorListEntry> list = Helper.loadCSV(openFileDialog1.FileName);
                    if (printDialog1.ShowDialog(this) == DialogResult.OK) {
                        DoorListPrinter printer = printDialog1.Document as DoorListPrinter;

                        printer.listTitle = "Door List by Surname";
                        printer.doorList = Helper.sortByName(list);
                        printer.Print();

                        printer.listTitle = "Door List by Seat";
                        printer.doorList = Helper.sortBySeat(list);
                        printer.Print();

                        printer.doorList = new List<DoorListEntry>();
                    }
                } catch (Exception) {
                    MessageBox.Show("Error processing file");
                }
            }
        }

        private void bQuit_Click(Object sender, EventArgs e) {
            Application.Exit();
        }

        private TryBookingInstructions instr = null;
        private void bTryBooking_Click(Object sender, EventArgs e) {
            if (instr == null) instr = new TryBookingInstructions();
            instr.ShowDialog(this);
        }
    }
}
