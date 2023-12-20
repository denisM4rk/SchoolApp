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
    /// Логика взаимодействия для AddTeacherPage.xaml
    /// </summary>
    public partial class AddTeacherPage : Page
    {
        public AddTeacherPage()
        {
            InitializeComponent();

            CmbClass.ItemsSource = DbConnect.entObj.Classes.ToList();
            CmbClass.SelectedValuePath = "Id";
            CmbClass.DisplayMemberPath = "Name";

            CmbComputer.ItemsSource = DbConnect.entObj.Computers.ToList();
            CmbComputer.SelectedValuePath = "Id";
            CmbComputer.DisplayMemberPath = "SerialNumber";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == null)
            {
                MessageBox.Show("Введите имя",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbComputer.Text == null)
            {
                MessageBox.Show("Выберите компьютер",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbGender.Text == null)
            {
                MessageBox.Show("Выберите пол",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbClass.Text == null)
            {
                MessageBox.Show("Выберите класс",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (BirthDate.Text == null)
            {
                MessageBox.Show("Введите дату рождения",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                if (DbConnect.entObj.Teachers.Count(x => x.FullName == TxbName.Text) > 0)
                {
                    MessageBox.Show("Такой учитель уже есть!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    return;
                }
                else
                {
                    try
                    {
                        Teachers teachersObj = new Teachers()
                        {
                            FullName = TxbName.Text,
                            DateOfBirth = Convert.ToDateTime(BirthDate.SelectedDate),
                            Gender = CmbGender.Text,
                            IdClass = CmbClass.SelectedIndex+1,
                            IdComputer = CmbComputer.SelectedIndex+1
                        };

                        DbConnect.entObj.Teachers.Add(teachersObj);
                        DbConnect.entObj.SaveChanges();

                        MessageBox.Show("Новый учитель добавлен!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        FrameApp.frmObj.Navigate(new TeachersPage());
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
}
