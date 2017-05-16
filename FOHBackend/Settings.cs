using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using FOHBackend.Mail;

namespace FOHBackend {
    class Settings {

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
            if (fname.Exists) {
                using (StreamReader reader = new StreamReader(fname.OpenRead())) {
                    _ActiveSettings = JsonConvert.DeserializeObject<Settings>(reader.ReadToEnd());
                    reader.Close();
                }
            } else {
                return new Settings();
            }
            return _ActiveSettings;
        }

        public static void saveSettings(FileInfo fname) {
            using (StreamWriter writer = new StreamWriter(fname.OpenWrite())) {
                writer.WriteLine(JsonConvert.SerializeObject(ActiveSettings, Formatting.Indented));
                writer.Close();
            }
        }

        public static void saveSettings() {
            saveSettings(new FileInfo(DefaultSettingFile));
        }

        private Settings() {}

        public string TryBookingUsername { get; set; } = "Username";
        public string TryBookingPassword { get; set; } = "Password";
        public bool MarkOutSoldSeats { get; set; } = true;

        public string GMailUsername { get; set; } = "Username";
        public string GMailPassword { get; set; } = "Password";

        public SMTPSettings SMTP { get; set; } = new SMTPSettings();
    }

    public class SMTPSettings {
        public string SMTPServer { get; set; } = "smtp.gmail.com";
        public UInt16 SMTPPort { get; set; } = 587;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class TryBookingSettings {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class Settingsv2 {
        public TryBookingSettings TryBooking { get; set; } = new TryBookingSettings();
        public SMTPSettings SMTP { get; set; } = new SMTPSettings();
        public MailAddress SenderAddress { get; set; } = new MailAddress() { Name = "User", EMail = "user@host.com" };

        public bool MarkThroughSeats { get; set; } = true;


        public Settingsv2 copy() {
            Settingsv2 _result = new Settingsv2();
            _result.copyFrom(this);
            return _result;
        }

        public void copyFrom(Settingsv2 s) {
            TryBooking.Username = s.TryBooking.Username;
            TryBooking.Password = s.TryBooking.Password;

            SMTP.Username = s.SMTP.Username;
            SMTP.Password = s.SMTP.Password;
            SMTP.SMTPServer = s.SMTP.SMTPServer;
            SMTP.SMTPPort = s.SMTP.SMTPPort;

            SenderAddress.Name = s.SenderAddress.Name;
            SenderAddress.EMail = s.SenderAddress.EMail;

            MarkThroughSeats = s.MarkThroughSeats;
        }

        private static Settingsv2 _Active = null;
        public static Settingsv2 Active {
            get {
                if (_Active == null) loadSettings();
                return _Active;
            }
        }

        private static FileInfo _SettingsFile = null;
        private static FileInfo SettingsFile {
            get {
                if (_SettingsFile == null) {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                    path = Path.Combine(path, "Jeff Sweeney - FOH Management");
                    DirectoryInfo dir = new DirectoryInfo(path);
                    if (!dir.Exists) dir.Create();
                    path = Path.Combine(path, "FOHManagement.v2.settings");
                    _SettingsFile = new FileInfo(path);
                }
                return _SettingsFile;
            }
        }

        private static void loadSettings() {
            if (SettingsFile.Exists) {
                using (StreamReader reader = new StreamReader(SettingsFile.OpenRead())) {
                    _Active = JsonConvert.DeserializeObject<Settingsv2>(reader.ReadToEnd());
                    reader.Close();
                }
            } else {
                Settings s = Settings.ActiveSettings;               // will load a v1 settings file if it is present
                _Active = new Settingsv2();                         // create an empty settings file....
                _Active.MarkThroughSeats = s.MarkOutSoldSeats;      // ... copy over existing settings (if found)...

                _Active.TryBooking.Username = s.TryBookingUsername;
                _Active.TryBooking.Password = s.TryBookingPassword;

                _Active.SMTP.SMTPServer = s.SMTP.SMTPServer;
                _Active.SMTP.SMTPPort = s.SMTP.SMTPPort;
                _Active.SMTP.Username = s.GMailUsername;
                _Active.SMTP.Password = s.GMailPassword;

                _Active.SenderAddress.Name = "FOH Management App";
                _Active.SenderAddress.EMail = s.SMTP.Username;                

                saveSettings();                                     // ... and make sure we save the new settings data
            }
        }

        public static bool hasExistingSettings() {
            return (SettingsFile.Exists);
        }

        public static void saveSettings() {
            if (_Active != null) {
                using (StreamWriter writer = new StreamWriter(SettingsFile.OpenWrite())) {
                    writer.WriteLine(JsonConvert.SerializeObject(_Active, Formatting.Indented));
                    writer.Flush();
                    writer.Close();
                }
            }
        }
    }
}