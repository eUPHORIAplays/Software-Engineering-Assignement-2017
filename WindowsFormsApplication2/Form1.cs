using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.MinimumSize = new System.Drawing.Size(this.Width + 50, this.Height + 50);

            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            radioButtonID.Checked = true;
            foreach (Control c in this.Controls)
            {
                c.Anchor = AnchorStyles.None;
            }
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
