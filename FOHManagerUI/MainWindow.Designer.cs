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
            this.bQuit = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.doorListPrinter = new FOHBackend.DoorList.DoorListPrinter();
            this.SuspendLayout();
            // 
            // bSelectExport
            // 
            this.bSelectExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSelectExport.Location = new System.Drawing.Point(13, 494);
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
            this.bExport.Location = new System.Drawing.Point(116, 494);
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
            this.bPrint.Location = new System.Drawing.Point(219, 494);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(97, 23);
            this.bPrint.TabIndex = 2;
            this.bPrint.Text = "Print Door List";
            this.bPrint.UseVisualStyleBackColor = true;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // bQuit
            // 
            this.bQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bQuit.Location = new System.Drawing.Point(1060, 494);
            this.bQuit.Name = "bQuit";
            this.bQuit.Size = new System.Drawing.Size(75, 23);
            this.bQuit.TabIndex = 3;
            this.bQuit.Text = "Exit";
            this.bQuit.UseVisualStyleBackColor = true;
            this.bQuit.Click += new System.EventHandler(this.bQuit_Click);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "doorList.csv";
            this.openDialog.Filter = "CSV Files|*.csv|All Files|*.*";
            this.openDialog.SupportMultiDottedExtensions = true;
            // 
            // printDialog
            // 
            this.printDialog.Document = this.doorListPrinter;
            this.printDialog.UseEXDialog = true;
            // 
            // doorListPrinter
            // 
            this.doorListPrinter.bodyFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.doorListPrinter.doorList = ((System.Collections.Generic.List<FOHBackend.DoorList.DoorListEntry>)(resources.GetObject("doorListPrinter.doorList")));
            this.doorListPrinter.headerFont = new System.Drawing.Font("Times New Roman", 14F);
            this.doorListPrinter.listTitle = null;
            this.doorListPrinter.subHeaderFont = new System.Drawing.Font("Times New Roman", 12F);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 529);
            this.Controls.Add(this.bQuit);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.bSelectExport);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FOH Management";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bSelectExport;
        private System.Windows.Forms.Button bExport;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Button bQuit;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.PrintDialog printDialog;
        private FOHBackend.DoorList.DoorListPrinter doorListPrinter;
    }
}

