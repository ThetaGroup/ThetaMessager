using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheataMessager;

namespace ThetaMessager.Forms
{
    public partial class ClearCacheForm : Form
    {
        public ClearCacheForm()
        {
            InitializeComponent();
        }

        private void ClearCacheForm_Load(object sender, EventArgs e)
        {

        }

        private void ClearCacheForm_Shown(object sender, EventArgs e)
        {
            for (int i = 1; i <= 50; i++)
            {
                ComUtils.clearMessage(i);
                this.clearProgressBar.Value = i * 2;
            }
            this.Close();
        }
    }
}
