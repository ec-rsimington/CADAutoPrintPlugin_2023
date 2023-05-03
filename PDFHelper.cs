using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace CADAutoPrintPlugin_2023
{
    class PDFHelper
    {
        private readonly PdfDocument _document;
        private readonly XUnit _topPosition;
        private readonly XUnit _bottomMargin;
        private readonly XUnit _margin;
        private XUnit _currentPosition;
        private string _projectName;
        private string _projectNumber;

        public PDFHelper(PdfDocument document, XUnit topPosition, XUnit bottomMargin, XUnit margin, string projectName, string projectNumber)
        {
            _document = document;
            _topPosition = topPosition;
            _bottomMargin = bottomMargin;
            _margin = margin;
            _projectName = projectName;
            _projectNumber = projectNumber;
       
            // Set a value outside the page - a new page will be created on the first request.
            _currentPosition = _bottomMargin + 10000;
        }

        public XUnit GetLinePosition(XUnit requestedHeight)
        {
            return GetLinePosition(requestedHeight, -1f, false);
        }

        public XUnit GetLinePosition(XUnit requestedHeight, XUnit requiredHeight, bool isHeader)
        {
            XUnit required = requiredHeight == -1f ? requestedHeight : requiredHeight;
            if (_currentPosition > _bottomMargin) 
            {
                CreatePage();
                isHeader = true;
            }

            if (!isHeader)
            {
                _currentPosition += requestedHeight;
            }

            XUnit result = _currentPosition;

            return result;
        }

        public XGraphics gfx { get; private set; }
        public PdfPage page { get; private set; }
        public XStringFormat format { get; private set; }

        void CreatePage()
        {
            page = _document.AddPage();
            page.Size = PageSize.Letter;
            gfx = XGraphics.FromPdfPage(page);
            format = new XStringFormat();

            // Create a font
            XFont titleFont = new XFont("Segoe UI", 14, XFontStyle.Bold);
            XRect titleRect = new XRect(_margin, _margin, page.Width - _margin * 2, titleFont.Height+1); // + titleFont.Height

            // Draw horizontal line
            gfx.DrawLine(XPens.DarkGray, 30, _margin + titleRect.Height, page.Width - _margin, _margin + titleRect.Height);

            // Draw the text
            format.LineAlignment = XLineAlignment.Far;
            format.Alignment = XStringAlignment.Near;
            gfx.DrawString("Pre-Print Report: ".ToUpper() + _projectNumber + " " + _projectName, titleFont, XBrushes.Black, titleRect, format); //XStringFormats.BottomLeft

            XFont headerFont = new XFont("Segoe UI", 10);
            XBrush headerBrush = XBrushes.Black;
            double headerHeight = 12;
            double headerY = _margin + (titleFont.Height + 2); // + (headerFont.Height+2)

            XRect partNumHeader = new XRect(_margin, headerY, 60, headerHeight);
            XRect descriptionHeader = new XRect(_margin + partNumHeader.Width, headerY, 245, headerHeight);
            XRect compTypeHeader = new XRect(_margin + partNumHeader.Width + descriptionHeader.Width, headerY, 85, headerHeight);
            XRect destHeader = new XRect(_margin + partNumHeader.Width + descriptionHeader.Width + compTypeHeader.Width, headerY, 80, headerHeight);
            XRect statusHeader = new XRect(_margin + partNumHeader.Width + descriptionHeader.Width + compTypeHeader.Width + destHeader.Width, headerY, 100, headerHeight);

            format.LineAlignment = XLineAlignment.Far;
            format.Alignment = XStringAlignment.Near;
            gfx.DrawString("Part Number", headerFont, headerBrush, partNumHeader, format); //printedDrawingsTable.Columns[0].ColumnName
            gfx.DrawString("| Description", headerFont, headerBrush, descriptionHeader, format);
            gfx.DrawString("| Component Type", headerFont, headerBrush, compTypeHeader, format);
            gfx.DrawString("", headerFont, headerBrush, destHeader, format);
            gfx.DrawString("| Status", headerFont, headerBrush, statusHeader, format);

            _currentPosition = _topPosition;
        }
    }
}
