using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.PlottingServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using CADApplication = Autodesk.AutoCAD.ApplicationServices.Application;
using System.Web.Management;
using PdfSharp.Charting;
using System.Threading;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using System.Drawing.Drawing2D;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static Autodesk.AutoCAD.LayerManager.LayerFilter;
using DialogResult = System.Windows.Forms.DialogResult;
//using System.Web.UI;

// Not necessary but improves performance
[assembly: CommandClass(typeof(CADAutoPrintPlugin_2023.MainFunctions))]

namespace CADAutoPrintPlugin_2023
{
      public class MainFunctions
      {
            // Explicit declaration of variables
            //Application acadApp = (Application)Autodesk.AutoCAD.ApplicationServices.Application.AcadApplication;
            Document acadDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            private List<BoMItem> bomItems = new List<BoMItem>();
            DataHelper dBHelper = new DataHelper();

            static string printFilePath;
            internal static string selectedDuplicate;
            string[] strWords; // a string array to hold the words from the line of data
            string strItemName; // string to hold the item name and project number
            static string strProjName; // a string to hold the Project Name
            static string strProjNumber; // a string to hold the Project Number

            private static string _strProjLead;
            private static int _intProdNum;
            private static bool _isMnfgPrint;
            private string _productionid;
            private string _projectnumber;
            private string _productionname;
            private string _productionUUID;

            public static string StrProjLead { get => _strProjLead; set => _strProjLead = value; }
            public static int ProdNum { get => _intProdNum; set => _intProdNum = value; }
            public static bool IsMnfgPrint { get => _isMnfgPrint; set => _isMnfgPrint = value; }
            public string ProductionID { get => _productionid; set => _productionid = value; }
            public string ProjectNumber { get => _projectnumber; set => _projectnumber = value; }
            public string ProductionName { get => _productionname; set => _productionname = value; }
            public string ProductionUUID { get => _productionUUID; set => _productionUUID = value; }

            [CommandMethod("CADPrint")]
            public void StartPrint()
            {
                  StrProjLead = "";
                  var projForm = new frmProjectLead();
                  projForm.ShowDialog();

                  //Control[] projControls = projForm.Controls.Find("btnCancel", false);
                  //Button userBtnCancel = (Button)projControls[0];
                  //userBtnCancel.Click += UserBtnCancel_Click;

                  //if (userBtnCancel.DialogResult == DialogResult.Cancel)
                  //{
                  //      projForm.Close();
                  //}
                  //else
                  //{
                        IsMnfgPrint = projForm.IsMnfgPrint;

                        if (!IsMnfgPrint)
                        {
                              StrProjLead = projForm.ProjectLead;
                              SelectPrintFile();
                        }
                        else
                        {
                              ProdNum = projForm.ProductionNumber;
                              SelectProjectProduction();
                        }
                  //}
            }

            //void UserBtnCancel_Click(object sender, EventArgs e)
            //{
            //      DialogResult cancelBtn = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
            //}

            public void SelectPrintFile()
            {
                  var printListForm = new frmGetPrintList();
                  printListForm.ShowDialog();
                  printFilePath = printListForm.LookupPath;

                  SelectSearchPaths();
            }

            public void SelectProjectProduction()
            {
                  var projProdForm = new frmProjProdPrint();
                  projProdForm.ShowDialog();

                  ProductionID = projProdForm.ProductionID;
                  ProjectNumber = projProdForm.ProductionNumber;
                  ProductionName = projProdForm.ProductionName;
                  ProductionUUID = projProdForm.ProductionUUID;

                  SelectDrawings();
            }

            public void SelectSearchPaths()
            {
                  var searchPathsForm = new frmSearchFolders();
                  searchPathsForm.ShowDialog();
                  //PrepareLookupFile();

                  if (printFilePath != null)
                  {
                        bomItems = GetItemsFromPL(printFilePath);

                        List<string> drawingPaths = new List<string>();
                        drawingPaths = GetDrawingPaths(bomItems, searchPathsForm.strFolderList);

                        PrintMissingFiles();
                  }
            }

            public void PrintMissingFiles()
            {
                  var missingDrawings = new frmMissingDwgs(bomItems, strProjName, printFilePath);
                  missingDrawings.ShowDialog();
                  SelectDrawings();
            }

            public void SelectDrawings()
            {

                  if (!IsMnfgPrint)
                  {
                        var drawingList = new frmSelectDrawings(bomItems, IsMnfgPrint);

                        // Open modeless else the drawing will not close after printing
                        drawingList.Show();
                  }
                  else
                  {
                        var drawingList = new frmSelectMnfgDwgs(bomItems, IsMnfgPrint, ProductionID, ProductionName, ProjectNumber, ProductionUUID);

                        // Open modeless else the drawing will not close after printing
                        drawingList.Show();
                  }
            }

            public void DrawingSearch()
            {
                  List<string> drawingPaths = new List<string>();
                  //drawingPaths = getDrawingPaths(7, "");
            }

            internal static string OpenPrintList()
            {
                  OpenFileDialog printFileOpen = new OpenFileDialog();
                  bool bExOccured = false;
                  DialogResult retVal;
                  string printListFile = "";
                  string Delimeter = ",";
                  bool skipMe = false;

                  try
                  {
                        // Adds an extension to a file name if the user omits the extension
                        printFileOpen.AddExtension = true;

                        // dialog box does not allow multiple files to be selected
                        printFileOpen.Multiselect = false;

                        printFileOpen.Filter = "Text files (*.txt)|*.txt";

                        retVal = printFileOpen.ShowDialog();
                        if (retVal == DialogResult.OK)
                        {
                              if (printFileOpen.CheckFileExists == true & printFileOpen.CheckPathExists == true)
                                    printListFile = printFileOpen.FileName;
                        }
                  }
                  catch (AccessViolationException ex1)
                  {
                        MessageBox.Show(ex1.StackTrace.ToString());
                        bExOccured = true;
                  }
                  catch (System.Exception ex)
                  {
                        MessageBox.Show(ex.StackTrace.ToString());
                        bExOccured = true;
                  }
                  finally
                  {
                        if (bExOccured == true)
                        {
                              MessageBox.Show("Program executed with some errors!!!");
                        }
                  }

                  return printListFile;
            }

