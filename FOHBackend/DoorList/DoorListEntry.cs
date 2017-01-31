using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;

namespace FOHBackend.DoorList {
    public enum TicketType {
        Adult, MemberConcession, Student
    }

    public struct PromotionCode {
        public string promoCode;
        public string promoName;
        public bool hasFreeDrink;

        public PromotionCode(string code, string name, bool freeDrink) {
            this.promoCode = code;
            this.promoName = (name == null) ? code : name;
            this.hasFreeDrink = freeDrink;
        }

        public PromotionCode(string code, string name) : this(code, name, false) {
            // TODO: Update to request free-drink status of unknown promo codes
            switch (code) {
                case "door":
                case "Comp1":
                case "Prepaid":
                case "":
                    hasFreeDrink = false;
                    break;

                default:
                    hasFreeDrink = true;
                    break;
            }
        }
    }

    public enum Seat {
        A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14,
        B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14,
        C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14,
        D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12, D13, D14,
        E1, E2, E3, E4, E5, E6, E7, E8, E9, E10, E11, E12, E13, E14,
        F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, F13, F14,
        G1, G2, G3, G4, G5, G6, G7, G8, G9, G10, G11, G12, G13, G14,
        H1, H2, H3, H4, H5, H6, H7, H8, H9, H10, H11, H12, H13, H14,
        I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14,
        J1, J2,
        XTD         // Used to record extra seats added for single performance or for performances outside ZPAC
    }

    public class DoorListEntry {
        // "Event Name","Session Date" (GMT+10:00),"Session Time",
        // "Booking First Name","Booking Last Name","Booking Telephone",
        // "Ticket Type","Ticket Price" (AUD),
        // Promotion[Discount] Code,
        // "Seat Row","Seat Number",

        public string eventName { get;  set; }
        public DateTime sessionTime { get;  set; }
        
        public string firstName { get;  set; }
        public string lastName { get;  set; }
        public string contactNumber { get;  set; }

        public TicketType ticketType { get;  set; }
        public CurrencyAUD ticketPrice { get;  set; }
        
        public PromotionCode promoCode { get;  set; }

        public Seat seat { get { return Helper.getSeat(seatRow, seatNumber); } }
        public string seatRow { get;  set; }
        public string seatNumber { get;  set; }

        public override String ToString() {
            return firstName + " " + lastName + "\n" +
                    contactNumber + "\n" +
                    eventName + " @ " + sessionTime + " [" + seat + "]" + "\n" +
                    ticketType + " [" + promoCode.promoName + "] = " + ticketPrice;
        }
    }

    public class Helper {
        public static void printDoorLists(List<DoorListEntry> list) {
            DoorListPrinter printer = new DoorListPrinter();            

            printer.listTitle = "Door List by Surname";
            printer.doorList = sortByName(list);
            printer.Print();

            printer.listTitle = "Door List by Seat";
            printer.doorList = sortBySeat(list);
            printer.Print();
        }

        public static void preloadPromotionCodes() {
            // TODO: Store the preloaded promotion codes
            PromotionCode code;
            code = new PromotionCode("door", "Pay at Door");
            code = new PromotionCode("Comp1", "Complimentary Ticket");
            code = new PromotionCode("zpac100", "ZPac Member Ticket");
            code = new PromotionCode("GIFT201", "Gift Certificate");
            code = new PromotionCode("BNIGIFT2015", "Gift Certificate BNI Members");
            code = new PromotionCode("SK2015", "Storage King Comp Tickets");
            code = new PromotionCode("CHS2015", "Campbell Hearing Solutions");
            code = new PromotionCode("Prepaid", "Prepaid");
            code = new PromotionCode("SCAGIFT", "Southern Cross Gift");
            code = new PromotionCode("GPSGIFT", "Guaranteed Plumbing Solutions");
        }

        public static Seat getSeat(string row, string number) {
            string enumID = row + number;
            Seat _result = Seat.XTD;
            try {
                _result = (Seat)Enum.Parse(typeof(Seat), "" + row + number, true);
                if (!Enum.IsDefined(typeof(Seat), _result)) _result = Seat.XTD;
            } catch (ArgumentException) {
                _result = Seat.XTD;
            }
            return _result;
        }

