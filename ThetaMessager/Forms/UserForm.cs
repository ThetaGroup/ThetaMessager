using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ThetaMessager.Commons;

namespace ThetaMessager.Forms
{
    public partial class UserForm : Form
    {
        private XmlDocument appConfigDoc;

        private static String appConfigPath = Application.StartupPath + "\\Config\\application-env.xml";

        private static String userNameTag = "UserName";

        private static String passwordTag = "Password";

        private static string SMALL_ICON = "logo32";

        private Icon icon = ((System.Drawing.Icon)(new ComponentResourceManager(typeof(MainForm))).GetObject(SMALL_ICON));

        private string password = null;

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            this.Icon = icon;
            this.appConfigDoc = new XmlDocument();
            appConfigDoc.Load(appConfigPath);
            this.tbuUsername.Text = this.appConfigDoc.GetElementsByTagName(userNameTag).Item(0).InnerText;
            this.password = this.appConfigDoc.GetElementsByTagName(passwordTag).Item(0).InnerText;
        }

        private void btuCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btuConfirm_Click(object sender, EventArgs e)
        {
            if (!this.isPasswordInfoEnough())
            {
                MessageBox.Show(ErrorMessage.PASSWORD_INFO_NOT_ENOUGH);
            }
            else if (!this.password.Equals(this.tbuOldPassword.Text))
            {
                this.clearAllTextBox();
                MessageBox.Show(ErrorMessage.OLD_PASSWORD_IS_WRONG);                
            }
            else if (!this.tbuNewPassword.Text.Equals(this.tbuConfirmPassword.Text))
            {
                this.clearAllTextBox();
                MessageBox.Show(ErrorMessage.PASSWORD_NOT_SAME);

            }
            else
            {
                this.changePassword(this.tbuNewPassword.Text);
                MessageBox.Show(ErrorMessage.PASSWORD_SET_SUCCESS);
                this.Close();
            }
        }

        private void changePassword(string newPassword)
        {
            this.appConfigDoc.GetElementsByTagName(passwordTag).Item(0).InnerText=newPassword;
            this.appConfigDoc.Save(appConfigPath);
        }

        private Boolean isPasswordInfoEnough()
        {
            string oldPasswordText = this.tbuOldPassword.Text;
            string newPasswordText = this.tbuNewPassword.Text;
            string confirmPasswordText = this.tbuConfirmPassword.Text;
            return oldPasswordText != null && oldPasswordText.Length > 0 && newPasswordText != null && newPasswordText.Length > 0 && confirmPasswordText != null && confirmPasswordText.Length > 0;
        }

        private void clearAllTextBox()
        {
            this.tbuOldPassword.Text = "";
            this.tbuNewPassword.Text = "";
            this.tbuConfirmPassword.Text = "";
        }
    }
}