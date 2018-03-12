using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProjectClassLibrary
{
    public class Allergy
    {
        public string IDNumber { get; set; }

        public string SpecificAllergy { get; set; }

        public override string ToString()
        {
            return SpecificAllergy;
        }
    }
}
