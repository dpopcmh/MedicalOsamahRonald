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
    /// Interaction logic for patientRecord.xaml
    /// </summary>
    public partial class patientRecord : Window
    {
        public patientRecord()
        {
            InitializeComponent();
            DataContext = SelectedPatient.CurrentPatient;
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
