using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOHBackend.ui {
    public class Scripts {

        public static string getExportSettingsCommand() {
            return Properties.Resources.exportSettings;
        }

        public static string getAutologinCommand(string uname, string pword) {
            return String.Format(Properties.Resources.autologin, uname, pword);
        }

        public static string getExportCommand() {
            return String.Format(Properties.Resources.exportCommand, getExportSettingsCommand());
        }
    }
}
