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
      public partial class frmDuplicateDrawings : Form, IDuplicates
      {
            private string _selecteddrawing;
            private string[] _duplicatefiles;

            public string selectedDrawing
            {
                  get { return _selecteddrawing; }
                  set { _selecteddrawing = value; }
            }

            public string[] duplicateFiles
            {
                  get { return _duplicatefiles; }
                  set { _duplicatefiles = value; }
            }
            public frmDuplicateDrawings()
            {
                  InitializeComponent();
            }

            private void frmDuplicateDrawings_Load(object sender, EventArgs e)
            {
                  foreach (string dFile in duplicateFiles)
                  {
                        lstOptions.Items.Add(dFile);
                  }
            }

            private void btnDone_Click(object sender, EventArgs e)
            {
                  string strTemp;
                  if (lstOptions.SelectedIndex > -1)
                  {
                        selectedDrawing = lstOptions.SelectedItem.ToString();
                        this.Close();
                  }
                  else
                  {
                        strTemp = "You have not selected a Drawing to print. Please select a Drawing from the list and try again.";
                        MessageBox.Show(strTemp, "Selection Error", MessageBoxButtons.OK); // Display an error message
                        btnDone.Focus();
                  }
            }

            private void lstOptions_DoubleClick(object sender, EventArgs e)
            {
                  btnDone_Click(sender, e);
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                  this.Close();
                 // Application.Exit();
            }
      }
}
