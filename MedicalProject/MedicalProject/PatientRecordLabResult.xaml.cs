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
    /// Interaction logic for PatientRecordLabResult.xaml
    /// </summary>
    public partial class PatientRecordLabResult : Window
    {
        public PatientRecordLabResult()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Data" + "\\labresults.txt";
                using (FileStream fs = new FileStream(path2, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(SelectedPatient.CurrentPatient.IDNumber + "|" + txtLabType.Text + "|" + txtLabResult.Text + "|" + DateTime.Now.ToString("MM/dd/yyyy"));
                    sw.Close();
                    fs.Close();
                    this.Close();
                }

            }

            catch (Exception)
            {
                MessageBox.Show("Error adding lab result...");
            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
