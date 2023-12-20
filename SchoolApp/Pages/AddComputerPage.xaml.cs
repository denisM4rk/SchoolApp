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
    /// Логика взаимодействия для AddComputerPage.xaml
    /// </summary>
    public partial class AddComputerPage : Page
    {
        public AddComputerPage()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxbProcessor.Text == null)
            {
                MessageBox.Show("Введите процессор",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbGraphics.Text == null)
            {
                MessageBox.Show("Введите видеокарту",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbMemory.Text == null)
            {
                MessageBox.Show("Введите ОЗУ",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbStorage.Text == null)
            {
                MessageBox.Show("Введите объём хранилища",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbSerial.Text == null)
            {
                MessageBox.Show("Введите серийный номер",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbPower.Text == null)
            {
                MessageBox.Show("Введите блок питания",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (DateEnd.Text == null)
            {
                MessageBox.Show("Введите конец лицензии",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (DateStart.Text == null)
            {
                MessageBox.Show("Введите начало лицензии",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                if (DbConnect.entObj.Computers.Count(x => x.SerialNumber == TxbSerial.Text) > 0)
                {
                    MessageBox.Show("Такой ПК уже есть!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    return;
                }
                else
                {
                    try
                    {
                        Computers computersObj = new Computers()
                        {
                            Processor = TxbProcessor.Text,
                            GraphicsCard = TxbGraphics.Text,
                            Memory = TxbMemory.Text,
                            Storage = TxbStorage.Text,
                            PowerSupply = TxbPower.Text,
                            SerialNumber = TxbSerial.Text,
                            AntivirusLicenseStart = Convert.ToDateTime(DateStart.SelectedDate),
                            AntivirusLicenseEnd = Convert.ToDateTime(DateEnd.SelectedDate)
                        };

                        DbConnect.entObj.Computers.Add(computersObj);
                        DbConnect.entObj.SaveChanges();

                        MessageBox.Show("Новый ПК добавлен!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        FrameApp.frmObj.Navigate(new ComputersPage());
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
