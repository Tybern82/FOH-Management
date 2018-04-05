using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOHBackend.DoorList {
    public abstract class BasePrinter : System.Drawing.Printing.PrintDocument {

        protected int buffer = 5;

        public static Font DefaultTitleFont = new Font(FontFamily.GenericSerif, 14);
        public static Font DefaultSubTitleFont = new Font(FontFamily.GenericSerif, 12);
        public static Font DefaultTextFont = new Font(FontFamily.GenericSansSerif, 10);

        protected int marginlessWidth {
            get {
                return (int)DefaultPageSettings.PrintableArea.Width;
            }
        }

        protected int marginlessHeight {
            get {
                return (int)DefaultPageSettings.PrintableArea.Height;
            }
        }

        protected int printableWidth {
            get {
                return (DefaultPageSettings.Landscape ? _downPage() : _acrossPage());
            }
        }

        protected int printableHeight {
            get {
                return (DefaultPageSettings.Landscape ? _acrossPage() : _downPage());
            }
        }

        protected int topMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Left : DefaultPageSettings.Margins.Top);
            }
        }

        protected int bottomMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Right : DefaultPageSettings.Margins.Bottom);
            }
        }

        protected int leftMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Bottom : DefaultPageSettings.Margins.Left);
            }
        }

        protected int rightMargin {
            get {
                return (DefaultPageSettings.Landscape ? DefaultPageSettings.Margins.Top : DefaultPageSettings.Margins.Right);
            }
        }

        protected int lineHeight { get { return bodyFont.Height; } }
        protected int headerLineHeight { get { return headerFont.Height; } }
        protected int subHeaderLineHeight { get { return subHeaderFont.Height; } }

        private Font _bodyFont = DefaultTextFont;
        public Font bodyFont {
            get { return _bodyFont; }
            set {
                if (OnBodyFontChange != null) OnBodyFontChange.Invoke(this, new FontChangeEventArgs(_bodyFont, value));
                _bodyFont = value;
            }
        }

        private Font _headerFont = DefaultTitleFont;
        public Font headerFont {
            get { return _headerFont; }
            set {
                if (OnHeaderFontChange != null) OnHeaderFontChange.Invoke(this, new FontChangeEventArgs(_headerFont, value));
                _headerFont = value;
            }
        }

        private Font _subHeaderFont = DefaultSubTitleFont;
        public Font subHeaderFont {
            get { return _subHeaderFont; }
            set {
                if (OnSubHeaderFontChange != null) OnSubHeaderFontChange.Invoke(this, new FontChangeEventArgs(_subHeaderFont, value));
                _subHeaderFont = value;
            }
        }

        protected delegate void OnFontChange(object sender, FontChangeEventArgs e);

        protected event OnFontChange OnBodyFontChange;
        protected event OnFontChange OnHeaderFontChange;
        protected event OnFontChange OnSubHeaderFontChange;

        protected class FontChangeEventArgs : EventArgs {
            public Font previousFont { get; set; }
            public Font currentFont { get; set; }

            public FontChangeEventArgs(Font previous, Font nFont) {
                this.previousFont = previous;
                this.currentFont = nFont;
            }
        }

        /// <summary>
        /// Determines the required width to display the list of items under the current body font.
        /// </summary>
        /// <param name="g">Graphics context to use for calculating the widths</param>
        /// <param name="items">List of items being displayed</param>
        /// <returns>Minimum width required for this list to fully display, maximized by the printable width of the document</returns>
        public int requiredWidth(IEnumerable<string> items, int minWidth) {
            Graphics g = PrinterSettings.CreateMeasurementGraphics();
            return requiredWidth(items, g, minWidth);
        }

        public int requiredWidth(IEnumerable<string> items, string header, int minWidth) {
            Graphics g = PrinterSettings.CreateMeasurementGraphics();
            SizeF sz = g.MeasureString(header, subHeaderFont, new Size(printableWidth, subHeaderLineHeight));
            minWidth = Math.Max(minWidth, (int)Math.Round(sz.Width, MidpointRounding.AwayFromZero));
            return requiredWidth(items, g, minWidth);
        }

        private int requiredWidth(IEnumerable<string> items, Graphics g, int minWidth) {
            int width = minWidth;
            StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.LineLimit);
            HashSet<string> uniqueItems = new HashSet<string>(items);
            foreach (string item in uniqueItems) {
                SizeF sz = g.MeasureString(item, bodyFont, new Size(printableWidth, lineHeight));
                width = Math.Max(width, (int)Math.Round(sz.Width, MidpointRounding.AwayFromZero));
            }
            return width;
        }


        private int _acrossPage() {
            return DefaultPageSettings.PaperSize.Width - DefaultPageSettings.Margins.Left - DefaultPageSettings.Margins.Right;
        }

        private int _downPage() {
            return DefaultPageSettings.PaperSize.Height - DefaultPageSettings.Margins.Top - DefaultPageSettings.Margins.Bottom;
        }

        protected Rectangle addMargin(Rectangle r, int margin) {
            return new Rectangle(r.Left + margin, r.Top + margin, r.Width - (margin * 2), r.Height - (margin * 2));
        }

        /// <summary>
        /// Helper method for table construction. 
        /// </summary>
        /// <param name="boxHeight">Height of each cell in the table</param>
        /// <param name="boxWidth">Width of each cell in the table</param>
        /// <param name="topMargin">Top position of the table</param>
        /// <param name="leftMargin">Left position of the table</param>
        /// <param name="row">Row in the table for top left of area</param>
        /// <param name="column">Column in the table for top left of area</param>
        /// <param name="width">Number of columns area spans</param>
        /// <param name="height">Number of rows area spans</param>
        /// <returns>Graphics rectangle defining an area coverering these cells</returns>
        protected Rectangle getArea(int boxHeight, int boxWidth, int topMargin, int leftMargin, int row, int column, int width, int height) {
            return new Rectangle(leftMargin + (column * boxWidth), topMargin + (row * boxHeight), boxWidth * width, boxHeight * height);
        }

        protected class TableHeader {
            public string name;
            public StringAlignment alignment = StringAlignment.Center;
            public bool isCheckbox = false;
            public bool mergeWithFollowing = false;
            public int requiredWidth = 0;
        }

        protected class TableData {
            public TableElement[] items;
        }

        protected class TableElement {
            public string text;
        }

        protected static readonly TableElement EMPTY_TABLE_ELEMENT = new TableElement { text = "" };

        protected class EnumerationGenerator {
            private TableData[] tdata;

            public EnumerationGenerator(TableData[] tdata) {
                this.tdata = tdata;
            }

            public IEnumerable<string> getColumn(int i) {
                foreach (TableData td in tdata) {
                    yield return td.items[i].text;
                }
            }
        }

        private void calculateSizes(TableHeader[] headers, TableData[] data) {
            EnumerationGenerator gen = new EnumerationGenerator(data);
            int boxSize = (bodyFont.Height * 2 / 3) + buffer;
            for (int x = 0; x < headers.Length; x++) {
                headers[x].requiredWidth = requiredWidth(gen.getColumn(x), headers[x].name, headers[x].isCheckbox ? boxSize : 0);
            }
        }

        protected int printTable(Graphics g, int leftMargin, int topMargin, int printableWidth, int printableHeight, TableHeader[] headers, TableData[] data, int currentRow) {
            if (data.Length != 0) {
                if (headers.Length != data[0].items.Length) throw new IndexOutOfRangeException("Mismatch between number of headers and entries in the table.");
            }
            int drawBorderAt = 4;
            int boxSize = bodyFont.Height * 2 / 3;
            int bufferDiff = buffer - drawBorderAt;

            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox);
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Near;

            Pen blackPen = new Pen(Brushes.Black, 1);

            // Determine the width required for each column in the table.
            if (currentRow == 0) calculateSizes(headers, data);
            int tableWidth = 0;
            foreach (TableHeader h in headers) {
                tableWidth += h.requiredWidth;
            }
            tableWidth += (buffer * (headers.Length));
            if (tableWidth < printableWidth) leftMargin += (printableWidth - tableWidth) / 2;
            printableWidth = Math.Min(printableWidth, tableWidth);

            // Draw the top line of the table
            g.DrawLine(blackPen, leftMargin, topMargin, leftMargin + printableWidth - bufferDiff, topMargin);
            topMargin += buffer - drawBorderAt;
            printableHeight -= buffer;

            // Print Table Headers

            fmt.LineAlignment = StringAlignment.Center;
            // Draw the left side of the first box (we'll add a right side for each header which will complete the table)
            g.DrawLine(blackPen, leftMargin, topMargin - bufferDiff, leftMargin, topMargin + subHeaderLineHeight + drawBorderAt);
            // Centre the headers
            fmt.Alignment = StringAlignment.Center;
            
            float linePos = leftMargin - bufferDiff;
            for (int x = 0; x < headers.Length; x++) {
                TableHeader h = headers[x];
                string text = h.name;
                int requiredWidth = h.requiredWidth;
                while ((h != null) && (h.mergeWithFollowing)) {
                    requiredWidth += buffer;
                    x++;
                    h = (x < headers.Length) ? headers[x] : null;
                    if (h != null) {
                        requiredWidth += h.requiredWidth;
                        text += h.name;
                    }
                }
                RectangleF box = new RectangleF(new PointF(linePos + bufferDiff, topMargin), new SizeF(requiredWidth+buffer, subHeaderLineHeight+buffer));
                // Draw the Header Text
                g.DrawString(text, subHeaderFont, Brushes.Black, box, fmt);
                linePos = box.Left + requiredWidth + drawBorderAt;
                // Add the right-hand side of the box
                g.DrawLine(blackPen, linePos, topMargin - bufferDiff, linePos, topMargin + subHeaderLineHeight + drawBorderAt);
            }

            /*
            foreach (TableHeader h in headers) {
                RectangleF box = new RectangleF(new PointF(linePos + bufferDiff, topMargin), new SizeF(h.requiredWidth+buffer, subHeaderLineHeight+buffer));
                // Draw the Header Text
                g.DrawString(h.name, subHeaderFont, Brushes.Black, box, fmt);
                linePos = box.Left + h.requiredWidth + drawBorderAt;
                // Add the right-hand side of the box
                g.DrawLine(blackPen, linePos, topMargin - bufferDiff, linePos, topMargin + subHeaderLineHeight + drawBorderAt);
            }
            */

            // Draw the line under the headers
            g.DrawLine(blackPen, leftMargin, topMargin + subHeaderLineHeight + drawBorderAt, leftMargin + printableWidth-bufferDiff, topMargin + subHeaderLineHeight + drawBorderAt);
            
            topMargin += subHeaderLineHeight + buffer;
            printableHeight -= subHeaderLineHeight + buffer;

            while ((currentRow < data.Length) && (printableHeight > (lineHeight + buffer))) {
                TableData td = data[currentRow];

                // Draw left side of table (again, we'll be adding a right side on each entry
                g.DrawLine(blackPen, leftMargin, topMargin - bufferDiff, leftMargin, topMargin + lineHeight + drawBorderAt);

                if (td.items.Length != headers.Length) throw new IndexOutOfRangeException("Mismatch between number of headers and entries in the table.");
                float leftPos = leftMargin - bufferDiff;
                for (int x = 0; x < headers.Length; x++) {
                    TableElement e = td.items[x];
                    TableHeader h = headers[x];
                    fmt.Alignment = h.alignment;
                    RectangleF box = new RectangleF(new PointF(leftPos + bufferDiff, topMargin), new SizeF(h.requiredWidth + buffer, lineHeight + buffer));
                    if (h.isCheckbox) {
                        g.DrawRectangle(blackPen, box.Left+buffer, topMargin + ((lineHeight + buffer - boxSize) / 2), boxSize, boxSize);
                    } else {
                        g.DrawString(e.text, bodyFont, Brushes.Black, box, fmt);
                    }
                    // Draw the right side of the box
                    leftPos = box.Left + h.requiredWidth + drawBorderAt;
                    g.DrawLine(blackPen, leftPos, topMargin - bufferDiff, leftPos, topMargin + lineHeight + drawBorderAt);
                    // leftPos += h.requiredWidth;
                }

                // Draw the line under the table
                g.DrawLine(blackPen, leftMargin, topMargin + lineHeight + drawBorderAt, leftMargin + printableWidth-bufferDiff, topMargin + lineHeight + drawBorderAt);

                topMargin += lineHeight + buffer;
                printableHeight -= lineHeight + buffer;
                currentRow++;
            }
            return currentRow;
        }
    }
}