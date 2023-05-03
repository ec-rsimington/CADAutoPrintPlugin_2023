namespace CADAutoPrintPlugin_2023
{
    partial class frmSelectDrawings
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
                  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectDrawings));
                  this.lblInstructions = new System.Windows.Forms.Label();
                  this.btnAddAll = new System.Windows.Forms.Button();
                  this.btnRemoveAll = new System.Windows.Forms.Button();
                  this.btnDone = new System.Windows.Forms.Button();
                  this.btnCancel = new System.Windows.Forms.Button();
                  this.lvwAllDwgs = new System.Windows.Forms.ListView();
                  this.clmPartNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmCompType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.lvwPrintDwgs = new System.Windows.Forms.ListView();
                  this.clmPrPartNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmPrDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmPrCompType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.clmPrStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                  this.lblAllItems = new System.Windows.Forms.Label();
                  this.lblPrintList = new System.Windows.Forms.Label();
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
            this.clmPartNum,
            this.clmDescription,
            this.clmCompType,
            this.clmStatus});
                  this.lvwAllDwgs.FullRowSelect = true;
                  this.lvwAllDwgs.HideSelection = false;
                  this.lvwAllDwgs.Location = new System.Drawing.Point(19, 91);
                  this.lvwAllDwgs.Margin = new System.Windows.Forms.Padding(10);
                  this.lvwAllDwgs.Name = "lvwAllDwgs";
                  this.lvwAllDwgs.Size = new System.Drawing.Size(600, 406);
                  this.lvwAllDwgs.TabIndex = 9;
                  this.lvwAllDwgs.UseCompatibleStateImageBehavior = false;
                  this.lvwAllDwgs.View = System.Windows.Forms.View.Details;
                  this.lvwAllDwgs.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwAllDwgs_ItemDrag);
                  this.lvwAllDwgs.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwAllDwgs_DragDrop);
                  this.lvwAllDwgs.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwAllDwgs_DragEnter);
                  // 
                  // clmPartNum
                  // 
                  this.clmPartNum.Text = "Part Number";
                  this.clmPartNum.Width = 80;
                  // 
                  // clmDescription
                  // 
                  this.clmDescription.Text = "Description";
                  this.clmDescription.Width = 340;
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
                  // lvwPrintDwgs
                  // 
                  this.lvwPrintDwgs.AllowDrop = true;
                  this.lvwPrintDwgs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                  this.lvwPrintDwgs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPrPartNum,
            this.clmPrDescription,
            this.clmPrCompType,
            this.clmPrStatus});
                  this.lvwPrintDwgs.FullRowSelect = true;
                  this.lvwPrintDwgs.HideSelection = false;
                  this.lvwPrintDwgs.Location = new System.Drawing.Point(635, 91);
                  this.lvwPrintDwgs.Margin = new System.Windows.Forms.Padding(10);
                  this.lvwPrintDwgs.Name = "lvwPrintDwgs";
                  this.lvwPrintDwgs.Size = new System.Drawing.Size(600, 406);
                  this.lvwPrintDwgs.TabIndex = 10;
                  this.lvwPrintDwgs.UseCompatibleStateImageBehavior = false;
                  this.lvwPrintDwgs.View = System.Windows.Forms.View.Details;
                  this.lvwPrintDwgs.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwPrintDwgs_ItemDrag);
                  this.lvwPrintDwgs.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwPrintDwgs_DragDrop);
                  this.lvwPrintDwgs.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwPrintDwgs_DragEnter);
                  // 
                  // clmPrPartNum
                  // 
                  this.clmPrPartNum.Text = "Part Number";
                  this.clmPrPartNum.Width = 80;
                  // 
                  // clmPrDescription
                  // 
                  this.clmPrDescription.Text = "Description";
                  this.clmPrDescription.Width = 340;
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
                  // lblAllItems
                  // 
                  this.lblAllItems.AutoSize = true;
                  this.lblAllItems.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  this.lblAllItems.Location = new System.Drawing.Point(24, 70);
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
                  this.lblPrintList.Location = new System.Drawing.Point(642, 70);
                  this.lblPrintList.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
                  this.lblPrintList.Name = "lblPrintList";
                  this.lblPrintList.Size = new System.Drawing.Size(117, 17);
                  this.lblPrintList.TabIndex = 12;
                  this.lblPrintList.Text = "Drawings to Print";
                  // 
                  // frmSelectDrawings
                  // 
                  this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                  this.ClientSize = new System.Drawing.Size(1254, 561);
                  this.Controls.Add(this.lvwPrintDwgs);
                  this.Controls.Add(this.lvwAllDwgs);
                  this.Controls.Add(this.btnCancel);
                  this.Controls.Add(this.btnDone);
                  this.Controls.Add(this.btnRemoveAll);
                  this.Controls.Add(this.btnAddAll);
                  this.Controls.Add(this.lblInstructions);
                  this.Controls.Add(this.lblPrintList);
                  this.Controls.Add(this.lblAllItems);
                  this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                  this.MaximizeBox = false;
                  this.MaximumSize = new System.Drawing.Size(1270, 600);
                  this.MinimizeBox = false;
                  this.MinimumSize = new System.Drawing.Size(1270, 600);
                  this.Name = "frmSelectDrawings";
                  this.ShowIcon = false;
                  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                  this.Text = "Select Drawings to Print";
                  this.Load += new System.EventHandler(this.frmSelectDrawings_Load);
                  this.ResumeLayout(false);
                  this.PerformLayout();

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
      }
}