            internal static string GetFolderPath()
            {
                  FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                  bool bExOccured = false;
                  DialogResult retVal;
                  string chosenPath = "";

                  try
                  {
                        // Hides the New Folder creation button
                        folderBrowser.ShowNewFolderButton = false;

                        retVal = folderBrowser.ShowDialog();
                        if (retVal == DialogResult.OK)
                        {
                              chosenPath = folderBrowser.SelectedPath + "\\";
                        }
                  }
                  catch (AccessViolationException ex1)
                  {
                        MessageBox.Show(ex1.StackTrace.ToString());
                        bExOccured = true;
                  }
                  catch (System.Exception ex)
                  {
                        MessageBox.Show(ex.StackTrace.ToString());
                        bExOccured = true;
                  }
                  finally
                  {
                        if (bExOccured == true)
                        {
                              MessageBox.Show("Program executed with some errors!!!");
                        }
                  }
                  return chosenPath;
            }

            public List<BoMItem> GetItemsFromPL(string printFilePath)
            {
                  List<BoMItem> bomItems = new List<BoMItem>();
                  BoMItem bomItem = null/* TODO Change to default(_) if this is not a reference type */;

                  try
                  {
                        var workingList = new List<string>(); // Create new workingList to hold the lines

                        var fileStream = new FileStream(printFilePath, FileMode.Open, FileAccess.Read); // Create a new File Stream and open the Print List
                        using (var streamReader = new StreamReader(fileStream)) // Create a new Stream Reader to read the the Print List
                        {
                              string line = ""; // Clear the line
                              while (line != null) // While the Streamer is still reading
                              {
                                    line = streamReader.ReadLine(); // Read the line into the line variable
                                    if (line != "") { workingList.Add(line); } // If the line is not empty add it to the workingList
                              }
                        }

                        strProjName = GetProjectData(workingList[2], 2);
                        strProjNumber = GetProjectData(workingList[2], 0); // The Axapta item number for this Project

                        for (int i = 4; i <= workingList.Count - 1; i++) // Iterate the workingList from position 4 to the end
                        {
                              if (workingList[i] != null) // Check to see if the end of the workingList has been reached
                              {
                                    strWords = BreakLineDown(workingList[i]); // Break down the current line into an array of words

                                    if (strWords.Length < 5) // If the words are less than 9 then
                                    {
                                          workingList.RemoveAt(i); // Remove the current line
                                          i--; // Decriment the current line by 1 because the current line was just deleted.
                                          continue;
                                    }
                                    else
                                    {
                                          switch (strWords[0].ToUpper())
                                          {
                                                case "COMP TYPE": // It is comp type
                                                      workingList.RemoveAt(i); // Remove the current line
                                                      i--; // Decriment the current line by 1 because the current line was just deleted.
                                                      continue;

                                                case "COMPONENT TYPE": // It is component type
                                                      workingList.RemoveAt(i); // Remove the current line
                                                      i--; // Decriment the current line by 1 because the current line was just deleted.
                                                      continue;

                                                case "EVANS CONSOLES INC.": // It is evans consoles inc.
                                                      workingList.RemoveAt(i); // Remove the current line
                                                      i--; // Decriment the current line by 1 because the current line was just deleted.
                                                      continue;

                                                case "EVANS CONSOLES CORPORATION": // It is evans consoles inc.
                                                      workingList.RemoveAt(i); // Remove the current line
                                                      i--; // Decriment the current line by 1 because the current line was just deleted.
                                                      continue;

                                                case "ITEM NUMBER": // It is item number
                                                      workingList.RemoveAt(i); // Remove the current line
                                                      i--; // Decriment the current line by 1 because the current line was just deleted.
                                                      continue;

                                          }
                                    }

                                    if (strWords[6] != "BOM")
                                    {
                                          workingList.RemoveAt(i); // Remove the current line
                                          i--; // Decriment the current line by 1 because the current line was just deleted.
                                          continue;
                                    }
                              }
                        }

                        for (int i = 4; i <= workingList.Count - 1; i++)// Iterate the new workingList from position 4 to the end
                        {
                              if (workingList[i] != null) // Check to see if the end of the workingList has been reached
                              {
                                    strWords = BreakLineDown(workingList[i]); // Break down the current line into an array of words

                                    bomItem = new BoMItem(); // Instantiate a new BoMItem

                                    // --Fill the Item object.
                                    bomItem.PartNumber = strWords[1].ToString();
                                    bomItem.Description = strWords[3].ToString();
                                    bomItem.Rev = strWords[2].ToString();
                                    bomItem.StockNumber = "";
                                    bomItem.Qty = Convert.ToInt32(Convert.ToDouble(strWords[4].ToString()));
                                    bomItem.CompType = strWords[0].ToString();
                                    bomItem.BoMFinish = strWords.Count() > 7 ? strWords[7].ToString() : "";
                                    bomItem.FinishID = 0;
                                    bomItem.StockName = "";
                                    bomItem.Usage = "";
                                    bomItem.Units = strWords[5].ToString();
                                    bomItem.IsInternal = false;
                                    bomItem.DefaultFinish = 0;
                                    bomItem.IsConfigurable = false;
                                    bomItem.Status = "";
                                    bomItem.Path = "";

                                    bomItems.Add(bomItem); // Add the BoMItem to the bomItems List
                              }
                        }
                  }
                  catch (System.Exception ex)
                  {
                        throw new System.Exception(ex.Message);
                  }
                  return bomItems; // Return the List BoMItems
            }

