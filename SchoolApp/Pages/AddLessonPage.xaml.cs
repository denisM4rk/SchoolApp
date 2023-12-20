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
    /// Логика взаимодействия для AddLessonPage.xaml
    /// </summary>
    public partial class AddLessonPage : Page
    {
        public AddLessonPage()
        {
            InitializeComponent();

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

        private void CmbClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classes selectedClass = (Classes)CmbClass.SelectedItem;
            CmbStudent.ItemsSource = selectedClass.Students;
            CmbStudent.SelectedValuePath = "Id";
            CmbStudent.DisplayMemberPath = "FullName";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CmbClass.Text == null)
            {
                MessageBox.Show("Выберите класс",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbGrade.Text == null)
            {
                MessageBox.Show("Выберите оценку",
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
                MessageBox.Show("Выберите дату",
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
            else
            {
                try
                {
                    Lessons lessonsObj = new Lessons()
                    {
                        IdClass = CmbClass.SelectedIndex+1,
                        IdStudent = CmbStudent.SelectedIndex + 1,
                        GradeDate = Convert.ToDateTime(GradeDate.SelectedDate),
                        IdSubject = CmbSubject.SelectedIndex + 1,
                        IdGrade = CmbGrade.SelectedIndex + 1
                    };

                    DbConnect.entObj.Lessons.Add(lessonsObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Данные об оценке добавлены!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new LessonsPage());
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
    }
}
