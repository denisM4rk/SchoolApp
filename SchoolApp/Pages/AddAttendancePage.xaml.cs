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
    /// Логика взаимодействия для AddAttendancePage.xaml
    /// </summary>
    public partial class AddAttendancePage : Page
    {
        public AddAttendancePage()
        {
            InitializeComponent();

            CmbClass.ItemsSource = DbConnect.entObj.Classes.ToList();
            CmbClass.SelectedValuePath = "Id";
            CmbClass.DisplayMemberPath = "Name";

            CmbTeacher.ItemsSource = DbConnect.entObj.Teachers.ToList();
            CmbTeacher.SelectedValuePath = "Id";
            CmbTeacher.DisplayMemberPath = "FullName";

            CmbSubject.ItemsSource = DbConnect.entObj.Subjects.ToList();
            CmbSubject.SelectedValuePath = "Id";
            CmbSubject.DisplayMemberPath = "Name";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CmbAttendance.Text == null)
            {
                MessageBox.Show("Выберите статус присутствия",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbStudent.Text == null)
            {
                MessageBox.Show("Выберите ученика",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (GradeDate.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату урока",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbSubject.Text == null)
            {
                MessageBox.Show("Выберите предмет",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbTeacher.Text == null)
            {
                MessageBox.Show("Выберите учителя",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Attendance attendancesObj = new Attendance()
                    {
                        IdStudent = CmbStudent.SelectedIndex + 1,
                        Date = Convert.ToDateTime(GradeDate.SelectedDate),
                        IdSubject = CmbSubject.SelectedIndex + 1,
                        IdTeacher = CmbTeacher.SelectedIndex + 1,
                        Attendance1 = CmbAttendance.Text
                    };

                    DbConnect.entObj.Attendance.Add(attendancesObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Данные добавлены!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new AttendancePage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                                    "Критический сбой работы приложения",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                }
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