            public List<string> GetDrawingPaths(List<BoMItem> bomItems, string[] searchPaths)
            {
                  List<string> drawingPaths = new List<string>();
                  List<string> tempList = new List<string>();
                  bool isStdDwg = true;
                  int itemNum = 0;

                  foreach (BoMItem bomItem in bomItems)
                  {
                        if (bomItem.CompType != "HDWKIT" && bomItem.CompType != "OBS" && !bomItem.CompType.StartsWith("X"))
                        {
                              // Check if we have an item "number" for fast searches
                              try
                              {
                                    itemNum = Convert.ToInt32(bomItem.PartNumber);
                              }
                              catch
                              {
                                    isStdDwg = false;
                              }

                              // Do core search in S:\EID Drawings\Project Drawings for item drawing
                              // this should be very fast for standard items as it will search no more than 500 drawings
                              // non-standard items will search the entire directory tree (approx 136k drawings July 2011)
                              if (isStdDwg)
                              {
                                    if ((itemNum >= 10000 && itemNum < 2000000) || (itemNum >= 3000000 && itemNum < 4000000))
                                    {
                                          string requestedPath = GetStdDwgPath(itemNum);
                                          try
                                          {
                                                if (System.IO.Directory.Exists(requestedPath))
                                                {
                                                      tempList.AddRange(System.IO.Directory.GetFiles(requestedPath, itemNum + ".dwg"));
                                                      bomItem.Path = requestedPath + itemNum + ".dwg";
                                                      bomItem.Status = "Drawing Found";
                                                }
                                          }
                                          catch
                                          {

                                          }
                                    }
                                    else
                                    {
                                          tempList.AddRange(System.IO.Directory.GetFiles("S:\\EID Drawings\\Project Drawings\\", itemNum + ".dwg"));
                                          bomItem.Path = "S:\\EID Drawings\\Project Drawings\\" + itemNum + ".dwg";
                                          bomItem.Status = "Drawing Found";
                                    }
                              }
                              else
                              {
                                    tempList.AddRange(System.IO.Directory.GetFiles("S:\\EID Drawings\\Project Drawings\\", itemNum + ".dwg"));
                                    bomItem.Path = "S:\\EID Drawings\\Project Drawings\\" + itemNum + ".dwg";
                                    bomItem.Status = "Drawing Found";
                              }

                              int pathsToSearch = searchPaths.Count();
                              int intTemp = 0;

                              if (pathsToSearch == 1)
                              {
                                    pathsToSearch = 1;
                              }
                              else
                              {
                                    pathsToSearch = pathsToSearch - 1;
                                    intTemp = 1;
                              }

                              for (int i = intTemp; i < pathsToSearch; i++)
                              {
                                    if (System.IO.Directory.GetFiles(searchPaths[i], itemNum + ".dwg", SearchOption.AllDirectories).Length > 0)
                                    {
                                          tempList.AddRange(System.IO.Directory.GetFiles(searchPaths[i], itemNum + ".dwg", SearchOption.AllDirectories));
                                          bomItem.Path = tempList.LastOrDefault().ToString(); //searchPaths[i] + itemNum + ".dwg";
                                          bomItem.Status = "Drawing Found";
                                    }
                              }

                              string strTestString = itemNum + ".dwg";
                              if (tempList.FirstOrDefault(stringToCheck => stringToCheck.Contains(strTestString)) == null)
                              {
                                    tempList.Add("No Drawing Found for: " + strTestString);
                                    bomItem.Path = "";
                                    bomItem.Status = "No Drawing Found";
                              }

                              tempList = tempList.Distinct().ToList();

                              var matchDrawings = tempList.Where(stringToCheck => stringToCheck.Contains(strTestString));

                              if (matchDrawings.Count() > 1)
                              {
                                    frmDuplicateDrawings frmSelectDwg = new frmDuplicateDrawings();

                                    frmSelectDwg.duplicateFiles = matchDrawings.ToArray();
                                    frmSelectDwg.ShowDialog();

                                    selectedDuplicate = frmSelectDwg.selectedDrawing;

                                    string[] tempDupFiles = matchDrawings.ToArray();
                                    foreach (string dupFile in tempDupFiles)
                                    {
                                          tempList.Remove(dupFile);
                                    }

                                    tempList.Add(selectedDuplicate.ToString());
                                    bomItem.Path = selectedDuplicate.ToString();

                                    //frmSelectDwg.Close();
                              }
                        }
                  }

                  drawingPaths = tempList.Distinct().ToList();

                  return drawingPaths;
            }

            public string[] BreakLineDown(string line)
            {
                  string[] delimiterStrings = { "\t", "\t\t" };
                  line = line.Replace("\t\t", "\t-\t");
                  string[] words = line.Split(delimiterStrings, System.StringSplitOptions.RemoveEmptyEntries);

                  return words;
            }

            private string GetProjectData(string projLine, int intWord)
            {
                  strWords = BreakLineDown(projLine); // break the line down into words
                  strItemName = strWords[intWord];

                  return strItemName;
            }

            private string GetStdDwgPath(int itemNum)
            {
                  string stdPath = "S:\\EID Drawings\\Project Drawings\\";

                  string strItemRoot, strItemNumSub, strItemRemainderSub;

                  string strItemNum = itemNum.ToString();

                  switch (strItemNum)
                  {
                        // 1000000 To 1999999
                        case string number when new Regex(@"100000[0-9]|10000[1-9][0-9]|1000[1-9][0-9]{2}|100[1-9][0-9]{3}|10[1-9][0-9]{4}|1[1-9][0-9]{5}").IsMatch(strItemNum):

                              strItemRoot = strItemNum.Substring(0, 3);
                              strItemNumSub = strItemNum.Substring(3, 1);
                              strItemRemainderSub = strItemNum.Substring(4, 3);

                              stdPath = stdPath + strItemRoot + "0000\\";

                              if (Convert.ToInt32(strItemRemainderSub) < 500)
                              {
                                    stdPath += strItemRoot + strItemNumSub + "000-" + strItemRoot + strItemNumSub + "499\\";
                              }
                              else
                              {
                                    stdPath += strItemRoot + strItemNumSub + "500-" + strItemRoot + strItemNumSub + "999\\";
                              }

                              break;

                        // 3000000 To 3999999
                        case var number when new Regex(@"300000\d|30000[1-9]\d|3000[1-9]\d{2}|300[1-9]\d{3}|30[1-9]\d{4}|3[1-9]\d{5}").IsMatch(itemNum.ToString()):

                              strItemRoot = itemNum.ToString().Substring(0, 3);
                              strItemNumSub = itemNum.ToString().Substring(3, 1);
                              strItemRemainderSub = itemNum.ToString().Substring(4, 3);

                              stdPath += strItemRoot + "0000\\";

                              if (Convert.ToInt32(strItemRemainderSub) < 500)
                              {
                                    stdPath += strItemRoot + strItemNumSub + "000-" + strItemRoot + strItemNumSub + "499\\";
                              }
                              else
                              {
                                    stdPath += strItemRoot + strItemNumSub + "500-" + strItemRoot + strItemNumSub + "999\\";
                              }

                              break;
                        // 15000 To 999999
                        case string number when new Regex(@"1500[0-9]|150[1-9][0-9]|15[1-9][0-9]{2}|1[6-9][0-9]{3}|[2-9][0-9]{4}|[1-9][0-9]{5}").IsMatch(strItemNum):
                              stdPath += "(10000 up to 6 digit)\\(15000 up to 6 digit)\\";
                              break;

                        // 10000 To 14999
                        case string number when new Regex(@"1000[0-9]|100[1-9][0-9]|10[1-9][0-9]{2}|1[1-4][0-9]{3}").IsMatch(strItemNum):
                              //itemNumRoot = System.Math.DivRem(itemNum, 1000, out int result);
                              strItemRoot = strItemNum.Substring(0, 2);
                              stdPath += "(10000 up to 6 digit)\\(" + strItemRoot + "000-" + strItemRoot + "999)\\";
                              break;

                        default:
                              throw new ArgumentOutOfRangeException("Item Number", "The Item Number is out side the search parameters.");
                  }

                  return stdPath;
            }

