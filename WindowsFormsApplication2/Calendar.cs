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
    public partial class Calendar : Form
    {
        public Calendar()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(this.Width + 50, this.Height + 50);

            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
           
            foreach (Control c in this.Controls)
            {
                c.Anchor = AnchorStyles.None;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            myGrid.DataSource = UIManager.Instance.ProjectSelectedDateToCalendar(myCalendar.SelectionRange.Start.ToShortDateString().Replace('/', '_')).Tables[0];
        }

        private void OnDateSelected(object sender, DateRangeEventArgs e)
        {
            myGrid.DataSource = UIManager.Instance.ProjectSelectedDateToCalendar(myCalendar.SelectionRange.Start.ToShortDateString().Replace('/', '_')).Tables[0];
        }
    }
}
