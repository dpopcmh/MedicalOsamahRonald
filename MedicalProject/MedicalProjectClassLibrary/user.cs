using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProjectClassLibrary
{
    public class User
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string JobTitle { get; set; }
    }
    public static class SavedLogin
    {
        public static bool IsDoctor { get; set; }
    }
}