            #region ZoomExtents
            //static void Zoom(Point3d pMin, Point3d pMax, Point3d pCenter, double dFactor)
            //{
            //    // Get the current document and database
            //    Document acDoc = CADApplication.DocumentManager.MdiActiveDocument;
            //    Database acCurDb = acDoc.Database;

            //    int nCurVport = System.Convert.ToInt32(CADApplication.GetSystemVariable("CVPORT"));

            //    // Get the extents of the current space when no points 
            //    // or only a center point is provided
            //    // Check to see if Model space is current
            //    if (acCurDb.TileMode == true)
            //    {
            //        if (pMin.Equals(new Point3d()) == true &&
            //            pMax.Equals(new Point3d()) == true)
            //        {
            //            pMin = acCurDb.Extmin;
            //            pMax = acCurDb.Extmax;
            //        }
            //    }
            //    else
            //    {
            //        // Check to see if Paper space is current
            //        if (nCurVport == 1)
            //        {
            //            // Get the extents of Paper space
            //            if (pMin.Equals(new Point3d()) == true &&
            //                pMax.Equals(new Point3d()) == true)
            //            {
            //                pMin = acCurDb.Pextmin;
            //                pMax = acCurDb.Pextmax;
            //            }
            //        }
            //        else
            //        {
            //            // Get the extents of Model space
            //            if (pMin.Equals(new Point3d()) == true &&
            //                pMax.Equals(new Point3d()) == true)
            //            {
            //                pMin = acCurDb.Extmin;
            //                pMax = acCurDb.Extmax;
            //            }
            //        }
            //    }

            //    // Start a transaction
            //    using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            //    {
            //        // Get the current view
            //        using (ViewTableRecord acView = acDoc.Editor.GetCurrentView())
            //        {
            //            Extents3d eExtents;

            //            // Translate WCS coordinates to DCS
            //            Matrix3d matWCS2DCS;
            //            matWCS2DCS = Matrix3d.PlaneToWorld(acView.ViewDirection);
            //            matWCS2DCS = Matrix3d.Displacement(acView.Target - Point3d.Origin) * matWCS2DCS;
            //            matWCS2DCS = Matrix3d.Rotation(-acView.ViewTwist,
            //                                            acView.ViewDirection,
            //                                            acView.Target) * matWCS2DCS;

            //            // If a center point is specified, define the min and max 
            //            // point of the extents
            //            // for Center and Scale modes
            //            if (pCenter.DistanceTo(Point3d.Origin) != 0)
            //            {
            //                pMin = new Point3d(pCenter.X - (acView.Width / 2),
            //                                    pCenter.Y - (acView.Height / 2), 0);

            //                pMax = new Point3d((acView.Width / 2) + pCenter.X,
            //                                    (acView.Height / 2) + pCenter.Y, 0);
            //            }

            //            // Create an extents object using a line
            //            using (Line acLine = new Line(pMin, pMax))
            //            {
            //                eExtents = new Extents3d(acLine.Bounds.Value.MinPoint,
            //                                            acLine.Bounds.Value.MaxPoint);
            //            }

            //            // Calculate the ratio between the width and height of the current view
            //            double dViewRatio;
            //            dViewRatio = (acView.Width / acView.Height);

            //            // Tranform the extents of the view
            //            matWCS2DCS = matWCS2DCS.Inverse();
            //            eExtents.TransformBy(matWCS2DCS);

            //            double dWidth;
            //            double dHeight;
            //            Point2d pNewCentPt;

            //            // Check to see if a center point was provided (Center and Scale modes)
            //            if (pCenter.DistanceTo(Point3d.Origin) != 0)
            //            {
            //                dWidth = acView.Width;
            //                dHeight = acView.Height;

            //                if (dFactor == 0)
            //                {
            //                    pCenter = pCenter.TransformBy(matWCS2DCS);
            //                }

            //                pNewCentPt = new Point2d(pCenter.X, pCenter.Y);
            //            }
            //            else // Working in Window, Extents and Limits mode
            //            {
            //                // Calculate the new width and height of the current view
            //                dWidth = eExtents.MaxPoint.X - eExtents.MinPoint.X;
            //                dHeight = eExtents.MaxPoint.Y - eExtents.MinPoint.Y;

            //                // Get the center of the view
            //                pNewCentPt = new Point2d(((eExtents.MaxPoint.X + eExtents.MinPoint.X) * 0.5),
            //                                            ((eExtents.MaxPoint.Y + eExtents.MinPoint.Y) * 0.5));
            //            }

            //            // Check to see if the new width fits in current window
            //            if (dWidth > (dHeight * dViewRatio)) dHeight = dWidth / dViewRatio;

            //            // Resize and scale the view
            //            if (dFactor != 0)
            //            {
            //                acView.Height = dHeight * dFactor;
            //                acView.Width = dWidth * dFactor;
            //            }

            //            // Set the center of the view
            //            acView.CenterPoint = pNewCentPt;

            //            // Set the current view
            //            acDoc.Editor.SetCurrentView(acView);
            //        }

            //        // Commit the changes
            //        acTrans.Commit();
            //    }
            //}
            #endregion

