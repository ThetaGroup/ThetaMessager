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

namespace ThetaMessager.Forms
{
    public partial class CommandForm : Form
    {
        private Dictionary<string, string> cmdMap = null;

        private XmlDocument appConfigDoc = null;
        private static String appConfigPath = Application.StartupPath + "\\Config\\application-env.xml";
        private static String commandTag = "Command";
        private static String commandsTag = "Commands";
        private static String commandNameProp = "name";

        private static string SMALL_ICON = "logo32";
        private Icon icon = ((System.Drawing.Icon)(new ComponentResourceManager(typeof(MainForm))).GetObject(SMALL_ICON));

        public CommandForm()
        {
            InitializeComponent();
        }

        private void CommandForm_Load(object sender, EventArgs e)
        {
            this.Icon = icon;

            this.appConfigDoc = new XmlDocument();
            appConfigDoc.Load(appConfigPath);

            this.loadConfig();
        }

        private void loadConfig()
        {
            this.lbcCommand.Items.Clear();

            this.cmdMap = new Dictionary<string, string>();
            XmlNodeList nodeList = appConfigDoc.GetElementsByTagName(commandTag);
            foreach (XmlNode node in nodeList)
            {
                String name = node.Attributes[commandNameProp].Value;
                String messageText = node.InnerText;
                this.cmdMap.Add(name, messageText);

                this.lbcCommand.Items.Add(name);

            }
        }

        private void lbcCommand_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string name = this.lbcCommand.SelectedItem.ToString();
                this.tbcName.Text = name;
                this.tbcContent.Text = this.cmdMap[name];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btcAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.tbcName.Text;
                string content = this.tbcContent.Text;

                this.addNode(name, content);

                this.loadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btcUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.tbcName.Text;
                string content = this.tbcContent.Text;
                string oldName = this.lbcCommand.SelectedItem.ToString();

                this.removeNode(oldName);
                this.addNode(name, content);
                
                this.loadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addNode(string name, string content)
        {
            this.cmdMap.Add(name, content);
            XmlNode node = this.appConfigDoc.CreateElement(commandTag);
            XmlAttribute nameAttr = this.appConfigDoc.CreateAttribute(commandNameProp);
            nameAttr.Value = name;
            node.InnerText = content;
            node.Attributes.Append(nameAttr);

            this.appConfigDoc.GetElementsByTagName(commandsTag).Item(0).AppendChild(node);
            this.appConfigDoc.Save(appConfigPath);
        }

        private void removeNode(string oldName)
        {
            this.cmdMap.Remove(oldName);

            XmlNodeList nodeList = this.appConfigDoc.GetElementsByTagName(commandTag);
            XmlNode oldNode = null;
            foreach (XmlNode node in nodeList)
            {
                XmlNode attr=node.Attributes.GetNamedItem(commandNameProp);
                if (attr != null && attr.Value!=null && attr.Value.Equals(oldName))
                {
                    oldNode = node;
                }
            }
            this.appConfigDoc.GetElementsByTagName(commandsTag).Item(0).RemoveChild(oldNode);
            this.appConfigDoc.Save(appConfigPath);
        }

        private void btcDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.tbcName.Text;
                string content = this.tbcContent.Text;
                string oldName = this.lbcCommand.SelectedItem.ToString();

                this.removeNode(oldName);

                this.loadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
