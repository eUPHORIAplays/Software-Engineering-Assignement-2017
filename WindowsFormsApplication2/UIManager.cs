﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public sealed class UIManager
    {

        private MainForm mainForm = new MainForm();
        private LoggInScreen myLoggInScreen = new LoggInScreen();
        private User activeUser;
        private Patient activePatient;
        private Calendar calendarForm;

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

        internal DataSet ProjectSelectedDateToCalendar(string selectedDate)
        {
            string sql = @"SELECT DISTINCT a.AppointmentTime, s.StaffMemberName, p.PatientName FROM Appointments a INNER JOIN StaffMembers s on a.StaffID = s.Id INNER JOIN Patients p on a.PatientID = p.Id WHERE a.AppointmentDate = '" + selectedDate + "'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
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

        internal void showCalendar()
        {
            calendarForm = new Calendar();
            calendarForm.ShowDialog();
        }

        internal bool ConfirmSearchPatientClick(string name, string address, string dOb)
        {
            string sql = @"SELECT * FROM Patients WHERE name = '" + name + "'AND Address = '" + address + "'AND dateOfBirth = '" + dOb + "'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            if (Utility.CheckFind(ds))
            {
                UIManager.Instance.activePatient = new Patient(ds);
                return true;
            }
            else return false;

        }

        internal bool ConfirmSearchPatientClick(string id)
        {
            string sql = @"SELECT * FROM Patients WHERE Id = '" + id + "'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            if (Utility.CheckFind(ds))
            {
                UIManager.Instance.activePatient = new Patient(ds);
                return true;
            }
            else return false;
        }

        public bool ClickLogIn(string userName, string password)
        {
            
            string sql = @"SELECT * FROM Users WHERE Username = '" + userName + "'AND Password = '" + password +"'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            if (Utility.CheckFind(ds))
            {
                UIManager.Instance.activeUser = new User(ds);
                return true;
            }
            else return false;
           
             
        }

        
    }
    public static class Utility
    {
        public static bool CheckFind(DataSet ds)
        {

            if (ds.Tables[0].Rows.Count == 1)
            {
                return true;
            }
            else if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Multiple Entries with the same credentials");
                Console.ReadLine();
                return false;
            }
        }
    }
}