            public static void PrintDrawings(List<BoMItem> printItems)
            {
                  string strFileName = "";
                  DocumentCollection acDocMgr = CADApplication.DocumentManager;
                  Document acDoc = null;// = acDocMgr.MdiActiveDocument;
                  Editor acEd = null;
                  // Start a new output document
                  PdfDocument outputDocument = new PdfDocument();

                  try
                  {
                        foreach (BoMItem item in printItems)
                        {
                              strFileName = item.Path;

                              if (File.Exists(strFileName))
                              {
                                    // Open the drawing
                                    acDoc = acDocMgr.Open(strFileName, true);

                                    // Set the newly opened drawing as the Current Document
                                    acDocMgr.CurrentDocument = acDoc;

                                    // Set the drawing as the active document
                                    acDocMgr.MdiActiveDocument = acDoc;

                                    // Lock the document so there can be no concurrency errors
                                    acDoc.LockDocument();

                                    // Wait for the drawing to fully open and load
                                    // Subscribe to the EndDwgOpen event to detect when the drawing is fully loaded
                                    acDoc.EndDwgOpen += AcDoc_EndDwgOpen;

                                    // Subscribe to the docColDocAct event to detect when the drawing is activated
                                    acDocMgr.DocumentActivated += new DocumentCollectionEventHandler(DocColDocAct);
                              }
                              else
                              {
                                    acDocMgr.MdiActiveDocument.Editor.WriteMessage("File " + strFileName + " does not exist.");
                              }

                              // Fill out the Title Block
                              FillTitleBlock(acDoc, strProjName, item.Qty, StrProjLead);

                              // Print the drawing to PDF
                              PrintToPDF(acDoc, item.PartNumber.ToString());

                              // Used for the error handler below
                              acEd = acDoc.Editor;

                              try
                              {
                                    // Close the drawing and discard any changes
                                    acDoc.CloseAndDiscard();
                              }
                              catch (System.Exception ex)
                              {
                                    acEd.WriteMessage(Environment.NewLine + ex.Source.ToString());
                              }

                              // Get some file names
                              string[] pdfFile = Directory.GetFiles(Path.GetTempPath(), "*.pdf", SearchOption.TopDirectoryOnly);

                              // Open the document to import pages from it.
                              PdfDocument inputDocument = PdfReader.Open(pdfFile[0], PdfDocumentOpenMode.Import);

                              //// Iterate pages
                              //int count = inputDocument.PageCount;

                              // Get the page from the external document...
                              PdfPage page = inputDocument.Pages[0];

                              // ...and add it to the output document.
                              outputDocument.AddPage(page);

                              // Delete the file after adding to the output document.
                              File.Delete(pdfFile[0]);

                        }
                        // ----------------------------------------------------------------------------------------------------------------------
                        // Combine printed pdfs...

                        // generate a file name for the combined PDFs
                        string combinedFile = strProjName;

                        // the directory to store the output.
                        string directory = Path.GetDirectoryName(printFilePath); ;

                        // Save the document...
                        string filename = Path.Combine(directory, combinedFile + " Design Drawing Package.pdf");

                        // ---------------------------------------------------------------------------------------------------------------------
                        try
                        {
                              if (outputDocument.PageCount > 0)
                              {
                                    outputDocument.Save(filename);
                                    MessageBox.Show("Print package to PDf complete.", "Print Complete", MessageBoxButtons.OK); // Display a print complete message
                              }
                              else
                              {
                                    MessageBox.Show("There must be at least 1 page to combine.", "No Pages Found", MessageBoxButtons.OK);
                              }

                        }
                        catch (System.Exception Printerror)
                        {
                              MessageBox.Show(Printerror.Message + "\n" + Printerror.StackTrace);
                        }
                  }
                  catch (System.Runtime.InteropServices.COMException ex)
                  {
                        // Log the error code
                        acEd.WriteMessage("\nError: COM exception ({0})", ex.ErrorCode.ToString("X"));
                  }
            }

            public static void PrintMnfgDrawings(System.Data.DataTable printTable, string strProjName, string strIssuedBy, string strIssueDate)
            {
                  string strFileName = "";
                  DocumentCollection acDocMgr = CADApplication.DocumentManager;
                  Document acDoc = null;// = acDocMgr.MdiActiveDocument;
                  Editor acEd = null;
                  // Start a new output document
                  PdfDocument outputDocument = new PdfDocument();

                  try
                  {
                        foreach (System.Data.DataRow item in printTable.Rows)
                        {
                              strFileName = item["DRAWINGPATH"].ToString();

                              if (File.Exists(strFileName))
                              {
                                    // Open the drawing
                                    acDoc = acDocMgr.Open(strFileName, true);

                                    // Set the newly opened drawing as the Current Document
                                    acDocMgr.CurrentDocument = acDoc;

                                    // Set the drawing as the active document
                                    acDocMgr.MdiActiveDocument = acDoc;

                                    // Lock the document so there can be no concurrency errors
                                    acDoc.LockDocument();

                                    // Wait for the drawing to fully open and load
                                    // Subscribe to the EndDwgOpen event to detect when the drawing is fully loaded
                                    acDoc.EndDwgOpen += AcDoc_EndDwgOpen;

                                    // Subscribe to the docColDocAct event to detect when the drawing is activated
                                    acDocMgr.DocumentActivated += new DocumentCollectionEventHandler(DocColDocAct);
                              }
                              else
                              {
                                    acDocMgr.MdiActiveDocument.Editor.WriteMessage("File " + strFileName + " does not exist.");
                              }

                              // Fill out the Title Block
                              FillTitleBlock(acDoc, strProjName, Convert.ToInt32(item["QTY"]), strIssuedBy, strIssueDate, item["BARCODEID"].ToString(), item["PRODID"].ToString());

                              // Print the drawing to PDF
                              PrintToPDF(acDoc, item["ITEMID"].ToString());

                              // Used for the error handler below
                              acEd = acDoc.Editor;

                              try
                              {
                                    // Close the drawing and discard any changes
                                    acDoc.CloseAndDiscard();
                              }
                              catch (System.Exception ex)
                              {
                                    acEd.WriteMessage(Environment.NewLine + ex.Source.ToString());
                              }

                              // Get some file names
                              string[] pdfFile = Directory.GetFiles(Path.GetTempPath(), "*.pdf", SearchOption.TopDirectoryOnly);

                              // Open the document to import pages from it.
                              PdfDocument inputDocument = PdfReader.Open(pdfFile[0], PdfDocumentOpenMode.Import);

                              //// Iterate pages
                              //int count = inputDocument.PageCount;

                              // Get the page from the external document...
                              PdfPage page = inputDocument.Pages[0];

                              // ...and add it to the output document.
                              outputDocument.AddPage(page);

                              // Delete the file after adding to the output document.
                              File.Delete(pdfFile[0]);

                        }
                        // ----------------------------------------------------------------------------------------------------------------------
                        // Combine printed pdfs...

                        // generate a file name for the combined PDFs
                        string combinedFile = strProjName;

                        // the directory to store the output.
                        string directory = "C:\\Temp\\"; //Path.GetDirectoryName(printFilePath); ;

                        // Save the document...
                        string filename = Path.Combine(directory, combinedFile + " Manufacturing Drawing Package.pdf");

                        // ---------------------------------------------------------------------------------------------------------------------
                        try
                        {
                              if (outputDocument.PageCount > 0)
                              {
                                    outputDocument.Save(filename);
                                    MessageBox.Show("Print package to PDF complete. File saved to C:\\Temp\\", "Print Complete", MessageBoxButtons.OK); // Display a print complete message
                              }
                              else
                              {
                                    MessageBox.Show("There must be at least 1 page to combine.", "No Pages Found", MessageBoxButtons.OK);
                              }

                        }
                        catch (System.Exception Printerror)
                        {
                              MessageBox.Show(Printerror.Message + "\n" + Printerror.StackTrace);
                        }
                  }
                  catch (System.Runtime.InteropServices.COMException ex)
                  {
                        // Log the error code
                        acEd.WriteMessage("\nError: COM exception ({0})", ex.ErrorCode.ToString("X"));
                  }
            }

