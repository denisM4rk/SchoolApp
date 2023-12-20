using SchoolApp.AppFiles;
using System;
using System.Collections.Generic;
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

namespace SchoolApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainAdminPage.xaml
    /// </summary>
    public partial class MainAdminPage : Page
    {
        public MainAdminPage()
        {
            InitializeComponent();
        }

        private void BtnLicense_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ComputersPage());
        }

        private void BtnTeachers_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TeachersPage());
        }

        private void BtnStudents_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new StudentsPage());
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new UsersPage());
        }
    }
}
