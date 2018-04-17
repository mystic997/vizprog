using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for NewBoatWindow.xaml
    /// </summary>
    public partial class NewBoatWindow : Window
    {
        List<Control> ShouldBeHiddenSometimes;
        public NewBoatWindow(bool boat)
        {
            InitializeComponent();
            ShouldBeHiddenSometimes = new List<Control>();

            ShouldBeHiddenSometimes.Add(lbBoatDept);
            ShouldBeHiddenSometimes.Add(tbBoatDept);
            ShouldBeHiddenSometimes.Add(lbDepth);
            ShouldBeHiddenSometimes.Add(lbSpeed);
            ShouldBeHiddenSometimes.Add(tbBoatSpeed);
            ShouldBeHiddenSometimes.Add(lbBoatSpeed);
            //ShouldBeHiddenSometimes.Add(lbBoatManpower);
            //ShouldBeHiddenSometimes.Add(tbBoatManpower);
            //ShouldBeHiddenSometimes.Add(lbManpower);
            ShouldBeHiddenSometimes.Add(tbBoatPlace);
            ShouldBeHiddenSometimes.Add(lbBoatPlace);
            ShouldBeHiddenSometimes.Add(tbBoatYear);
            ShouldBeHiddenSometimes.Add(lbBoatYear);
            ShouldBeHiddenSometimes.Add(lbConsumption);
            ShouldBeHiddenSometimes.Add(tbBoatConsumption);
            ShouldBeHiddenSometimes.Add(lbBoatConsumption);
            ShouldBeHiddenSometimes.Add(lbBoatPrice);
            ShouldBeHiddenSometimes.Add(tbBoatPrice);
            ShouldBeHiddenSometimes.Add(lbPrice);




            if (boat)
            {

            }
            else
            {
                lbBoatManpower.Content = "Teherbírás";
                lbManpower.Content = "kg";
                ShouldBeHiddenSometimes.ForEach(i => i.Visibility = Visibility.Hidden);
                lbHeader.Content = "Új szállítóeszköz regisztrálása";
                lbHeader2.Content = "A szállítóeszköz adatai";


            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UploadPic_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            dialog.DefaultExt = ".jpg";
            dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                // Open document
                imgBoatPicture.Tag = dialog.FileName;
                System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources");
                string fileName = System.IO.Path.GetFileName(Convert.ToString(imgBoatPicture.Tag));
                string newFileName = generateID() + ".jpg";
                File.Copy(Convert.ToString(imgBoatPicture.Tag), System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName, true);
                imgBoatPicture.Tag = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName;
                var uri = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName, UriKind.Absolute);
                var bitmap = new BitmapImage(uri);
                imgBoatPicture.Source = bitmap;
            }
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