        public static TicketType getTicketType(string name) {
            switch (name) {
                case "Member/Concession":   return TicketType.MemberConcession;
                case "Student":             return TicketType.Student;
                default:                    return TicketType.Adult;
            }
        }

        public static string getTicketTypeName(TicketType t) {
            switch (t) {
                case TicketType.Adult: return "Adult";
                case TicketType.Student: return "Student";
                case TicketType.MemberConcession: return "Member/Conc";
                default: return "";
            }
        }

        public static List<DoorListEntry> sortByName(IEnumerable<DoorListEntry> lst) {
            SortedList<string, List<DoorListEntry>> sList = new SortedList<string, List<DoorListEntry>>(lst.Count());
            foreach (DoorListEntry d in lst) {
                string key = d.lastName + ", " + d.firstName;
                if (sList.ContainsKey(key)) {
                    List<DoorListEntry> v = sList[key];
                    v.Add(d);
                } else {
                    sList.Add(key, new List<DoorListEntry>(new DoorListEntry[] { d }));
                }
            }
            List<DoorListEntry> _result = new List<DoorListEntry>(lst.Count());
            foreach (List<DoorListEntry> i in sList.Values) {
                if (i.Count() == 1) {
                    _result.Add(i[0]);
                } else if (i.Count() > 1) {
                    foreach (DoorListEntry d in sortBySeat(i)) _result.Add(d);
                }
            }
            return _result;
        }

        public static List<DoorListEntry> sortBySeat(IEnumerable<DoorListEntry> lst) {
            SortedList<Seat, DoorListEntry> sList = new SortedList<Seat, DoorListEntry>(lst.Count());
            foreach (DoorListEntry d in lst) {
                sList.Add(d.seat, d);
            }
            return sList.Values.ToList();
        }

        public static List<DoorListEntry> loadCSV(string fname) {
            List<DoorListEntry> _result = new List<DoorListEntry>();
            using (CsvReader reader = new CsvReader(new StreamReader(fname),false)) {

                // foreach (string s in reader.GetFieldHeaders()) Console.WriteLine("[" + s + "]");

                int eventNameI = 0;     // reader.GetFieldIndex("Event Name");
                int sessionDateI = 1;   // reader.GetFieldIndex("Session Date");
                int sessionTimeI = 2;   // reader.GetFieldIndex("Session Time");

                int firstNameI = 3;     // reader.GetFieldIndex("Booking First Name");
                int lastNameI = 4;      // reader.GetFieldIndex("Booking Last Name");
                int contactNumberI = 5; // reader.GetFieldIndex("Booking Telephone");

                int ticketTypeI = 6;    // reader.GetFieldIndex("Ticket Type");
                int ticketPriceI = 7;   // reader.GetFieldIndex("Ticket Price");

                int promoCodeI = 8;     // reader.GetFieldIndex("Promotion[Discount] Code");

                int seatRowI = 9;       // reader.GetFieldIndex("Seat Row");
                int seatNumberI = 10;   // reader.GetFieldIndex("Seat Number");

                while (reader.ReadNextRecord()) {
                    DoorListEntry entry = new DoorListEntry();

                    entry.eventName = reader[eventNameI];
                    DateTime d = DateTime.Parse(reader[sessionDateI]);
                    DateTime t = DateTime.Parse(reader[sessionTimeI]);
                    entry.sessionTime = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second, DateTimeKind.Local);

                    entry.firstName = reader[firstNameI];
                    entry.lastName = reader[lastNameI];
                    entry.contactNumber = reader[contactNumberI];

                    entry.ticketType = getTicketType(reader[ticketTypeI]);
                    entry.ticketPrice = (CurrencyAUD)("$" + reader[ticketPriceI]);

                    entry.promoCode = new PromotionCode(reader[promoCodeI], null);    // TODO: Lookup promotion codes

                    entry.seatRow = reader[seatRowI];
                    if (entry.seatRow == "I-") entry.seatRow = "I";     // TODO: Fix the TryBooking name....
                    entry.seatNumber = reader[seatNumberI];

                    _result.Add(entry);
                }
            }
            return _result;
        }
    }
}