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
        public bool logOut = false;

        public Form1()
        {
            InitializeComponent();
            
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseCancel(e);
        }

        public void CloseCancel(FormClosingEventArgs e)
        {

            if (logOut == false)
            {
                const string message = "Are you sure that you would like to exit?";
                const string caption = "Attention";
                var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

                e.Cancel = (result == DialogResult.No);
            }
          
            

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
            const string message = "Are you sure that you would like to log out?";
            const string caption = "Log Out";
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                logOut = true;
                this.Close();
                
                LoggInScreen logInForm = new LoggInScreen();
                logInForm.Show();
            }
        }
    }
}
