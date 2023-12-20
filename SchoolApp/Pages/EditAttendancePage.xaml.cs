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
    /// Логика взаимодействия для EditAttendancePage.xaml
    /// </summary>
    public partial class EditAttendancePage : Page
    {
        private Attendance attendance;
        public EditAttendancePage(Attendance selectedAttendance)
        {
            InitializeComponent();

            this.attendance = selectedAttendance;

            CmbTeacher.ItemsSource = DbConnect.entObj.Teachers.ToList();
            CmbTeacher.SelectedValuePath = "Id";
            CmbTeacher.DisplayMemberPath = "FullName";

            CmbSubject.ItemsSource = DbConnect.entObj.Subjects.ToList();
            CmbSubject.SelectedValuePath = "Id";
            CmbSubject.DisplayMemberPath = "Name";

            CmbClass.ItemsSource = DbConnect.entObj.Classes.ToList();
            CmbClass.SelectedValuePath = "Id";
            CmbClass.DisplayMemberPath = "Name";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (attendance != null)
            {
                attendance.Attendance1 = CmbAttendance.Text;
                attendance.IdStudent = CmbStudent.SelectedIndex + 1;
                attendance.IdSubject = CmbSubject.SelectedIndex + 1;
                attendance.IdTeacher = CmbTeacher.SelectedIndex + 1;
                attendance.Date = Convert.ToDateTime(GradeDate.SelectedDate);

                DbConnect.entObj.SaveChanges();
                DbConnect.entObj.Attendance.ToList();

                MessageBox.Show("Изменения внесены успешно!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                FrameApp.frmObj.Navigate(new LessonsPage());
            }
        }

        private void CmbClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classes selectedClass = (Classes)CmbClass.SelectedItem;
            CmbStudent.ItemsSource = selectedClass.Students;

            CmbStudent.SelectedValuePath = "Id";
            CmbStudent.DisplayMemberPath = "FullName";
        }
    }
}
