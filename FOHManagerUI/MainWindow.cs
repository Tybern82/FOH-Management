using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using FOHBackend.DoorList;
using FOHBackend.Roster;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;

namespace FOHManagerUI {
    public partial class MainWindow : Form {

        static readonly string LocalVolunteers = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LocalRecords.volunteer");

        static readonly string HomePage = "http://www.trybooking.com/";
        static readonly string Dashboard = "https://portal.trybooking.com/Account/AccountDashboard.aspx";
        static readonly string ExportData = "https://portal.trybooking.com/Reports/ReportTicketHolderCSVExport.aspx";

        ChromiumWebBrowser webBrowser;
        DownloadHandler downloadHandler;

        public MainWindow() {
            InitializeComponent();
            printDialog.Document = new DoorListPrinter();
            printDialog.Document.DocumentName = "doorList";
            webBrowser = new ChromiumWebBrowser(HomePage);
            downloadHandler = new DownloadHandler();
            webBrowser.DownloadHandler = downloadHandler;
            webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            webBrowser.Location = new System.Drawing.Point(13, 13);
            webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            webBrowser.Name = "browserDisplay";
            webBrowser.Size = new System.Drawing.Size(pWebBrowser.Size.Width - 13 - 13, pWebBrowser.Size.Height - 13 - 13);
            // webBrowser.Size = new System.Drawing.Size(1122, 475);
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.TabIndex = 0;
            webBrowser.FrameLoadEnd += automaticLogin;
            // this.Controls.Add(webBrowser);
            pWebBrowser.Controls.Add(webBrowser);
        }

        void automaticLogin(object sender, EventArgs args) {
            loginUser(webBrowser);
            webBrowser.FrameLoadEnd -= automaticLogin;
        }

        void loginUser(IWebBrowser browser) {
            string uname = FOHBackend.Settings.ActiveSettings.TryBookingUsername;
            string pword = FOHBackend.Settings.ActiveSettings.TryBookingPassword;

            string cmd = "document.getElementById(\"loginForm\").elements[\"txtEmailAdd\"].value = \"" + uname + "\";";
            cmd += "document.getElementById(\"loginForm\").elements[\"txtPassword\"].value = \"" + pword + "\";";
            cmd += "document.getElementById(\"loginForm\").submit();";
            browser.EvaluateScriptAsync(cmd);
        }

        void exportData() {
            webBrowser.FrameLoadEnd += automaticExport;
            webBrowser.Load(ExportData);
        }

        /*
        delegate void DCallbackStringArray(IEnumerable<string> values);
        void getItemList(string ctrl, IWebBrowser browser, DCallbackStringArray cback) {
            string cmd = "";
            cmd += "(function() {";
            cmd += "    var _res = [];";
            cmd += "    var ctrl = window['" + ctrl + "'];";
            cmd += "    for (var i = 0; i < ctrl.GetItemCount(); i++) {";
            cmd += "        _res.push(ctrl.GetItem(i).text);";
            cmd += "    }";
            cmd += "    return JSON.stringify(_res);";
            cmd += "})();";
            
            var task = browser.EvaluateScriptAsync(cmd);
            task.ContinueWith(t => {
                if (!t.IsFaulted) {
                    if (t.Result.Success) {
                        dynamic dynObj = JsonConvert.DeserializeObject((string)t.Result.Result);
                        List<string> values = new List<string>();
                        foreach (string s in dynObj) {
                            values.Add(s);
                        }
                        cback(values);
                    } else {
                        cback(null);
                    }
                }
            });
        }
        */

        void allowExport(bool enabled) {
            this.Invoke((Action)(() => { bExport.Enabled = enabled; }));
        }

        void automaticExport(object sender, EventArgs args) {
            webBrowser.FrameLoadEnd -= automaticExport;
            webBrowser.EvaluateScriptAsync(setExportSettings());
            allowExport(true);
        }

        string setExportSettings() {
            // Basic settings
            string cmd = "window['chkAllBooks'].SetChecked(true);";
            cmd = "window['ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblIncludeHeader'].SetChecked(false);";
            cmd += "window['ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblGroupDuplicatedDetails'].SetChecked(false);";
            cmd += "window['chkExcludeBOFQuickSale'].SetChecked(false);";
            cmd += "window['chkIncludeRefundedTickets'].SetChecked(false);";
            // Event Details
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblEventDetails_0\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblEventDetails_1\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblEventDetails_2\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblEventDetails_3\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblEventDetails_4\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblEventDetails_5\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblEventDetails_6\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblEventDetails_7\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblEventDetails_8\").checked = false;";
            // Booking Details 
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_0\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_1\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_2\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_3\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_4\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_5\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_6\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_7\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_8\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_9\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_10\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_11\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_12\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_13\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_14\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_15\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_16\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_17\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_18\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_19\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblBookingDetails_20\").checked = false;";

            // Ticket Details
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblTicketDetails_0\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblTicketDetails_1\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblTicketDetails_2\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblTicketDetails_3\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblTicketDetails_4\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblTicketDetails_5\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblTicketDetails_6\").checked = true;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblTicketDetails_7\").checked = false;";
            cmd += "document.getElementById(\"ctl00_ContentPlaceHolder1_CallbackPanelLabel_cblTicketDetails_8\").checked = false;";
            return cmd;
        }

        private void bSelectExport_Click(Object sender, EventArgs e) {
            exportData();
        }

