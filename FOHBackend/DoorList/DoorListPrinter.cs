﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOHBackend.DoorList {
    public class DoorListPrinter : System.Drawing.Printing.PrintDocument {

        public static Font DefaultTitleFont = new Font(FontFamily.GenericSerif, 14);
        public static Font DefaultSubTitleFont = new Font(FontFamily.GenericSerif, 12);
        public static Font DefaultTextFont = new Font(FontFamily.GenericSansSerif, 10);

        int marginlessWidth {
            get {
                return (int)DefaultPageSettings.PrintableArea.Width;
            }
        }

        int marginlessHeight {
            get {
                return (int)DefaultPageSettings.PrintableArea.Height;
            }
        }

        int printableWidth {
            get {
                return (DefaultPageSettings.Landscape ? _downPage() : _acrossPage());
            }
        }

        int printableHeight {
            get {
                return (DefaultPageSettings.Landscape ? _acrossPage() : _downPage());
            }
        }

        int topMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Left : DefaultPageSettings.Margins.Top);
            }
        }

        int bottomMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Right : DefaultPageSettings.Margins.Bottom);
            }
        }

        int leftMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Bottom : DefaultPageSettings.Margins.Left);
            }
        }

        int rightMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Top : DefaultPageSettings.Margins.Right);
            }
        }

        int lineHeight { get { return bodyFont.Height; } }
        int headerLineHeight { get { return headerFont.Height; } }
        int subHeaderLineHeight { get { return subHeaderFont.Height; } }

        public Font bodyFont { get; set; } = DefaultTextFont;
        public Font headerFont { get; set; } = DefaultTitleFont;

        private Font _subHeaderFont = DefaultSubTitleFont;
        public Font subHeaderFont {
            get { return _subHeaderFont; }
            set {
                if (_subHeaderFont != value) {
                    _subHeaderFont = value;
                    // Mark the headers as needing recalculation
                    _NameHeaderWidth = -1;
                    _PhoneHeaderWidth = -1;
                    _TicketHeaderWidth = -1;
                    _PromoHeaderWidth = -1;
                    _SeatHeaderWidth = -1;
                }
            }
        }

        private int _NameHeaderWidth = -1;
        private int NameHeaderWidth {
            get {
                if (_NameHeaderWidth == -1) _NameHeaderWidth = TextRenderer.MeasureText(NameHeader, subHeaderFont, new Size(printableWidth, subHeaderLineHeight)).Width;
                return _NameHeaderWidth;
            }
        }

        private int _PhoneHeaderWidth = -1;
        private int PhoneHeaderWidth {
            get {
                if (_PhoneHeaderWidth == -1) _PhoneHeaderWidth = TextRenderer.MeasureText(PhoneHeader, subHeaderFont, new Size(printableWidth, subHeaderLineHeight)).Width;
                return _PhoneHeaderWidth;
            }
        }

        private int _TicketHeaderWidth = -1;
        private int TicketHeaderWidth {
            get {
                if (_TicketHeaderWidth == -1) _TicketHeaderWidth = TextRenderer.MeasureText(TicketHeader, subHeaderFont, new Size(printableWidth, subHeaderLineHeight)).Width;
                return _TicketHeaderWidth;
            }
        }

        private int _PromoHeaderWidth = -1;
        private int PromoHeaderWidth {
            get {
                if (_PromoHeaderWidth == -1) _PromoHeaderWidth = TextRenderer.MeasureText(PromoHeader, subHeaderFont, new Size(printableWidth, subHeaderLineHeight)).Width;
                return _PromoHeaderWidth;
            }
        }

        private int _SeatHeaderWidth = -1;
        private int SeatHeaderWidth {
            get {
                if (_SeatHeaderWidth == -1) _SeatHeaderWidth = TextRenderer.MeasureText(SeatHeader, subHeaderFont, new Size(printableWidth, subHeaderLineHeight)).Width;
                return _SeatHeaderWidth;
            }
        }

        private static readonly string NameHeader = "Name";
        private static readonly string PhoneHeader = "Phone";
        private static readonly string TicketHeader = "Ticket";
        private static readonly string PromoHeader = "Promo";
        private static readonly string SeatHeader = "Seat";

        /// <summary>
        /// Determines the required width to display the list of items under the current body font.
        /// </summary>
        /// <param name="g">Graphics context to use for calculating the widths</param>
        /// <param name="items">List of items being displayed</param>
        /// <returns>Minimum width required for this list to fully display, maximized by the printable width of the document</returns>
        public int requiredWidth(IEnumerable<string> items, int minWidth) {
            int width = minWidth;
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

        private int buffer = 5;

        protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs e) {
            base.OnBeginPrint(e);
            EnumerationGenerator gen = new EnumerationGenerator(doorList);
            firstNameWidth = requiredWidth(gen.firstNames, 0);
            int minWidth = Math.Max(0, NameHeaderWidth - firstNameWidth - buffer - buffer);
            lastNameWidth = requiredWidth(gen.lastNames, minWidth);

            minWidth = Math.Max(0, PhoneHeaderWidth - buffer);
            contactNumberWidth = requiredWidth(gen.contactNumbers, minWidth);

            ticketPriceWidth = requiredWidth(gen.ticketPrices, 0);
            minWidth = Math.Max(0, TicketHeaderWidth - buffer - buffer - ticketPriceWidth);
            ticketTypeWidth = requiredWidth(gen.ticketTypes, minWidth);

            minWidth = Math.Max(0, PromoHeaderWidth - buffer);
            promoCodeWidth = requiredWidth(gen.promoCodes, minWidth);

            minWidth = Math.Max(0, SeatHeaderWidth - buffer);
            seatWidth = requiredWidth(gen.seats, minWidth);

            freeDrinkWidth = TextRenderer.MeasureText(FreeDrinkText, bodyFont, new Size(printableWidth, lineHeight)).Width;

            currentRow = 0;     // reset to the first row
            currentPage = 0;    // reset to the first page
        }

        protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs e) {
            base.OnPrintPage(e);

            /*
            int leftMargin = this.leftMargin;
            int topMargin = this.topMargin;
            int printableWidth = this.printableWidth;
            int printableHeight = this.printableHeight;
            */

            RectangleF printableArea = DefaultPageSettings.PrintableArea;
            int minMargins = (DefaultTitleFont.Height * 2);
            int hardLeft = (int)Math.Round(printableArea.Left, MidpointRounding.AwayFromZero);
            int hardTop = (int)Math.Round(printableArea.Top, MidpointRounding.AwayFromZero);
            int hardRight = DefaultPageSettings.Bounds.Width - (int)Math.Round(printableArea.Right, MidpointRounding.AwayFromZero);
            int hardBottom = DefaultPageSettings.Bounds.Height - (int)Math.Round(printableArea.Bottom, MidpointRounding.AwayFromZero);

            int leftMargin = Math.Max(hardLeft, minMargins);
            int topMargin = Math.Max(hardTop, minMargins);

            int printableWidth = (int)printableArea.Width;
            if (hardLeft < minMargins) printableWidth -= (minMargins - hardLeft);
            if (hardRight < minMargins) printableWidth -= (minMargins - hardRight);

            int printableHeight = (int)printableArea.Height;
            if (hardTop < minMargins) printableHeight -= (minMargins - hardTop);
            if (hardBottom < minMargins) printableHeight -= (minMargins - hardBottom);
            
            int drawBorderAt = 4;
            int boxSize = bodyFont.Height * 2 / 3;
            int bufferDiff = buffer - drawBorderAt;
            
            string sessionTitle = (doorList.Count() > 0) ? doorList[0].eventName : "";
            string sessionTime = (doorList.Count() > 0) ? doorList[0].sessionTime.ToString("d-MMM-yyyy h:mm tt") : "";

            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox);

            Pen blackPen = new Pen(Brushes.Black, 1);

            RectangleF layoutRect;
            
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Near;

            layoutRect = new RectangleF(new PointF(leftMargin, topMargin), new SizeF(printableWidth, headerLineHeight));
            e.Graphics.DrawString(sessionTitle, headerFont, Brushes.Black, layoutRect, fmt);
            int h = headerLineHeight + buffer;
            topMargin += h;
            printableHeight -= h;

            layoutRect = new RectangleF(new PointF(leftMargin, topMargin), new SizeF(printableWidth, subHeaderLineHeight));
            e.Graphics.DrawString(sessionTime, subHeaderFont, Brushes.Black, layoutRect, fmt);
            h = subHeaderLineHeight + buffer;
            topMargin += h;
            printableHeight -= h;

            
            layoutRect = new RectangleF(new PointF(leftMargin, topMargin), new SizeF(printableWidth, subHeaderLineHeight));
            e.Graphics.DrawString(listTitle, subHeaderFont, Brushes.Black, layoutRect, fmt);
            h = subHeaderLineHeight + buffer;
            topMargin += h;
            printableHeight -= h;
            

            topMargin += buffer;
            printableHeight -= buffer;

            fmt.LineAlignment = StringAlignment.Far;
            layoutRect = new RectangleF(new PointF(leftMargin, topMargin), new SizeF(printableWidth, printableHeight));
            // fmt.Alignment = StringAlignment.Near;
            // e.Graphics.DrawString(sessionTime, subHeaderFont, Brushes.Black, layoutRect, fmt);
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

            fmt.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawLine(blackPen, leftMargin, topMargin - bufferDiff, leftMargin, topMargin + subHeaderLineHeight + drawBorderAt);
            fmt.Alignment = StringAlignment.Center;
            RectangleF box = new RectangleF(new PointF(leftMargin, topMargin), new SizeF(firstNameWidth+buffer+lastNameWidth+buffer, subHeaderLineHeight+buffer));
            e.Graphics.DrawString(NameHeader, subHeaderFont, Brushes.Black, box, fmt);
            float linePos = box.Left+firstNameWidth+lastNameWidth+buffer+buffer+drawBorderAt;
            e.Graphics.DrawLine(blackPen, linePos, topMargin - bufferDiff, linePos, topMargin + subHeaderLineHeight + drawBorderAt);

            box = new RectangleF(new PointF(linePos + bufferDiff, topMargin), new SizeF(contactNumberWidth + buffer, subHeaderLineHeight + buffer));
            e.Graphics.DrawString(PhoneHeader, subHeaderFont, Brushes.Black, box, fmt);
            linePos = box.Left + contactNumberWidth + drawBorderAt;
            e.Graphics.DrawLine(blackPen, linePos, topMargin - bufferDiff, linePos, topMargin + subHeaderLineHeight + drawBorderAt);

            box = new RectangleF(new PointF(linePos + bufferDiff, topMargin), new SizeF(ticketTypeWidth + buffer + ticketPriceWidth + buffer, subHeaderLineHeight + buffer));
            e.Graphics.DrawString(TicketHeader, subHeaderFont, Brushes.Black, box, fmt);
            linePos = box.Left + ticketTypeWidth + buffer + ticketPriceWidth + drawBorderAt;
            e.Graphics.DrawLine(blackPen, linePos, topMargin - bufferDiff, linePos, topMargin + subHeaderLineHeight + drawBorderAt);

            box = new RectangleF(new PointF(linePos + bufferDiff, topMargin), new SizeF(promoCodeWidth + buffer, subHeaderLineHeight + buffer));
            e.Graphics.DrawString(PromoHeader, subHeaderFont, Brushes.Black, box, fmt);
            linePos = box.Left + promoCodeWidth + drawBorderAt;
            e.Graphics.DrawLine(blackPen, linePos, topMargin - bufferDiff, linePos, topMargin + subHeaderLineHeight + drawBorderAt);

            box = new RectangleF(new PointF(linePos + bufferDiff, topMargin), new SizeF(seatWidth + buffer, subHeaderLineHeight + buffer));
            e.Graphics.DrawString(SeatHeader, subHeaderFont, Brushes.Black, box, fmt);
            linePos = box.Left + seatWidth + drawBorderAt;
            e.Graphics.DrawLine(blackPen, linePos, topMargin - bufferDiff, linePos, topMargin + subHeaderLineHeight + drawBorderAt);

            linePos = linePos + bufferDiff + freeDrinkWidth + buffer + buffer + buffer + boxSize;
            e.Graphics.DrawLine(blackPen, linePos, topMargin - bufferDiff, linePos, topMargin + subHeaderLineHeight + drawBorderAt);

            e.Graphics.DrawLine(blackPen, leftMargin, topMargin + subHeaderLineHeight + drawBorderAt, leftMargin + printableWidth, topMargin + subHeaderLineHeight + drawBorderAt);

            topMargin += subHeaderLineHeight + buffer;
            printableHeight -= subHeaderLineHeight + buffer;

            while ((currentRow < doorList.Count()) && (printableHeight > (lineHeight + buffer))) {
                DoorListEntry row = doorList[currentRow];

                fmt.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawLine(blackPen, leftMargin, topMargin-bufferDiff, leftMargin, topMargin + lineHeight + drawBorderAt);

                fmt.Alignment = StringAlignment.Near;
                box = new RectangleF(new PointF(leftMargin + buffer, topMargin), new SizeF(firstNameWidth + buffer, lineHeight + buffer));
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
