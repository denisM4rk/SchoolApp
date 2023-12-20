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
    /// Логика взаимодействия для MainTeacherPage.xaml
    /// </summary>
    public partial class MainTeacherPage : Page
    {
        public MainTeacherPage()
        {
            InitializeComponent();
        }

        private void BtnLessons_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new LessonsPage());
        }

        private void BtnAttendance_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AttendancePage());
        }

        private void BtnSubjects_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TeachersSubjectsPage());
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
