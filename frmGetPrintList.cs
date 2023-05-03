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
    public partial class frmGetPrintList : Form, ILookUp
    {
        private string _lookupPath;
        private bool _bolProjNum;
        private bool _bolProjName;
        private bool _bolItemQty;
        public string LookupPath
        {
            get { return _lookupPath; }
            set { _lookupPath = value; }
        }

        public bool bolProjNum
        {
            get { return _bolProjNum; }
            set { _bolProjNum = value; }
        }

        public bool bolProjName
        {
            get { return _bolProjName; }
            set { _bolProjName = value; }
        }

        public bool bolItemQty
        {
            get { return _bolItemQty; }
            set { _bolItemQty = value; }
        }

        public frmGetPrintList()
        {
            InitializeComponent();
        }

        private void frmGetPrintList_Load(object sender, EventArgs e)
        {
            cbxProjNo.CheckState = CheckState.Checked;
            cbxProjName.CheckState = CheckState.Checked;
            cbxQuantity.CheckState = CheckState.Checked;
        }

        private void btnOpenPrintList_Click(object sender, EventArgs e)
        {
            string printListPath = MainFunctions.OpenPrintList(); // Browse to the Print List

            txtSelectedFile.Text = printListPath; // Show the selected file
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            clickedDone();
        }

        private void txtSelectedFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                clickedDone();
                e.Handled = true;
            }
        }

        private void clickedDone()
        {
            string strTemp;

            if (txtSelectedFile.Text == "") // If no file was selected then
            {
                strTemp = "You must select a valid Print File to continue.";
                MessageBox.Show(strTemp, "No Value Error", MessageBoxButtons.OK); // Display an error message
                txtSelectedFile.Focus(); // Reset the focus to the textbox
            }
            else // A file was selected
            {
                LookupPath = txtSelectedFile.Text; // Pass the file to the main program

                if (cbxProjName.CheckState==0) // If the checkbox is unchecked then,
                {
                    bolProjNum = false;
                }
                else // The checkbox is checked so
                {
                    bolProjNum = true;
                }

                if (cbxProjName.CheckState == 0) // If the checkbox is unchecked then,
                {
                    bolProjName = false;
                }
                else // The checkbox is checked so
                {
                    bolProjName = true;
                }

                if (cbxQuantity.CheckState == 0) // If the checkbox is unchecked then,
                {
                    bolItemQty = false;
                }
                else // The checkbox is checked so
                {
                    bolItemQty = true;
                }
                this.Close();
            }
        }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                  //MainFunctions.Cancel();
                  this.Close();
                  //Application.Exit();
            }
      }
}
