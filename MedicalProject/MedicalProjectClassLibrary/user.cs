using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProjectClassLibrary
{
    public class User
    {
        private string _username;
        public string UserName { get; set; }

        private string _password;
        public string PassWord { get; set; }

        private string _jobtitle;
        public string JobTitle { get; set; }
    }
}
