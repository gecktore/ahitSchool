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
    /// Логика взаимодействия для AddEditSubjectPage.xaml
    /// </summary>
    public partial class AddEditSubjectPage : Page
    {
        public Discipline subject;
        public string WhatToDo;
        public AddEditSubjectPage(Discipline _subject, string _WhatToDo)
        {
            InitializeComponent();
            subject = _subject;
            WhatToDo = _WhatToDo;
            this.DataContext = subject;
            IdTb.MaxLength = 3;
            if (subject != null && subject.Code > 0) IdTb.IsReadOnly = true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool errors = false;
            if (IdTb.Text.Length < 3)
            {
                errors = true;
                MessageBox.Show("Длина таб.номера должна быть 3 символа!");
            }
            if (App.Entities.Discipline.Any(x => x.Code == subject.Code) && WhatToDo == "add")
            {
                errors = true;
                MessageBox.Show("Такой таб.номер уже есть!");
            }

            if (!errors)
            {
                if (WhatToDo == "add")
                {
                    App.Entities.Discipline.Add(new Discipline()
                    {
                        Code = subject.Code,
                        Volume = subject.Volume,
                        Name = subject.Name,
                    });
                }
                MessageBox.Show("Сохранено!");
                App.Entities.SaveChanges();
                NavigationService.Navigate(new SubjListPage());
            }
        }
    }
}
