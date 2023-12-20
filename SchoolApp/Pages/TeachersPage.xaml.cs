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
    /// Логика взаимодействия для TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        private Teachers selectedTeacher;

        public TeachersPage()
        {
            InitializeComponent();

            TeachersGrid.ItemsSource = DbConnect.entObj.Teachers.ToList();
        }

        private void TeachersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeacher = (Teachers)TeachersGrid.SelectedItem;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddTeacherPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TeachersGrid.SelectedItem != null)
            {
                var filesForRemoving = TeachersGrid.SelectedItems.Cast<Teachers>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Teachers.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        TeachersGrid.ItemsSource = DbConnect.entObj.Teachers.ToList();
                    }
                    else
                    {
                        TeachersGrid.ItemsSource = DbConnect.entObj.Teachers.ToList();
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

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTeacher != null)
            {
                EditTeacherPage editPage = new EditTeacherPage(selectedTeacher);
                FrameApp.frmObj.Navigate(editPage);
            }
        }

        private void BtnTeachersSubjects_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddSubjectsTeachersPage());
        }
    }
}
