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
using System.Windows.Shapes;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for NewBoatWindow.xaml
    /// </summary>
    public partial class NewBoatWindow : Window
    {
        List<object> ShouldBeHiddenSometimes;
        public NewBoatWindow(bool boat)
        {
            InitializeComponent();
            ShouldBeHiddenSometimes = new List<object>();

            ShouldBeHiddenSometimes.Add(lbBoatDept);
            /*folytatom, Dani*/

            if (boat)
            {
                
            }
            else
            {
                lbHeader.Content = "Új szállítóeszköz regisztrálása";
                lbHeader2.Content = "A szállítóeszköz adatai";
                lbBoatDept.Visibility = Visibility.Hidden;
                tbBoatDept.Visibility = Visibility.Hidden;

            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UploadPic_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
            }
        }
    }
}
