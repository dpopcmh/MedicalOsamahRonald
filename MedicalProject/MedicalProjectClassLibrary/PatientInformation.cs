using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProjectClassLibrary
{
    public class PatientInformation
    {
        private string _firstName;
        public string FirstName { get; set; }


        private string _lastName;
        public string LastName { get; set; }


        private string _dateofbirth;
        public string DateOfBirth { get; set; }


        private string _admitdate;
        public string AdmitDate { get; set; }

        public int Age { get; set; }

        private string _gender;
        public string Gender { get; set; }

        private string _chiefcomplaint;
        public string ChiefComplaint { get; set; }

        private string _idnumber;
        public string IDNumber { get; set; }
    }
}
