using AhitSchool.components;
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

namespace AhitSchool.pages
{
    /// <summary>
    /// Логика взаимодействия для SotrudPage.xaml
    /// </summary>
    public partial class SotrudPage : Page
    {
        public SotrudPage()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            IEnumerable<Employee> sotrSort = App.Entities.Employee;
            if (SortCB.SelectedIndex == 1) sotrSort = sotrSort.OrderBy(x => x.Code);
            if (SortCB.SelectedIndex == 2) sotrSort = sotrSort.OrderBy(x => x.LastName);
            if (SortCB.SelectedIndex == 3) sotrSort = sotrSort.OrderBy(x => x.Salary);

            if (SearchTbx.Text != null)
            {
                sotrSort = sotrSort.Where(x => x.LastName.ToLower().Contains(SearchTbx.Text.ToLower()));
            }

            SotrListView.ItemsSource = sotrSort.ToList();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditEmpPage(new Employee(), "add"));
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            var emp = (Employee)SotrListView.SelectedItem; if (emp == null) MessageBox.Show("Для редактирования выберите данные!");
            NavigationService.Navigate(new AddEditEmpPage(emp, "redact"));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var emp = (Employee)SotrListView.SelectedItem;

            if (emp != null)
            {
                App.Entities.Employee.Remove(emp);
                App.Entities.SaveChanges();
                MessageBox.Show("Удалено!");
                Refresh();
            }
        }
    }
}
