using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class User
    {
        private string password;
        private string username;
        private Job job;
        
        public User(DataSet data)
        {
            this.password = data.Tables[0].Rows[0][2].ToString().Trim(' ');
            this.username = data.Tables[0].Rows[0][1].ToString().Trim(' ');
            Dictionary<string, Job> dictionary = new Dictionary<string, Job>();
            dictionary.Add("Manager", Job.Manager);
            dictionary.Add("Receptionist", Job.Receptionist);
            string test = data.Tables[0].Rows[0][3].ToString().Trim(' ');
            this.job = dictionary[test];

        }
    }
}
