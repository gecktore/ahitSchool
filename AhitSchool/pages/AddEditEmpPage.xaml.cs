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
    /// Логика взаимодействия для AddEditEmpPage.xaml
    /// </summary>
    public partial class AddEditEmpPage : Page
    {
        public Employee employee; public string WhatToDo;
        public AddEditEmpPage(Employee _employee, string _WhatToDo)
        {
            InitializeComponent();
            WhatToDo = _WhatToDo; InitializeComponent();
            employee = _employee; this.DataContext = employee;
            int OriginalID = employee.TabNumber; IdTb.MaxLength = 3;
            if (employee != null && employee.TabNumber > 0) IdTb.IsReadOnly = true;
            PositionCbx.ItemsSource = App.Entities.Employee.ToList();
            PositionCbx.DisplayMemberPath = "Position";
            LecternCbx.ItemsSource = App.Entities.Discipline.ToList();
            LecternCbx.DisplayMemberPath = "Executor";
            ChiefCbx.ItemsSource = App.Entities.Employee.ToList().Where(x => x.TabNumber == x.Boss);
            ChiefCbx.DisplayMemberPath = "LastName";
            if (employee.TabNumber > 0)
            {
                var bbb = App.Entities.Discipline.ToList().Where(x => x.Executor == employee.Code).First();
                LecternCbx.SelectedIndex = LecternCbx.Items.IndexOf(bbb); 
                var ccc = App.Entities.Employee.ToList().Where(x => x.Boss == employee.Boss).First();
                ChiefCbx.SelectedIndex = ChiefCbx.Items.IndexOf(ccc);

                var bbbb = App.Entities.Employee.ToList().Where(x => x.Position == employee.Position).First();
                PositionCbx.SelectedIndex = PositionCbx.Items.IndexOf(bbbb);
            }
        }

        private void SaveButt_Click(object sender, RoutedEventArgs e)
        {
            bool errors = false; 
            var selectLectern = LecternCbx.SelectedItem as Discipline;
            var selectChief = ChiefCbx.SelectedItem as Employee;
            var selectPos = PositionCbx.SelectedItem as Employee;
            if (IdTb.Text.Length < 3)
            {
                errors = true;
                MessageBox.Show("Длина таб.номера должна быть 3 символа!");
            }
            if (App.Entities.Employee.Any(x => x.TabNumber == employee.TabNumber) && WhatToDo == "add")
            {
                errors = true;
                MessageBox.Show("Такой таб.номер уже есть!");
            }
            if (!errors)
            {
                if (WhatToDo == "add")
                {
                    App.Entities.Employee.Add(new Employee()
                    {
                        TabNumber = employee.TabNumber,
                        Position = selectPos.Position,
                        Code = selectLectern.Executor,
                        LastName = FioTb.Text,
                        Salary = SalaryTb.Text,
                        Boss = selectChief.TabNumber,
                    });
                }
                employee.Code = selectLectern.Executor;
                employee.Boss = selectChief.TabNumber;
                MessageBox.Show("Сохранено!");
                App.Entities.SaveChanges();
                NavigationService.Navigate(new SotrudPage());
            }
        }
        private void SalaryTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
