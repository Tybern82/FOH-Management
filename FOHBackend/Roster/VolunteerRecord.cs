using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOHBackend.DoorList;
using Newtonsoft.Json;

namespace FOHBackend.Roster {

    public class VolunteerRecord {

        public static VolunteerRecord loadJSON(FileInfo fName) {
            if (fName.Exists) {
                StreamReader reader = new StreamReader(fName.OpenRead(), Encoding.UTF8);
                VolunteerRecord _result = JsonConvert.DeserializeObject<VolunteerRecord>(reader.ReadToEnd());
                reader.Close();
                return _result;
            } else {
                return null;
            }
        }

        public static List<VolunteerRecord> loadJSONList(FileInfo fName) {
            if (fName.Exists) {
                StreamReader reader = new StreamReader(fName.OpenRead(), Encoding.UTF8);
                VolunteerRecord[] _list = JsonConvert.DeserializeObject<VolunteerRecord[]>(reader.ReadToEnd());
                reader.Close();
                return new List<VolunteerRecord>(_list);
            } else {
                return new List<VolunteerRecord>();
            }
        }

        public static void storeJSONList(List<VolunteerRecord> items, FileInfo fName) {
            if (fName == null) return;
            else {
                StreamWriter writer = new StreamWriter(fName.OpenWrite(), Encoding.UTF8);
                writer.Write(JsonConvert.SerializeObject(items.ToArray(), Formatting.Indented));
                writer.Flush();
                writer.Close();
            }
        }

        public VolunteerRecord fromJSON(string text) {
            return JsonConvert.DeserializeObject<VolunteerRecord>(text);
        }

        public string toJSON() {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public void storeJSON(string fName) {
            storeJSON(new FileInfo(fName));
        }

        public void storeJSON(FileInfo fName) {            
            if (fName == null) return;
            else { 
                StreamWriter writer = new StreamWriter(fName.OpenWrite(), Encoding.UTF8);
                writer.Write(toJSON());
                writer.Flush();
                writer.Close();
            }
        }

        public override String ToString() {
            return String.Format("{0} - {1} - {2}", 
                Name, 
                EMail,
                String.IsNullOrWhiteSpace(HomePhone) ? Helper.formatPhone(MobilePhone) 
                : Helper.formatPhone(HomePhone) + (String.IsNullOrWhiteSpace(MobilePhone) ? "" : " / " + Helper.formatPhone(MobilePhone)));
        }

        public VolunteerRecord dup() {
            VolunteerRecord _result = new VolunteerRecord();
            copyTo(_result);
            return _result;
        }

        public void copyTo(VolunteerRecord rec) {
            rec.Name = Name;
            rec.EMail = EMail;
            rec.HomePhone = HomePhone;
            rec.MobilePhone = MobilePhone;

            rec.TicketSelling = TicketSelling;
            rec.Kitchen = Kitchen;
            rec.Bar = Bar;
            rec.Maintenance = Maintenance;

            rec.BlueCard = BlueCard;
            rec.RSA = RSA;
            rec.FHC = FHC;
            rec.FirstAid = FirstAid;

            rec.FridayMornings = FridayMornings;
            rec.FridayNight = FridayNight;
            rec.SaturdayMatinee = SaturdayMatinee;
            rec.SaturdayNight = SaturdayNight;
            rec.SundayMatinee = SundayMatinee;

            rec.Notes = new string[Notes.Length];
            Array.Copy(Notes, rec.Notes, Notes.Length);
        }

        // Basic Details
        public string Name { get; set; }
        public string EMail { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }

        // Preferred Areas
        public bool TicketSelling { get; set; } = false;
        public bool Kitchen { get; set; }       = false;
        public bool Bar { get; set; }           = false;
        public bool Maintenance { get; set; }   = false;

        // Certification
        public bool BlueCard { get; set; }  = false;
        public bool RSA { get; set; }       = false;
        public bool FHC { get; set; }       = false;
        public bool FirstAid { get; set; }  = false;

        // Preferred Hours
        public bool FridayMornings { get; set; }    = false;
        public bool FridayNight { get; set; }       = false;
        public bool SaturdayMatinee { get; set; }   = false;
        public bool SaturdayNight { get; set; }     = false;
        public bool SundayMatinee { get; set; }     = false;

        // Other
        public string[] Notes { get; set; } = new string[0];
    }
}
