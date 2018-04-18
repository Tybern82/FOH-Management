using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;

namespace FOHManagerUI {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            /*
            // Generates the default configuration files
            System.IO.FileInfo fullSettingsFile = new System.IO.FileInfo(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Full.dlp"));
            System.IO.FileInfo minimalSettingsFile = new System.IO.FileInfo(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Minimal.dlp"));

            FOHBackend.DoorList.DoorListPrinterSettings defSettings = new FOHBackend.DoorList.DoorListPrinterSettings();
            defSettings.ConfigName = "Full";
            defSettings.saveSettings(fullSettingsFile);
            defSettings.ConfigName = "Minimal";
            defSettings.saveSettings(minimalSettingsFile);
            return;
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //For Windows 7 and above, best to include relevant app.manifest entries as well
            Cef.EnableHighDPISupport();

            //We're going to manually call Cef.Shutdown below, this maybe required in some complex scenarious
            CefSharpSettings.ShutdownOnExit = false;
            var settings = new CefSettings();
            // settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
            
            // var browser = new BrowserForm();
            var browser =new MainWindow();
            Application.Run(browser);

            //Shutdown before your application exists or it will hang.
            Cef.Shutdown();
        }
    }
}
