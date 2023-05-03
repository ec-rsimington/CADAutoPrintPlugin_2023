namespace CADAutoPrintPlugin_2023
{
    partial class frmMissingDwgs
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
                  this.lvwMissingDwgs = new System.Windows.Forms.ListView();
                  this.clmPartNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmCompType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.btnPrint = new System.Windows.Forms.Button();
                  this.btnDone = new System.Windows.Forms.Button();
                  this.lbPath = new System.Windows.Forms.Label();
                  this.btnCancel = new System.Windows.Forms.Button();
                  this.SuspendLayout();
                  // 
                  // lvwMissingDwgs
                  // 
                  this.lvwMissingDwgs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                  this.lvwMissingDwgs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPartNum,
            this.clmDescription,
            this.clmCompType,
            this.clmStatus});
                  this.lvwMissingDwgs.HideSelection = false;
                  this.lvwMissingDwgs.Location = new System.Drawing.Point(39, 39);
                  this.lvwMissingDwgs.Margin = new System.Windows.Forms.Padding(30, 30, 30, 75);
                  this.lvwMissingDwgs.Name = "lvwMissingDwgs";
                  this.lvwMissingDwgs.Size = new System.Drawing.Size(855, 396);
                  this.lvwMissingDwgs.TabIndex = 0;
                  this.lvwMissingDwgs.UseCompatibleStateImageBehavior = false;
                  this.lvwMissingDwgs.View = System.Windows.Forms.View.Details;
                  // 
                  // clmPartNum
                  // 
                  this.clmPartNum.Text = "Part Number";
                  this.clmPartNum.Width = 100;
                  // 
                  // clmDescription
                  // 
                  this.clmDescription.Text = "Description";
                  this.clmDescription.Width = 300;
                  // 
                  // clmCompType
                  // 
                  this.clmCompType.Text = "Component Type";
                  this.clmCompType.Width = 110;
                  // 
                  // clmStatus
                  // 
                  this.clmStatus.Text = "Status";
                  this.clmStatus.Width = 150;
                  // 
                  // btnPrint
                  // 
                  this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnPrint.Location = new System.Drawing.Point(630, 484);
                  this.btnPrint.Name = "btnPrint";
                  this.btnPrint.Size = new System.Drawing.Size(102, 23);
                  this.btnPrint.TabIndex = 1;
                  this.btnPrint.Text = "Print to PDF";
                  this.btnPrint.UseVisualStyleBackColor = true;
                  this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
                  // 
                  // btnDone
                  // 
                  this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnDone.Location = new System.Drawing.Point(738, 484);
                  this.btnDone.Name = "btnDone";
                  this.btnDone.Size = new System.Drawing.Size(75, 23);
                  this.btnDone.TabIndex = 2;
                  this.btnDone.Text = "Continue";
                  this.btnDone.UseVisualStyleBackColor = true;
                  this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
                  // 
                  // lbPath
                  // 
                  this.lbPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                  this.lbPath.AutoSize = true;
                  this.lbPath.Location = new System.Drawing.Point(36, 484);
                  this.lbPath.Name = "lbPath";
                  this.lbPath.Size = new System.Drawing.Size(78, 15);
                  this.lbPath.TabIndex = 3;
                  this.lbPath.Text = "PDF saved to:";
                  this.lbPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                  // 
                  // btnCancel
                  // 
                  this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnCancel.Location = new System.Drawing.Point(819, 484);
                  this.btnCancel.Name = "btnCancel";
                  this.btnCancel.Size = new System.Drawing.Size(75, 23);
                  this.btnCancel.TabIndex = 4;
                  this.btnCancel.Text = "Cancel";
                  this.btnCancel.UseVisualStyleBackColor = true;
                  this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                  // 
                  // frmMissingDwgs
                  // 
                  this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                  this.ClientSize = new System.Drawing.Size(933, 519);
                  this.Controls.Add(this.btnCancel);
                  this.Controls.Add(this.lbPath);
                  this.Controls.Add(this.btnDone);
                  this.Controls.Add(this.btnPrint);
                  this.Controls.Add(this.lvwMissingDwgs);
                  this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                  this.MaximizeBox = false;
                  this.MinimizeBox = false;
                  this.Name = "frmMissingDwgs";
                  this.ShowIcon = false;
                  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                  this.Text = "Missing Drawings";
                  this.Load += new System.EventHandler(this.frmMissingDwgs_Load);
                  this.ResumeLayout(false);
                  this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwMissingDwgs;
        private System.Windows.Forms.ColumnHeader clmPartNum;
        private System.Windows.Forms.ColumnHeader clmDescription;
        private System.Windows.Forms.ColumnHeader clmCompType;
        private System.Windows.Forms.ColumnHeader clmStatus;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lbPath;
            private System.Windows.Forms.Button btnCancel;
      }
}