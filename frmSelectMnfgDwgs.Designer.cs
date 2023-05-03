namespace CADAutoPrintPlugin_2023
{
      partial class frmSelectMnfgDwgs
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
                  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectMnfgDwgs));
                  this.lblInstructions = new System.Windows.Forms.Label();
                  this.btnAddAll = new System.Windows.Forms.Button();
                  this.btnRemoveAll = new System.Windows.Forms.Button();
                  this.btnDone = new System.Windows.Forms.Button();
                  this.btnCancel = new System.Windows.Forms.Button();
                  this.lvwAllDwgs = new System.Windows.Forms.ListView();
                  this.clmnProdID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmPartNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmnRev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmnQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmnFinish = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmCompType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmDwgStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmDwgPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.lvwPrintDwgs = new System.Windows.Forms.ListView();
                  this.clmnPrProdID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmPrPartNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmPrDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmnPrRev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmnPrQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmnPrFinish = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmPrCompType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmPrStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmPrDwgStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmPrDwgPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.lblAllItems = new System.Windows.Forms.Label();
                  this.lblPrintList = new System.Windows.Forms.Label();
                  this.splitContainer1 = new System.Windows.Forms.SplitContainer();
                  ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
                  this.splitContainer1.Panel1.SuspendLayout();
                  this.splitContainer1.Panel2.SuspendLayout();
                  this.splitContainer1.SuspendLayout();
                  this.SuspendLayout();
                  // 
                  // lblInstructions
                  // 
                  this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                  this.lblInstructions.Location = new System.Drawing.Point(21, 22);
                  this.lblInstructions.Margin = new System.Windows.Forms.Padding(12, 12, 12, 0);
                  this.lblInstructions.Name = "lblInstructions";
                  this.lblInstructions.Size = new System.Drawing.Size(1212, 48);
                  this.lblInstructions.TabIndex = 0;
                  this.lblInstructions.Text = resources.GetString("lblInstructions.Text");
                  // 
                  // btnAddAll
                  // 
                  this.btnAddAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnAddAll.Location = new System.Drawing.Point(508, 515);
                  this.btnAddAll.Name = "btnAddAll";
                  this.btnAddAll.Size = new System.Drawing.Size(111, 27);
                  this.btnAddAll.TabIndex = 3;
                  this.btnAddAll.Text = "Add All >>>";
                  this.btnAddAll.UseVisualStyleBackColor = true;
                  this.btnAddAll.Visible = false;
                  // 
                  // btnRemoveAll
                  // 
                  this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnRemoveAll.Location = new System.Drawing.Point(635, 515);
                  this.btnRemoveAll.Name = "btnRemoveAll";
                  this.btnRemoveAll.Size = new System.Drawing.Size(111, 27);
                  this.btnRemoveAll.TabIndex = 6;
                  this.btnRemoveAll.Text = "<<< Remove All";
                  this.btnRemoveAll.UseVisualStyleBackColor = true;
                  this.btnRemoveAll.Visible = false;
                  // 
                  // btnDone
                  // 
                  this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnDone.Location = new System.Drawing.Point(1065, 517);
                  this.btnDone.Margin = new System.Windows.Forms.Padding(10);
                  this.btnDone.Name = "btnDone";
                  this.btnDone.Size = new System.Drawing.Size(75, 25);
                  this.btnDone.TabIndex = 7;
                  this.btnDone.Text = "Continue";
                  this.btnDone.UseVisualStyleBackColor = true;
                  this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
                  // 
                  // btnCancel
                  // 
                  this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnCancel.Location = new System.Drawing.Point(1160, 517);
                  this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
                  this.btnCancel.Name = "btnCancel";
                  this.btnCancel.Size = new System.Drawing.Size(75, 25);
                  this.btnCancel.TabIndex = 8;
                  this.btnCancel.Text = "Cancel";
                  this.btnCancel.UseVisualStyleBackColor = true;
                  this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                  // 
                  // lvwAllDwgs
                  // 
                  this.lvwAllDwgs.AllowDrop = true;
                  this.lvwAllDwgs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                  this.lvwAllDwgs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnProdID,
            this.clmPartNum,
            this.clmDescription,
            this.clmnRev,
            this.clmnQty,
            this.clmnFinish,
            this.clmCompType,
            this.clmStatus,
            this.clmDwgStatus,
            this.clmDwgPath});
                  this.lvwAllDwgs.FullRowSelect = true;
                  this.lvwAllDwgs.HideSelection = false;
                  this.lvwAllDwgs.Location = new System.Drawing.Point(13, 25);
                  this.lvwAllDwgs.Margin = new System.Windows.Forms.Padding(10);
                  this.lvwAllDwgs.Name = "lvwAllDwgs";
                  this.lvwAllDwgs.Size = new System.Drawing.Size(576, 387);
                  this.lvwAllDwgs.TabIndex = 9;
                  this.lvwAllDwgs.UseCompatibleStateImageBehavior = false;
                  this.lvwAllDwgs.View = System.Windows.Forms.View.Details;
                  this.lvwAllDwgs.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwAllDwgs_ItemDrag);
                  this.lvwAllDwgs.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwAllDwgs_DragDrop);
                  this.lvwAllDwgs.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwAllDwgs_DragEnter);
                  // 
                  // clmnProdID
                  // 
                  this.clmnProdID.Text = "Prod No.";
                  // 
                  // clmPartNum
                  // 
                  this.clmPartNum.Text = "Part No.";
                  this.clmPartNum.Width = 80;
                  // 
                  // clmDescription
                  // 
                  this.clmDescription.Text = "Description";
                  this.clmDescription.Width = 100;
                  // 
                  // clmnRev
                  // 
                  this.clmnRev.Text = "Rev";
                  // 
                  // clmnQty
                  // 
                  this.clmnQty.Text = "Qty";
                  // 
                  // clmnFinish
                  // 
                  this.clmnFinish.Text = "Finish";
                  // 
                  // clmCompType
                  // 
                  this.clmCompType.Text = "Comp Type";
                  this.clmCompType.Width = 80;
                  // 
                  // clmStatus
                  // 
                  this.clmStatus.Text = "Status";
                  this.clmStatus.Width = 100;
                  // 
                  // clmDwgStatus
                  // 
                  this.clmDwgStatus.Text = "Drawing Status";
                  this.clmDwgStatus.Width = 0;
                  // 
                  // clmDwgPath
                  // 
                  this.clmDwgPath.Text = "Drawing Path";
                  this.clmDwgPath.Width = 0;
                  // 
                  // lvwPrintDwgs
                  // 
                  this.lvwPrintDwgs.AllowDrop = true;
                  this.lvwPrintDwgs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                  this.lvwPrintDwgs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnPrProdID,
            this.clmPrPartNum,
            this.clmPrDescription,
            this.clmnPrRev,
            this.clmnPrQty,
            this.clmnPrFinish,
            this.clmPrCompType,
            this.clmPrStatus,
            this.clmPrDwgStatus,
            this.clmPrDwgPath});
                  this.lvwPrintDwgs.FullRowSelect = true;
                  this.lvwPrintDwgs.HideSelection = false;
                  this.lvwPrintDwgs.Location = new System.Drawing.Point(13, 25);
                  this.lvwPrintDwgs.Margin = new System.Windows.Forms.Padding(10);
                  this.lvwPrintDwgs.Name = "lvwPrintDwgs";
                  this.lvwPrintDwgs.Size = new System.Drawing.Size(575, 387);
                  this.lvwPrintDwgs.TabIndex = 10;
                  this.lvwPrintDwgs.UseCompatibleStateImageBehavior = false;
                  this.lvwPrintDwgs.View = System.Windows.Forms.View.Details;
                  this.lvwPrintDwgs.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwPrintDwgs_ItemDrag);
                  this.lvwPrintDwgs.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwPrintDwgs_DragDrop);
                  this.lvwPrintDwgs.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwPrintDwgs_DragEnter);
                  // 
                  // clmnPrProdID
                  // 
                  this.clmnPrProdID.Text = "Prod No.";
                  // 
                  // clmPrPartNum
                  // 
                  this.clmPrPartNum.Text = "Part Number";
                  this.clmPrPartNum.Width = 80;
                  // 
                  // clmPrDescription
                  // 
                  this.clmPrDescription.Text = "Description";
                  this.clmPrDescription.Width = 100;
                  // 
                  // clmnPrRev
                  // 
                  this.clmnPrRev.Text = "Rev";
                  // 
                  // clmnPrQty
                  // 
                  this.clmnPrQty.Text = "Qty";
                  // 
                  // clmnPrFinish
                  // 
                  this.clmnPrFinish.Text = "Finish";
                  // 
                  // clmPrCompType
                  // 
                  this.clmPrCompType.Text = "Comp Type";
                  this.clmPrCompType.Width = 80;
                  // 
                  // clmPrStatus
                  // 
                  this.clmPrStatus.Text = "Status";
                  this.clmPrStatus.Width = 100;
                  // 
                  // clmPrDwgStatus
                  // 
                  this.clmPrDwgStatus.Text = "Drawing Status";
                  this.clmPrDwgStatus.Width = 0;
                  // 
                  // clmPrDwgPath
                  // 
                  this.clmPrDwgPath.Text = "Drawing Path";
                  this.clmPrDwgPath.Width = 0;
                  // 
                  // lblAllItems
                  // 
                  this.lblAllItems.AutoSize = true;
                  this.lblAllItems.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  this.lblAllItems.Location = new System.Drawing.Point(18, 0);
                  this.lblAllItems.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
                  this.lblAllItems.Name = "lblAllItems";
                  this.lblAllItems.Size = new System.Drawing.Size(87, 17);
                  this.lblAllItems.TabIndex = 11;
                  this.lblAllItems.Text = "All Drawings";
                  // 
                  // lblPrintList
                  // 
                  this.lblPrintList.AutoSize = true;
                  this.lblPrintList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  this.lblPrintList.Location = new System.Drawing.Point(10, 0);
                  this.lblPrintList.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
                  this.lblPrintList.Name = "lblPrintList";
                  this.lblPrintList.Size = new System.Drawing.Size(117, 17);
                  this.lblPrintList.TabIndex = 12;
                  this.lblPrintList.Text = "Drawings to Print";
                  this.lblPrintList.Click += new System.EventHandler(this.lblPrintList_Click);
                  // 
                  // splitContainer1
                  // 
                  this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                  this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                  this.splitContainer1.Location = new System.Drawing.Point(24, 70);
                  this.splitContainer1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
                  this.splitContainer1.Name = "splitContainer1";
                  // 
                  // splitContainer1.Panel1
                  // 
                  this.splitContainer1.Panel1.Controls.Add(this.lblAllItems);
                  this.splitContainer1.Panel1.Controls.Add(this.lvwAllDwgs);
                  this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3, 15, 3, 10);
                  // 
                  // splitContainer1.Panel2
                  // 
                  this.splitContainer1.Panel2.Controls.Add(this.lvwPrintDwgs);
                  this.splitContainer1.Panel2.Controls.Add(this.lblPrintList);
                  this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
                  this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3, 15, 3, 10);
                  this.splitContainer1.Size = new System.Drawing.Size(1211, 434);
                  this.splitContainer1.SplitterDistance = 604;
                  this.splitContainer1.TabIndex = 13;
                  // 
                  // frmSelectMnfgDwgs
                  // 
                  this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                  this.ClientSize = new System.Drawing.Size(1254, 561);
                  this.Controls.Add(this.btnCancel);
                  this.Controls.Add(this.btnDone);
                  this.Controls.Add(this.btnRemoveAll);
                  this.Controls.Add(this.btnAddAll);
                  this.Controls.Add(this.lblInstructions);
                  this.Controls.Add(this.splitContainer1);
                  this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                  this.MinimizeBox = false;
                  this.MinimumSize = new System.Drawing.Size(1270, 600);
                  this.Name = "frmSelectMnfgDwgs";
                  this.ShowIcon = false;
                  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                  this.Text = "Select Drawings to Print";
                  this.Load += new System.EventHandler(this.frmSelectDrawings_Load);
                  this.splitContainer1.Panel1.ResumeLayout(false);
                  this.splitContainer1.Panel1.PerformLayout();
                  this.splitContainer1.Panel2.ResumeLayout(false);
                  this.splitContainer1.Panel2.PerformLayout();
                  ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
                  this.splitContainer1.ResumeLayout(false);
                  this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Label lblInstructions;
            private System.Windows.Forms.Button btnAddAll;
            private System.Windows.Forms.Button btnRemoveAll;
            private System.Windows.Forms.Button btnDone;
            private System.Windows.Forms.Button btnCancel;
            private System.Windows.Forms.ListView lvwAllDwgs;
            private System.Windows.Forms.ListView lvwPrintDwgs;
            private System.Windows.Forms.Label lblAllItems;
            private System.Windows.Forms.Label lblPrintList;
            private System.Windows.Forms.ColumnHeader clmPartNum;
            private System.Windows.Forms.ColumnHeader clmDescription;
            private System.Windows.Forms.ColumnHeader clmCompType;
            private System.Windows.Forms.ColumnHeader clmStatus;
            private System.Windows.Forms.ColumnHeader clmPrPartNum;
            private System.Windows.Forms.ColumnHeader clmPrDescription;
            private System.Windows.Forms.ColumnHeader clmPrCompType;
            private System.Windows.Forms.ColumnHeader clmPrStatus;
            private System.Windows.Forms.ColumnHeader clmnProdID;
            private System.Windows.Forms.ColumnHeader clmnRev;
            private System.Windows.Forms.ColumnHeader clmnQty;
            private System.Windows.Forms.ColumnHeader clmnFinish;
            private System.Windows.Forms.ColumnHeader clmnPrProdID;
            private System.Windows.Forms.ColumnHeader clmnPrRev;
            private System.Windows.Forms.ColumnHeader clmnPrQty;
            private System.Windows.Forms.ColumnHeader clmnPrFinish;
            private System.Windows.Forms.SplitContainer splitContainer1;
            private System.Windows.Forms.ColumnHeader clmDwgStatus;
            private System.Windows.Forms.ColumnHeader clmDwgPath;
            private System.Windows.Forms.ColumnHeader clmPrDwgStatus;
            private System.Windows.Forms.ColumnHeader clmPrDwgPath;
      }
}