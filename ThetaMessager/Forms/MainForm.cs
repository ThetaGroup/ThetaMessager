using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using TheataMessager;
using ThetaMessager.Utils;
using ThetaMessager.Forms;
using System.Resources;
using ThetaMessager.Forms.Widget;
using System.Xml;
using ThetaMessager.Commons;

namespace ThetaMessager
{
    public partial class MainForm : Form
    {
        private static string GREEN_PIN = "gpin";
        private static string ORANGE_PIN = "opin";
        private static string RED_PIN = "rpin";
        private static string YELLOW_PIN = "ypin";
        private static string SMALL_ICON = "logo32";

        private XmlDocument nodeConfigDoc = null;
        private XmlDocument appConfigDoc = null;
        private static String nodeConfigPath = Application.StartupPath + "\\Config\\map-info.xml";
        private static String appConfigPath = Application.StartupPath + "\\Config\\application-env.xml";
        private static String commandTag = "Command";
        private static String commandNameProp = "name";
        private static String mapTag = "map";
        private static String nodeTag = "node";
        private static String nodeNameProp = "name";
        private static String nodeNumberProp = "number";
        private static String nodeLocationXProp = "locationX";
        private static String nodeLocationYProp = "locationY";
        private static String OPEN_CALL_BACK_TAG = "opened";

