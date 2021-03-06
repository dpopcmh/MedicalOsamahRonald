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
                while (sr.Peek() != -1)
                {
                    string singlepatient = sr.ReadLine();
                    string[] singlepatientdata = singlepatient.Split('|');
                    PatientInformation patient = new PatientInformation() { IDNumber = singlepatientdata[0], FirstName = singlepatientdata[1], LastName = singlepatientdata[2], DateOfBirth = singlepatientdata[3],
                    AdmitDate = singlepatientdata[4], Age = Int32.Parse(singlepatientdata[5]), Gender = singlepatientdata[6], ChiefComplaint = singlepatientdata[7], NotDischarged = Convert.ToBoolean(singlepatientdata[8]) };
                    if (singlepatientdata[8] == "True")
                    {
                        patientlist.Add(patient);
                    }
                    PatientTable.ItemsSource = patientlist;
                    string newestid = singlepatientdata[0];
                    int nextid = Int32.Parse(newestid) + 1;
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
            
            try
            {
                patientlist.Clear();
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Data" + "\\patientinformation.txt";
                FileStream fs = new FileStream(path2, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string singlepatient = sr.ReadLine();
                    string[] singlepatientdata = singlepatient.Split('|');
                    PatientInformation patient = new PatientInformation() { IDNumber = singlepatientdata[0], FirstName = singlepatientdata[1], LastName = singlepatientdata[2], DateOfBirth = singlepatientdata[3], AdmitDate = singlepatientdata[4], Age = Int32.Parse(singlepatientdata[5]), Gender = singlepatientdata[6], ChiefComplaint = singlepatientdata[7], NotDischarged = Convert.ToBoolean(singlepatientdata[8]) };
                    if (singlepatientdata[8] == "True")
                    {
                        if ((txtBxFName.Text.Length > 0) & (singlepatientdata[1].Contains(txtBxFName.Text)) | ((txtBxLName.Text.Length > 0) & (singlepatientdata[2].Contains(txtBxLName.Text)) | ((txtBxChComp.Text.Length > 0) & (singlepatientdata[7].Contains(txtBxChComp.Text)) | ((txtBxAge.Text.Length > 0) & (singlepatientdata[5] == (txtBxAge.Text))))))
                        {
                            patientlist.Add(patient);
                        }
                    }
                }
                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Search error...");
            }
        }

        private void PatientTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SelectedPatient.CurrentPatient = (PatientInformation)PatientTable.SelectedItems[0];
                patientRecord sw = new patientRecord();
                sw.Show();
                this.Close();
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (System.InvalidOperationException)
            {

            }
        }
        private void PatientTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
 
        private void LogOutbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow sw = new MainWindow();
            sw.Show();
            this.Close();
        }

        private void Refreshbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                patientlist.Clear();
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Data" + "\\patientinformation.txt";
                FileStream fs = new FileStream(path2, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string singlepatient = sr.ReadLine();
                    string[] singlepatientdata = singlepatient.Split('|');
                    PatientInformation patient = new PatientInformation() { IDNumber = singlepatientdata[0], FirstName = singlepatientdata[1], LastName = singlepatientdata[2], DateOfBirth = singlepatientdata[3], AdmitDate = singlepatientdata[4], Age = Int32.Parse(singlepatientdata[5]), Gender = singlepatientdata[6], ChiefComplaint = singlepatientdata[7], NotDischarged = Convert.ToBoolean(singlepatientdata[8]) };
                    if (singlepatientdata[8] == "True")
                    {
                        patientlist.Add(patient);
                    }
                    PatientTable.ItemsSource = patientlist;
                }
                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error refreshing patients...");
            }
        }

        private void Addpatientbtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
