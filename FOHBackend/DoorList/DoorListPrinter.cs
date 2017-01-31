using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOHBackend.DoorList {
    public class DoorListPrinter : System.Drawing.Printing.PrintDocument {

        public static Font DefaultTextFont = new Font(FontFamily.GenericSansSerif, 10);
        public static Font DefaultTitleFont = new Font(FontFamily.GenericSerif, 14);
        public static Font DefaultSubTitleFont = new Font(FontFamily.GenericSerif, 12);

        public int marginlessWidth {
            get {
                return (int)DefaultPageSettings.PrintableArea.Width;
            }
        }

        public int marginlessHeight {
            get {
                return (int)DefaultPageSettings.PrintableArea.Height;
            }
        }

        public int printableWidth {
            get {
                return (DefaultPageSettings.Landscape ? _downPage() : _acrossPage());
            }
        }

        public int printableHeight {
            get {
                return (DefaultPageSettings.Landscape ? _acrossPage() : _downPage());
            }
        }

        public int topMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Left : DefaultPageSettings.Margins.Top);
            }
        }

        public int bottomMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Right : DefaultPageSettings.Margins.Bottom);
            }
        }

        public int leftMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Bottom : DefaultPageSettings.Margins.Left);
            }
        }

        public int rightMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Top : DefaultPageSettings.Margins.Right);
            }
        }

        public int lineHeight { get { return bodyFont.Height; } }
        public int headerLineHeight { get { return headerFont.Height; } }
        public int subHeaderLineHeight { get { return subHeaderFont.Height; } }

        public Font bodyFont { get; set; } = DefaultTextFont;
        public Font headerFont { get; set; } = DefaultTitleFont;
        public Font subHeaderFont { get; set; } = DefaultSubTitleFont;

        /// <summary>
        /// Determines the required width to display the list of items under the current body font.
        /// </summary>
        /// <param name="g">Graphics context to use for calculating the widths</param>
        /// <param name="items">List of items being displayed</param>
        /// <returns>Minimum width required for this list to fully display, maximized by the printable width of the document</returns>
        public int requiredWidth(IEnumerable<string> items) {
            int width = 0;
            StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.LineLimit);
            HashSet<string> uniqueItems = new HashSet<string>(items);
            foreach (string item in uniqueItems) {
                Size sz = TextRenderer.MeasureText(item, bodyFont, new Size(printableWidth, lineHeight));
                width = Math.Max(width, sz.Width);
            }
            return width;
        }

        public string listTitle { get; set; }
        public List<DoorListEntry> doorList { get; set; } = new List<DoorListEntry>();

        static string FreeDrinkText = "FD";

        int firstNameWidth { get; set; }
        int lastNameWidth { get; set; }
        int contactNumberWidth { get; set; }
        int ticketTypeWidth { get; set; }
        int ticketPriceWidth { get; set; }
        int promoCodeWidth { get; set; }
        int seatWidth { get; set; }
        int freeDrinkWidth { get; set; }

        private int currentRow;
        private int currentPage;

        protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs e) {
            base.OnBeginPrint(e);
            EnumerationGenerator gen = new EnumerationGenerator(doorList);
            firstNameWidth = requiredWidth(gen.firstNames);
            lastNameWidth = requiredWidth(gen.lastNames);
            contactNumberWidth = requiredWidth(gen.contactNumbers);
            ticketTypeWidth = requiredWidth(gen.ticketTypes);
            ticketPriceWidth = requiredWidth(gen.ticketPrices);
            promoCodeWidth = requiredWidth(gen.promoCodes);
            seatWidth = requiredWidth(gen.seats);
            freeDrinkWidth = TextRenderer.MeasureText(FreeDrinkText, bodyFont, new Size(printableWidth, lineHeight)).Width;

            currentRow = 0;     // reset to the first row
            currentPage = 0;    // reset to the first page
        }

        protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs e) {
            base.OnPrintPage(e);

            int leftMargin = this.leftMargin;
            int topMargin = this.topMargin;
            int printableWidth = this.printableWidth;
            int printableHeight = this.printableHeight;

            int buffer = 5;
            int drawBorderAt = 4;
            int boxSize = bodyFont.Height * 2 / 3;
            int bufferDiff = buffer - drawBorderAt;
            
            string sessionTitle = (doorList.Count() > 0) ? doorList[0].eventName : "";
            string sessionTime = (doorList.Count() > 0) ? doorList[0].sessionTime.ToString("d-MMM-yyyy h:mm tt") : "";

            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox);

            Pen blackPen = new Pen(Brushes.Black, 1);

            RectangleF layoutRect;

            // if (currentPage == 0) {
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Near;
            layoutRect = new RectangleF(new PointF(leftMargin, topMargin), new SizeF(printableWidth, headerLineHeight));
            int h = headerLineHeight + buffer;
            topMargin += h;
            printableHeight -= h;
            e.Graphics.DrawString(sessionTitle, headerFont, Brushes.Black, layoutRect, fmt);
            layoutRect = new RectangleF(new PointF(leftMargin, topMargin), new SizeF(printableWidth, subHeaderLineHeight));
            e.Graphics.DrawString(sessionTime, subHeaderFont, Brushes.Black, layoutRect, fmt);
            h = subHeaderLineHeight + buffer * 2;
            topMargin += h;
            printableHeight -= h;
            // }

            fmt.Alignment = StringAlignment.Near;
            fmt.LineAlignment = StringAlignment.Far;
            layoutRect = new RectangleF(new PointF(leftMargin, topMargin), new SizeF(printableWidth, printableHeight));
            e.Graphics.DrawString(listTitle, subHeaderFont, Brushes.Black, layoutRect, fmt);
            fmt.Alignment = StringAlignment.Far;
            e.Graphics.DrawString("Page " + (currentPage + 1), subHeaderFont, Brushes.Black, layoutRect, fmt);
            printableHeight -= subHeaderLineHeight + buffer;

            int tableWidth = firstNameWidth + lastNameWidth + contactNumberWidth + ticketTypeWidth + ticketPriceWidth + promoCodeWidth + seatWidth + freeDrinkWidth + boxSize + (buffer * 11);
            if (tableWidth < printableWidth) leftMargin += (printableWidth - tableWidth) / 2;
            printableWidth = Math.Min(printableWidth, tableWidth);

            e.Graphics.DrawLine(blackPen, leftMargin, topMargin, leftMargin + printableWidth, topMargin);
            topMargin += buffer - drawBorderAt;
            printableHeight -= buffer;
            
            // TODO: Need to print table headers

            while ((currentRow < doorList.Count()) && (printableHeight > (lineHeight + buffer))) {
                DoorListEntry row = doorList[currentRow];

                fmt.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawLine(blackPen, leftMargin, topMargin-bufferDiff, leftMargin, topMargin + lineHeight + drawBorderAt);

                fmt.Alignment = StringAlignment.Near;
                RectangleF box = new RectangleF(new PointF(leftMargin + buffer, topMargin), new SizeF(firstNameWidth + buffer, lineHeight + buffer));
                e.Graphics.DrawString(row.firstName, bodyFont, Brushes.Black, box, fmt);
                e.Graphics.DrawLine(blackPen, box.Left + firstNameWidth + drawBorderAt, topMargin-bufferDiff, box.Left + firstNameWidth + drawBorderAt, topMargin + lineHeight + drawBorderAt);

                fmt.Alignment = StringAlignment.Near;
                box = new RectangleF(new PointF(box.Left + firstNameWidth + buffer, topMargin), new SizeF(lastNameWidth + buffer, lineHeight + buffer));
                e.Graphics.DrawString(row.lastName, bodyFont, Brushes.Black, box, fmt);
                e.Graphics.DrawLine(blackPen, box.Left + lastNameWidth + drawBorderAt, topMargin - bufferDiff, box.Left + lastNameWidth + drawBorderAt, topMargin + lineHeight + drawBorderAt);

                fmt.Alignment = StringAlignment.Center;
                box = new RectangleF(new PointF(box.Left + lastNameWidth + buffer, topMargin), new SizeF(contactNumberWidth + buffer, lineHeight + buffer));
                e.Graphics.DrawString(row.contactNumber, bodyFont, Brushes.Black, box, fmt);
                e.Graphics.DrawLine(blackPen, box.Left + contactNumberWidth + drawBorderAt, topMargin - bufferDiff, box.Left + contactNumberWidth + drawBorderAt, topMargin + lineHeight + drawBorderAt);

                fmt.Alignment = StringAlignment.Center;
                box = new RectangleF(new PointF(box.Left + contactNumberWidth + buffer, topMargin), new SizeF(ticketTypeWidth + buffer, lineHeight + buffer));
                e.Graphics.DrawString(Helper.getTicketTypeName(row.ticketType), bodyFont, Brushes.Black, box, fmt);
                e.Graphics.DrawLine(blackPen, box.Left + ticketTypeWidth + drawBorderAt, topMargin - bufferDiff, box.Left + ticketTypeWidth + drawBorderAt, topMargin + lineHeight + drawBorderAt);

                fmt.Alignment = StringAlignment.Center;
                box = new RectangleF(new PointF(box.Left + ticketTypeWidth+buffer, topMargin), new SizeF(ticketPriceWidth + buffer, lineHeight + buffer));
                e.Graphics.DrawString(row.ticketPrice, bodyFont, Brushes.Black, box, fmt);
                e.Graphics.DrawLine(blackPen, box.Left + ticketPriceWidth + drawBorderAt, topMargin - bufferDiff, box.Left + ticketPriceWidth + drawBorderAt, topMargin + lineHeight + drawBorderAt);

                fmt.Alignment = StringAlignment.Center;
                box = new RectangleF(new PointF(box.Left + ticketPriceWidth + buffer, topMargin), new SizeF(promoCodeWidth + buffer, lineHeight + buffer));
                e.Graphics.DrawString(row.promoCode.promoCode, bodyFont, Brushes.Black, box, fmt);
                e.Graphics.DrawLine(blackPen, box.Left + promoCodeWidth + drawBorderAt, topMargin - bufferDiff, box.Left + promoCodeWidth + drawBorderAt, topMargin + lineHeight + drawBorderAt);

                fmt.Alignment = StringAlignment.Center;
                box = new RectangleF(new PointF(box.Left + promoCodeWidth + buffer, topMargin), new SizeF(seatWidth + buffer, lineHeight + buffer));
                e.Graphics.DrawString(row.seat.ToString(), bodyFont, Brushes.Black, box, fmt);
                e.Graphics.DrawLine(blackPen, box.Left + seatWidth + drawBorderAt, topMargin - bufferDiff, box.Left + seatWidth + drawBorderAt, topMargin + lineHeight + drawBorderAt);

                fmt.Alignment = StringAlignment.Center;
                box = new RectangleF(new PointF(box.Left + seatWidth + buffer, topMargin), new SizeF(freeDrinkWidth + buffer, lineHeight + buffer));
                if (row.promoCode.hasFreeDrink) e.Graphics.DrawString(FreeDrinkText, bodyFont, Brushes.Black, box, fmt);
                e.Graphics.DrawLine(blackPen, box.Left + freeDrinkWidth + drawBorderAt, topMargin - bufferDiff, box.Left + freeDrinkWidth + drawBorderAt, topMargin + lineHeight + drawBorderAt);
                
                float leftPosition = box.Left + freeDrinkWidth + buffer + buffer;
                e.Graphics.DrawRectangle(blackPen, leftPosition, topMargin + ((lineHeight + buffer - boxSize) / 2), boxSize, boxSize);
                e.Graphics.DrawLine(blackPen, leftPosition + buffer + boxSize, topMargin - bufferDiff, leftPosition + buffer + boxSize, topMargin + lineHeight + drawBorderAt);

                e.Graphics.DrawLine(blackPen, leftMargin, topMargin + lineHeight + drawBorderAt, leftMargin + printableWidth, topMargin + lineHeight + drawBorderAt);

                topMargin += lineHeight + buffer;
                printableHeight -= lineHeight + buffer;
                currentRow++;
            }

            currentPage++;
            e.HasMorePages = (currentRow < doorList.Count);
        }


        private int _acrossPage() {
            return DefaultPageSettings.PaperSize.Width - DefaultPageSettings.Margins.Left - DefaultPageSettings.Margins.Right;
        }

        private int _downPage() {
            return DefaultPageSettings.PaperSize.Height - DefaultPageSettings.Margins.Top - DefaultPageSettings.Margins.Bottom;
        }
    }
    
    class EnumerationGenerator {
        private List<DoorListEntry> doorList;

        public EnumerationGenerator(List<DoorListEntry> dList) {
            this.doorList = dList;
        }

        public IEnumerable<string> firstNames { get { foreach (DoorListEntry d in doorList) yield return d.firstName; } }
        public IEnumerable<string> lastNames { get { foreach (DoorListEntry d in doorList) yield return d.lastName; } }
        public IEnumerable<string> contactNumbers { get { foreach (DoorListEntry d in doorList) yield return d.contactNumber; } }
        public IEnumerable<string> ticketTypes { get { foreach (DoorListEntry d in doorList) yield return Helper.getTicketTypeName(d.ticketType); } }
        public IEnumerable<string> ticketPrices { get { foreach (DoorListEntry d in doorList) yield return d.ticketPrice.ToString(); } }
        public IEnumerable<string> promoCodes { get { foreach (DoorListEntry d in doorList) yield return d.promoCode.promoCode; } } // TODO: promoName?
        public IEnumerable<string> seats { get { foreach (DoorListEntry d in doorList) yield return d.seat.ToString(); } }
    }
}
