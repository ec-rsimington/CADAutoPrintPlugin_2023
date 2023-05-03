using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CADAutoPrintPlugin_2023
{
      internal partial class frmProjectLead : Form, IProjLead
      {
            private string _projectLead;
            private int _productionNum;
            private bool _isMnfgPrint;

            public string ProjectLead
            {
                  get { return _projectLead; }
                  set { _projectLead = value; }
            }

            public int ProductionNumber
            {
                  get { return _productionNum; }
                  set { _productionNum = value; }
            }

            public bool IsMnfgPrint
            {
                  get { return _isMnfgPrint; }
                  set { _isMnfgPrint = value; }
            }
            public frmProjectLead()
            {
                  InitializeComponent();
            }

            private void frmProjectLead_Load(object sender, EventArgs e)
            {
                  // Set the instructions label
                  LabelPrompt();
            }

            private void btnDone_Click(object sender, EventArgs e)
            {
                  // Call the Done method
                  clickedDone();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                  //MainFunctions.CancelSelect();
                  this.Close();
                  //Application.Exit();
            }

            private void txtProjectLead_KeyPress(object sender, KeyPressEventArgs e)
            {
                  // If the user hits the Enter key while in the textbox call the Done method
                  if (e.KeyChar == (char)Keys.Enter)
                  {
                        clickedDone();
                        e.Handled = true;
                  }
            }

            private void clickedDone()
            {
                  string strTemp;

                  if (txtProjectLead.Text != "") // If some text was entered then
                  {
                        if (txtProjectLead.Text.Length > 18) // If they entered more than 18 characters then,
                        {
                              strTemp = "The name you have enetered is too long. Please enter a name that is 18 characters or less.";
                              MessageBox.Show(strTemp, "Entry Error", MessageBoxButtons.OK); // Display an error message
                              txtProjectLead.Text = ""; // Clear the textbox
                              txtProjectLead.Focus(); // Reset the focus to the textbox
                        }
                        else // The text enetered is <= 18 characters
                        {
                              if (!chkMnfgPrint.Checked) // If the Manufacturing Print checkbox is NOT checked then
                              {
                                    // Add the project Lead to the ProjectLead property
                                    ProjectLead = txtProjectLead.Text.ToUpper();

                                    // Set the Is Manufacturing Print property to false
                                    IsMnfgPrint = false;

                                    // Close the window
                                    this.Close();

                                    //var printListForm = new frmGetPrintList();
                                    //printListForm.ShowDialog();
                              }
                              else // Else if this is a Manufacturing Print then
                              {
                                    // Set the test default Production Number to 0
                                    int intProdNum = 0;

                                    // Check to see if the user has enetered a number
                                    bool IsNumeric = int.TryParse(txtProjectLead.Text, out intProdNum);

                                    if (IsNumeric)
                                    {
                                          // If the number is valid set it to the Production Number property
                                          ProductionNumber = intProdNum;

                                          // Close the form
                                          this.Close();

                                          //var projProdForm = new frmProjProdPrint();
                                          //projProdForm.ShowDialog();
                                    }
                                    else // If it is not a valid number then
                                    {
                                          strTemp = "You have not entered a valid Production Number. Please try again.";

                                          // Display an error message, clear the textbox and set the focus to the textbox.
                                          MessageBox.Show(strTemp, "Not a Valid Number", MessageBoxButtons.OK); // Display an error message
                                          txtProjectLead.Text = "";
                                          txtProjectLead.Focus(); // Reset the focus to the textbox
                                    }
                                    // Set the Is Manufacturing Print property to true
                                    IsMnfgPrint = true;
                              }
                        }
                  }
                  else // No text was entered
                  {
                        strTemp = "You must enter a name to be used for the Project Lead to continue.";

                        if (chkMnfgPrint.Checked)
                        {
                              strTemp = "You must enter a Production Number to continue.";
                        }

                        MessageBox.Show(strTemp, "No Value Error", MessageBoxButtons.OK); // Display an error message
                        txtProjectLead.Focus(); // Reset the focus to the textbox
                  }

                  //if (!IsMnfgPrint)
                  //{
                  //      var printListForm = new frmGetPrintList();
                  //      printListForm.ShowDialog();
                  //      //printFilePath = printListForm.LookupPath;

                  //      //SelectPrintFile();
                  //}
                  //else
                  //{
                  //      var projProdForm = new frmProjProdPrint();
                  //      projProdForm.ShowDialog();

                  //      //SelectProjectProduction();
                  //}
            }

            private void chkMnfgPrint_CheckedChanged(object sender, EventArgs e)
            {
                  // Whenever the checkbox is changed call LabelPrompt, clear the textbox, and reset the focus
                  LabelPrompt();
                  txtProjectLead.Text = "";
                  txtProjectLead.Focus();
            }

            private void LabelPrompt()
            {
                  if (!chkMnfgPrint.Checked) // If this is NOT a manufacturing print set to Project Lead
                  {
                        this.Text = "Project Lead";
                        lblPrompt.Text = "Please enter the name of the project lead.\n\nThe name you enter here will be printed in the ISSUED BY field of the title block."; // set the dialogs prompt;
                  }
                  else // Else if this is a manufacturing print set to Production Number
                  {
                        this.Text = "Production Number";
                        lblPrompt.Text = "Please enter the Production Number.\n\nThe number you enter here will be used for printing the 2D drawings."; // set the dialogs prompt;
                  }
            }
      }
}
