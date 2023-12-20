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
    /// Логика взаимодействия для LessonsPage.xaml
    /// </summary>
    public partial class LessonsPage : Page
    {
        private Lessons selectedLesson;
        private List<Students> allStudents;
        public LessonsPage()
        {
            InitializeComponent();

            LessonsGrid.ItemsSource = DbConnect.entObj.Lessons.ToList();
            allStudents = DbConnect.entObj.Students.ToList();

            CmbClass.ItemsSource = DbConnect.entObj.Classes.ToList();
            CmbClass.SelectedValuePath = "Id";
            CmbClass.DisplayMemberPath = "Name";
        }

        private void LessonsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedLesson = (Lessons)LessonsGrid.SelectedItem;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedLesson != null)
            {
                EditLessonPage editPage = new EditLessonPage(selectedLesson);
                FrameApp.frmObj.Navigate(editPage);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LessonsGrid.SelectedItem != null)
            {
                var filesForRemoving = LessonsGrid.SelectedItems.Cast<Lessons>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Lessons.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        LessonsGrid.ItemsSource = DbConnect.entObj.Lessons.ToList();
                    }
                    else
                    {
                        LessonsGrid.ItemsSource = DbConnect.entObj.Lessons.ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Критический сбой в работе приложения: " + ex.Message.ToString(),
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddLessonPage());
        }

        private void CmbClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbClass.SelectedItem as Classes;
            var items = (select != null) ? allStudents.Where(x => x.IdClass == select.Id) : allStudents;
            List<Lessons> filteredStudents = ((List<Lessons>)LessonsGrid.ItemsSource).Where(s => s.IdClass == select.Id).ToList();
            LessonsGrid.ItemsSource = filteredStudents;
        }
    }
}