        private Dictionary<string, string> cmdMap = null;
        private LoginForm loginForm=null;
        private List<NodeButton> editNodeButtonList = null;        
        private NodeButton editCurrentNodeButton = null;
        private List<NodeButton> controlNodeButtonList = null;
        private Image gpinImage = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(GREEN_PIN)));
        private Image opinImage = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(ORANGE_PIN)));
        private Image rpinImage = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(RED_PIN)));
        private Image ypinImage = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(YELLOW_PIN)));
        private Icon icon = ((System.Drawing.Icon)(new ComponentResourceManager(typeof(MainForm))).GetObject(SMALL_ICON));

        private static int baudRate = 9600;

        private int locationX = 0;
        private int locationY = 0;
       
        public MainForm()
        {
            InitializeComponent();
            InitForm();
            InitNodeButtonList();
            InitComInfos();            
        }

        private void InitForm()
        {
            this.Icon = icon;
        }

        private void InitComInfos()
        {
            this.btComSend.Enabled = false;
            this.btStateUpdate.Enabled = false;
            foreach (string portName in ComUtils.searchPortNames())
            {
                this.cbComPort.Items.Add(portName);
            }
            try
            {
                this.cbComPort.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMessage.COM_LIST_IS_EMPTY);
                System.Environment.Exit(-1);                
            }
            this.appConfigDoc = new XmlDocument();
            appConfigDoc.Load(appConfigPath);
            try
            {
                this.cmdMap=new Dictionary<string,string>();
                XmlNodeList nodeList = appConfigDoc.GetElementsByTagName(commandTag);
                foreach (XmlNode node in nodeList)
                {
                    String name = node.Attributes[commandNameProp].Value;
                    String messageText = node.InnerText;
                    this.cmdMap.Add(name, messageText);

                    this.cbSentText.Items.Add(name);                    
                }
                try
                {
                    this.cbSentText.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMessage.MESSAGE_LIST_IS_EMPTY);
                    System.Environment.Exit(-1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitNodeButtonList()
        {
            this.editNodeButtonList = new List<NodeButton>();
            this.controlNodeButtonList = new List<NodeButton>();
            nodeConfigDoc = new XmlDocument();
            nodeConfigDoc.Load(nodeConfigPath);
            try
            {
                XmlNodeList nodeList = nodeConfigDoc.GetElementsByTagName(nodeTag);
                foreach(XmlNode node in nodeList){
                    String name = node.Attributes[nodeNameProp].Value;
                    String number = node.Attributes[nodeNumberProp].Value;
                    int locationX = int.Parse(node.Attributes[nodeLocationXProp].Value);
                    int locationY = int.Parse(node.Attributes[nodeLocationYProp].Value);
                    Point point = new Point(locationX, locationY);

                    NodeButton nodeButton = new NodeButton(point, gpinImage, btEditNode_Click);
                    nodeButton.setInfo(name, number, point);
                    this.addNodeButton(nodeButton);

                    this.dgvForEdit.Rows.Add(new string[2]{name,number});
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (loginForm == null)
            {
                loginForm = new LoginForm(this);                
                loginForm.Show();                                
            }            

        }

        private void miExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void pbEditMap_Click(object sender, EventArgs e)
        {
            MouseEventArgs meArgs = (MouseEventArgs)e;
            if (meArgs.Button == MouseButtons.Right)
            {                                                
                this.cmStripMapEdit.Show(Control.MousePosition);
                this.locationX = meArgs.X;
                this.locationY = meArgs.Y;
            }
        }

        private void cmiAdd_Click(object sender, EventArgs e)
        {
            Point location=new Point(locationX,locationY);            
            NodeButton nodeButton = new NodeButton(location, gpinImage, btEditNode_Click);
            nodeButton.setInfo(null, null, location);
            this.addNodeButton(nodeButton);                
        }

        private void addNodeButton(NodeButton nodeButton)
        {            
            this.editNodeButtonList.Add(nodeButton);
            this.pbEditMap.Controls.Add(nodeButton);

            NodeButton controlNodeButton = new NodeButton(nodeButton, btControlNode_Click);
            this.controlNodeButtonList.Add(controlNodeButton);
            this.pbControlMap.Controls.Add(controlNodeButton);  
        }

        private void removeNodeButton(NodeButton nodeButton)
        {
            this.editNodeButtonList.Remove(this.editCurrentNodeButton);
            this.editCurrentNodeButton.Dispose();
        }

        private void btControlNode_Click(object sender, EventArgs e)
        {
            NodeButton button = (NodeButton)sender;
            string nodeName = button.name;
            string nodeNumber = button.number;
            if (nodeName == null || nodeNumber == null)
            {
                MessageBox.Show(ErrorMessage.ERROR_NODE_HAS_NOT_BEEN_INITIALIZED);
                return;
            }
            switch (button.selectedState)
            {
                case 0:
                    button.selectedState = 1;
                    button.Image = opinImage;
                    this.dgvForSendings.Rows.Add(new string[2] { nodeName, nodeNumber });
                    break;
                case 1:
                    button.selectedState = 0;
                    button.Image = gpinImage;
                    foreach (DataGridViewRow row in this.dgvForSendings.Rows)
                    {
                        object value = row.Cells[0].Value;
                        if (value != null && value.Equals(nodeName)) 
                        {
                            this.dgvForSendings.Rows.Remove(row);
                            break;
                        }
                    };
                    break;
                case 2:
                    button.selectedState = 3;
                    button.Image = opinImage;
                    foreach (DataGridViewRow row in this.dgvForSendings.Rows)
                    {
                        object value = row.Cells[0].Value;
                        if (value!=null && value.Equals(nodeName))
                        {
                            this.dgvForSendings.Rows.Remove(row);
                            break;
                        }
                    };
                    break;
                case 3:
                    button.selectedState = 2;
                    button.Image = rpinImage;
                    this.dgvForSendings.Rows.Add(new string[2] { nodeName, nodeNumber });
                    break;
                case 4:
                    break;
            }
        }

        private void btEditNode_Click(object sender, EventArgs e)
        {
            NodeButton button = (NodeButton)sender;
            
            this.textBoxNodeName.Text = button.name;
            this.textBoxNodeNumber.Text = button.number;

            this.editCurrentNodeButton = button;            
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            string name = this.textBoxNodeName.Text;
            this.textBoxNodeName.Text = null;
            this.textBoxNodeNumber.Text = null;

            List<NodeButton> toRemoveEditButton = new List<NodeButton>();
            foreach (NodeButton nodeButton in this.editNodeButtonList)
            {
                if (nodeButton.name.Equals(name))
                {
                    toRemoveEditButton.Add(nodeButton);
                }
            }
            List<NodeButton> toRemoveControlButton = new List<NodeButton>();
            foreach (NodeButton nodeButton in this.controlNodeButtonList)
            {
                if (nodeButton.name.Equals(name))
                {
                    toRemoveControlButton.Add(nodeButton);
                }
            }
            foreach (NodeButton nodeButton in toRemoveEditButton)
            {
                this.editNodeButtonList.Remove(nodeButton);
                this.pbEditMap.Controls.Remove(nodeButton);
            }
            foreach (NodeButton nodeButton in toRemoveControlButton)
            {
                this.controlNodeButtonList.Remove(nodeButton);
                this.pbControlMap.Controls.Remove(nodeButton);
            }

            this.saveConfigs();

            this.reloadEditDataGridView();

        }

        private void reloadEditDataGridView()
        {
            this.dgvForEdit.Rows.Clear();
            foreach (NodeButton nodeButton in this.editNodeButtonList)
            {
                this.dgvForEdit.Rows.Add(new string[2] { nodeButton.name, nodeButton.number });
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {                       
            string name = this.textBoxNodeName.Text;
            string number = this.textBoxNodeNumber.Text;

            if (name == null || number == null || name.Equals("") || number.Equals(""))
            {
                MessageBox.Show(ErrorMessage.EDIT_INFO_NOT_COMPLETE);
                return;
            }

            Point location = editCurrentNodeButton.location;
            editCurrentNodeButton.setInfo(name, number, location);
            this.saveConfigs();

            int editIndex = this.editNodeButtonList.IndexOf(editCurrentNodeButton);
            this.controlNodeButtonList[editIndex].name = name;
            this.controlNodeButtonList[editIndex].number = number;

            this.reloadEditDataGridView();
        }

        private void saveConfigs()
        {
            XmlNode mapNode = nodeConfigDoc.GetElementsByTagName(mapTag)[0];
            mapNode.RemoveAll();
            foreach (NodeButton nodeButton in this.editNodeButtonList)
            {
                try
                {
                    XmlNode node = nodeConfigDoc.CreateElement(nodeTag);
                    this.appendAttributes(node, nodeNameProp, nodeButton.name);
                    this.appendAttributes(node, nodeNumberProp, nodeButton.number);
                    Point point = nodeButton.location;
                    this.appendAttributes(node, nodeLocationXProp, point.X.ToString());
                    this.appendAttributes(node, nodeLocationYProp, point.Y.ToString());

                    mapNode.AppendChild(node);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            nodeConfigDoc.Save(nodeConfigPath);
        }

        private void appendAttributes(XmlNode node, string key, string value)
        {
            XmlAttribute attr = nodeConfigDoc.CreateAttribute(key);
            attr.Value = value.ToString();
            node.Attributes.Append(attr);
        }

        private void btComSend_Click(object sender, EventArgs e)
        {
            this.btComSend.Enabled = false;
            this.btStateUpdate.Enabled = false;
            if (!this.checkSendParas())
            {
                MessageBox.Show(ErrorMessage.ERROR_MESSAGE_SEND_INFO_IS_NOT_ENOUGH);
            }
            this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_QUEUE_START+this.dgvForSendings.Size);

            string sendingText = this.cmdMap[this.cbSentText.Text];            
            foreach (DataGridViewRow row in this.dgvForSendings.Rows){
                if (row.Cells[1].Value== null)
                {
                    continue;
                }
                string nowNo = row.Cells[1].Value.ToString();
                string nowName = row.Cells[0].Value.ToString();
                SendInfo sendInfo = new SendInfo(nowNo, sendingText);

                this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_SINGLE_SEND_START);
                this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_SINGLE_INFO_NAME+nowName);
                this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_SINGLE_INFO_CMD + this.cbSentText.Text);
                ComUtils.send(sendInfo);
                this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_SINGLE_SEND_END);

                foreach (NodeButton nodeButton in this.controlNodeButtonList)
                {
                    if (nodeButton.number.Equals(nowNo))
                    {
                        nodeButton.Image = this.ypinImage;
                        nodeButton.selectedState = 4;
                        break;
                    }
                }
            }
            this.btComSend.Enabled = true;
            this.btStateUpdate.Enabled = true;

            this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_QUEUE_END);
        }

        private bool checkSendParas()
        {            
            bool result = (this.dgvForSendings.Rows.Count > 0)  && (this.cbSentText.Text != null) && (ComUtils.isInit) && (ComUtils.isReady);
            return result;
        }

        private void btOpenCom_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ComUtils.isInit)
                {
                    this.lbAtInfo.Items.Add(AtProcess.COM_INIT);
                    ComUtils.init(this.cbComPort.Text, baudRate);
                    this.lbAtInfo.Items.Add(AtProcess.COM_INIT_FINISH);
                }
                this.lbAtInfo.Items.Add(AtProcess.COM_OPEN);
                ComUtils.open();
                this.lbAtInfo.Items.Add(AtProcess.COM_OPEN_FINISH);
                this.lbAtInfo.Items.Add(AtProcess.COM_TEST);
                bool tested=ComUtils.testTunnel();
                this.lbAtInfo.Items.Add(AtProcess.COM_TEST_FINISH);
                if (tested)
                {
                    MessageBox.Show(ErrorMessage.NORMAL_COM_PORT_OPEN_OK);
                    this.btComSend.Enabled = true;
                    this.btStateUpdate.Enabled = true;
                }
                else
                {
                    MessageBox.Show(ErrorMessage.ERROR_COM_PORT_OPEN_FAIL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }      

        private void btStateUpdate_Click(object sender, EventArgs e)
        {
            this.btComSend.Enabled = false;
            this.btStateUpdate.Enabled = false;
            string[] messageStringList = ComUtils.listReceivedMessages();
            foreach (string messageString in messageStringList)
            {
                foreach (NodeButton nodeButton in this.controlNodeButtonList)
                {
                    string number = nodeButton.number;
                    if (messageString.Contains(number) && messageString.Contains(OPEN_CALL_BACK_TAG))
                    {
                        nodeButton.Image = this.rpinImage;
                        nodeButton.selectedState = 2;
                    }
                }
            }
            this.btComSend.Enabled = true;
            this.btStateUpdate.Enabled = true;
        }

        private void miUser_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Show();
        }

        private void miCommand_Click(object sender, EventArgs e)
        {
            CommandForm commandForm = new CommandForm();
            commandForm.Show();
        }
            
    }
}

