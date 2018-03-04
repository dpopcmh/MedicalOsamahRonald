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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MedicalProjectClassLibrary;

namespace MedicalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Main_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        List<User> userlist = new List<User>();
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Data" + "\\users.txt";
                FileStream fs = new FileStream(path2, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                while (sr.Peek() != -1)
                {
                    string singleuser = sr.ReadLine();
                    string[] singleuserdata = singleuser.Split('|');
                    User user = new User() { UserName = singleuserdata[0], PassWord = singleuserdata[1], JobTitle = singleuserdata[2] };
                    userlist.Add(user);
                }
                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error reading file...");
            }
            bool loggedin = false;
            foreach (var u in userlist)
            {
                if ((txtBxUsername.Text.Trim() == u.UserName) & (passwordBox.Password == u.PassWord))
                {
                    PatientInfo sw = new PatientInfo();
                    sw.Show();
                    this.Close();
                    loggedin = true;
                    if (u.JobTitle == "Doctor")
                    {
                        SavedLogin.IsDoctor = true;
                    }
                    break;
                }
            }
           if (loggedin == false)
           MessageBox.Show("Wrong password/username... Try again");   
        }
    }
}
