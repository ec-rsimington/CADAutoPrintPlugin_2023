using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace CADAutoPrintPlugin_2023
{
    public partial class frmSearchFolders : Form, ISearchFolders
    {
        readonly DriveInfo[] allDrives = DriveInfo.GetDrives();

        private string[] _folderList;

        public string[] strFolderList
        {
            get { return _folderList; }
            set { _folderList = value; }
        }

        public frmSearchFolders()
        {
            InitializeComponent();
        }

        private void frmSearchFolders_Load(object sender, EventArgs e)
        {
            resetForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string searchPath = MainFunctions.GetFolderPath();
            //CreateFolderList(searchPath);
            lstFolders.Items.Add(searchPath);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string strTemp;

            if (lstFolders.SelectedItems.Count == 0)
            {
                strTemp = "You have not selected a Path to remove. Please select a Path from the list and try again.";
                MessageBox.Show(strTemp, "Selection Error", MessageBoxButtons.OK); // Display an error message
                btnRemove.Focus();
            }
            else
            {
                for (int i = 0; i < lstFolders.SelectedItems.Count; i++)
                {
                    lstFolders.Items.RemoveAt(lstFolders.SelectedIndex);
                    i--;
                    continue;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            string strTemp;
            strFolderList = new string[lstFolders.Items.Count];

            if (lstFolders.Items.Count < 1)
            {
                strTemp = "You must have at least one Path to search to continue. Please select a Path and try again.";
                MessageBox.Show(strTemp, "No Folder Chosen", MessageBoxButtons.OK); // Display an error message
                btnAdd.Focus();
            }
            else
            {
                for (int i = 0; i <= lstFolders.Items.Count - 1; i++)
                {
                    strFolderList[i] = lstFolders.Items[i].ToString();
                }
            }
            this.Close();
        }

        private void resetForm()
        {
            lstFolders.Items.Clear();
            lstFolders.Items.Add("S:\\EID Drawings\\Project Drawings\\");
            lstFolders.Items.Add("S:\\EID Drawings\\Project Transfer Folder\\");
            lstFolders.Items.Add("S:\\EID Drawings\\Project Transfer Folder\\Project Revisions\\");
            lstFolders.Items.Add("S:\\EID Drawings\\Project Transfer Folder\\Updates without Revision\\");
        }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                  this.Close();
                  //Application.Exit();
            }
      }
}