            private static void AcDoc_EndDwgOpen(object sender, EventArgs e)
            {
                  Document acDoc = (Document)sender;
                  Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Drawing " + acDoc.Name + " is fully loaded.");
                  acDoc.EndDwgOpen -= AcDoc_EndDwgOpen; // Unsubscribe from the event to avoid memory leaks
            }

            public static void DocColDocAct(object senderObj, DocumentCollectionEventArgs docColDocActEvtArgs)
            {
                  DocumentCollection acDocMgr = CADApplication.DocumentManager;
                  //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(docColDocActEvtArgs.Document.Name + " was activated.");
                  acDocMgr.DocumentActivated -= new DocumentCollectionEventHandler(DocColDocAct); // Unsubscribe from the event to avoid memory leaks
            }

            public static void FillTitleBlock(Document acDoc, string projName, int qty, string issuedBy, string issuedDate = "", string barCode = "", string prodID = "")
            {
                  // Lock the document to ensure no conurrency errors
                  acDoc.LockDocument();

                  // Get the full Title Block name
                  string blockName = FindBlockName(acDoc);

                  string plotOrient = blockName;
                  string plotRotation = "portrait";

                  if (plotOrient.Contains("1185") || plotOrient.Contains("1117"))
                  {
                        plotRotation = "landscape";
                  }

                  // Open a new Transaction
                  using (var acTrans = new OpenCloseTransaction())
                  {
                        // get the document database
                        Database acCurDb = acDoc.Database;

                        // get the database block table
                        BlockTable blkTable = (BlockTable)acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead);

                        // If the block table contains a block definitions named 'blockName'...
                        if (blkTable.Has(blockName))
                        {
                              // Open the block definition
                              BlockTableRecord acBlkTblRec = (BlockTableRecord)acTrans.GetObject(blkTable[blockName], OpenMode.ForWrite);

                              if (barCode != "")
                              {
                                    TextStyleTable barcodeStyleTable = acTrans.GetObject(acDoc.Database.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;

                                    if (!barcodeStyleTable.Has("Free 3 of 9"))  //The TextStyle is currently not in the database
                                    {
                                          barcodeStyleTable.UpgradeOpen();
                                          TextStyleTableRecord barcodeStyleTableRecord = new TextStyleTableRecord();
                                          barcodeStyleTableRecord.FileName = "FREE3OF9.TTF";
                                          barcodeStyleTableRecord.Name = "BARCODE";
                                          //Autodesk.AutoCAD.GraphicsInterface.FontDescriptor myNewTextStyle = new Autodesk.AutoCAD.GraphicsInterface.FontDescriptor("ROMANS", false, false, 0, 0);
                                          //newTextStyleTableRecord.Font = myNewTextStyle;
                                          barcodeStyleTable.Add(barcodeStyleTableRecord);
                                          acTrans.AddNewlyCreatedDBObject(barcodeStyleTableRecord, true);
                                    }

                                    // Create a single-line text object
                                    using (DBText acText = new DBText())
                                    {
                                          if (plotRotation.Equals("landscape"))
                                          {
                                                acText.Position = new Point3d(.25, 7.8125, 0);
                                                acText.Rotation = 0;
                                          }
                                          else if (plotRotation.Equals("portrait"))
                                          {
                                                acText.Position = new Point3d(.25, .3125, 0);
                                                acText.Rotation = 1.5708;
                                          }

                                          acText.Height = 0.375;
                                          acText.TextString = "*" + barCode + "*"; // "Hello, World.";
                                          acText.TextStyleId = barcodeStyleTable["BARCODE"];

                                          acBlkTblRec.AppendEntity(acText);
                                          acTrans.AddNewlyCreatedDBObject(acText, true);
                                    }
                              }

                              // Get the inserted block references ObjectIds
                              var objIds = acBlkTblRec.GetBlockReferenceIds(true, true);

                              // If any...
                              if (0 < objIds.Count)
                              {
                                    // Open the first block reference
                                    BlockReference acBlkRef = (BlockReference)acTrans.GetObject(objIds[0], OpenMode.ForRead);

                                    // Iterate through the attribute collection
                                    foreach (ObjectId objId in acBlkRef.AttributeCollection)
                                    {
                                          // Open the attribute reference
                                          AttributeReference attRef = (AttributeReference)acTrans.GetObject(objId, OpenMode.ForWrite);

                                          // Get the Attribute Tag name and store it in a variable
                                          string strTagString = attRef.Tag.ToString().ToUpper();

                                          // Create a new empty Tag value
                                          string strTagValue = "";

                                          switch (strTagString)
                                          {
                                                case "PROJ_NO":

                                                      // Set the Project Tag value to the Project Name
                                                      strTagValue = prodID;

                                                      break;

                                                case "PROJECT":

                                                      // Set the Project Tag value to the Project Name
                                                      strTagValue = projName;

                                                      break;

                                                case "QTY":
                                                case "QUANTITY":

                                                      // Set the Quantity Tag value to the Quantity
                                                      strTagValue = qty.ToString();

                                                      break;

                                                case "IBY":

                                                      // Set the Issued By Tag value to the Issued By
                                                      strTagValue = issuedBy;

                                                      break;

                                                case "IDATE":

                                                      if (issuedDate == "")
                                                      {
                                                            // Set the Issued Date Tag value to todays date
                                                            strTagValue = DateTime.Now.ToString("dd MMM yyyy");
                                                      }
                                                      else
                                                      {
                                                            strTagValue = issuedDate;
                                                      }


                                                      break;

                                                case "A":

                                                      // Don't change the Rev value.
                                                      strTagValue = attRef.TextString;

                                                      break;

                                                default:

                                                      // Set other Tag values to what they are currently
                                                      strTagString = attRef.TextString;

                                                      break;
                                          }

                                          // If the attribute tag is equal to 'tag'
                                          if (attRef.Tag.Equals(strTagString, StringComparison.CurrentCultureIgnoreCase))
                                          {
                                                // Update the value of the attribute
                                                attRef.TextString = strTagValue;

                                                // Commit the transaction
                                                acTrans.Commit();

                                                // Get the editor object
                                                Editor ed = acDoc.Editor;

                                                // Regenerate the drawing
                                                ed.Regen();
                                          }

                                    }
                              }
                        }
                  }
            }

