using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButtonID.Checked = true;
        }

        private void radioButtonID_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonID.Checked == true)
            {
                nameLabel.Enabled = false;
                nametextBox.Enabled = false;
                addressLabel.Enabled = false;
                addresstextBox.Enabled = false;
                dObLabel.Enabled = false;
                dObtextBox.Enabled = false;
                idLabel.Enabled = true;
                iDtextBox.Enabled = true;
            }
            else
            {
                nameLabel.Enabled = true;
                nametextBox.Enabled = true;
                addressLabel.Enabled = true;
                addresstextBox.Enabled = true;
                dObLabel.Enabled = true;
                dObtextBox.Enabled = true;
                idLabel.Enabled = false;
                iDtextBox.Enabled = false;
            }
        }

        private void logOffBut_Click(object sender, EventArgs e)
        {
            UIManager.Instance.logOffBut_ClickUi(e);
        }
    }
}
