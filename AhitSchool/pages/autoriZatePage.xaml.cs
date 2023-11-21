using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace AhitSchool.pages
{
    /// <summary>
    /// Логика взаимодействия для autoriZatePage.xaml
    /// </summary>
    public partial class autoriZatePage : Page
    {
        public autoriZatePage()
        {
            InitializeComponent();
        }

        private void StudentBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы вошли как гость!");
            NavigationService.Navigate(new SubjListPage());
        }

        private void SotrudBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PswrdPb.Password == "0000")
            {
                App.isAhit = true;
                MessageBox.Show("Вы вошли как сотрудник!");
                NavigationService.Navigate(new NavigationPage());
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
            }
        }

        private void QRBtn_Click(object sender, RoutedEventArgs e)
        {
            string soucer_xl = "https://www.youtube.com/watch?v=NOeoG_Q5sTc";
            // Создание переменной библиотеки QRCoder
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            // Присваеваем значиения
            QRCoder.QRCodeData data = qr.CreateQrCode(soucer_xl, QRCoder.QRCodeGenerator.ECCLevel.L);
            // переводим в Qr
            QRCoder.QRCode code = new QRCoder.QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);
            /// Создание картинки
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                QRImg.Source = bitmapimage;
            }
        }
    }
}
