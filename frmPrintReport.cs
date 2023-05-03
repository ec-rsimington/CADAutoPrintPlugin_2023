using Autodesk.AutoCAD.DatabaseServices;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CADAutoPrintPlugin_2023
{
      public partial class frmMissingDwgs : Form
      {
            private string projectName { get; set; }
            private string projectNumber { get; set; }
            private string pdfPath { get; set; }

            public List<BoMItem> bomDataList = new List<BoMItem>();

            private double margin = 36; // Margin in pixels
            private XUnit _topPosition = 75;

            public frmMissingDwgs(List<BoMItem> bomList, string _projectName, string _pdfPath)
            {
                  InitializeComponent();
                  bomDataList = bomList;
                  projectName = _projectName.ToUpper();
                  projectNumber = "";
                  pdfPath = _pdfPath;
                  pdfPath = Path.GetDirectoryName(pdfPath);
                  pdfPath = pdfPath + "\\" + projectName + " Print Report.pdf";
            }

            private void frmMissingDwgs_Load(object sender, EventArgs e)
            {
                  foreach (BoMItem row in bomDataList)
                  {
                        try
                        {
                              MainFunctions mainFunctions = new MainFunctions();
                              //string[] words = mainFunctions.breakLineDown(row..ToString());

                              if (row.Status.ToLower() == "no drawing found" && row.Status != null)
                              {
                                    ListViewItem missingListItem = new ListViewItem(row.PartNumber.ToString());
                                    //printedListItem.SubItems.Add(row["PartNumber"].ToString());
                                    missingListItem.SubItems.Add(row.Description.ToString());
                                    missingListItem.SubItems.Add(row.CompType.ToString());
                                    missingListItem.SubItems.Add(row.Status.ToString());

                                    lvwMissingDwgs.Items.Add(missingListItem);

                                    lbPath.Text = "PDF will be saved to: " + pdfPath;
                              }
                        }
                        catch
                        {

                        }
                  }
            }

            private void btnPrint_Click(object sender, EventArgs e)
            {

                  double fieldHeight = 12; // Set the field height
                  double headerHeight = 66; // Set the header height

                  XFont font = new XFont("Segoe UI", 8.5); // Set the font
                  XBrush normalBrush = XBrushes.RoyalBlue; // "Normal" font colour
                  XBrush dangerBrush = XBrushes.IndianRed; // "Alert" font colour
                  XBrush warningBrush = XBrushes.DarkOrange; // "Warning" font colour
                  XBrush mehBrush = XBrushes.DimGray; // "Not Applicable" font colour
                  XBrush lineBrush;

                  XStringFormat format = new XStringFormat();

                  string targetPath = pdfPath; // "C:\\TEMP\\Test.pdf";

                  // Create a PDF Document
                  PdfDocument pdfReport = new PdfDocument();
                  pdfReport.Info.Title = "Print Report";

                  PDFHelper pdfHelper = new PDFHelper(pdfReport, headerHeight, (828 - margin - headerHeight), margin, projectName, projectNumber);

                  #region new stuff

                  XRect partNumField = new XRect(margin, _topPosition, 60, fieldHeight);
                  XRect descriptionField = new XRect(margin + partNumField.Width, _topPosition, 245, fieldHeight);
                  XRect compTypeField = new XRect(margin + partNumField.Width + descriptionField.Width, _topPosition, 85, fieldHeight);
                  XRect destField = new XRect(margin + partNumField.Width + descriptionField.Width + compTypeField.Width, _topPosition, 80, fieldHeight);
                  XRect statusField = new XRect(margin + partNumField.Width + descriptionField.Width + compTypeField.Width + destField.Width, _topPosition, 100, fieldHeight);

                  bool wasHeader = false;

                  for (int line = 0; line < bomDataList.Count; ++line)
                  {
                        bool isHeader = line == 0;
                        wasHeader = isHeader;

                        XUnit top = pdfHelper.GetLinePosition(isHeader ? headerHeight : fieldHeight, isHeader ? headerHeight + fieldHeight : fieldHeight, isHeader);

                        XRect partNumRect = new XRect(partNumField.X, top, partNumField.Width, partNumField.Height);
                        XRect descRect = new XRect(descriptionField.X, top, descriptionField.Width, descriptionField.Height);
                        XRect compTypeRect = new XRect(compTypeField.X, top, compTypeField.Width, compTypeField.Height);
                        XRect destRect = new XRect(destField.X, top, destField.Width, destField.Height);
                        XRect statusRect = new XRect(statusField.X, top, statusField.Width, statusField.Height);

                        //pdfHelper.Gfx.DrawRectangle(XPens.YellowGreen, partNumRect);

                        if (bomDataList[line].Status.ToLower().Contains("no drawing found"))
                        {
                              lineBrush = dangerBrush;
                        }
                        else
                        {
                              lineBrush = normalBrush;
                        }

                        if (bomDataList[line].CompType.ToLower().StartsWith("x") || bomDataList[line].CompType.ToLower().StartsWith("hdw"))
                        {
                              lineBrush = mehBrush;
                        }
                        

                        if (bomDataList[line].CompType.ToLower().Equals("obs"))
                        {
                              lineBrush = warningBrush;
                        }

                        //bool dwgNotFound = bomDataList[line].Status.ToLower().Contains("no drawing found");

                        format.LineAlignment = XLineAlignment.Far;
                        format.Alignment = XStringAlignment.Near;
                        //pdfHelper.gfx.DrawString("PN: " + (line + 1), font, normalBrush, partNumRect, format);
                        //pdfHelper.gfx.DrawString("  Description: " + (line + 1), font, normalBrush, descRect, format);
                        //pdfHelper.gfx.DrawString("  Comp Type: " + (line + 1), font, normalBrush, compTypeRect, format);
                        //pdfHelper.gfx.DrawString("  Dest: " + (line + 1), font, normalBrush, destRect, format);
                        //pdfHelper.gfx.DrawString("  Status: " + (line + 1), font, normalBrush, statusRect, format);

                        //pdfHelper.gfx.DrawString(bomDataList[line].PartNumber, font, dwgNotFound ? dangerBrush : normalBrush, partNumRect, format);
                        //pdfHelper.gfx.DrawString("  " + bomDataList[line].Description, font, dwgNotFound ? dangerBrush : normalBrush, descRect, format);
                        //pdfHelper.gfx.DrawString("  " + bomDataList[line].CompType, font, dwgNotFound ? dangerBrush : normalBrush, compTypeRect, format);
                        //pdfHelper.gfx.DrawString("  " + "", font, dwgNotFound ? dangerBrush : normalBrush, destRect, format);
                        //pdfHelper.gfx.DrawString("  " + bomDataList[line].Status, font, dwgNotFound ? dangerBrush : normalBrush, statusRect, format);

                        pdfHelper.gfx.DrawString(bomDataList[line].PartNumber, font, lineBrush, partNumRect, format);
                        pdfHelper.gfx.DrawString("  " + bomDataList[line].Description, font, lineBrush, descRect, format);
                        pdfHelper.gfx.DrawString("  " + bomDataList[line].CompType, font, lineBrush, compTypeRect, format);
                        pdfHelper.gfx.DrawString("  " + "", font, lineBrush, destRect, format);
                        pdfHelper.gfx.DrawString("  " + bomDataList[line].Status, font, lineBrush, statusRect, format);

                  }
                  #endregion

                  try
                  {
                        pdfReport.Save(targetPath);
                        MessageBox.Show("Print report saved.", "Print Report");
                  }
                  catch (Exception saveError)
                  {
                        MessageBox.Show(saveError.Message);//partNumHeader
                  }
            }

            private void btnDone_Click(object sender, EventArgs e)
            {
                  clickedDone();
            }

            private void clickedDone()
            {
                  this.Close();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                  this.Close();
                  //Application.Exit();
            }
      }
}