            public static string FindBlockName(Document doc)
            {
                  // Initialize the Title Blokc name to an empty string
                  string blockName = string.Empty;

                  // Get the dB from the Document
                  Database db = doc.Database;

                  // Start a new Transcation
                  Transaction tr = db.TransactionManager.StartTransaction();

                  try
                  {
                        // Get the Block Table 
                        BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);

                        // Iterate through the block table
                        foreach (ObjectId btrId in bt)
                        {
                              // Get the Block Table Record ID from the Block Table Record
                              BlockTableRecord btr = (BlockTableRecord)tr.GetObject(btrId, OpenMode.ForRead);

                              if (btr.IsLayout || btr.IsAnonymous) continue;

                              // Get the Block Name from the Block Table Record
                              string name = btr.Name.ToUpper();

                              // If the Block Name contains either of the Evans Legacy Title Block names
                              // return the block name
                              if (name.Contains("1185ECI") ||
                                    name.Contains("8511ECI") ||
                                    name.Contains("1117ECI") ||
                                    name.Contains("1711ECI"))
                              {
                                    blockName = name;
                                    break;
                              }
                        }

                        // Commit the Transaction
                        tr.Commit();
                  }
                  catch (System.Exception ex)
                  {
                        // If there is a problem rollback the transaction
                        tr.Abort();
                        throw ex;
                  }

                  // Return the block name
                  return blockName;
            }

            public static void PrintToPDF(Document acDoc, string partNumber)
            {
                  // Used for error handling notification
                  Editor acEd = acDoc.Editor;

                  // Get the dB of the drawing
                  Database acDb = acDoc.Database;

                  // May not be used
                  //string currentFolder = Path.GetDirectoryName(acDoc.Name);

                  // Create an empty string to hold the Plot Style name
                  string strPlotStyle = "";

                  // Return the name of the Title Block
                  string plotOrient = FindBlockName(acDoc);
                  string plotRotation = "portrait";

                  if (plotOrient.Contains("1185") || plotOrient.Contains("1117"))
                  {
                        plotRotation = "landscape";
                  }

                  // The users default system based temp folder
                  string directory = Path.GetTempPath();

                  // The file name of the drawing
                  string fileName = partNumber;

                  // Start a Transaction
                  using (Transaction acTrans = acDb.TransactionManager.StartOpenCloseTransaction())
                  {
                        // We'll be plotting the current layout
                        BlockTableRecord currentSpace = (BlockTableRecord)acTrans.GetObject(acDb.CurrentSpaceId, OpenMode.ForRead);
                        Layout currLayout = (Layout)acTrans.GetObject(currentSpace.LayoutId, OpenMode.ForRead);

                        // PlotInfo object linked to the layout
                        PlotInfo plotInfo = new PlotInfo();
                        plotInfo.Layout = currentSpace.LayoutId;

                        // Set the PlotSettings object based on the layout settings
                        PlotSettings plotSettings = new PlotSettings(currLayout.ModelType);
                        plotSettings.CopyFrom(currLayout);

                        // The PlotSettingsValidator helps
                        // create a valid PlotSettings object
                        PlotSettingsValidator plotSettingsValidator = PlotSettingsValidator.Current;
                        PlotConfigManager.RefreshList(RefreshCode.All);

                        // Plot extents, scaled to fit, centred
                        plotSettingsValidator.SetPlotType(plotSettings, Autodesk.AutoCAD.DatabaseServices.PlotType.Extents);
                        plotSettingsValidator.SetUseStandardScale(plotSettings, true);
                        plotSettingsValidator.SetStdScaleType(plotSettings, StdScaleType.ScaleToFit);
                        plotSettingsValidator.SetPlotCentered(plotSettings, true);

                        // Rotate the plot based on the Title Block orientation 90 = Landscape
                        plotSettingsValidator.SetPlotRotation(plotSettings, plotRotation.Equals("landscape") ? PlotRotation.Degrees090 : PlotRotation.Degrees000);

                        // Populate the Plot Style variable with the Evans 2010 ctb
                        foreach (string plotStyle in PlotSettingsValidator.Current.GetPlotStyleSheetList())
                        {
                              if (plotStyle.Contains("EVANS_2010"))
                              {
                                    strPlotStyle = plotStyle.ToString();
                              }
                        }

                        // Use Microsoft Plot to PDF in Letter size for plotting to a file
                        plotSettingsValidator.SetPlotConfigurationName(plotSettings, "Microsoft Print to PDF", "Letter");
                        plotSettingsValidator.SetCurrentStyleSheet(plotSettings, strPlotStyle);

                        // Override the plot settings because this will be temporary settings
                        plotInfo.OverrideSettings = plotSettings;

                        // Create a Plot Info Validator and Validate the plot info settings above
                        // The drawing will not plot until the Plot Info is valid
                        PlotInfoValidator plotInfoValidator = new PlotInfoValidator();
                        plotInfoValidator.MediaMatchingPolicy = MatchingPolicy.MatchEnabledCustom;
                        plotInfoValidator.Validate(plotInfo);

                        // A PlotEngine does the actual plotting
                        if (PlotFactory.ProcessPlotState == ProcessPlotState.NotPlotting)
                        {

                              try
                              {
                                    // Create a publish engine
                                    PlotEngine plotEngine = PlotFactory.CreatePublishEngine();

                                    // Start the plot
                                    plotEngine.BeginPlot(null, null);

                                    // Validate the Plot Configuration
                                    PlotConfig config = plotInfo.ValidatedConfig;

                                    // Plot to file
                                    config.IsPlotToFile = true;

                                    // Start the Document
                                    plotEngine.BeginDocument(plotInfo, acDoc.Name, null, 1, true, Path.Combine(directory, fileName + ".pdf"));

                                    // Create new page and Start the page
                                    PlotPageInfo plotPageInfo = new PlotPageInfo();
                                    plotEngine.BeginPage(plotPageInfo, plotInfo, true, null);

                                    // Start and finish the graphics generation
                                    plotEngine.BeginGenerateGraphics(null);
                                    plotEngine.EndGenerateGraphics(null);

                                    // Finish the page
                                    plotEngine.EndPage(null);

                                    // Finish the document
                                    plotEngine.EndDocument(null);

                                    // Finish the plot
                                    plotEngine.EndPlot(null);

                                    // Clean up
                                    plotEngine.Destroy();
                                    plotEngine = null;

                              }
                              catch (System.Exception error) { System.Exception Err = error; }
                        }

                        else
                        {
                              acEd.WriteMessage("\nAnother plot is in progress.");
                        }

                        // Wait for the plot to complete
                        while (PlotFactory.ProcessPlotState != ProcessPlotState.NotPlotting)
                        {
                              Thread.Sleep(100);
                        }

                        // Aborting = do not save changes
                        acTrans.Abort();
                  }
            }

