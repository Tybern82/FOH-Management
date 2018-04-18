using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FOHBackend.DoorList {
    public enum PageHeaderTypes {
        SessionTitle, ListTitle, SessionTime, CustomHeading, Unknown
    };

    public enum TableHeaderTypes {
        FirstName, LastName, FullName, FullNameSurnameFirst, ContactNumber, 
        TicketType, TicketPrice,
        PromotionCode, SeatNumber, HasFreeDrink,
        Checkmark
    };

    public enum FontStyle {
        MainHeading, SubHeading, TableHeading, BodyText
    };

    public class PageHeader {
        [JsonConverter(typeof(StringEnumConverter))] public PageHeaderTypes headingType { get; set; } = PageHeaderTypes.SessionTitle;
        [JsonConverter(typeof(StringEnumConverter))] public FontStyle fontSelect { get; set; } = FontStyle.MainHeading;
        public ushort index = 0;
    }

    public class TableHeader {
        [JsonConverter(typeof(StringEnumConverter))]    public TableHeaderTypes headingType { get; set; } = TableHeaderTypes.FullNameSurnameFirst;
        [JsonConverter(typeof(StringEnumConverter))]    public StringAlignment alignment { get; set; } = StringAlignment.Center;
                                                        public bool mergeWithFollowingHeader { get; set; } = false;

        private string _title;
        public string title {
            get {
                return (_title != null) ? _title : defaultTitle();
            }
            set {
                if (defaultTitle() == value) {
                    _title = null;
                } else {
                    _title = value;
                }
            }
        }

        public string defaultTitle() {
            switch (headingType) {
                case TableHeaderTypes.FirstName:
                case TableHeaderTypes.FullName:
                case TableHeaderTypes.FullNameSurnameFirst:
                case TableHeaderTypes.LastName:
                    return "Name";

                case TableHeaderTypes.ContactNumber:
                    return "Phone";

                case TableHeaderTypes.TicketType:
                    return "Ticket";

                case TableHeaderTypes.TicketPrice:
                    return "Price";

                case TableHeaderTypes.PromotionCode:
                    return "Promo";

                case TableHeaderTypes.SeatNumber:
                    return "Seat";

                case TableHeaderTypes.Checkmark:
                case TableHeaderTypes.HasFreeDrink:
                default:
                    return "";
            }
        }

        [JsonIgnore] public bool isCheckbox { get { return headingType == TableHeaderTypes.Checkmark; } }
        [JsonIgnore] public int requiredWidth { get; set; } = 0;
    }

    public class TableData {
        public TableElement[] items;
    }

    public class TableElement {
        public string text;
    }

    public class DoorListPrinterSettings {

        public static readonly string DEFAULT_CONFIG = "default";

        public static FileInfo getSettingsFile(string configName) {
            if (DEFAULT_CONFIG.Equals(configName)) return null;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            path = Path.Combine(path, "Jeff Sweeney - FOH Management");
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists) dir.Create();
            path = Path.Combine(path, configName + ".dlp");
            return new FileInfo(path);
        }

        public string ConfigName { get; set; }

        public List<PageHeader> pageHeaders { get; set; }    // defines a set of headings added to each page
        public List<string> customHeadings { get; set; }     // custom heading strings

        public List<TableHeader> tableHeaders { get; set; }  // list of headings for the table

        public Font mainHeadingFont { get; set; }
        public Font subHeadingFont { get; set; }
        public Font tableHeadingFont { get; set; }
        public Font textFont { get; set; }

        public DoorListPrinterSettings(string configName) {
            FileInfo fname = getSettingsFile(configName);
            this.ConfigName = configName;
            this.pageHeaders = new List<PageHeader>();
            this.customHeadings = new List<string>();
            this.tableHeaders = new List<TableHeader>();
            if ((fname == null) || (!fname.Exists)) {
                // generate a default config
                // Standard Page Headings
                pageHeaders.Add(new PageHeader() { headingType = PageHeaderTypes.SessionTitle, fontSelect = FontStyle.MainHeading });
                pageHeaders.Add(new PageHeader() { headingType = PageHeaderTypes.SessionTime, fontSelect = FontStyle.SubHeading });
                pageHeaders.Add(new PageHeader() { headingType = PageHeaderTypes.ListTitle, fontSelect = FontStyle.SubHeading });

                // Default Font Styles
                mainHeadingFont = new Font(FontFamily.GenericSerif, 14);
                subHeadingFont = new Font(FontFamily.GenericSerif, 12);
                tableHeadingFont = subHeadingFont;
                textFont = new Font(FontFamily.GenericSansSerif, 10);

                tableHeaders.Add(new TableHeader { headingType = TableHeaderTypes.FullNameSurnameFirst, alignment = StringAlignment.Near });
                tableHeaders.Add(new TableHeader { headingType = TableHeaderTypes.ContactNumber });
                tableHeaders.Add(new TableHeader { headingType = TableHeaderTypes.TicketType, mergeWithFollowingHeader = true });
                tableHeaders.Add(new TableHeader { headingType = TableHeaderTypes.TicketPrice, title = "" });
                tableHeaders.Add(new TableHeader { headingType = TableHeaderTypes.PromotionCode });
                tableHeaders.Add(new TableHeader { headingType = TableHeaderTypes.SeatNumber });
                tableHeaders.Add(new TableHeader { headingType = TableHeaderTypes.HasFreeDrink, mergeWithFollowingHeader = true });
                tableHeaders.Add(new TableHeader { headingType = TableHeaderTypes.Checkmark });
            } else {
                // load config from file
                using (StreamReader reader = new StreamReader(fname.OpenRead())) {
                    DoorListPrinterSettings _Loaded = JsonConvert.DeserializeObject<DoorListPrinterSettings>(reader.ReadToEnd());
                    copyFrom(_Loaded);
                    reader.Close();
                }
            }
        }

        public DoorListPrinterSettings() {
            this.ConfigName = "empty";
            this.pageHeaders = new List<PageHeader>();
            this.customHeadings = new List<string>();
            this.tableHeaders = new List<TableHeader>();
            mainHeadingFont = new Font(FontFamily.GenericSerif, 14);
            subHeadingFont = new Font(FontFamily.GenericSerif, 12);
            tableHeadingFont = subHeadingFont;
            textFont = new Font(FontFamily.GenericSansSerif, 10);
        }

        public void copyFrom(DoorListPrinterSettings settings) {
            this.ConfigName = settings.ConfigName;

            this.mainHeadingFont = settings.mainHeadingFont;
            this.subHeadingFont = settings.subHeadingFont;
            this.tableHeadingFont = settings.tableHeadingFont;
            this.textFont = settings.textFont;

            this.pageHeaders.Clear();
            this.pageHeaders.AddRange(settings.pageHeaders);

            this.customHeadings.Clear();
            this.customHeadings.AddRange(settings.customHeadings);

            this.tableHeaders.Clear();
            this.tableHeaders.AddRange(settings.tableHeaders);
        }

        public DoorListPrinterSettings copy() {
            DoorListPrinterSettings _result = new DoorListPrinterSettings();
            _result.copyFrom(this);
            return _result;
        }

        public bool saveSettings() {
            FileInfo fname = getSettingsFile(ConfigName);
            if (fname == null) {
                string name = FOHBackendCallbackManager.CallbackManager.doRequestString("What name would you like to call this configuration?", "mySettings");
                ConfigName = name;
                fname = getSettingsFile(ConfigName);
                if (fname == null) return false;
            }
            saveSettings(fname);
            return true;
        }

        public bool saveSettings(FileInfo fname) {
            if (fname == null) return false;
            using (StreamWriter writer = new StreamWriter(fname.OpenWrite())) {
                writer.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));
                writer.Close();
                return true;
            }
        }

        private static TableElement fdElement = new TableElement { text = "FD" };
        private static readonly TableElement emptyElement = new TableElement { text = "" };

        private TableElement getItem(DoorListEntry row, TableHeaderTypes type) {
            switch (type) {
                case TableHeaderTypes.ContactNumber:
                    return new TableElement { text = row.contactNumber };

                case TableHeaderTypes.FirstName:
                    return new TableElement { text = row.firstName };

                case TableHeaderTypes.FullName:
                    return new TableElement { text = row.firstName + " " + row.lastName };

                case TableHeaderTypes.FullNameSurnameFirst:
                    return new TableElement { text = row.lastName + ", " + row.firstName };

                case TableHeaderTypes.HasFreeDrink:
                    return row.promoCode.hasFreeDrink ? fdElement : emptyElement;

                case TableHeaderTypes.LastName:
                    return new TableElement { text = row.lastName };

                case TableHeaderTypes.PromotionCode:
                    return new TableElement { text = row.promoCode.promoCode };

                case TableHeaderTypes.SeatNumber:
                    return new TableElement { text = row.seat.ToString() };

                case TableHeaderTypes.TicketPrice:
                    return new TableElement { text = row.ticketPrice };

                case TableHeaderTypes.TicketType:
                    return new TableElement { text = TicketTypeHelper.getTicketTypeName(row.ticketType) };

                case TableHeaderTypes.Checkmark:
                default:
                    return emptyElement;
            }
        }

        public TableData[] populateData(List<DoorListEntry> doorList) {
            List<TableData> _result = new List<TableData>();
            TableElement fdElement = new TableElement { text = "FD" };

            foreach (DoorListEntry row in doorList) {
                List<TableElement> rowItems = new List<TableElement>();
                foreach (TableHeader hdr in tableHeaders) {
                    rowItems.Add(getItem(row, hdr.headingType));
                }
                _result.Add(new TableData {
                    items = rowItems.ToArray()
                });            
            }
            return _result.ToArray();
        }
    }
}
