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
    /// Логика взаимодействия для EditStudentsPage.xaml
    /// </summary>
    public partial class EditStudentsPage : Page
    {
        private Students students;

        public EditStudentsPage(Students selectedStudents)
        {
            InitializeComponent();

            this.students = selectedStudents;
            if (students != null)
            {
                TxbName.Text = students.FullName;
                CmbGender.Text = students.Gender;
                BirthDate.SelectedDate = Convert.ToDateTime(students.DateOfBirth);
                CmbClass.Text = Convert.ToString(students.IdClass);
            }

            CmbClass.ItemsSource = DbConnect.entObj.Classes.ToList();
            CmbClass.SelectedValuePath = "Id";
            CmbClass.DisplayMemberPath = "Name";
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (students != null)
            {
                students.FullName = TxbName.Text;
                students.DateOfBirth = Convert.ToDateTime(BirthDate.SelectedDate);
                students.Gender = CmbGender.Text;
                students.IdClass = CmbClass.SelectedIndex + 1;

                DbConnect.entObj.SaveChanges();
                DbConnect.entObj.Students.ToList();

                MessageBox.Show("Изменения внесены успешно!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                FrameApp.frmObj.Navigate(new StudentsPage());
            }
        }
    }
}
