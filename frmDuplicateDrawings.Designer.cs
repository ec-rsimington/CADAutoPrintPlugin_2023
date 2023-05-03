namespace CADAutoPrintPlugin_2023
{
    partial class frmDuplicateDrawings
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
                  this.lstOptions = new System.Windows.Forms.ListBox();
                  this.btnDone = new System.Windows.Forms.Button();
                  this.btnCancel = new System.Windows.Forms.Button();
                  this.SuspendLayout();
                  // 
                  // lblInstructions
                  // 
                  this.lblInstructions.AutoSize = true;
                  this.lblInstructions.Location = new System.Drawing.Point(14, 10);
                  this.lblInstructions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                  this.lblInstructions.Name = "lblInstructions";
                  this.lblInstructions.Size = new System.Drawing.Size(157, 15);
                  this.lblInstructions.TabIndex = 0;
                  this.lblInstructions.Text = "Please select the file to print.";
                  // 
                  // lstOptions
                  // 
                  this.lstOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                  this.lstOptions.FormattingEnabled = true;
                  this.lstOptions.ItemHeight = 15;
                  this.lstOptions.Location = new System.Drawing.Point(17, 28);
                  this.lstOptions.Name = "lstOptions";
                  this.lstOptions.Size = new System.Drawing.Size(505, 94);
                  this.lstOptions.TabIndex = 1;
                  this.lstOptions.DoubleClick += new System.EventHandler(this.lstOptions_DoubleClick);
                  // 
                  // btnDone
                  // 
                  this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnDone.Location = new System.Drawing.Point(366, 141);
                  this.btnDone.Name = "btnDone";
                  this.btnDone.Size = new System.Drawing.Size(75, 23);
                  this.btnDone.TabIndex = 2;
                  this.btnDone.Text = "Continue";
                  this.btnDone.UseVisualStyleBackColor = true;
                  this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
                  // 
                  // btnCancel
                  // 
                  this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnCancel.Location = new System.Drawing.Point(447, 141);
                  this.btnCancel.Name = "btnCancel";
                  this.btnCancel.Size = new System.Drawing.Size(75, 23);
                  this.btnCancel.TabIndex = 3;
                  this.btnCancel.Text = "Cancel";
                  this.btnCancel.UseVisualStyleBackColor = true;
                  this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                  // 
                  // frmDuplicateDrawings
                  // 
                  this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                  this.ClientSize = new System.Drawing.Size(534, 176);
                  this.Controls.Add(this.btnCancel);
                  this.Controls.Add(this.btnDone);
                  this.Controls.Add(this.lstOptions);
                  this.Controls.Add(this.lblInstructions);
                  this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                  this.MaximizeBox = false;
                  this.MaximumSize = new System.Drawing.Size(550, 215);
                  this.MinimizeBox = false;
                  this.MinimumSize = new System.Drawing.Size(550, 215);
                  this.Name = "frmDuplicateDrawings";
                  this.ShowIcon = false;
                  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                  this.Text = "Duplicate Drawings Found";
                  this.Load += new System.EventHandler(this.frmDuplicateDrawings_Load);
                  this.ResumeLayout(false);
                  this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.ListBox lstOptions;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
    }
}