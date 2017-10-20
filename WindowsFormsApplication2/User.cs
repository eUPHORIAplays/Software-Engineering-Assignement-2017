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
        public enum Job
        {
            Receptionist,
            Manager
        };
        

        private string password;
        private string username;
        private Job job;
        
        public User(DataSet data)
        {
            this.password = data.Tables[0].Rows[0][2].ToString().Replace(" ", "");
            this.username = data.Tables[0].Rows[0][1].ToString().Replace(" ", "");
            Dictionary<string, Job> dictionary = new Dictionary<string, Job>();
            dictionary.Add("Manager", Job.Manager);
            dictionary.Add("Receptionist", Job.Receptionist);
            string test = data.Tables[0].Rows[0][3].ToString().Replace(" ", "");
            this.job = dictionary[test];

        }
    }
}
