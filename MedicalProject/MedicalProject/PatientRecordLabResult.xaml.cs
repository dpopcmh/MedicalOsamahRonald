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
            patientRecord sw = new patientRecord();
            sw.Show();
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Data" + "\\labresults.txt";
                {
                    List<string> filetext = File.ReadAllLines(path2).ToList();
                    filetext.Add(SelectedPatient.CurrentPatient.IDNumber + "|" + txtLabType.Text + "|" + txtLabResult.Text + "|" + DateTime.Now.ToString("MM/dd/yyyy"));
                    File.WriteAllLines(path2, filetext);
                    patientRecord sw = new patientRecord();
                    sw.Show();
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
