
namespace CADAutoPrintPlugin_2023
{
    partial class frmSearchFolders
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
                  this.lblFolder = new System.Windows.Forms.Label();
                  this.lblSearchProgress = new System.Windows.Forms.Label();
                  this.prgFolderSearch = new System.Windows.Forms.ProgressBar();
                  this.btnAdd = new System.Windows.Forms.Button();
                  this.btnDone = new System.Windows.Forms.Button();
                  this.btnReset = new System.Windows.Forms.Button();
                  this.btnCancel = new System.Windows.Forms.Button();
                  this.btnRemove = new System.Windows.Forms.Button();
                  this.lstFolders = new System.Windows.Forms.ListBox();
                  this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
                  this.SuspendLayout();
                  // 
                  // lblInstructions
                  // 
                  this.lblInstructions.AutoSize = true;
                  this.lblInstructions.Location = new System.Drawing.Point(12, 9);
                  this.lblInstructions.Name = "lblInstructions";
                  this.lblInstructions.Size = new System.Drawing.Size(275, 15);
                  this.lblInstructions.TabIndex = 0;
                  this.lblInstructions.Text = "Please select the Folder(s) you would like searched.";
                  // 
                  // lblFolder
                  // 
                  this.lblFolder.Location = new System.Drawing.Point(21, 84);
                  this.lblFolder.Name = "lblFolder";
                  this.lblFolder.Size = new System.Drawing.Size(50, 15);
                  this.lblFolder.TabIndex = 2;
                  this.lblFolder.Text = "Folder:";
                  this.lblFolder.TextAlign = System.Drawing.ContentAlignment.TopRight;
                  // 
                  // lblSearchProgress
                  // 
                  this.lblSearchProgress.AutoSize = true;
                  this.lblSearchProgress.Location = new System.Drawing.Point(357, 47);
                  this.lblSearchProgress.Name = "lblSearchProgress";
                  this.lblSearchProgress.Size = new System.Drawing.Size(93, 15);
                  this.lblSearchProgress.TabIndex = 5;
                  this.lblSearchProgress.Text = "Search Progress:";
                  // 
                  // prgFolderSearch
                  // 
                  this.prgFolderSearch.Location = new System.Drawing.Point(456, 44);
                  this.prgFolderSearch.Name = "prgFolderSearch";
                  this.prgFolderSearch.Size = new System.Drawing.Size(250, 23);
                  this.prgFolderSearch.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                  this.prgFolderSearch.TabIndex = 6;
                  // 
                  // btnAdd
                  // 
                  this.btnAdd.Location = new System.Drawing.Point(77, 47);
                  this.btnAdd.Name = "btnAdd";
                  this.btnAdd.Size = new System.Drawing.Size(108, 27);
                  this.btnAdd.TabIndex = 8;
                  this.btnAdd.Text = "Add Folder";
                  this.btnAdd.UseVisualStyleBackColor = true;
                  this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                  // 
                  // btnDone
                  // 
                  this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnDone.Location = new System.Drawing.Point(500, 422);
                  this.btnDone.Name = "btnDone";
                  this.btnDone.Size = new System.Drawing.Size(108, 27);
                  this.btnDone.TabIndex = 9;
                  this.btnDone.Text = "Continue";
                  this.btnDone.UseVisualStyleBackColor = true;
                  this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
                  // 
                  // btnReset
                  // 
                  this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnReset.Location = new System.Drawing.Point(386, 422);
                  this.btnReset.Name = "btnReset";
                  this.btnReset.Size = new System.Drawing.Size(108, 27);
                  this.btnReset.TabIndex = 10;
                  this.btnReset.Text = "Reset";
                  this.btnReset.UseVisualStyleBackColor = true;
                  this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
                  // 
                  // btnCancel
                  // 
                  this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnCancel.Location = new System.Drawing.Point(614, 422);
                  this.btnCancel.Name = "btnCancel";
                  this.btnCancel.Size = new System.Drawing.Size(108, 27);
                  this.btnCancel.TabIndex = 11;
                  this.btnCancel.Text = "Cancel";
                  this.btnCancel.UseVisualStyleBackColor = true;
                  this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                  // 
                  // btnRemove
                  // 
                  this.btnRemove.Location = new System.Drawing.Point(77, 349);
                  this.btnRemove.Name = "btnRemove";
                  this.btnRemove.Size = new System.Drawing.Size(108, 27);
                  this.btnRemove.TabIndex = 12;
                  this.btnRemove.Text = "Remove Folder";
                  this.btnRemove.UseVisualStyleBackColor = true;
                  this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
                  // 
                  // lstFolders
                  // 
                  this.lstFolders.FormattingEnabled = true;
                  this.lstFolders.ItemHeight = 15;
                  this.lstFolders.Location = new System.Drawing.Point(77, 84);
                  this.lstFolders.Name = "lstFolders";
                  this.lstFolders.Size = new System.Drawing.Size(629, 259);
                  this.lstFolders.TabIndex = 13;
                  // 
                  // frmSearchFolders
                  // 
                  this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                  this.ClientSize = new System.Drawing.Size(734, 461);
                  this.Controls.Add(this.lstFolders);
                  this.Controls.Add(this.btnRemove);
                  this.Controls.Add(this.btnCancel);
                  this.Controls.Add(this.btnReset);
                  this.Controls.Add(this.btnDone);
                  this.Controls.Add(this.btnAdd);
                  this.Controls.Add(this.prgFolderSearch);
                  this.Controls.Add(this.lblSearchProgress);
                  this.Controls.Add(this.lblFolder);
                  this.Controls.Add(this.lblInstructions);
                  this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  this.MaximizeBox = false;
                  this.MaximumSize = new System.Drawing.Size(750, 500);
                  this.MinimizeBox = false;
                  this.MinimumSize = new System.Drawing.Size(750, 500);
                  this.Name = "frmSearchFolders";
                  this.ShowIcon = false;
                  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                  this.Text = "Select Search Folders";
                  this.Load += new System.EventHandler(this.frmSearchFolders_Load);
                  this.ResumeLayout(false);
                  this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label lblSearchProgress;
        private System.Windows.Forms.ProgressBar prgFolderSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lstFolders;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}