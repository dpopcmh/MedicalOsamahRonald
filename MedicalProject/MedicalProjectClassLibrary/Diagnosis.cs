using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProjectClassLibrary
{
    public class Diagnosis
    {
        public string IDNumber { get; set; }

        public string Opinion { get; set; }

        public string DoctorName { get; set; }

        public string DateDiagnosis { get; set; }

        public override string ToString()
        {
            return Opinion + " - " + DoctorName + " - " + DateDiagnosis;
        }
    }
}
