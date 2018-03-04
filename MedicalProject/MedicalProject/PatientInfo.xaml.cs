﻿using System;
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
    /// Interaction logic for PatientRecord.xaml
    /// </summary>
    public partial class PatientInfo : Window
    {
        public ObservableCollection<MedicalProjectClassLibrary.PatientInformation> patientlist = new ObservableCollection<MedicalProjectClassLibrary.PatientInformation>();
        public PatientInfo()
        {
            InitializeComponent();
            try
            {
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Data" + "\\patientinformation.txt";
                FileStream fs = new FileStream(path2, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                int newestid = 1;
                while (sr.Peek() != -1)
                {
                    string singlepatient = sr.ReadLine();
                    string[] singlepatientdata = singlepatient.Split('|');
                    PatientInformation patient = new PatientInformation() { FirstName = singlepatientdata[0], LastName = singlepatientdata[1], DateOfBirth = singlepatientdata[2],
                    AdmitDate = singlepatientdata[3], Age = Int32.Parse(singlepatientdata[4]), Gender = singlepatientdata[5], ChiefComplaint = singlepatientdata[6], NotDischarged = Convert.ToBoolean(singlepatientdata[7]), IDNumber = newestid++.ToString("D5") };
                    if (singlepatientdata[7] == "True")
                    {
                        patientlist.Add(patient);
                    }
                    PatientTable.ItemsSource = patientlist;
                }
                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error finding patients...");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PatientTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedPatient.CurrentPatient = (PatientInformation)PatientTable.SelectedItems[0];
            patientRecord sw = new patientRecord();
            sw.Show();
            this.Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void PatientTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
