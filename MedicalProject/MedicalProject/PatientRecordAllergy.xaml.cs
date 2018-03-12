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

namespace MedicalProject
{
    /// <summary>
    /// Interaction logic for PatientRecordAllergy.xaml
    /// </summary>
    public partial class PatientRecordAllergy : Window
    {
        public PatientRecordAllergy()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Data" + "\\allergies.txt";
                {
                    List<string> filetext = File.ReadAllLines(path2).ToList();
                    filetext.Add(SelectedPatient.CurrentPatient.IDNumber + "|" + txtAllergy.Text);
                    File.WriteAllLines(path2, filetext);
                    patientRecord sw = new patientRecord();
                    sw.Show();
                    this.Close();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error adding allergy...");
            }
        }

        
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

       
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            patientRecord sw = new patientRecord();
            sw.Show();
            this.Close();
        }
    }
}