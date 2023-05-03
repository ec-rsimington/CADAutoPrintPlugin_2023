namespace CADAutoPrintPlugin_2023
{
      partial class frmProjProdPrint
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
                  this.lstProjects = new System.Windows.Forms.ListBox();
                  this.btnCancel = new System.Windows.Forms.Button();
                  this.btnDone = new System.Windows.Forms.Button();
                  this.SuspendLayout();
                  // 
                  // lblInstructions
                  // 
                  this.lblInstructions.AutoSize = true;
                  this.lblInstructions.Location = new System.Drawing.Point(19, 19);
                  this.lblInstructions.Margin = new System.Windows.Forms.Padding(10, 10, 10, 3);
                  this.lblInstructions.Name = "lblInstructions";
                  this.lblInstructions.Size = new System.Drawing.Size(223, 13);
                  this.lblInstructions.TabIndex = 7;
                  this.lblInstructions.Text = "Please select a Project you would like printed.";
                  // 
                  // lstProjects
                  // 
                  this.lstProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                  this.lstProjects.FormattingEnabled = true;
                  this.lstProjects.Location = new System.Drawing.Point(19, 38);
                  this.lstProjects.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
                  this.lstProjects.Name = "lstProjects";
                  this.lstProjects.Size = new System.Drawing.Size(501, 121);
                  this.lstProjects.TabIndex = 8;
                  this.lstProjects.DoubleClick += new System.EventHandler(this.lstProjects_DoubleClick);
                  // 
                  // btnCancel
                  // 
                  this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnCancel.Location = new System.Drawing.Point(445, 176);
                  this.btnCancel.Name = "btnCancel";
                  this.btnCancel.Size = new System.Drawing.Size(75, 23);
                  this.btnCancel.TabIndex = 9;
                  this.btnCancel.Text = "Cancel";
                  this.btnCancel.UseVisualStyleBackColor = true;
                  this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                  // 
                  // btnDone
                  // 
                  this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnDone.Location = new System.Drawing.Point(364, 176);
                  this.btnDone.Name = "btnDone";
                  this.btnDone.Size = new System.Drawing.Size(75, 23);
                  this.btnDone.TabIndex = 10;
                  this.btnDone.Text = "Continue";
                  this.btnDone.UseVisualStyleBackColor = true;
                  this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
                  // 
                  // frmProjProdPrint
                  // 
                  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                  this.ClientSize = new System.Drawing.Size(539, 211);
                  this.Controls.Add(this.btnDone);
                  this.Controls.Add(this.btnCancel);
                  this.Controls.Add(this.lstProjects);
                  this.Controls.Add(this.lblInstructions);
                  this.MaximizeBox = false;
                  this.MaximumSize = new System.Drawing.Size(555, 250);
                  this.MinimizeBox = false;
                  this.MinimumSize = new System.Drawing.Size(555, 250);
                  this.Name = "frmProjProdPrint";
                  this.ShowIcon = false;
                  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                  this.Text = "Project Production Orders";
                  this.ResumeLayout(false);
                  this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Label lblInstructions;
            private System.Windows.Forms.ListBox lstProjects;
            private System.Windows.Forms.Button btnCancel;
            private System.Windows.Forms.Button btnDone;
      }
}