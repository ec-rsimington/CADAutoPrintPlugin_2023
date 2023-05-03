
namespace CADAutoPrintPlugin_2023
{
    partial class frmProjectLead
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
                  this.lblPrompt = new System.Windows.Forms.Label();
                  this.txtProjectLead = new System.Windows.Forms.TextBox();
                  this.btnDone = new System.Windows.Forms.Button();
                  this.btnCancel = new System.Windows.Forms.Button();
                  this.chkMnfgPrint = new System.Windows.Forms.CheckBox();
                  this.SuspendLayout();
                  // 
                  // lblPrompt
                  // 
                  this.lblPrompt.Location = new System.Drawing.Point(10, 7);
                  this.lblPrompt.Name = "lblPrompt";
                  this.lblPrompt.Size = new System.Drawing.Size(215, 66);
                  this.lblPrompt.TabIndex = 0;
                  // 
                  // txtProjectLead
                  // 
                  this.txtProjectLead.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                  this.txtProjectLead.Location = new System.Drawing.Point(10, 76);
                  this.txtProjectLead.Name = "txtProjectLead";
                  this.txtProjectLead.Size = new System.Drawing.Size(215, 22);
                  this.txtProjectLead.TabIndex = 1;
                  this.txtProjectLead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProjectLead_KeyPress);
                  // 
                  // btnDone
                  // 
                  this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnDone.Location = new System.Drawing.Point(69, 129);
                  this.btnDone.Name = "btnDone";
                  this.btnDone.Size = new System.Drawing.Size(75, 23);
                  this.btnDone.TabIndex = 2;
                  this.btnDone.Text = "Done";
                  this.btnDone.UseVisualStyleBackColor = true;
                  this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
                  // 
                  // btnCancel
                  // 
                  this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                  this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                  this.btnCancel.Location = new System.Drawing.Point(150, 129);
                  this.btnCancel.Name = "btnCancel";
                  this.btnCancel.Size = new System.Drawing.Size(75, 23);
                  this.btnCancel.TabIndex = 3;
                  this.btnCancel.Text = "Cancel";
                  this.btnCancel.UseVisualStyleBackColor = true;
                  this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                  // 
                  // chkMnfgPrint
                  // 
                  this.chkMnfgPrint.AutoSize = true;
                  this.chkMnfgPrint.Location = new System.Drawing.Point(10, 104);
                  this.chkMnfgPrint.Name = "chkMnfgPrint";
                  this.chkMnfgPrint.Size = new System.Drawing.Size(177, 17);
                  this.chkMnfgPrint.TabIndex = 4;
                  this.chkMnfgPrint.Text = "Is this a Manufacturing Print?";
                  this.chkMnfgPrint.UseVisualStyleBackColor = true;
                  this.chkMnfgPrint.CheckedChanged += new System.EventHandler(this.chkMnfgPrint_CheckedChanged);
                  // 
                  // frmProjectLead
                  // 
                  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                  this.CancelButton = this.btnCancel;
                  this.ClientSize = new System.Drawing.Size(234, 161);
                  this.Controls.Add(this.chkMnfgPrint);
                  this.Controls.Add(this.btnCancel);
                  this.Controls.Add(this.btnDone);
                  this.Controls.Add(this.txtProjectLead);
                  this.Controls.Add(this.lblPrompt);
                  this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  this.MaximizeBox = false;
                  this.MaximumSize = new System.Drawing.Size(250, 200);
                  this.MinimizeBox = false;
                  this.MinimumSize = new System.Drawing.Size(250, 200);
                  this.Name = "frmProjectLead";
                  this.ShowIcon = false;
                  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                  this.Text = "Project Lead";
                  this.Load += new System.EventHandler(this.frmProjectLead_Load);
                  this.ResumeLayout(false);
                  this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtProjectLead;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
            private System.Windows.Forms.CheckBox chkMnfgPrint;
      }
}