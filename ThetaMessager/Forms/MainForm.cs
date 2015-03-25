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

namespace ThetaMessager
{
    public partial class MainForm : Form
    {
        private static string GREEN_PIN = "gpin";

        private LoginForm loginForm=null;
        private ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));

        private string portName = "COM3";
        private int baudRate = 9600;
        private bool trigger = false;

        private int locationX = 0;
        private int locationY = 0;

        public MainForm()
        {
            InitializeComponent();

            ComUtils.init(portName, baudRate);
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
            Image image=((Image)(resources.GetObject(GREEN_PIN)));            

            Label picLabel = new Label();
            picLabel.Image = image;
            picLabel.Location = new Point(locationX, locationY);
            picLabel.Size = image.Size;
            picLabel.BackColor = Color.Transparent;            
            this.tpMapEdit.Controls.Add(picLabel);
            picLabel.BringToFront();

            PictureBox pbMapEditFlag = new PictureBox();
            pbMapEditFlag.Image = image;
            pbMapEditFlag.Location = new Point(locationX, locationY);           
            pbMapEditFlag.SizeMode = PictureBoxSizeMode.AutoSize;
            pbMapEditFlag.BackColor = Color.Transparent;
            
            //this.tpMapEdit.Controls.Add(pbMapEditFlag);
            
            
        }

        private void cmiEdit_Click(object sender, EventArgs e)
        {

        }

    }
}

