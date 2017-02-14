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
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;

namespace FOHManagerUI {
    public partial class MainWindow : Form {

        static readonly string HomePage = "http://www.trybooking.com/";
        static readonly string Dashboard = "https://portal.trybooking.com/Account/AccountDashboard.aspx";
        static readonly string ExportData = "https://portal.trybooking.com/Reports/ReportTicketHolderCSVExport.aspx";

        ChromiumWebBrowser webBrowser;
        DownloadHandler downloadHandler;

        public MainWindow() {
            InitializeComponent();
            webBrowser = new ChromiumWebBrowser(HomePage);
            downloadHandler = new DownloadHandler();
            webBrowser.DownloadHandler = downloadHandler;
            webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            webBrowser.Location = new System.Drawing.Point(13, 13);
            webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            webBrowser.Name = "browserDisplay";
            webBrowser.Size = new System.Drawing.Size(1122, 475);
            webBrowser.TabIndex = 0;
            webBrowser.FrameLoadEnd += automaticLogin;
            this.Controls.Add(webBrowser);
        }

        void automaticLogin(object sender, EventArgs args) {
            loginUser(webBrowser);
            webBrowser.FrameLoadEnd -= automaticLogin;
        }

        void loginUser(IWebBrowser browser) {
            // TODO: Modify to use username and password recorded in APP to allow modification
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
                    if (printDialog.ShowDialog(this) == DialogResult.OK) {
                        DoorListPrinter printer = printDialog.Document as DoorListPrinter;

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
    }
}
