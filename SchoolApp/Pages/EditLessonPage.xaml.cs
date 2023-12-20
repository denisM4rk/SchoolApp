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
    /// Логика взаимодействия для EditLessonPage.xaml
    /// </summary>
    public partial class EditLessonPage : Page
    {
        private Lessons lessons;
        public EditLessonPage(Lessons selectedLessons)
        {
            InitializeComponent();

            this.lessons = selectedLessons;

            CmbClass.ItemsSource = DbConnect.entObj.Classes.ToList();
            CmbClass.SelectedValuePath = "Id";
            CmbClass.DisplayMemberPath = "Name";

            CmbGrade.ItemsSource = DbConnect.entObj.Grades.ToList();
            CmbGrade.SelectedValuePath = "Id";
            CmbGrade.DisplayMemberPath = "Grade";

            CmbSubject.ItemsSource = DbConnect.entObj.Subjects.ToList();
            CmbSubject.SelectedValuePath = "Id";
            CmbSubject.DisplayMemberPath = "Name";

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lessons != null)
            {
                lessons.IdClass = CmbClass.SelectedIndex+1;
                lessons.IdGrade = CmbGrade.SelectedIndex+1;
                lessons.IdStudent = CmbStudent.SelectedIndex+1;
                lessons.IdSubject = CmbSubject.SelectedIndex+1;
                lessons.GradeDate = Convert.ToDateTime(GradeDate.SelectedDate);

                DbConnect.entObj.SaveChanges();
                DbConnect.entObj.Lessons.ToList();

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
