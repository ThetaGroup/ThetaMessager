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

namespace ThetaMessager
{
    public partial class MainForm : Form
    {
        private static string GREEN_PIN = "gpin";

        private XmlDocument doc = null;
        private static String nodeConfigPath = Application.StartupPath + "\\Config\\map-info.xml";
        private static String mapTag = "map";
        private static String nodeTag = "node";
        private static String nodeNameProp = "name";
        private static String nodeNumberProp = "number";
        private static String nodeLocationXProp = "locationX";
        private static String nodeLocationYProp = "locationY";        

        private LoginForm loginForm=null;
        private List<NodeButton> nodeButtonList = null;
        private NodeButton currentNodeButton = null;
        private Image image = ((Image)((new ComponentResourceManager(typeof(MainForm))).GetObject(GREEN_PIN)));

        private string portName = "COM3";
        private int baudRate = 9600;
        private bool trigger = false;

        private int locationX = 0;
        private int locationY = 0;
       
        public MainForm()
        {
            InitializeComponent();
            InitNodeButtonList();
            ComUtils.init(portName, baudRate);
        }

        private void InitNodeButtonList()
        {
            this.nodeButtonList = new List<NodeButton>();
            doc = new XmlDocument();
            doc.Load(nodeConfigPath);
            try
            {
                XmlNodeList nodeList = doc.GetElementsByTagName(nodeTag);
                foreach(XmlNode node in nodeList){
                    String name = node.Attributes[nodeNameProp].Value;
                    String number = node.Attributes[nodeNumberProp].Value;
                    int locationX = int.Parse(node.Attributes[nodeLocationXProp].Value);
                    int locationY = int.Parse(node.Attributes[nodeLocationYProp].Value);
                    Point point = new Point(locationX, locationY);

                    NodeButton nodeButton = new NodeButton(point, image, btNode_Click);
                    nodeButton.setInfo(name, number, point);
                    this.addNodeButton(nodeButton);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2;i++ )
                ComUtils.send(new SendInfo("13912929646", i+":Testing in " + DateTime.Now + "!"));
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            ComUtils.open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ComUtils.close();
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
            NodeButton nodeButton = new NodeButton(location, image, btNode_Click);
            nodeButton.setInfo(null, null, location);
            this.addNodeButton(nodeButton);                     
        }

        private void addNodeButton(NodeButton nodeButton)
        {            
            this.nodeButtonList.Add(nodeButton);
            this.pbEditMap.Controls.Add(nodeButton);
        }

        private void btNode_Click(object sender, EventArgs e)
        {
            NodeButton button = (NodeButton)sender;
            
            this.textBoxNodeName.Text = button.name;
            this.textBoxNodeNumber.Text = button.number;

            this.currentNodeButton = button;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {            
            this.nodeButtonList.Remove(this.currentNodeButton);
            this.textBoxNodeName.Text = null;
            this.textBoxNodeNumber.Text = null;
            this.currentNodeButton.Dispose();
            this.saveConfigs();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {            
            string name = this.textBoxNodeName.Text;
            string number = this.textBoxNodeNumber.Text;
            Point location = currentNodeButton.location;
            currentNodeButton.setInfo(name, number, location);
            this.saveConfigs();
        }

        private void saveConfigs()
        {
            XmlNode mapNode = doc.GetElementsByTagName(mapTag)[0];
            mapNode.RemoveAll();
            foreach (NodeButton nodeButton in this.nodeButtonList)
            {
                try
                {
                    XmlNode node = doc.CreateElement(nodeTag);
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
            doc.Save(nodeConfigPath);
        }

        private void appendAttributes(XmlNode node, string key, string value)
        {
            XmlAttribute attr = doc.CreateAttribute(key);
            attr.Value = value.ToString();
            node.Attributes.Append(attr);
        }

    }
}

