using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ThetaMessager.Commons;

namespace ThetaMessager.Forms
{
    public partial class LoginForm : Form
    {
        private Form parent;

        private static String configPath=Application.StartupPath+"\\Config\\application-env.xml";

        private static String userNameTag="UserName";

        private static String passwordTag = "Password";

        private static String userInfoNeededTag = "UserInfoNeeded";

        private String userName="ranger";

        private String password="ranger";

        private Boolean userInfoNeeded = true;

        public LoginForm(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configPath);
            try
            {
                userName=doc.GetElementsByTagName(userNameTag).Item(0).InnerText;
                password=doc.GetElementsByTagName(passwordTag).Item(0).InnerText;
                userInfoNeeded = Boolean.Parse(doc.GetElementsByTagName(userInfoNeededTag).Item(0).InnerText);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            if (this.userName==this.txtUserName.Text && this.password==this.txtPassword.Text || !this.userInfoNeeded){
                this.Hide();
                parent.Enabled = true;
                parent.Show();
            }else{
                MessageBox.Show(ErrorMessage.ERROR_USER_INFO_IS_WRONG);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            this.parent.Hide();
        }
    }
}
