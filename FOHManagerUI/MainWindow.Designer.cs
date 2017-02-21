namespace FOHManagerUI {
    partial class MainWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.bSelectExport = new System.Windows.Forms.Button();
            this.bExport = new System.Windows.Forms.Button();
            this.bPrint = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.pWebBrowser = new System.Windows.Forms.Panel();
            this.mbarMainMenu = new System.Windows.Forms.MenuStrip();
            this.mFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mitmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mSection = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmTicketing = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmRostering = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmVolunteers = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMainUI = new System.Windows.Forms.TabControl();
            this.pgTicketing = new System.Windows.Forms.TabPage();
            this.pgRoster = new System.Windows.Forms.TabPage();
            this.pgVolunteers = new System.Windows.Forms.TabPage();
            this.bAddVolunteerRecord = new System.Windows.Forms.Button();
            this.bEditVolunteerRecord = new System.Windows.Forms.Button();
            this.lstVolunteerRecords = new System.Windows.Forms.ListBox();
            this.bDeleteVolunteerRecord = new System.Windows.Forms.Button();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.mbarMainMenu.SuspendLayout();
            this.tabMainUI.SuspendLayout();
            this.pgTicketing.SuspendLayout();
            this.pgVolunteers.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSelectExport
            // 
            this.bSelectExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSelectExport.Location = new System.Drawing.Point(6, 433);
            this.bSelectExport.Name = "bSelectExport";
            this.bSelectExport.Size = new System.Drawing.Size(97, 23);
            this.bSelectExport.TabIndex = 0;
            this.bSelectExport.Text = "Save Door List";
            this.bSelectExport.UseVisualStyleBackColor = true;
            this.bSelectExport.Click += new System.EventHandler(this.bSelectExport_Click);
            // 
            // bExport
            // 
            this.bExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bExport.Enabled = false;
            this.bExport.Location = new System.Drawing.Point(109, 433);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(97, 23);
            this.bExport.TabIndex = 1;
            this.bExport.Text = "Export Door List";
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // bPrint
            // 
            this.bPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bPrint.Location = new System.Drawing.Point(212, 433);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(97, 23);
            this.bPrint.TabIndex = 2;
            this.bPrint.Text = "Print Door List";
            this.bPrint.UseVisualStyleBackColor = true;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "doorList.csv";
            this.openDialog.Filter = "CSV Files|*.csv|All Files|*.*";
            this.openDialog.SupportMultiDottedExtensions = true;
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // pWebBrowser
            // 
            this.pWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pWebBrowser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pWebBrowser.Location = new System.Drawing.Point(6, 6);
            this.pWebBrowser.Name = "pWebBrowser";
            this.pWebBrowser.Size = new System.Drawing.Size(466, 421);
            this.pWebBrowser.TabIndex = 4;
            // 
            // mbarMainMenu
            // 
            this.mbarMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFile,
            this.mHelp,
            this.mSection});
            this.mbarMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mbarMainMenu.Name = "mbarMainMenu";
            this.mbarMainMenu.Size = new System.Drawing.Size(514, 24);
            this.mbarMainMenu.TabIndex = 5;
            this.mbarMainMenu.Text = "menuStrip1";
            // 
            // mFile
            // 
            this.mFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.mitmExit});
            this.mFile.Name = "mFile";
            this.mFile.Size = new System.Drawing.Size(37, 20);
            this.mFile.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 6);
            // 
            // mitmExit
            // 
            this.mitmExit.Name = "mitmExit";
            this.mitmExit.Size = new System.Drawing.Size(92, 22);
            this.mitmExit.Text = "E&xit";
            this.mitmExit.Click += new System.EventHandler(this.mitmExit_onClick);
            // 
            // mHelp
            // 
            this.mHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmAbout});
            this.mHelp.Image = ((System.Drawing.Image)(resources.GetObject("mHelp.Image")));
            this.mHelp.Name = "mHelp";
            this.mHelp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mHelp.Size = new System.Drawing.Size(60, 20);
            this.mHelp.Text = "&Help";
            // 
            // mitmAbout
            // 
            this.mitmAbout.Image = global::FOHManagerUI.Properties.Resources.AboutIcon;
            this.mitmAbout.Name = "mitmAbout";
            this.mitmAbout.Size = new System.Drawing.Size(107, 22);
            this.mitmAbout.Text = "&About";
            this.mitmAbout.Click += new System.EventHandler(this.mitmAbout_onClick);
            // 
            // mSection
            // 
            this.mSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmTicketing,
            this.mitmRostering,
            this.mitmVolunteers});
            this.mSection.Name = "mSection";
            this.mSection.Size = new System.Drawing.Size(58, 20);
            this.mSection.Text = "&Section";
            // 
            // mitmTicketing
            // 
            this.mitmTicketing.Name = "mitmTicketing";
            this.mitmTicketing.Size = new System.Drawing.Size(186, 22);
            this.mitmTicketing.Text = "&Ticketing / Door Lists";
            this.mitmTicketing.Click += new System.EventHandler(this.mitmTicketing_onClick);
            // 
            // mitmRostering
            // 
            this.mitmRostering.Name = "mitmRostering";
            this.mitmRostering.Size = new System.Drawing.Size(186, 22);
            this.mitmRostering.Text = "FOH &Rostering";
            this.mitmRostering.Click += new System.EventHandler(this.mitmRostering_onClick);
            // 
            // mitmVolunteers
            // 
            this.mitmVolunteers.Name = "mitmVolunteers";
            this.mitmVolunteers.Size = new System.Drawing.Size(186, 22);
            this.mitmVolunteers.Text = "&Volunteer Records";
            this.mitmVolunteers.Click += new System.EventHandler(this.mitmVolunteers_onClick);
            // 
            // tabMainUI
            // 
            this.tabMainUI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMainUI.Controls.Add(this.pgTicketing);
            this.tabMainUI.Controls.Add(this.pgRoster);
            this.tabMainUI.Controls.Add(this.pgVolunteers);
            this.tabMainUI.HotTrack = true;
            this.tabMainUI.Location = new System.Drawing.Point(12, 27);
            this.tabMainUI.Multiline = true;
            this.tabMainUI.Name = "tabMainUI";
            this.tabMainUI.RightToLeftLayout = true;
            this.tabMainUI.SelectedIndex = 0;
            this.tabMainUI.Size = new System.Drawing.Size(490, 492);
            this.tabMainUI.TabIndex = 6;
            // 
            // pgTicketing
            // 
            this.pgTicketing.BackColor = System.Drawing.SystemColors.Control;
            this.pgTicketing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pgTicketing.Controls.Add(this.pWebBrowser);
            this.pgTicketing.Controls.Add(this.bSelectExport);
            this.pgTicketing.Controls.Add(this.bPrint);
            this.pgTicketing.Controls.Add(this.bExport);
            this.pgTicketing.Location = new System.Drawing.Point(4, 22);
            this.pgTicketing.Name = "pgTicketing";
            this.pgTicketing.Padding = new System.Windows.Forms.Padding(3);
            this.pgTicketing.Size = new System.Drawing.Size(482, 466);
            this.pgTicketing.TabIndex = 0;
            this.pgTicketing.Text = "Ticketing / Door Lists";
            // 
            // pgRoster
            // 
            this.pgRoster.BackColor = System.Drawing.SystemColors.Control;
            this.pgRoster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pgRoster.Location = new System.Drawing.Point(4, 22);
            this.pgRoster.Name = "pgRoster";
            this.pgRoster.Padding = new System.Windows.Forms.Padding(3);
            this.pgRoster.Size = new System.Drawing.Size(482, 466);
            this.pgRoster.TabIndex = 1;
            this.pgRoster.Text = "FOH Rostering";
            // 
            // pgVolunteers
            // 
            this.pgVolunteers.BackColor = System.Drawing.SystemColors.Control;
            this.pgVolunteers.Controls.Add(this.bDeleteVolunteerRecord);
            this.pgVolunteers.Controls.Add(this.bAddVolunteerRecord);
            this.pgVolunteers.Controls.Add(this.bEditVolunteerRecord);
            this.pgVolunteers.Controls.Add(this.lstVolunteerRecords);
            this.pgVolunteers.Location = new System.Drawing.Point(4, 22);
            this.pgVolunteers.Name = "pgVolunteers";
            this.pgVolunteers.Padding = new System.Windows.Forms.Padding(3);
            this.pgVolunteers.Size = new System.Drawing.Size(482, 466);
            this.pgVolunteers.TabIndex = 2;
            this.pgVolunteers.Text = "Volunteer Records";
            // 
            // bAddVolunteerRecord
            // 
            this.bAddVolunteerRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddVolunteerRecord.Location = new System.Drawing.Point(170, 437);
            this.bAddVolunteerRecord.Name = "bAddVolunteerRecord";
            this.bAddVolunteerRecord.Size = new System.Drawing.Size(98, 23);
            this.bAddVolunteerRecord.TabIndex = 2;
            this.bAddVolunteerRecord.Text = "Add Volunteer";
            this.bAddVolunteerRecord.UseVisualStyleBackColor = true;
            this.bAddVolunteerRecord.Click += new System.EventHandler(this.bAddVolunteerRecord_Click);
            // 
            // bEditVolunteerRecord
            // 
            this.bEditVolunteerRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bEditVolunteerRecord.Location = new System.Drawing.Point(274, 437);
            this.bEditVolunteerRecord.Name = "bEditVolunteerRecord";
            this.bEditVolunteerRecord.Size = new System.Drawing.Size(98, 23);
            this.bEditVolunteerRecord.TabIndex = 1;
            this.bEditVolunteerRecord.Text = "Edit Volunteer";
            this.bEditVolunteerRecord.UseVisualStyleBackColor = true;
            this.bEditVolunteerRecord.Click += new System.EventHandler(this.bEditVolunteerRecord_Click);
            // 
            // lstVolunteerRecords
            // 
            this.lstVolunteerRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVolunteerRecords.FormattingEnabled = true;
            this.lstVolunteerRecords.Location = new System.Drawing.Point(7, 7);
            this.lstVolunteerRecords.Name = "lstVolunteerRecords";
            this.lstVolunteerRecords.Size = new System.Drawing.Size(469, 420);
            this.lstVolunteerRecords.Sorted = true;
            this.lstVolunteerRecords.TabIndex = 0;
            // 
            // bDeleteVolunteerRecord
            // 
            this.bDeleteVolunteerRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDeleteVolunteerRecord.Location = new System.Drawing.Point(378, 437);
            this.bDeleteVolunteerRecord.Name = "bDeleteVolunteerRecord";
            this.bDeleteVolunteerRecord.Size = new System.Drawing.Size(98, 23);
            this.bDeleteVolunteerRecord.TabIndex = 3;
            this.bDeleteVolunteerRecord.Text = "Delete Volunteer";
            this.bDeleteVolunteerRecord.UseVisualStyleBackColor = true;
            this.bDeleteVolunteerRecord.Click += new System.EventHandler(this.bDeleteVolunteerRecord_Click);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 531);
            this.Controls.Add(this.tabMainUI);
            this.Controls.Add(this.mbarMainMenu);
            this.MainMenuStrip = this.mbarMainMenu;
            this.MinimumSize = new System.Drawing.Size(530, 570);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FOH Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.mbarMainMenu.ResumeLayout(false);
            this.mbarMainMenu.PerformLayout();
            this.tabMainUI.ResumeLayout(false);
            this.pgTicketing.ResumeLayout(false);
            this.pgVolunteers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSelectExport;
        private System.Windows.Forms.Button bExport;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.Panel pWebBrowser;
        private System.Windows.Forms.MenuStrip mbarMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mFile;
        private System.Windows.Forms.ToolStripMenuItem mHelp;
        private System.Windows.Forms.ToolStripMenuItem mitmAbout;
        private System.Windows.Forms.ToolStripMenuItem mitmExit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.TabControl tabMainUI;
        private System.Windows.Forms.TabPage pgTicketing;
        private System.Windows.Forms.TabPage pgRoster;
        private System.Windows.Forms.ToolStripMenuItem mSection;
        private System.Windows.Forms.ToolStripMenuItem mitmTicketing;
        private System.Windows.Forms.ToolStripMenuItem mitmRostering;
        private System.Windows.Forms.ToolStripMenuItem mitmVolunteers;
        private System.Windows.Forms.TabPage pgVolunteers;
        private System.Windows.Forms.Button bAddVolunteerRecord;
        private System.Windows.Forms.Button bEditVolunteerRecord;
        private System.Windows.Forms.ListBox lstVolunteerRecords;
        private System.Windows.Forms.Button bDeleteVolunteerRecord;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    }
}

