using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Patient
    {
        private string patientID;
        private string patientName;
        private string patientDateOfBirth;
        private string patientAddress;

        public Patient(DataSet data)
        {
            this.patientID = data.Tables[0].Rows[0][0].ToString().Trim(' ');
            this.patientName = data.Tables[0].Rows[0][1].ToString().Trim(' ');
            this.patientDateOfBirth = data.Tables[0].Rows[0][2].ToString().Trim(' ');
            this.patientAddress = data.Tables[0].Rows[0][3].ToString().Trim(' ');

        }
    }
}

