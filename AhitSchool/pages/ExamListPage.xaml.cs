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
    /// Логика взаимодействия для ExamListPage.xaml
    /// </summary>
    public partial class ExamListPage : Page
    {
        public ExamListPage()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            IEnumerable<Exam> examSort = App.Entities.Exam;
            if (SortCb.SelectedIndex == 1) examSort = examSort.OrderByDescending(x => x.Date);
            if (SortCb.SelectedIndex == 2) examSort = examSort.OrderBy(x => x.Date);

            if (GradeSortCb.SelectedIndex != 0)
            {
                if (GradeSortCb.SelectedIndex == 1) examSort = examSort.Where(x => x.Grade == 5);
                else if (GradeSortCb.SelectedIndex == 2) examSort = examSort.Where(x => x.Grade == 4);
                else if (GradeSortCb.SelectedIndex == 3) examSort = examSort.Where(x => x.Grade == 3);
                else if (GradeSortCb.SelectedIndex == 4) examSort = examSort.Where(x => x.Grade == 2);
            }
            if (SearchTbx.Text != null)
            {
                examSort = examSort.Where(x => x.Student.LastName.ToLower().Contains(SearchTbx.Text.ToLower()) || x.Discipline.Name.ToLower().Contains(SearchTbx.Text.ToLower()));
            }
            ExamListView.ItemsSource = examSort.ToList();

        }

        private void GradeSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var exam = new Exam();
            NavigationService.Navigate(new AddEditExamPage(exam));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var exm = (Exam)ExamListView.SelectedItem; if (exm == null) MessageBox.Show("Для редактирования выберите данные!");
            else NavigationService.Navigate(new AddEditExamPage(exm));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var exam = (Exam)ExamListView.SelectedItem;

            if (exam != null)
            {
                App.Entities.Exam.Remove(exam);
                App.Entities.SaveChanges();
                MessageBox.Show("Удалено!");
                Refresh();
            }
        }
    }
}
