using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThetaMessager.Forms.Widget
{
    class NodeButton:Button
    {
        public string name;
        public string number;
        public Point location;
        public int selectedState;

        public NodeButton(NodeButton nodeButton,EventHandler eventHandler)
        {
            this.name = nodeButton.name;
            this.number = nodeButton.number;
            this.location = nodeButton.location;
            this.Location = nodeButton.Location;
            this.Image = nodeButton.Image;
            this.Height = nodeButton.Height;
            this.Width = nodeButton.Width;
            this.Click += eventHandler;
            this.setBasicInfos();
            this.selectedState = 0;
        }

        public NodeButton(Point location,Image image,EventHandler eventHandler)
        {            
            this.Image = image;
            this.Height = image.Height;
            this.Width = image.Width;
            this.Location = location;            
            this.Click += eventHandler;
            this.setBasicInfos();
        }

        private void setBasicInfos()
        {
            this.ForeColor = Color.Transparent;
            this.BackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;

            this.BringToFront();
        }

        public void setInfo(string name,string number,Point location){
            this.name = name;
            this.number = number;
            this.location = location;
        }
    }
}
