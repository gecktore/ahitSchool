using AhitSchool.components;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для AddEditStudentPage.xaml
    /// </summary>
    public partial class AddEditStudentPage : Page
    {
        public Student student;
        public string WhatToDo;
        public AddEditStudentPage(Student _student, string _whatToDo)
        {
            InitializeComponent();
            student = _student;
            WhatToDo = _whatToDo;
            this.DataContext = student;
            IdTb.MaxLength = 5;
            if (student != null && student.RegNumber > 0) IdTb.IsReadOnly = true;
            SpecCbx.ItemsSource = App.Entities.Specialty.ToList();
            SpecCbx.DisplayMemberPath = "Direction";

            if (student.RegNumber > 0)
            {
                var sss = App.Entities.Specialty.ToList().Where(x => x.Number == student.Number).First();
                SpecCbx.SelectedIndex = SpecCbx.Items.IndexOf(sss);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool errors = false;
            var selectSpec = SpecCbx.SelectedItem as Specialty;
            if (selectSpec == null || IdTb.Text == "0" || FioTb.Text == "")
            {
                errors = true;
                MessageBox.Show("Заполните обязательные данные!");
            }
            if (IdTb.Text.Length < 5)
            {
                errors = true;
                MessageBox.Show("Длина таб.номера должна быть 5 символа!");
            }
            if (App.Entities.Student.Any(x => x.RegNumber == student.RegNumber) && WhatToDo == "add")
            {
                errors = true;
                MessageBox.Show("Такой таб.номер уже есть!");
            }
            if (!errors)
            {
                if (WhatToDo == "add")
                {
                    App.Entities.Student.Add(new Student()
                    {
                        RegNumber = student.RegNumber,
                        LastName = student.LastName,
                        Number = selectSpec.Number,
                    });
                }
                else student.Number = selectSpec.Number;
                MessageBox.Show("Сохранено!");
                App.Entities.SaveChanges();
                NavigationService.Navigate(new StudentListPage());
            }
        }
        private void IdTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
