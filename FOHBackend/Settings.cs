using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using FOHBackend.Mail;
using FOHBackend.DoorList;

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

        public static readonly string DefaultSettingFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FOHManagement.settings");

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
        public string SMTPServer { get; set; } = "mail.zpactheatre.com";
        public UInt16 SMTPPort { get; set; } = 465;
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

        public bool MarkThroughSeats { get; set; } = false;


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

        public void copyFrom(Settings s) {
            this.MarkThroughSeats = s.MarkOutSoldSeats;

            this.TryBooking.Username = s.TryBookingUsername;
            this.TryBooking.Password = s.TryBookingPassword;

            this.SMTP.SMTPServer = s.SMTP.SMTPServer;
            this.SMTP.SMTPPort = s.SMTP.SMTPPort;
            this.SMTP.Username = s.GMailUsername;
            this.SMTP.Password = s.GMailPassword;

            this.SenderAddress.Name = "FOH Management App";
            this.SenderAddress.EMail = s.SMTP.Username;
        }
        
        public static Settingsv2 Active {
            get {
                return SettingsLoader.Active;
            }
        }
    }

    public class Settingsv3 : Settingsv2 {

        public new static Settingsv3 Active {
            get {
                return SettingsLoader.Active;
            }
        }

        public string DLPConfig { get; set; }

        private DoorListPrinterSettings _doorListPrinterSettings = null;
        [JsonIgnore] public DoorListPrinterSettings DoorListPrintSettings {
            get {
                if (_doorListPrinterSettings == null) _doorListPrinterSettings = new DoorListPrinterSettings(DLPConfig);
                return _doorListPrinterSettings;
            }
        }

        public Settingsv3() : base() {
            this.DLPConfig = DoorListPrinterSettings.DEFAULT_CONFIG;
        }

        public Settingsv3(Settingsv2 oldSettings) : this() {
            copyFrom(oldSettings);
        }

        public new Settingsv3 copy() {
            Settingsv3 _result = new Settingsv3();
            _result.copyFrom(this);
            return _result;
        }

        public void copyFrom(Settingsv3 s) {
            base.copyFrom(s);
            DLPConfig = s.DLPConfig;
        }
    }

    public class SettingsLoader {

        private static readonly string AppSettingsFolder = "Jeff Sweeney - FOH Management";
        private static readonly string SettingsFilev2 = "FOHManagement.v2.settings";
        private static readonly string SettingsFilev3 = "FOHManagement.v3.settings";

        public static DirectoryInfo SettingsFolder {
            get {
                // TODO: Update to use UICallback to get the base path
                string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                path = Path.Combine(path, AppSettingsFolder);
                DirectoryInfo _result = new DirectoryInfo(path);
                if (!_result.Exists) _result.Create();
                return _result;
            }
        }

        private static Settingsv3 _Active = null;
        public static Settingsv3 Active {
            get {
                if (_Active == null) loadSettings();
                return _Active;
            }
        }

        private static FileInfo getSettings(string settingsFile) {
            return new FileInfo(Path.Combine(SettingsFolder.FullName, settingsFile));
        }

        private static void loadSettings() {
            FileInfo settingsFile = getSettings(SettingsFilev3);
            if (settingsFile.Exists) {
                // Load v3 settings
                using (StreamReader reader = new StreamReader(settingsFile.OpenRead())) {
                    _Active = JsonConvert.DeserializeObject<Settingsv3>(reader.ReadToEnd());
                    reader.Close();
                }
                return;
            }
            settingsFile = getSettings(SettingsFilev2);
            if (settingsFile.Exists) {
                // Load v2 settings
                using (StreamReader reader = new StreamReader(settingsFile.OpenRead())) {
                    Settingsv2 _oldSettings = JsonConvert.DeserializeObject<Settingsv2>(reader.ReadToEnd());
                    reader.Close();
                    // Trigger a settings check for the update, since new default settings may have been added
                    _Active = FOHBackendCallbackManager.CallbackManager.triggerInitialSettings(new Settingsv3(_oldSettings));
                }
                saveSettings(); // make sure the newly loaded settings are saved
                return;
            }
            _Active = FOHBackendCallbackManager.CallbackManager.triggerInitialSettings(new Settingsv3());   // create a new default settings file...
            saveSettings();                                                                                 // ... and make sure it is saved for future use
        }

        public static void saveSettings() {
            if (_Active != null) {
                FileInfo settingsFile = getSettings(SettingsFilev3);
                using (StreamWriter writer = new StreamWriter(settingsFile.OpenWrite())) {
                    writer.WriteLine(JsonConvert.SerializeObject(_Active, Formatting.Indented));
                    writer.Flush();
                    writer.Close();
                }
            }
        }
    }
}