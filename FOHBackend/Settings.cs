using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;

namespace FOHBackend {
    public class Settings {

        private static Settings _ActiveSettings;
        public static Settings ActiveSettings {
            get {
                if (_ActiveSettings == null) loadDefaultSettings();
                return _ActiveSettings;
            }
            set { _ActiveSettings = value; }
        }

        static readonly string DefaultSettingFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FOHManagement.settings");

        public static Settings loadDefaultSettings() {
            _ActiveSettings = loadJSONSettings(new FileInfo(DefaultSettingFile));
            return _ActiveSettings;
        }

        public static Settings loadJSONSettings(FileInfo fname) {
            StreamReader reader = new StreamReader(fname.OpenRead());
            _ActiveSettings = JsonConvert.DeserializeObject<Settings>(reader.ReadToEnd());
            return _ActiveSettings;
        }

        private Settings() {}

        public string TryBookingUsername { get; set; } = "Username";
        public string TryBookingPassword { get; set; } = "Password";
    }
}
