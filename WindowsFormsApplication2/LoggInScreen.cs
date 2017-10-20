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
    public partial class LoggInScreen : Form
    {
        public LoggInScreen()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {


            if (UIManager.Instance.ClickLogIn(usernameTxtBox.Text, passwordTxtBox.Text) == true)
            {
                UIManager.Instance.swapVisibility();
                passwordTxtBox.Text = "";
                invalidTextBox.Visible = false;
            }
            else
            {
                invalidTextBox.Visible = true;

            }
            
        }

        private void showPassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassCheckBox.Checked)
            {
                passwordTxtBox.UseSystemPasswordChar = false;
            }
            else
            {
                passwordTxtBox.UseSystemPasswordChar = true;
            }
        }
    }
}
