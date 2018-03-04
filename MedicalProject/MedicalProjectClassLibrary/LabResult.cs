using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProjectClassLibrary
{
    public class LabResult
    {
        public string IDNumber { get; set; }

        public string TestType { get; set; }

        public string TestResult { get; set; }

        public string TestDate { get; set; }

        public override string ToString()
        {
            return TestType + " - " + TestResult + " - " + TestDate;
        }
    }
}
