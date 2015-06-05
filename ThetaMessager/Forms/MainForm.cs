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
        private static string BLACK_PIN = "bpin";
        private static string SMALL_ICON = "logo32";
        private static string GREY_PIN = "greypin";

        private XmlDocument nodeConfigDoc = null;
        private XmlDocument appConfigDoc = null;
        private XmlDocument logDoc = null;
        private static String nodeConfigPath = Application.StartupPath + "\\Config\\map-info.xml";
        private static String appConfigPath = Application.StartupPath + "\\Config\\application-env.xml";
        private static String logPath = Application.StartupPath + "\\Config\\log.xml";
        private static String commandTag = "Command";
        private static String commandNameProp = "name";
        private static String logsTag = "logs";
        private static String logTag = "log";
        private static String logDateProp = "date";
        private static String mapTag = "map";
        private static String nodeTag = "node";
        private static String nodeNameProp = "name";
        private static String nodeNumberProp = "number";
        private static String nodeLocationXProp = "locationX";
        private static String nodeLocationYProp = "locationY";

        private static Dictionary<String, String> OPEN_CALL_MAP = new Dictionary<String, String>() { 
            { "8F9351FA53E30030FF1A517395ED", "离线" }, 
            { "8F9351FA53E30030FF1A542F52A8", "待命" }, 
            { "IOOP6,2", "锁定" }, {"9004F004F00500036002C0032","锁定"},
            { "IOOH0", "待命" }, {"9004F004F00480030","待命"},                                   
            { "IOOP2,2", "报警中" }, { "9004F004F00500032002C0032", "报警中" },                            
            { "IOOP3,2", "报警中" }, { "9004F004F00500033002C0032", "报警中" },
            { "IOOP4,2", "报警中" }, { "9004F004F00500034002C0032", "报警中" },
            { "IOOP5,2", "报警中" }, { "9004F004F00500035002C0032", "报警中" },
            { "IOOP1,2", "待命" }, { "9004F004F00500031002C0032", "待命" },
            { "IOOL0", "锁定" }, { "9004F004F004C0030", "锁定" },
            { "IOOP7,2", "离线" }, { "9004F004F00500037002C0032", "离线" },
        };
        
        private static String OPEN_CALL_INIT_STATE = "未知";

        private string nowDate = null;
        private string logContent = "";
        private XmlNode logNode = null;
        private Dictionary<string, string> cmdMap = null;
        private LoginForm loginForm=null;
        private List<NodeButton> editNodeButtonList = null;        
        private NodeButton editCurrentNodeButton = null;
        private List<NodeButton> controlNodeButtonList = null;
        private List<bool> dgvStateList = null;
        private static Image gpinImage = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(GREEN_PIN)));
        private static Image opinImage = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(ORANGE_PIN)));
        private static Image rpinImage = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(RED_PIN)));
        private static Image ypinImage = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(YELLOW_PIN)));
        private static Image bpinImage = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(BLACK_PIN)));
        private static Image greypinImage = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(GREY_PIN)));
        private static Dictionary<String, Image> IMAGE_MAP = new Dictionary<string, Image>() { { "未知", bpinImage }, { "离线", greypinImage }, { "锁定", opinImage }, { "待命", gpinImage }, { "报警中", rpinImage } };
        private Icon icon = ((System.Drawing.Icon)(new ComponentResourceManager(typeof(MainForm))).GetObject(SMALL_ICON));

        private static string newLine = "\n";

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
            this.logDoc = new XmlDocument();           
            this.logDoc.Load(logPath);
            this.nowDate = DateTime.Now.ToShortDateString();
            XmlNodeList logNodeList = this.logDoc.GetElementsByTagName(logTag);
            foreach (XmlNode node in logNodeList){
                XmlNode dateAttr=node.Attributes.GetNamedItem(logDateProp);
                if (dateAttr.Value.Equals(this.nowDate))
                {
                    this.logNode = node;
                }
            }
            if (this.logNode == null)
            {
                this.logNode = this.logDoc.CreateElement(logTag);
                XmlAttribute dateAttr=this.logDoc.CreateAttribute(logDateProp);
                dateAttr.Value=this.nowDate;
                this.logNode.Attributes.Append(dateAttr);
                this.logDoc.GetElementsByTagName(logsTag).Item(0).AppendChild(this.logNode);
            }            

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
            this.dgvForSendings.AllowUserToAddRows = false;
            this.dgvForEdit.AllowUserToAddRows = false;                

            this.editNodeButtonList = new List<NodeButton>();
            this.controlNodeButtonList = new List<NodeButton>();
            nodeConfigDoc = new XmlDocument();
            nodeConfigDoc.Load(nodeConfigPath);
            this.dgvForEdit.Rows.Clear();
            this.dgvForSendings.Rows.Clear();
            bool isFirst = true;
            this.dgvStateList = new List<bool>();
                        
            try
            {
                XmlNodeList nodeList = nodeConfigDoc.GetElementsByTagName(nodeTag);
                foreach(XmlNode node in nodeList){
                    String name = node.Attributes[nodeNameProp].Value;
                    String number = node.Attributes[nodeNumberProp].Value;
                    int locationX = int.Parse(node.Attributes[nodeLocationXProp].Value);
                    int locationY = int.Parse(node.Attributes[nodeLocationYProp].Value);
                    Point point = new Point(locationX, locationY);

                    NodeButton nodeButton = new NodeButton(point, bpinImage, btEditNode_Click);
                    nodeButton.setInfo(name, number, point);
                    this.addNodeButton(nodeButton);

                    this.dgvStateList.Add(false);
                   
                    this.dgvForEdit.Rows.Add(new string[2] { name, number });
                    this.dgvForSendings.Rows.Add(new object[4] { 0, name, number,OPEN_CALL_INIT_STATE });
                    
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
            NodeButton nodeButton = new NodeButton(location, bpinImage, btEditNode_Click);
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
                    button.Image = ypinImage;
                    foreach (DataGridViewRow row in this.dgvForSendings.Rows)
                    {
                        object value = row.Cells[1].Value;                        
                        if (value != null && value.Equals(nodeName))
                        {                            
                            DataGridViewCheckBoxCell cbCell = (DataGridViewCheckBoxCell)row.Cells[0];
                            cbCell.Value = true;                            
                            break;
                        }
                    }
                    break;
                case 1:
                    button.selectedState = 0;
                    foreach (DataGridViewRow row in this.dgvForSendings.Rows)
                    {
                        object value = row.Cells[1].Value;
                        if (value != null && value.Equals(nodeName)) 
                        {
                            DataGridViewCheckBoxCell cbCell = (DataGridViewCheckBoxCell)row.Cells[0];
                            cbCell.Value = false;
                            button.Image = IMAGE_MAP[row.Cells[3].Value.ToString()];
                            break;
                        }
                    };
                    break;
                case 2:
                    button.selectedState = 3;
                    foreach (DataGridViewRow row in this.dgvForSendings.Rows)
                    {
                        object value = row.Cells[1].Value;
                        if (value!=null && value.Equals(nodeName))
                        {
                            DataGridViewCheckBoxCell cbCell = (DataGridViewCheckBoxCell)row.Cells[0];
                            cbCell.Value = false;
                            button.Image = IMAGE_MAP[row.Cells[3].Value.ToString()];
                            break;
                        }
                    };
                    break;
                case 3:
                    button.selectedState = 2;
                    button.Image = ypinImage;
                    foreach (DataGridViewRow row in this.dgvForSendings.Rows)
                    {
                        object value = row.Cells[1].Value;
                        if (value != null && value.Equals(nodeName))
                        {
                            DataGridViewCheckBoxCell cbCell = (DataGridViewCheckBoxCell)row.Cells[0];
                            cbCell.Value = true;
                            break;
                        }
                    }
                    break;
                case 4:
                    button.selectedState = 0;
                    foreach(DataGridViewRow row in this.dgvForSendings.Rows)
                    {
                        object value = row.Cells[1].Value;
                        if (value != null && value.Equals(nodeName))
                        {
                            DataGridViewCheckBoxCell cbCell = (DataGridViewCheckBoxCell)row.Cells[0];
                            button.Image = IMAGE_MAP[row.Cells[3].Value.ToString()];
                            break;
                        }
                    }
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
            this.dgvForSendings.Rows.Clear();            
            this.dgvStateList.Clear();

            foreach (NodeButton nodeButton in this.editNodeButtonList)
            {
                this.dgvStateList.Add(false);
          
                this.dgvForEdit.Rows.Add(new string[2] { nodeButton.name, nodeButton.number });
                this.dgvForSendings.Rows.Add(new object[4] { 0, nodeButton.name, nodeButton.number,OPEN_CALL_INIT_STATE });             
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
            try
            {
                this.btComSend.Enabled = false;
                this.btStateUpdate.Enabled = false;
                if (!this.checkSendParas())
                {
                    MessageBox.Show(ErrorMessage.ERROR_MESSAGE_SEND_INFO_IS_NOT_ENOUGH);
                }
                this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_QUEUE_START + (this.dgvForSendings.Rows.Count - 1));
                log(AtProcess.COM_MESSAGE_QUEUE_START + (this.dgvForSendings.Rows.Count - 1));

                string sendingText = this.cmdMap[this.cbSentText.Text];
                foreach (DataGridViewRow row in this.dgvForSendings.Rows)
                {
                    if (row.Cells[1].Value == null)
                    {
                        continue;
                    }
                    if ((bool)row.Cells[0].FormattedValue == false)
                    {
                        continue;
                    }
                    string nowNo = row.Cells[2].Value.ToString();
                    string nowName = row.Cells[1].Value.ToString();
                    SendInfo sendInfo = new SendInfo(nowNo, sendingText);

                    this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_SINGLE_SEND_START);
                    log(AtProcess.COM_MESSAGE_SINGLE_SEND_START);
                    this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_SINGLE_INFO_NAME + nowName);
                    log(AtProcess.COM_MESSAGE_SINGLE_INFO_NAME + nowName);
                    this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_SINGLE_INFO_CMD + this.cbSentText.Text);
                    log(AtProcess.COM_MESSAGE_SINGLE_INFO_CMD + this.cbSentText.Text);
                    ComUtils.send(sendInfo);
                    this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_SINGLE_SEND_END);
                    log(AtProcess.COM_MESSAGE_SINGLE_SEND_END);

                    foreach (NodeButton nodeButton in this.controlNodeButtonList)
                    {
                        if (nodeButton.number.Equals(nowNo))
                        {
                            nodeButton.Image = ypinImage;
                            nodeButton.selectedState = 4;
                            break;
                        }
                    }
                }
                this.btComSend.Enabled = true;
                this.btStateUpdate.Enabled = true;

                this.lbAtInfo.Items.Add(AtProcess.COM_MESSAGE_QUEUE_END);                
                log(AtProcess.COM_MESSAGE_QUEUE_END);
                this.lbAtInfo.Items.Add(newLine);
                log(newLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    log(AtProcess.COM_INIT);
                    ComUtils.init(this.cbComPort.Text, baudRate);
                    this.lbAtInfo.Items.Add(AtProcess.COM_INIT_FINISH);
                    log(AtProcess.COM_INIT_FINISH);
                }
                this.lbAtInfo.Items.Add(AtProcess.COM_OPEN);
                log(AtProcess.COM_OPEN);
                ComUtils.open();
                this.lbAtInfo.Items.Add(AtProcess.COM_OPEN_FINISH);
                log(AtProcess.COM_OPEN_FINISH);
                this.lbAtInfo.Items.Add(AtProcess.COM_TEST);
                log(AtProcess.COM_TEST);
                bool tested=ComUtils.testTunnel();
                this.lbAtInfo.Items.Add(AtProcess.COM_TEST_FINISH);
                log(AtProcess.COM_TEST_FINISH);
                this.lbAtInfo.Items.Add(newLine);
                log(newLine);
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
                //MessageBox.Show(messageString);
                foreach (NodeButton nodeButton in this.controlNodeButtonList)
                {
                    string number = nodeButton.number;
                    foreach (String callBackKey in OPEN_CALL_MAP.Keys)
                    {
                        if (messageString.Contains(number) && messageString.Contains(callBackKey))
                        {
                            //nodeButton.Image = this.rpinImage;
                            //nodeButton.selectedState = 2;                            
                            this.changeCallBackState(nodeButton.name, OPEN_CALL_MAP[callBackKey]);
                        }
                    }
                }
            }
            this.btComSend.Enabled = true;
            this.btStateUpdate.Enabled = true;
        }

        private void changeCallBackState(String nodeName, String state)
        {
            foreach (DataGridViewRow row in this.dgvForSendings.Rows)
            {                
                object value = row.Cells[1].Value;
                if (value != null && value.Equals(nodeName))
                {
                    DataGridViewCell cbCell = row.Cells[3];
                    cbCell.Value = state;
                    foreach (NodeButton nodeButton in this.controlNodeButtonList)
                    {
                        if (nodeName.Equals(nodeButton.name))
                        {
                            nodeButton.Image = IMAGE_MAP[state];
                            break;
                        }
                    }
                    break;
                }
            }
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

        private void log(string str)
        {
            this.logContent += "[" + DateTime.Now.ToString() + "]" + str + "|";
            this.logNode.InnerText = this.logContent;
            this.logDoc.Save(logPath);
        }

        private void dtpLog_ValueChanged(object sender, EventArgs e)
        {
            this.showLog();
        }

        private void showLog()
        {
            string chosenDate = this.dtpLog.Value.ToShortDateString();
            XmlNode nowLogNode = null;
            foreach (XmlNode node in this.logDoc.GetElementsByTagName(logTag))
            {
                if (node.Attributes.GetNamedItem(logDateProp).Value.Equals(chosenDate))
                {
                    nowLogNode = node;
                }
            }
            if (nowLogNode != null)
            {
                this.rtbLog.Text = nowLogNode.InnerText;
                this.rtbLog.Text=this.rtbLog.Text.Replace("|", "\r\n");
            }
            else
            {
                this.rtbLog.Text = "";
            }
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.showLog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ComUtils.Shutdown();
        }

        private void dgvForSendings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (false)
            {
                if (e.ColumnIndex == 0)
                {
                    bool b = (bool)this.dgvForSendings.Rows[e.RowIndex].Cells[0].EditedFormattedValue;
                    bool remain = this.dgvStateList[e.RowIndex];

                    if (b != remain)
                    {
                        string buttonName = this.dgvForSendings.Rows[e.RowIndex].Cells[1].Value.ToString();

                        foreach (NodeButton node in this.controlNodeButtonList)
                        {
                            if (node.name.Equals(buttonName))
                            {
                                this.btControlNode_Click(node, new EventArgs());
                                this.dgvStateList[e.RowIndex] = b;
                                Thread.Sleep(100);
                                break;
                            }
                        }
                    }

                }
            }
        }

        private void clearCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ComUtils.isInit)
            {
                ClearCacheForm clearCacheForm = new ClearCacheForm();
                clearCacheForm.Show();
            }
            else
            {
                MessageBox.Show(ErrorMessage.ERROR_COM_NOT_OPEN);
            }
        }

    }
}

