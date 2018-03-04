using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProjectClassLibrary
{
    public class PatientInformation
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string AdmitDate { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string ChiefComplaint { get; set; }

        public bool NotDischarged { get; set; }

        public string IDNumber { get; set; }
    }
    public static class SelectedPatient
    {
        public static PatientInformation CurrentPatient = new PatientInformation();
    }
    public static class EditText
    {
        static void LineEdit (string NewText, string FileName, int ChosenLine)
        {
            string[] AllLine = File.ReadAllLines(FileName);
            AllLine[ChosenLine - 1] = NewText;
            File.WriteAllLines(FileName, AllLine);
        }
    }
}