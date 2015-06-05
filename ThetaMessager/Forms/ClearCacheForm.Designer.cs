namespace ThetaMessager.Forms
{
    partial class ClearCacheForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClearCacheForm));
            this.clearProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // clearProgressBar
            // 
            this.clearProgressBar.Location = new System.Drawing.Point(12, 12);
            this.clearProgressBar.MaximumSize = new System.Drawing.Size(267, 23);
            this.clearProgressBar.MinimumSize = new System.Drawing.Size(267, 23);
            this.clearProgressBar.Name = "clearProgressBar";
            this.clearProgressBar.Size = new System.Drawing.Size(267, 23);
            this.clearProgressBar.TabIndex = 0;
            // 
            // ClearCacheForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 46);
            this.Controls.Add(this.clearProgressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClearCacheForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "清除进度";
            this.Load += new System.EventHandler(this.ClearCacheForm_Load);
            this.Shown += new System.EventHandler(this.ClearCacheForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar clearProgressBar;
    }
}