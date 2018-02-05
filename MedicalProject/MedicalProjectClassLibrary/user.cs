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
        public string UserName
        {
            get { return _username; }
        }

        private string _password;
        public string PassWord
        {
            get { return _password; }
        }

        private bool _isdoctor;
        public bool IsDoctor
        {
            get { return _isdoctor; }
        }
    }
}
