using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CADAutoPrintPlugin_2023
{
      public partial class frmProjProdPrint : Form
      {
            private string _productionid;

            public string ProductionID
            {
                  get { return _productionid; }
                  set { _productionid = value; }
            }

            private string _productionnumber;

            public string ProductionNumber
            {
                  get { return _productionnumber; }
                  set { _productionnumber = value; }
            }

            private string _productionname;

            public string ProductionName
            {
                  get { return _productionname; }
                  set { _productionname = value; }
            }

            private string _productionUUID;

            public string ProductionUUID
            {
                  get { return _productionUUID; }
                  set { _productionUUID = value; }
            }

            public frmProjProdPrint()
            {
                  InitializeComponent();
                  projectsearch();
            }

            private void projectsearch()
            {
                  DataTable ProjectSearchData = new DataTable();
                  DataHelper dBHelper = new DataHelper();
                  ProjectSearchData = dBHelper.GetSearchProjectData(MainFunctions.ProdNum.ToString(), "eci");

                  ProjectSearchData.Columns.Add("DisplayString", typeof(System.String));

                  foreach (DataRow row in ProjectSearchData.Rows)
                  {
                        //need to set value to NewColumn column
                        row["DisplayString"] = row["PRODID"].ToString() + "    " + row["PRODPROJECT"].ToString() + "    " + row["PRODNAME"].ToString();   // or set it to some other value
                  }

                  lstProjects.DataSource = ProjectSearchData;
                  lstProjects.DisplayMember = "DisplayString";
                  lstProjects.ValueMember = "PRODID";
            }

            private void btnDone_Click(object sender, EventArgs e)
            {
                  ClickedDone();
            }

            private void lstProjects_DoubleClick(object sender, EventArgs e)
            {
                  ClickedDone();
            }

            private void ClickedDone()
            {
                  string strTemp;

                  if (lstProjects.Items.Count < 1)
                  {
                        strTemp = "You must select a job to continue. Please select a job and try again.";
                        MessageBox.Show(strTemp, "No Job Chosen", MessageBoxButtons.OK); // Display an error message
                        lstProjects.Focus();
                  }

                  try
                  {
                        DataRowView selecteditem = (DataRowView)lstProjects.SelectedItem;
                        ProductionID = selecteditem.Row["PRODID"].ToString();
                        ProductionNumber = selecteditem.Row["PRODPROJECT"].ToString();
                        ProductionName = selecteditem.Row["PRODNAME"].ToString();
                        ProductionUUID = selecteditem.Row["UUID"].ToString();
                  }
                  catch
                  {
                        MessageBox.Show("You need to select a job");
                        return;
                  }

                  this.Close();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                  this.Close();
                 // Application.Exit();
            }
      }
}
