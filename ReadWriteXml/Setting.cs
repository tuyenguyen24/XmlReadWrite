using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadWriteXml
{
    public partial class settingForm : Form
    {
        public settingForm()
        {
            InitializeComponent();
        }

        private void ckLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (ckLimit.Checked)
            {
                numericUpDown1.Enabled = true;
            }
            else
            {
                numericUpDown1.Enabled = false;
            }
        }
    }
}