        private void bExport_Click(Object sender, EventArgs e) {
            string cmd = "";
            cmd += "(function() {";
            cmd += setExportSettings();
            cmd += "window['btnExport'].DoClick();";
            cmd += "return 0;";
            cmd += "})();";
            downloadHandler.OnDownloadUpdatedFired += onDownload;
            webBrowser.ExecuteScriptAsync(cmd);
        }

        void onDownload(object sender, DownloadItem item) {
            if (item.IsComplete) {
                allowExport(false);
                webBrowser.Load(Dashboard);
                downloadHandler.OnDownloadUpdatedFired -= onDownload;
            }
        }

        private void bQuit_Click(Object sender, EventArgs e) {
            Application.Exit();
        }

        private void bPrint_Click(Object sender, EventArgs e) {
            if (openDialog.ShowDialog(this) == DialogResult.OK) {
                try {
                    List<DoorListEntry> list = Helper.loadCSV(openDialog.FileName);

                    DoorListPrinter printer = new DoorListPrinter();
                    printDialog.Document = printer;
                    if (printDialog.ShowDialog(this) == DialogResult.OK) {

                        printer.DocumentName = "doorList-bySurname";
                        printer.listTitle = "Door List by Surname";
                        printer.doorList = Helper.sortByName(list);
                        printer.Print();

                        printer.DocumentName = "doorList-bySeat";
                        printer.listTitle = "Door List by Seat";
                        DoorListEntrySizes sz = printer.doorListSizes;  // cache the already calculated sizes, since these won't change simply by reordering
                        printer.doorList = Helper.sortBySeat(list);
                        printer.doorListSizes = sz; // restore already calculated sizes
                        printer.Print();

                        SeatingMapPrinter seatingMapPrinter = new SeatingMapPrinter();
                        seatingMapPrinter.PrinterSettings = printDialog.PrinterSettings;
                        printDialog.Document = seatingMapPrinter;
                        seatingMapPrinter.doorList = printer.doorList;
                        seatingMapPrinter.Print();
                    }
                } catch (Exception) {
                    MessageBox.Show("Error processing file");
                }
            }
        }

        private void mitmAbout_onClick(Object sender, EventArgs e) {
            AboutBox abt = new AboutBox();
            abt.ShowDialog(this);
        }

        private void mitmExit_onClick(Object sender, EventArgs e) {
            bQuit_Click(sender, e);
        }

        private void mitmTicketing_onClick(Object sender, EventArgs e) {
            tabMainUI.SelectedTab = pgTicketing;
        }

        private void mitmRostering_onClick(Object sender, EventArgs e) {
            tabMainUI.SelectedTab = pgRoster;
        }

        private void mitmVolunteers_onClick(Object sender, EventArgs e) {
            tabMainUI.SelectedTab = pgVolunteers;
        }

        private void bAddVolunteerRecord_Click(Object sender, EventArgs e) {
            VolunteerRecordUI dlg = new VolunteerRecordUI();
            if (dlg.ShowDialog() == DialogResult.OK) {
                lstVolunteerRecords.Items.Add(dlg.baseRecord);
                lstVolunteerRecords.Update();
            }
        }

        private void bEditVolunteerRecord_Click(Object sender, EventArgs e) {
            if (lstVolunteerRecords.SelectedItem == null) {
                MessageBox.Show("Please select the record to be edited first.");
            } else {
                VolunteerRecord oRec = lstVolunteerRecords.SelectedItem as VolunteerRecord;
                if (oRec == null) {
                    MessageBox.Show("Unable to edit this record - it does not appear to be a valid record.");
                    return;
                }
                VolunteerRecordUI dlg = new VolunteerRecordUI(oRec.dup());
                if (dlg.ShowDialog() == DialogResult.OK) {
                    lstVolunteerRecords.BeginUpdate();
                    lstVolunteerRecords.Items.Remove(oRec);
                    lstVolunteerRecords.Items.Add(dlg.baseRecord);
                    lstVolunteerRecords.EndUpdate();
                }
            }
        }

        private void MainWindow_Load(Object sender, EventArgs e) {
            lstVolunteerRecords.BeginUpdate();
            List<VolunteerRecord> _items = VolunteerRecord.loadJSONList(new System.IO.FileInfo(LocalVolunteers));
            foreach (VolunteerRecord rec in _items) lstVolunteerRecords.Items.Add(rec);
            lstVolunteerRecords.EndUpdate();
        }

        private void MainWindow_FormClosing(Object sender, FormClosingEventArgs e) {
            List<VolunteerRecord> _items = new List<VolunteerRecord>();
            foreach (object i in lstVolunteerRecords.Items) {
                VolunteerRecord _rec = i as VolunteerRecord;
                if (_rec != null) _items.Add(_rec);
            }
            VolunteerRecord.storeJSONList(_items, new System.IO.FileInfo(LocalVolunteers));
        }

        private void bDeleteVolunteerRecord_Click(Object sender, EventArgs e) {
            if (lstVolunteerRecords.SelectedItem == null) {
                MessageBox.Show("Please select the record to be deleted first.");
            } else {
                VolunteerRecord oRec = lstVolunteerRecords.SelectedItem as VolunteerRecord;
                lstVolunteerRecords.BeginUpdate();
                if (oRec == null) {
                    lstVolunteerRecords.Items.Remove(lstVolunteerRecords.SelectedItem);
                    return;
                }
                if (MessageBox.Show(String.Format("Are you sure you want to delete {0}?", oRec), "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                    lstVolunteerRecords.Items.Remove(oRec);
                }
                lstVolunteerRecords.EndUpdate();
            }
        }
    }
}
