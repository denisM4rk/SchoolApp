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
    /// Логика взаимодействия для EditTeacherPage.xaml
    /// </summary>
    public partial class EditTeacherPage : Page
    {
        private Teachers teachers;

        public EditTeacherPage(Teachers selectedTeacher)
        {
            InitializeComponent();

            this.teachers = selectedTeacher;
            if (teachers != null)
            {
                TxbName.Text = teachers.FullName;
                CmbGender.Text = teachers.Gender;
                BirthDate.SelectedDate = Convert.ToDateTime(teachers.DateOfBirth);
            }

            CmbClass.ItemsSource = DbConnect.entObj.Classes.ToList();
            CmbClass.SelectedValuePath = "Id";
            CmbClass.DisplayMemberPath = "Name";

            CmbComputer.ItemsSource = DbConnect.entObj.Computers.ToList();
            CmbComputer.SelectedValuePath = "Id";
            CmbComputer.DisplayMemberPath = "SerialNumber";
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (teachers != null)
            {
                teachers.FullName = TxbName.Text;
                teachers.DateOfBirth = Convert.ToDateTime(BirthDate.SelectedDate);
                teachers.Gender = CmbGender.Text;
                teachers.IdClass = CmbClass.SelectedIndex + 1;
                teachers.IdComputer = CmbComputer.SelectedIndex + 1;

                DbConnect.entObj.SaveChanges();
                DbConnect.entObj.Teachers.ToList();

                MessageBox.Show("Изменения внесены успешно!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                FrameApp.frmObj.Navigate(new TeachersPage());
            }
        }
    }
}
