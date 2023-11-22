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
    /// Логика взаимодействия для AddEditExamPage.xaml
    /// </summary>
    public partial class AddEditExamPage : Page
    {
        public Exam exam;
        public AddEditExamPage(Exam _exam)
        {
            InitializeComponent();
            exam = _exam;
            this.DataContext = exam;
            DatePck.DisplayDateStart = new DateTime(2014, 01, 01);

            MarkTb.MaxLength = 1;

            SubjectCb.ItemsSource = App.Entities.Discipline.ToList();
            SubjectCb.DisplayMemberPath = "Name";

            StudentCb.ItemsSource = App.Entities.Student.ToList();
            StudentCb.DisplayMemberPath = "LastName";

            TeacherCb.ItemsSource = App.Entities.Employee.ToList();
            TeacherCb.DisplayMemberPath = "LastName";

            if (exam.TabNumber > 0)
            {
                var bbb = App.Entities.Student.ToList().Where(x => x.RegNumber == exam.RegNumber).First();
                StudentCb.SelectedIndex = StudentCb.Items.IndexOf(bbb);
                var aaa = App.Entities.Discipline.ToList().Where(x => x.Code == exam.Code).First();
                SubjectCb.SelectedIndex = SubjectCb.Items.IndexOf(aaa);
                var ccc = App.Entities.Employee.ToList().Where(x => x.TabNumber == exam.TabNumber).First();
                TeacherCb.SelectedIndex = TeacherCb.Items.IndexOf(ccc);
            }
            if (exam.TabNumber == 0)
            {
                exam.Date = DateTime.Now;
            }
        }

        private void SaveButt_Click(object sender, RoutedEventArgs e)
        {
            bool errors = false;
            var selectStudent = StudentCb.SelectedItem as Student;
            var selectTeacher = TeacherCb.SelectedItem as Employee;
            var selectSubject = SubjectCb.SelectedItem as Discipline;
            if (string.IsNullOrEmpty(AuditoryTb.Text) || selectStudent == null || selectTeacher == null || selectSubject == null)
            {
                MessageBox.Show("Заполните данные!");
                errors = true;
            }
            if ((MarkTb.Text == "" || char.IsDigit(char.Parse(MarkTb.Text))) && !errors)
            {
                if (int.Parse(MarkTb.Text) > 5 || int.Parse(MarkTb.Text)
       < 1)
                {
                    MessageBox.Show("Неправильный формат оценки!");
                    errors = true;
                }
            }
            else
            { MessageBox.Show("Неправильный формат оценки!"); errors = true; }

            if (exam.TabNumber == 0 && !errors)
            {
                if (App.Entities.Exam.Any(x => x.Date == exam.Date && x.TabNumber == exam.TabNumber && x.Code == exam.Code))
                {
                    MessageBox.Show("Повторение!!1!");
                    errors = true;
                }
                else
                {

                    App.Entities.Exam.Add(new Exam()
                    {
                        Date = exam.Date,
                        Code = selectSubject.Code,
                        RegNumber = selectStudent.RegNumber,
                        TabNumber = selectTeacher.TabNumber,
                        Auditorium = exam.Auditorium,
                        Grade = exam.Grade,
                    });
                }
            }
            if (!errors)
            {
                exam.Code = selectSubject.Code;
                exam.RegNumber = selectStudent.RegNumber;
                exam.TabNumber = selectTeacher.TabNumber;
                App.Entities.SaveChanges();
                MessageBox.Show("Сохранено!");
                NavigationService.Navigate(new ExamListPage());
            }
        }
    }
}
