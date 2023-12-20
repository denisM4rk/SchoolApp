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
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        private Students selectedStudents;

        public StudentsPage()
        {
            InitializeComponent();

            StudentsGrid.ItemsSource = DbConnect.entObj.Students.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddStudentsPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsGrid.SelectedItem != null)
            {
                var filesForRemoving = StudentsGrid.SelectedItems.Cast<Students>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Students.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        StudentsGrid.ItemsSource = DbConnect.entObj.Students.ToList();
                    }
                    else
                    {
                        StudentsGrid.ItemsSource = DbConnect.entObj.Students.ToList();
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
            if (selectedStudents != null)
            {
                EditStudentsPage editPage = new EditStudentsPage(selectedStudents);
                FrameApp.frmObj.Navigate(editPage);
            }
        }

        private void StudentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudents = (Students)StudentsGrid.SelectedItem;
        }

        private void BtnAttendance_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
