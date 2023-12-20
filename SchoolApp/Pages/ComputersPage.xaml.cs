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
using System.IO;
using SchoolApp.AppFiles;
using System.Globalization;
using System.Data;

namespace SchoolApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ComputersPage.xaml
    /// </summary>
    /// 
    public partial class ComputersPage : Page
    {
        private Computers selectedComputer;

        public ComputersPage()
        {
            InitializeComponent();

            ComputersGrid.ItemsSource = DbConnect.entObj.Computers.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedComputer != null)
            {
                EditComputerPage editPage = new EditComputerPage(selectedComputer); ;
                FrameApp.frmObj.Navigate(editPage);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ComputersGrid.SelectedItem != null)
            {
                var filesForRemoving = ComputersGrid.SelectedItems.Cast<Computers>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Computers.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        ComputersGrid.ItemsSource = DbConnect.entObj.Computers.ToList();
                    }
                    else
                    {
                        ComputersGrid.ItemsSource = DbConnect.entObj.Computers.ToList();
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
            FrameApp.frmObj.Navigate(new AddComputerPage());
        }

        private void ComputersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedComputer = (Computers)ComputersGrid.SelectedItem;
        }
    }
}
