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
    /// Логика взаимодействия для StudentListPage.xaml
    /// </summary>
    public partial class StudentListPage : Page
    {
        public StudentListPage()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            IEnumerable<Student> studlist = App.Entities.Student;

            if (SpecSortCB.SelectedIndex != 0)
            {
                if (SpecSortCB.SelectedIndex == 1) studlist = studlist.Where(x => x.Specialty.Direction == "Прикладная математика");
                else if (SpecSortCB.SelectedIndex == 2) studlist = studlist.Where(x => x.Specialty.Direction == "Информационные системы и технологии");
                else if (SpecSortCB.SelectedIndex == 3) studlist = studlist.Where(x => x.Specialty.Direction == "Прикладная информатика");
                else if (SpecSortCB.SelectedIndex == 4) studlist = studlist.Where(x => x.Specialty.Direction == "Ядерные физика и технологии");
                else if (SpecSortCB.SelectedIndex == 5) studlist = studlist.Where(x => x.Specialty.Direction == "Бизнес-информатика");
            }

            if (SearchTbx.Text != null)
            {
                studlist = studlist.Where(x => x.LastName.ToLower().Contains(SearchTbx.Text.ToLower()) || x.Specialty.Direction.ToLower().Contains(SearchTbx.Text.ToLower()));
            }

            if (SortCB.SelectedIndex == 1) studlist = studlist.OrderBy(x => x.LastName);
            if (SortCB.SelectedIndex == 2) studlist = studlist.OrderByDescending(x => x.LastName);

            StudentListView.ItemsSource = studlist.ToList();
        }


        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var student = (Student)StudentListView.SelectedItem;

            if (student != null)
            {
                App.Entities.Student.Remove(student);
                App.Entities.SaveChanges();
                MessageBox.Show("Удалено!");
                Refresh();
            }
        }

        private void SpecSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
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
            NavigationService.Navigate(new AddEditStudentPage(new Student(), "add"));
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            var student = (Student)StudentListView.SelectedItem;
            NavigationService.Navigate(new AddEditStudentPage(student, "redact"));
        }
    }
}
