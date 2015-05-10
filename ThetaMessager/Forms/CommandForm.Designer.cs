namespace ThetaMessager.Forms
{
    partial class CommandForm
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
            this.lbcCommand = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbcName = new System.Windows.Forms.TextBox();
            this.tbcContent = new System.Windows.Forms.TextBox();
            this.btcAdd = new System.Windows.Forms.Button();
            this.btcUpdate = new System.Windows.Forms.Button();
            this.btcDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbcCommand
            // 
            this.lbcCommand.FormattingEnabled = true;
            this.lbcCommand.ItemHeight = 12;
            this.lbcCommand.Location = new System.Drawing.Point(13, 13);
            this.lbcCommand.Name = "lbcCommand";
            this.lbcCommand.Size = new System.Drawing.Size(90, 112);
            this.lbcCommand.TabIndex = 0;
            this.lbcCommand.SelectedValueChanged += new System.EventHandler(this.lbcCommand_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "指令名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "指令内容";
            // 
            // tbcName
            // 
            this.tbcName.Location = new System.Drawing.Point(169, 38);
            this.tbcName.Name = "tbcName";
            this.tbcName.Size = new System.Drawing.Size(180, 21);
            this.tbcName.TabIndex = 3;
            // 
            // tbcContent
            // 
            this.tbcContent.Location = new System.Drawing.Point(169, 65);
            this.tbcContent.Name = "tbcContent";
            this.tbcContent.Size = new System.Drawing.Size(180, 21);
            this.tbcContent.TabIndex = 4;
            // 
            // btcAdd
            // 
            this.btcAdd.Location = new System.Drawing.Point(112, 97);
            this.btcAdd.Name = "btcAdd";
            this.btcAdd.Size = new System.Drawing.Size(75, 23);
            this.btcAdd.TabIndex = 5;
            this.btcAdd.Text = "新增指令";
            this.btcAdd.UseVisualStyleBackColor = true;
            this.btcAdd.Click += new System.EventHandler(this.btcAdd_Click);
            // 
            // btcUpdate
            // 
            this.btcUpdate.Location = new System.Drawing.Point(193, 97);
            this.btcUpdate.Name = "btcUpdate";
            this.btcUpdate.Size = new System.Drawing.Size(75, 23);
            this.btcUpdate.TabIndex = 6;
            this.btcUpdate.Text = "更新指令";
            this.btcUpdate.UseVisualStyleBackColor = true;
            this.btcUpdate.Click += new System.EventHandler(this.btcUpdate_Click);
            // 
            // btcDelete
            // 
            this.btcDelete.Location = new System.Drawing.Point(274, 97);
            this.btcDelete.Name = "btcDelete";
            this.btcDelete.Size = new System.Drawing.Size(75, 23);
            this.btcDelete.TabIndex = 7;
            this.btcDelete.Text = "删除指令";
            this.btcDelete.UseVisualStyleBackColor = true;
            this.btcDelete.Click += new System.EventHandler(this.btcDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(138, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "如需改动指令请事先咨询维护人员";
            // 
            // CommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 137);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btcDelete);
            this.Controls.Add(this.btcUpdate);
            this.Controls.Add(this.btcAdd);
            this.Controls.Add(this.tbcContent);
            this.Controls.Add(this.tbcName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbcCommand);
            this.MaximumSize = new System.Drawing.Size(377, 176);
            this.MinimumSize = new System.Drawing.Size(377, 176);
            this.Name = "CommandForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指令设置";
            this.Load += new System.EventHandler(this.CommandForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbcCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbcName;
        private System.Windows.Forms.TextBox tbcContent;
        private System.Windows.Forms.Button btcAdd;
        private System.Windows.Forms.Button btcUpdate;
        private System.Windows.Forms.Button btcDelete;
        private System.Windows.Forms.Label label3;
    }
}