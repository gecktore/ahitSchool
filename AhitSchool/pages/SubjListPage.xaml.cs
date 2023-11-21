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
using System.Xml.Linq;

namespace AhitSchool.pages
{
    /// <summary>
    /// Логика взаимодействия для SubjListPage.xaml
    /// </summary>
    public partial class SubjListPage : Page
    {
        public SubjListPage()
        {
            InitializeComponent();
            if (!App.isAhit)
            {
                DeleteBtn.Visibility = Visibility.Hidden;
                RedactBtn.Visibility = Visibility.Hidden;
                AddBtn.Visibility = Visibility.Hidden;
            }
            Refresh();

        }
        public void Refresh()
        {
            IEnumerable<Discipline> DisSort = App.Entities.Discipline;
            if (SortCB.SelectedIndex == 1) DisSort = DisSort.OrderBy(x => x.Name);
            if (SortCB.SelectedIndex == 2) DisSort = DisSort.OrderByDescending(x => x.Name);

            if (LecSortCB.SelectedIndex != 0)
            {
                if (LecSortCB.SelectedIndex == 1) DisSort = DisSort.Where(x => x.Executor == "вм");
                else if (LecSortCB.SelectedIndex == 2) DisSort = DisSort.Where(x => x.Executor == "ис");
                else if (LecSortCB.SelectedIndex == 3) DisSort = DisSort.Where(x => x.Executor == "мм");
                else if (LecSortCB.SelectedIndex == 4) DisSort = DisSort.Where(x => x.Executor == "оф");
                else if (LecSortCB.SelectedIndex == 5) DisSort = DisSort.Where(x => x.Executor == "пи");
                else if (LecSortCB.SelectedIndex == 6) DisSort = DisSort.Where(x => x.Executor == "эф");
            }
            if (SearchTbx.Text != null)
            {
                DisSort = DisSort.Where(x => x.Name.ToLower().Contains(SearchTbx.Text.ToLower()));
            }

            SubjectListView.ItemsSource = DisSort.ToList();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void LecSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            var subject = (Discipline)SubjectListView.SelectedItem;
            NavigationService.Navigate(new AddEditSubjectPage(subject, "redact"));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var subject = (Discipline)SubjectListView.SelectedItem;

            if (subject != null)
            {
                App.Entities.Discipline.Remove(subject);
                App.Entities.SaveChanges();
                MessageBox.Show("Удалено!");
                Refresh();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditSubjectPage(new Discipline(), "add"));
        }
    }
}
