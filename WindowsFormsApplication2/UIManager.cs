using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public sealed class UIManager
    {

        private Form1 mainForm = new Form1();
        private LoggInScreen myLoggInScreen = new LoggInScreen();

        private static readonly UIManager instance = new UIManager();

        static UIManager()
        {
        }

        private UIManager()
        {
        }

        public static UIManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void callLoginScreen()
        {
            myLoggInScreen.FormClosing += Form_FormClosing;
            mainForm.Visible = false;
            mainForm.FormClosing += Form_FormClosing;
            Application.Run(myLoggInScreen);   
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCancel(e);
        }

        public void swapVisibility()
        {
            if(myLoggInScreen.Visible == true)
            {
                myLoggInScreen.Visible = false;
                mainForm.Visible = true;
            }
            else if(mainForm.Visible == true)
            {
                mainForm.Visible = false;
                myLoggInScreen.Visible = true;
                
            }
        }

        public void logOffBut_ClickUi(EventArgs e)
        {
            const string message = "Are you sure that you would like to log out?";
            const string caption = "Log Out";
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Instance.swapVisibility();
            }
        }

        public void CloseCancel(FormClosingEventArgs e)
        {

                const string message = "Are you sure that you would like to exit?";
                const string caption = "Attention";
                var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                myLoggInScreen.FormClosing -= Form_FormClosing;
                mainForm.FormClosing -= Form_FormClosing;
                Application.Exit();
            }
        }
    }
}
