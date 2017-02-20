using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string getJSON() {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public void storeJSON(string fName) {
            storeJSON(new FileInfo(fName));
        }

        public void storeJSON(FileInfo fName) {            
            if (fName == null) return;
            else { 
                StreamWriter writer = new StreamWriter(fName.OpenWrite(), Encoding.UTF8);
                writer.Write(getJSON());
                writer.Flush();
                writer.Close();
            }
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
