using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CADAutoPrintPlugin_2023
{
      public partial class frmSelectMnfgDwgs : Form, IPrintItems
      {
            private List<BoMItem> _printitems;
            private DataTable _printtable;
            private bool _isMnfgPrint;
            private string _productionid;
            private string _projectnumber;
            private string _productionname;
            private string _productionUUID;
            private string _jobnumber;

            public List<BoMItem> bomDataList = new List<BoMItem>();
            public DataTable PrintTable { get => _printtable; set => _printtable = value;  }
            public bool IsMnfgPrint { get => _isMnfgPrint; set => _isMnfgPrint = value; }
            public List<BoMItem> printItems { get => _printitems; set => _printitems = value; }
            public string ProductionID { get => _productionid; set => _productionid = value; }
            public string ProjectNumber { get => _projectnumber; set => _projectnumber = value; }
            public string ProductionName { get => _productionname; set => _productionname = value; }
            public string ProductionUUID { get => _productionUUID; set => _productionUUID = value; }
            public string JobNumber { get => _jobnumber; set => _jobnumber = value; }

            private DataHelper dBHelper = new DataHelper();

            public frmSelectMnfgDwgs(List<BoMItem> bomList,
                                                                        bool IsManPrint,
                                                                        string _productionid,
                                                                        string _productionname,
                                                                        string _projectnumber,
                                                                        string _productionuuid)
            {
                  InitializeComponent();
                  IsMnfgPrint = IsManPrint;
                  bomDataList = bomList;
                  lvwAllDwgs.Columns.Add("", 60);
                  ProductionID = _productionid;
                  ProductionName = _productionname;
                  ProjectNumber = _projectnumber;
                  ProductionUUID = _productionuuid;

                  JobNumber = dBHelper.GetItemIDFromAPI(ProductionUUID);

            }

            private void frmSelectDrawings_Load(object sender, EventArgs e)
            {
                  updateLists(); // Call the Update List method.
            }

            private void updateLists()
            {
                  //DataTable designBoM = new DataTable();
                  string designBoM = dBHelper.GetDesignBoMByProjectNumber(JobNumber);

                  // Deserialize the JSON string to an array of BoMRow objects
                  BoMItem[] JsonBoM = JsonConvert.DeserializeObject<BoMItem[]>(designBoM);

                  DataTable allData = new DataTable();
                  allData = dBHelper.GetAllProductionItemsByUUID(ProductionUUID);

                  // Remove XVMI XKB XRM
                  foreach (DataRow row in allData.Rows)
                  {
                        // If this row is offensive then
                        if (row["COMPONENTTYPE"].ToString() == "XVMI" | row["COMPONENTTYPE"].ToString() == "XKB" | row["COMPONENTTYPE"].ToString() == "XRM")
                        {
                              row.Delete();
                        }
                  }

                  allData.AcceptChanges();

                  allData.Columns.Add("DRAWINGSTATUS");
                  allData.Columns.Add("DRAWINGPATH");

                  foreach (BoMItem bomRow in JsonBoM)
                  {
                        foreach (DataRow dRow in allData.Rows)
                        {
                              if (bomRow.PartNumber == dRow["ITEMID"].ToString())
                              {
                                    dRow["DRAWINGSTATUS"] = bomRow.Status;
                                    dRow["DRAWINGPATH"] = bomRow.Path;
                              }
                        }
                  }

                  allData.AcceptChanges();

                  // Sort by Component Type and then by Part Number.
                  DataView dView = new DataView(allData);

                  dView.Sort = "COMPONENTTYPE ASC, ITEMID ASC";

                  allData = dView.ToTable();

                  PrintTable = allData.Clone();

                  lvwAllDwgs.Items.Clear();
                  lvwPrintDwgs.Items.Clear();

                  foreach (DataRow row in allData.Rows)
                  {
                        try
                        {
                              if (row["DRAWINGSTATUS"].ToString().ToLower() == "drawing found")
                              {
                                    ListViewItem printListItem = new ListViewItem(row["PRODID"].ToString());
                                    printListItem.SubItems.Add(row["ITEMID"].ToString());
                                    printListItem.SubItems.Add(row["ITEMNAME"].ToString());
                                    printListItem.SubItems.Add(row["REV"].ToString());
                                    printListItem.SubItems.Add(row["QTY"].ToString());
                                    printListItem.SubItems.Add(row["FINISH"].ToString());
                                    printListItem.SubItems.Add(row["COMPONENTTYPE"].ToString());
                                    printListItem.SubItems.Add(row["STATUS"].ToString());
                                    printListItem.SubItems.Add(row["DRAWINGSTATUS"].ToString());
                                    printListItem.SubItems.Add(row["DRAWINGPATH"].ToString());

                                    lvwAllDwgs.Items.Add(printListItem);
                              }
                        }
                        catch
                        {

                        }
                  }
                  lvwAllDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                  lvwAllDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                  lvwPrintDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                  lvwPrintDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            private void getDwgs(List<BoMItem> bomList)
            {
            }

            private void lvwAllDwgs_ItemDrag(object sender, ItemDragEventArgs e)
            {
                  if (this.lvwAllDwgs.SelectedIndices.Count > 0)
                  {
                        List<ListViewItem> selecteditems = new List<ListViewItem>();
                        foreach (int index in this.lvwAllDwgs.SelectedIndices)
                        {
                              selecteditems.Add(this.lvwAllDwgs.Items[index]);
                        }
                        this.lvwAllDwgs.DoDragDrop(selecteditems, DragDropEffects.Move);
                  }

                  lvwAllDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                  lvwAllDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }

            private void lvwPrintDwgs_ItemDrag(object sender, ItemDragEventArgs e)
            {
                  if (this.lvwPrintDwgs.SelectedIndices.Count > 0)
                  {
                        List<ListViewItem> selecteditems = new List<ListViewItem>();
                        foreach (int index in this.lvwPrintDwgs.SelectedIndices)
                        {
                              selecteditems.Add(this.lvwPrintDwgs.Items[index]);
                        }
                        this.lvwPrintDwgs.DoDragDrop(selecteditems, DragDropEffects.Move);
                  }

                  lvwPrintDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                  lvwPrintDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }

            private void lvwAllDwgs_DragEnter(object sender, DragEventArgs e)
            {
                  if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
                  {
                        e.Effect = DragDropEffects.Move;
                  }
            }

            private void lvwPrintDwgs_DragEnter(object sender, DragEventArgs e)
            {
                  if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
                  {
                        e.Effect = DragDropEffects.Move;
                  }
            }

            private void lvwAllDwgs_DragDrop(object sender, DragEventArgs e)
            {
                  List<ListViewItem> items = new List<ListViewItem>();
                  items = e.Data.GetData(typeof(List<ListViewItem>)) as List<ListViewItem>;
                  foreach (ListViewItem li in items)
                  {
                        ListViewItem copyitem = (ListViewItem)li.Clone();
                        lvwAllDwgs.Items.Add(copyitem);
                        li.ListView.Items.Remove(li);
                  }

                  lvwAllDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                  lvwAllDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }

            private void lvwPrintDwgs_DragDrop(object sender, DragEventArgs e)
            {
                  List<ListViewItem> items = new List<ListViewItem>();
                  items = e.Data.GetData(typeof(List<ListViewItem>)) as List<ListViewItem>;
                  foreach (ListViewItem li in items)
                  {
                        ListViewItem copyitem = (ListViewItem)li.Clone();
                        lvwPrintDwgs.Items.Add(copyitem);
                        li.ListView.Items.Remove(li);
                  }

                  lvwPrintDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                  lvwPrintDwgs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }

            private void btnDone_Click(object sender, EventArgs e)
            {
                  printItems = new List<BoMItem>();

                  PrintTable.Columns.Add("BARCODEID");
                  
                  PrintTable.AcceptChanges();

                  foreach (ListViewItem printItem in lvwPrintDwgs.Items)
                  {
                        var newPrintRow = PrintTable.NewRow();

                        newPrintRow["PRODID"] = printItem.SubItems[0].Text;
                        newPrintRow["ITEMID"] = printItem.SubItems[1].Text;
                        newPrintRow["ITEMNAME"] = printItem.SubItems[2].Text;
                        newPrintRow["REV"] = printItem.SubItems[3].Text;
                        newPrintRow["QTY"] = printItem.SubItems[4].Text;
                        newPrintRow["FINISH"] = printItem.SubItems[5].Text;
                        newPrintRow["COMPONENTTYPE"] = printItem.SubItems[6].Text;
                        newPrintRow["STATUS"] = printItem.SubItems[7].Text;
                        newPrintRow["DRAWINGSTATUS"] = printItem.SubItems[8].Text;
                        newPrintRow["DRAWINGPATH"] = printItem.SubItems[9].Text;
                        newPrintRow["BARCODEID"] = dBHelper.GetBarcode(ProductionID, printItem.SubItems[1].Text, printItem.SubItems[3].Text, "eci");

                        PrintTable.Rows.Add(newPrintRow);

                  }

                  List<string> issuerInfo = dBHelper.GetIssuerInfoByProjectNumber(JobNumber);

                  string projectName = ProjectNumber +  " " + ProductionName;

                  MainFunctions.PrintMnfgDrawings(PrintTable, projectName, issuerInfo[0], issuerInfo[1]);

                  this.Close();
            }

            private void lblPrintList_Click(object sender, EventArgs e)
            {

            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                  this.Close();
                 // Application.Exit();
            }
      }
}
