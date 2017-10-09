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
            
            LoggInScreen.ActiveForm.Hide();
            Form1 mainForm = new Form1();
            mainForm.ShowDialog();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseCancel(e);
        }

        public static void CloseCancel(FormClosingEventArgs e)
        {
            const string message = "Are you sure that you would like to exit?";
            const string caption = "See you later";
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
            e.Cancel = (result == DialogResult.No);
            if (result == DialogResult.Yes)
            {
                
            }
            
             
        }
    }
}
