namespace FOHManager {
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
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.doorListPrinter1 = new FOHBackend.DoorList.DoorListPrinter();
            this.bDoorList = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bQuit = new System.Windows.Forms.Button();
            this.bTryBooking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.doorListPrinter1;
            this.printDialog1.UseEXDialog = true;
            // 
            // doorListPrinter1
            // 
            this.doorListPrinter1.bodyFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.doorListPrinter1.doorList = ((System.Collections.Generic.List<FOHBackend.DoorList.DoorListEntry>)(resources.GetObject("doorListPrinter1.doorList")));
            this.doorListPrinter1.headerFont = new System.Drawing.Font("Times New Roman", 14F);
            this.doorListPrinter1.listTitle = null;
            this.doorListPrinter1.subHeaderFont = new System.Drawing.Font("Times New Roman", 12F);
            // 
            // bDoorList
            // 
            this.bDoorList.Location = new System.Drawing.Point(149, 12);
            this.bDoorList.Name = "bDoorList";
            this.bDoorList.Size = new System.Drawing.Size(110, 23);
            this.bDoorList.TabIndex = 0;
            this.bDoorList.Text = "Generate Door List";
            this.bDoorList.UseVisualStyleBackColor = true;
            this.bDoorList.Click += new System.EventHandler(this.bDoorList_onClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.FileName = "doorList.csv";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // bQuit
            // 
            this.bQuit.Location = new System.Drawing.Point(294, 165);
            this.bQuit.Name = "bQuit";
            this.bQuit.Size = new System.Drawing.Size(75, 23);
            this.bQuit.TabIndex = 1;
            this.bQuit.Text = "Quit";
            this.bQuit.UseVisualStyleBackColor = true;
            this.bQuit.Click += new System.EventHandler(this.bQuit_Click);
            // 
            // bTryBooking
            // 
            this.bTryBooking.Location = new System.Drawing.Point(12, 12);
            this.bTryBooking.Name = "bTryBooking";
            this.bTryBooking.Size = new System.Drawing.Size(131, 23);
            this.bTryBooking.TabIndex = 2;
            this.bTryBooking.Text = "Display Export Settings";
            this.bTryBooking.UseVisualStyleBackColor = true;
            this.bTryBooking.Click += new System.EventHandler(this.bTryBooking_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 200);
            this.Controls.Add(this.bTryBooking);
            this.Controls.Add(this.bQuit);
            this.Controls.Add(this.bDoorList);
            this.Name = "MainWindow";
            this.Text = "ZPAC Theatre - FOH";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button bDoorList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private FOHBackend.DoorList.DoorListPrinter doorListPrinter1;
        private System.Windows.Forms.Button bQuit;
        private System.Windows.Forms.Button bTryBooking;
    }
}

