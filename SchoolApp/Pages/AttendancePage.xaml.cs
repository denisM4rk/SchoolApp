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
    /// Логика взаимодействия для AttendancePage.xaml
    /// </summary>
    public partial class AttendancePage : Page
    {
        private Attendance selectedAttendance;

        public AttendancePage()
        {
            InitializeComponent();

            AttendanceGrid.ItemsSource = DbConnect.entObj.Attendance.ToList();
        }

        private void AttendanceGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAttendance = (Attendance)AttendanceGrid.SelectedItem;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAttendance != null)
            {
                EditAttendancePage editPage = new EditAttendancePage(selectedAttendance);
                FrameApp.frmObj.Navigate(editPage);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddAttendancePage());
        }
    }
}
