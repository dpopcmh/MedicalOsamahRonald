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
        public string FirstName
        {
            get { return _firstName; }
        }


        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
        }


        private DateTime _dateofbirth;
        public DateTime DateOfBirth
        {
            get { return _dateofbirth; }
        }


        private DateTime _admitdate;
        public DateTime AdmitDate
        {
            get { return _admitdate; }
        }

        public int Age
        {
            get
            { return Age; }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
        }

        private string _chiefcomplaint;
        public string ChiefComplaint
        {
            get { return _chiefcomplaint; }
        }
    }
}
