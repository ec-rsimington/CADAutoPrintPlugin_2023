
namespace CADAutoPrintPlugin_2023
{
    partial class frmGetPrintList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
                  this.lblInstructions = new System.Windows.Forms.Label();
                  this.grpDataOptions = new System.Windows.Forms.GroupBox();
                  this.cbxQuantity = new System.Windows.Forms.CheckBox();
                  this.cbxProjName = new System.Windows.Forms.CheckBox();
                  this.cbxProjNo = new System.Windows.Forms.CheckBox();
                  this.btnCancel = new System.Windows.Forms.Button();
                  this.btnDone = new System.Windows.Forms.Button();
                  this.txtSelectedFile = new System.Windows.Forms.TextBox();
                  this.lblLookupList = new System.Windows.Forms.Label();
                  this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                  this.btnOpenPrintList = new System.Windows.Forms.Button();
                  this.grpDataOptions.SuspendLayout();
                  this.SuspendLayout();
                  // 
                  // lblInstructions
                  // 
                  this.lblInstructions.AutoSize = true;
                  this.lblInstructions.Location = new System.Drawing.Point(14, 10);
                  this.lblInstructions.Name = "lblInstructions";
                  this.lblInstructions.Size = new System.Drawing.Size(415, 15);
                  this.lblInstructions.TabIndex = 6;
                  this.lblInstructions.Text = "Please locate the Print List to establish the list of items you would like printe" +
    "d.";
                  // 
                  // grpDataOptions
                  // 
                  this.grpDataOptions.Controls.Add(this.cbxQuantity);
                  this.grpDataOptions.Controls.Add(this.cbxProjName);
                  this.grpDataOptions.Controls.Add(this.cbxProjNo);
                  this.grpDataOptions.Location = new System.Drawing.Point(17, 95);
                  this.grpDataOptions.Name = "grpDataOptions";
                  this.grpDataOptions.Size = new System.Drawing.Size(250, 110);
                  this.grpDataOptions.TabIndex = 7;
                  this.grpDataOptions.TabStop = false;
                  this.grpDataOptions.Text = "Data Transfer Options";
                  // 
                  // cbxQuantity
                  // 
                  this.cbxQuantity.AutoSize = true;
                  this.cbxQuantity.Location = new System.Drawing.Point(16, 78);
                  this.cbxQuantity.Name = "cbxQuantity";
                  this.cbxQuantity.Size = new System.Drawing.Size(99, 19);
                  this.cbxQuantity.TabIndex = 2;
                  this.cbxQuantity.Text = "Item Quantity";
                  this.cbxQuantity.UseVisualStyleBackColor = true;
                  // 
                  // cbxProjName
                  // 
                  this.cbxProjName.AutoSize = true;
                  this.cbxProjName.Location = new System.Drawing.Point(16, 53);
                  this.cbxProjName.Name = "cbxProjName";
                  this.cbxProjName.Size = new System.Drawing.Size(98, 19);
                  this.cbxProjName.TabIndex = 1;
                  this.cbxProjName.Text = "Project Name";
                  this.cbxProjName.UseVisualStyleBackColor = true;
                  // 
                  // cbxProjNo
                  // 
                  this.cbxProjNo.AutoSize = true;
                  this.cbxProjNo.Location = new System.Drawing.Point(16, 28);
                  this.cbxProjNo.Name = "cbxProjNo";
                  this.cbxProjNo.Size = new System.Drawing.Size(110, 19);
                  this.cbxProjNo.TabIndex = 0;
                  this.cbxProjNo.Text = "Project Number";
                  this.cbxProjNo.UseVisualStyleBackColor = true;
                  // 
                  // btnCancel
                  // 
                  this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnCancel.Location = new System.Drawing.Point(452, 226);
                  this.btnCancel.Name = "btnCancel";
                  this.btnCancel.Size = new System.Drawing.Size(75, 23);
                  this.btnCancel.TabIndex = 8;
                  this.btnCancel.Text = "Cancel";
                  this.btnCancel.UseVisualStyleBackColor = true;
                  this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                  // 
                  // btnDone
                  // 
                  this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnDone.Location = new System.Drawing.Point(371, 226);
                  this.btnDone.Name = "btnDone";
                  this.btnDone.Size = new System.Drawing.Size(75, 23);
                  this.btnDone.TabIndex = 10;
                  this.btnDone.Text = "Continue";
                  this.btnDone.UseVisualStyleBackColor = true;
                  this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
                  // 
                  // txtSelectedFile
                  // 
                  this.txtSelectedFile.Location = new System.Drawing.Point(218, 44);
                  this.txtSelectedFile.Name = "txtSelectedFile";
                  this.txtSelectedFile.Size = new System.Drawing.Size(290, 23);
                  this.txtSelectedFile.TabIndex = 11;
                  this.txtSelectedFile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSelectedFile_KeyPress);
                  // 
                  // lblLookupList
                  // 
                  this.lblLookupList.Location = new System.Drawing.Point(132, 43);
                  this.lblLookupList.Name = "lblLookupList";
                  this.lblLookupList.Size = new System.Drawing.Size(80, 23);
                  this.lblLookupList.TabIndex = 12;
                  this.lblLookupList.Text = "Selected List:";
                  this.lblLookupList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                  // 
                  // openFileDialog1
                  // 
                  this.openFileDialog1.FileName = "openFileDialog1";
                  // 
                  // btnOpenPrintList
                  // 
                  this.btnOpenPrintList.Location = new System.Drawing.Point(17, 43);
                  this.btnOpenPrintList.Name = "btnOpenPrintList";
                  this.btnOpenPrintList.Size = new System.Drawing.Size(100, 23);
                  this.btnOpenPrintList.TabIndex = 13;
                  this.btnOpenPrintList.Text = "Open Print List";
                  this.btnOpenPrintList.UseVisualStyleBackColor = true;
                  this.btnOpenPrintList.Click += new System.EventHandler(this.btnOpenPrintList_Click);
                  // 
                  // frmGetPrintList
                  // 
                  this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                  this.ClientSize = new System.Drawing.Size(539, 261);
                  this.Controls.Add(this.btnOpenPrintList);
                  this.Controls.Add(this.lblLookupList);
                  this.Controls.Add(this.txtSelectedFile);
                  this.Controls.Add(this.btnDone);
                  this.Controls.Add(this.btnCancel);
                  this.Controls.Add(this.grpDataOptions);
                  this.Controls.Add(this.lblInstructions);
                  this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
                  this.MinimumSize = new System.Drawing.Size(555, 300);
                  this.Name = "frmGetPrintList";
                  this.ShowIcon = false;
                  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                  this.Text = "Locate Print List";
                  this.Load += new System.EventHandler(this.frmGetPrintList_Load);
                  this.grpDataOptions.ResumeLayout(false);
                  this.grpDataOptions.PerformLayout();
                  this.ResumeLayout(false);
                  this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.GroupBox grpDataOptions;
        private System.Windows.Forms.CheckBox cbxQuantity;
        private System.Windows.Forms.CheckBox cbxProjName;
        private System.Windows.Forms.CheckBox cbxProjNo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TextBox txtSelectedFile;
        private System.Windows.Forms.Label lblLookupList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenPrintList;
    }
}