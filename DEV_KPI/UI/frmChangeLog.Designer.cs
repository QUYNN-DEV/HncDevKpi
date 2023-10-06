namespace DEV_KPI.UI
{
    partial class frmChangeLog
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
            this.txtChangeLog = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChangeLog.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtChangeLog
            // 
            this.txtChangeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChangeLog.EditValue = "";
            this.txtChangeLog.Location = new System.Drawing.Point(0, 0);
            this.txtChangeLog.Name = "txtChangeLog";
            this.txtChangeLog.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtChangeLog.Properties.Appearance.Options.UseFont = true;
            this.txtChangeLog.Properties.ReadOnly = true;
            this.txtChangeLog.Size = new System.Drawing.Size(626, 403);
            this.txtChangeLog.TabIndex = 0;
            this.txtChangeLog.TabStop = false;
            // 
            // frmChangeLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 403);
            this.Controls.Add(this.txtChangeLog);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Có gì mới trong phiên bản này?";
            this.Load += new System.EventHandler(this.frmChangeLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtChangeLog.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtChangeLog;
    }
}