            public static string DataTableToJSONAsc(List<BoMItem> bomItems)
            {
                  string BoMlist = string.Empty;
                  BoMlist = JsonConvert.SerializeObject(bomItems, Formatting.Indented);

                  return BoMlist;
            }

            public void AddBoMTodB(List<BoMItem> printItems)
            {
                  int BoMId = dBHelper.GetBoMIDByProjectNumber(strProjNumber);

                  // Create the JSON files
                  string JsonBom = DataTableToJSONAsc(printItems);
                  string JsonMaterials = ""; // DataTableToJSONAsc(DS.Tables["Material"]);
                  string JsonStructured = ""; // DataTableToJSONAsc(DS.Tables["Structured BoM"]);

                  int bomID,
                      ProjectID;

                  string ProjectName,
                      ProjectNumber,
                      ProjectPartNumber,
                      ProjectRev,
                      ProjectBom,
                      ProjectMaterials,
                      ProjectStructured;

                  bool Success;

                  bomID = BoMId;
                  ProjectID = 0;
                  ProjectName = strProjName;
                  ProjectNumber = strProjNumber.ToString();
                  ProjectPartNumber = strProjNumber.ToString();
                  ProjectRev = "";
                  ProjectBom = JsonBom;
                  ProjectMaterials = JsonMaterials;
                  ProjectStructured = JsonStructured;

                  string UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                  UserName = UserName.Remove(0, 6);

                  UserName = UserName.ToLower();

                  if (BoMId > 0)
                  {
                        Success = (bool)dBHelper.UpdateDesignBoM(BoMId,
                            UserName,
                            ProjectID,
                            ProjectName,
                            ProjectNumber,
                            ProjectRev,
                            ProjectBom,
                            ProjectMaterials,
                            ProjectStructured);

                        if (!Success)
                        {
                              MessageBox.Show("There was an issue updating this BoM in the Database.");
                        }
                        else
                        {
                              MessageBox.Show("The BoM was updated in the Database.");

                              if (!dBHelper.UpdateProject(ProjectNumber, UserName, BoMId))
                              {
                                    MessageBox.Show("There was an issue updating this Project in the Database.");
                              }
                              else
                              {
                                    MessageBox.Show("The Project was updated in the Database.");
                              }
                        }
                  }
                  else
                  {
                        int BoMID = (int)dBHelper.AddNewDesignBoM(UserName,
                        ProjectID,
                        ProjectName,
                        ProjectNumber,
                        ProjectRev,
                        ProjectBom,
                        ProjectMaterials,
                        ProjectStructured);

                        if (BoMID == 0)
                        {
                              MessageBox.Show("There was an issue adding this Design BoM to the Database.");
                        }
                        else
                        {
                              MessageBox.Show("The Design BoM has been added to the Database.");

                              if (!dBHelper.AddNewProject(ProjectNumber, UserName, 9999, BoMID, ProjectName))
                              {
                                    MessageBox.Show("There was an issue adding this Project to the Database.");
                              }
                              else
                              {
                                    MessageBox.Show("The Project was added to the Database.");
                              }
                        }
                  }
            }

            //internal static void Cancel()
            //{
            //      throw new NotImplementedException();
            //      //Application.Exit(0); // quit
            //}

            public static void CancelSelect()
            {
                  // ***************************************
                  // ***** gracefully quit the program *****
                  // ***************************************

                  // clear all object variables
                  //acadApp = null; // clear the autocad application object variable
                  //acadDrawing = null; // clear the autocad drawing object variable
                  //ssetBlocks = null; // clear the object variable
                  //ssetMSBlocks = null; // clear the object variable
                  //ssetPSBlocks = null; // clear the object variable
                  //thisBlockRef = null; // clear the object variable
                  //utilObj = null; // clear the object variable
                  //acadPlot = null; // clear the object variable
                  //excelApp = null; // clear the excel application object variable
                  //excelRecordWorkbook = null; // clear the excel record workbook object variable
                  //excelRecordSpreadsheet = null; // clear the excel record spreadsheet object variable
                  //FSO = null; // clear the file system object variable

                  //// unload all forms
                  //projForm.Close(); // unload the enter project lead dialog box
                  //frmChooseDrawings.Close(); // unload the choose drawings dialog box
                  //frmEnterItems.Close(); // unload the enter items dialog box

                  //frmEnterProjNum.Close(); // unload the enter project number dialog box
                  //frmEnterQuantity.Close(); // unload the enter quantity dialog box
                  //frmOpenAxaptaDump.Close(); // unload the open lookup file dialog box
                  //frmSelectFolder.Close(); // unload the select folder dialog box
                  //frmSelectOption.Close(); // unload the select option dialog box
                  //frmSelectSearchFolders.Close(); // unload the select files dialog box
                  //frmTestingWindow.Close(); // unload the testing window dialog box
                  //frmProgress.Close(); // unload the progress dialog box

                  //System.Environment.Exit(0); // quit
            }

      }
}
