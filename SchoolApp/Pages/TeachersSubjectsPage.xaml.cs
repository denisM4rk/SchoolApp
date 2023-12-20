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
    /// Логика взаимодействия для TeachersSubjectsPage.xaml
    /// </summary>
    public partial class TeachersSubjectsPage : Page
    {
        private List<Teachers> allTeachers;
        public TeachersSubjectsPage()
        {
            InitializeComponent();

            SubjectsGrid.ItemsSource = DbConnect.entObj.Teachers_Subjects.ToList();
            allTeachers = DbConnect.entObj.Teachers.ToList();

            CmbTeacher.ItemsSource = DbConnect.entObj.Teachers.ToList();
            CmbTeacher.SelectedValuePath = "Id";
            CmbTeacher.DisplayMemberPath = "FullName";
        }

        private void CmbTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedTeacher = (int)CmbTeacher.SelectedIndex+1;
            var filteredData = DbConnect.entObj.Teachers_Subjects.Where(ts => ts.IdTeacher == selectedTeacher).ToList();
            SubjectsGrid.ItemsSource = filteredData;
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            SubjectsGrid.ItemsSource = DbConnect.entObj.Teachers_Subjects.ToList();
        }
    }
}
