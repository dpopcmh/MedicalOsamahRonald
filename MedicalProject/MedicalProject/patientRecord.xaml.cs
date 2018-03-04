using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MedicalProjectClassLibrary;
using System.Collections.ObjectModel;

namespace MedicalProject
{
    /// <summary>
    /// Interaction logic for patientRecord.xaml
    /// </summary>
    public partial class patientRecord : Window
    {
        public ObservableCollection<MedicalProjectClassLibrary.Diagnosis> patientdiagnosislist = new ObservableCollection<MedicalProjectClassLibrary.Diagnosis>();
        public ObservableCollection<MedicalProjectClassLibrary.Medication> patientmedicationlist = new ObservableCollection<MedicalProjectClassLibrary.Medication>();
        public ObservableCollection<MedicalProjectClassLibrary.LabResult> patientlabresultlist = new ObservableCollection<MedicalProjectClassLibrary.LabResult>();
        public patientRecord()
        {
            InitializeComponent();
            string imagepath = System.Environment.CurrentDirectory;
            string imagepath2 = imagepath.Substring(0, imagepath.LastIndexOf("bin")) + "Photos" + "\\" + SelectedPatient.CurrentPatient.IDNumber + ".png";
            if (File.Exists(imagepath2))
                {
                 { PatientImage.Source = new BitmapImage(new Uri(imagepath2)); }
                }
            DataContext = SelectedPatient.CurrentPatient;

            try
            {
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Data" + "\\diagnosis.txt";
                FileStream fs = new FileStream(path2, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string singledataentry = sr.ReadLine();
                    string[] singledatasplit = singledataentry.Split('|');
                    Diagnosis diagnosis = new Diagnosis() { IDNumber = singledatasplit[0], Opinion = singledatasplit[1], DoctorName = singledatasplit[2], DateDiagnosis = singledatasplit[3] };
                    if (singledatasplit[0] == SelectedPatient.CurrentPatient.IDNumber)
                    {
                     patientdiagnosislist.Add(diagnosis);
                     patientDiagnosis.ItemsSource = patientdiagnosislist;
                    }
                }
                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error finding diagnosis...");
            }

            try
            {
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Data" + "\\medication.txt";
                FileStream fs = new FileStream(path2, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string singledataentry = sr.ReadLine();
                    string[] singledatasplit = singledataentry.Split('|');
                    Medication medication = new Medication() { IDNumber = singledatasplit[0], MedicationName = singledatasplit[1], Dose = singledatasplit[2], DatePrescribed = singledatasplit[3] };
                    if (singledatasplit[0] == SelectedPatient.CurrentPatient.IDNumber)
                    {
                        patientmedicationlist.Add(medication);
                        patientMedication.ItemsSource = patientmedicationlist;
                    }
                }
                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error finding medications...");
            }

            try
            {
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Data" + "\\labresults.txt";
                FileStream fs = new FileStream(path2, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string singledataentry = sr.ReadLine();
                    string[] singledatasplit = singledataentry.Split('|');
                    LabResult labresult = new LabResult() { IDNumber = singledatasplit[0], TestType = singledatasplit[1], TestResult = singledatasplit[2], TestDate = singledatasplit[3] };
                    if (singledatasplit[0] == SelectedPatient.CurrentPatient.IDNumber)
                    {
                        patientlabresultlist.Add(labresult);
                        patientLabResult.ItemsSource = patientlabresultlist;
                    }
                }
                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error finding lab results...");
            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SavedLogin.IsDoctor == true)
            {
                PatientRecordDiagnosis sw = new PatientRecordDiagnosis();
                sw.Show();
            }
            else
            {
                MessageBox.Show("Only doctors may add a diagnosis.");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            PatientInfo sw = new PatientInfo();
            sw.Show();
            this.Close();
        }
    }
}
