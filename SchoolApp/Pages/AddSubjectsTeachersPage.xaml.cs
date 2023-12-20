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
    /// Логика взаимодействия для AddSubjectsTeachersPage.xaml
    /// </summary>
    public partial class AddSubjectsTeachersPage : Page
    {
        public AddSubjectsTeachersPage()
        {
            InitializeComponent();

            CmbTeacher.ItemsSource = DbConnect.entObj.Teachers.ToList();
            CmbTeacher.SelectedValuePath = "Id";
            CmbTeacher.DisplayMemberPath = "FullName";

            CmbSubject.ItemsSource = DbConnect.entObj.Subjects.ToList();
            CmbSubject.SelectedValuePath = "Id";
            CmbSubject.DisplayMemberPath = "Name";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CmbTeacher.Text == null)
            {
                MessageBox.Show("Выберите учителя",
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
                    Teachers_Subjects teachersSubjectsObj = new Teachers_Subjects()
                    {
                        IdTeacher = CmbTeacher.SelectedIndex + 1,
                        IdSubject = CmbSubject.SelectedIndex + 1
                    };

                    DbConnect.entObj.Teachers_Subjects.Add(teachersSubjectsObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Данные добавлены!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new TeachersSubjectsPage());
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
