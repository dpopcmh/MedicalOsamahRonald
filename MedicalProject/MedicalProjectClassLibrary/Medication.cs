using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProjectClassLibrary
{
    public class Medication
    {
        public string IDNumber { get; set; }

        public string MedicationName { get; set; }

        public string Dose { get; set; }

        public string DatePrescribed { get; set; }

        public override string ToString()
        {
            return MedicationName + " - " + Dose + " - " + DatePrescribed;
        }
    }
}
