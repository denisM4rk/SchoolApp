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
    /// Логика взаимодействия для EditComputerPage.xaml
    /// </summary>
    public partial class EditComputerPage : Page
    {
        private Computers computer;
        public EditComputerPage(Computers selectedComputer)
        {
            InitializeComponent();

            this.computer = selectedComputer;
            if (computer != null)
            {
                TxbGraphics.Text = computer.GraphicsCard;
                TxbProcessor.Text = computer.Processor;
                TxbMemory.Text = computer.Memory;
                TxbPower.Text = computer.PowerSupply;
                TxbSerial.Text = computer.SerialNumber;
                TxbStorage.Text = computer.Storage;
                DateEnd.SelectedDate = Convert.ToDateTime(computer.AntivirusLicenseEnd);
                DateStart.SelectedDate = Convert.ToDateTime(computer.AntivirusLicenseStart);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (computer != null)
            {
                computer.GraphicsCard = TxbGraphics.Text;
                computer.Processor = TxbProcessor.Text;
                computer.Memory = TxbMemory.Text;
                computer.PowerSupply = TxbPower.Text;
                computer.SerialNumber = TxbSerial.Text;
                computer.Storage = TxbStorage.Text;
                computer.AntivirusLicenseEnd = Convert.ToDateTime(DateEnd.SelectedDate);
                computer.AntivirusLicenseStart = Convert.ToDateTime(DateStart.SelectedDate);

                DbConnect.entObj.SaveChanges();
                DbConnect.entObj.Computers.ToList();

                MessageBox.Show("Изменения внесены успешно!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                FrameApp.frmObj.Navigate(new ComputersPage());
            }
        }
    }
}
