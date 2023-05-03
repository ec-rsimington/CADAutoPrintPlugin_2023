using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CADAutoPrintPlugin_2023
{
      public partial class frmSelectDrawings : Form, IPrintItems
      {
            private List<BoMItem> _printitems;
            private bool _isMnfgPrint;

            public List<BoMItem> bomDataList = new List<BoMItem>();
            public bool IsMnfgPrint
            {
                  get { return _isMnfgPrint; }
                  set {_isMnfgPrint = value; }
            }

            public List<BoMItem> printItems
            {
                  get { return _printitems; }
                  set { _printitems = value; }
            }

            public frmSelectDrawings(List<BoMItem> bomList, bool IsManPrint)
            {
                  InitializeComponent();
                  IsMnfgPrint = IsManPrint;
                  bomDataList = bomList;
                  lvwAllDwgs.Columns.Add("", 60);
            }

            private void frmSelectDrawings_Load(object sender, EventArgs e)
            {
                  updateLists(); // Call the Update List method.
            }

            private void updateLists()
            {
                  lvwAllDwgs.Items.Clear();
                  lvwPrintDwgs.Items.Clear();

                  foreach (BoMItem row in bomDataList)
                  {
                        try
                        {
                              MainFunctions mainFunctions = new MainFunctions();
                              //string[] words = mainFunctions.breakLineDown(row..ToString());

                              if (row.Status.ToLower() == "drawing found")
                              {
                                    ListViewItem printListItem = new ListViewItem(row.PartNumber.ToString());
                                    //printedListItem.SubItems.Add(row["PartNumber"].ToString());
                                    printListItem.SubItems.Add(row.Description.ToString());
                                    printListItem.SubItems.Add(row.CompType.ToString());
                                    printListItem.SubItems.Add(row.Status.ToString());
                                    //printListItem.SubItems.Add(row.Rev.ToString());
                                    //printListItem.SubItems.Add(row.Status.ToString());
                                    //printListItem.SubItems.Add(row.Status.ToString());
                                    //printListItem.SubItems.Add(row.Status.ToString());
                                    //printListItem.SubItems.Add(row.Status.ToString());
                                    //printListItem.SubItems.Add(row.Status.ToString());
                                    //printListItem.SubItems.Add(row.Status.ToString());
                                    //printListItem.SubItems.Add(row.Status.ToString());

                                    lvwAllDwgs.Items.Add(printListItem);
                              }
                        }
                        catch
                        {

                        }
                  }

            }

            private void getDwgs(List<BoMItem> bomList)
            {
                  //foreach(string row in bomList)
                  //{

                  //}
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
            }

            private void btnDone_Click(object sender, EventArgs e)
            {
                  //printItems = new List<BoMItem>();

                  List<BoMItem> sortedPrintList = new List<BoMItem>();

                  foreach (ListViewItem printItem in lvwPrintDwgs.Items)
                  {
                        foreach (BoMItem bomItem in bomDataList)
                        {
                              if (printItem.SubItems[0].Text == bomItem.PartNumber)
                              {
                                    sortedPrintList.Add(bomItem);
                              }
                        }
                  }

                  printItems = sortedPrintList.OrderBy(ct => ct.CompType).ToList();

                  MainFunctions.PrintDrawings(printItems);

                  MainFunctions mainFunctions = new MainFunctions();
                        
                  mainFunctions.AddBoMTodB(printItems);

                  this.Close();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                  this.Close();
                 // Application.Exit();
            }
      }
}
