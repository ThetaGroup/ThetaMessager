namespace ThetaMessager.Forms
{
    partial class UserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbuUsername = new System.Windows.Forms.TextBox();
            this.tbuOldPassword = new System.Windows.Forms.TextBox();
            this.tbuNewPassword = new System.Windows.Forms.TextBox();
            this.tbuConfirmPassword = new System.Windows.Forms.TextBox();
            this.btuConfirm = new System.Windows.Forms.Button();
            this.btuCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "旧密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "新密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "再确认";
            // 
            // tbuUsername
            // 
            this.tbuUsername.Location = new System.Drawing.Point(60, 33);
            this.tbuUsername.Name = "tbuUsername";
            this.tbuUsername.ReadOnly = true;
            this.tbuUsername.Size = new System.Drawing.Size(183, 21);
            this.tbuUsername.TabIndex = 4;
            // 
            // tbuOldPassword
            // 
            this.tbuOldPassword.Location = new System.Drawing.Point(59, 60);
            this.tbuOldPassword.Name = "tbuOldPassword";
            this.tbuOldPassword.PasswordChar = '*';
            this.tbuOldPassword.Size = new System.Drawing.Size(183, 21);
            this.tbuOldPassword.TabIndex = 5;
            // 
            // tbuNewPassword
            // 
            this.tbuNewPassword.Location = new System.Drawing.Point(59, 87);
            this.tbuNewPassword.Name = "tbuNewPassword";
            this.tbuNewPassword.PasswordChar = '*';
            this.tbuNewPassword.Size = new System.Drawing.Size(183, 21);
            this.tbuNewPassword.TabIndex = 6;
            // 
            // tbuConfirmPassword
            // 
            this.tbuConfirmPassword.Location = new System.Drawing.Point(59, 114);
            this.tbuConfirmPassword.Name = "tbuConfirmPassword";
            this.tbuConfirmPassword.PasswordChar = '*';
            this.tbuConfirmPassword.Size = new System.Drawing.Size(183, 21);
            this.tbuConfirmPassword.TabIndex = 7;
            // 
            // btuConfirm
            // 
            this.btuConfirm.Location = new System.Drawing.Point(37, 141);
            this.btuConfirm.Name = "btuConfirm";
            this.btuConfirm.Size = new System.Drawing.Size(75, 23);
            this.btuConfirm.TabIndex = 8;
            this.btuConfirm.Text = "确定";
            this.btuConfirm.UseVisualStyleBackColor = true;
            this.btuConfirm.Click += new System.EventHandler(this.btuConfirm_Click);
            // 
            // btuCancel
            // 
            this.btuCancel.Location = new System.Drawing.Point(148, 141);
            this.btuCancel.Name = "btuCancel";
            this.btuCancel.Size = new System.Drawing.Size(75, 23);
            this.btuCancel.TabIndex = 9;
            this.btuCancel.Text = "取消";
            this.btuCancel.UseVisualStyleBackColor = true;
            this.btuCancel.Click += new System.EventHandler(this.btuCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(36, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "如需改动用户名请联系维护人员";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 180);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btuCancel);
            this.Controls.Add(this.btuConfirm);
            this.Controls.Add(this.tbuConfirmPassword);
            this.Controls.Add(this.tbuNewPassword);
            this.Controls.Add(this.tbuOldPassword);
            this.Controls.Add(this.tbuUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(274, 219);
            this.MinimumSize = new System.Drawing.Size(274, 219);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbuUsername;
        private System.Windows.Forms.TextBox tbuOldPassword;
        private System.Windows.Forms.TextBox tbuNewPassword;
        private System.Windows.Forms.TextBox tbuConfirmPassword;
        private System.Windows.Forms.Button btuConfirm;
        private System.Windows.Forms.Button btuCancel;
        private System.Windows.Forms.Label label5;
    }
}