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
using YachtKlub.service;
using YachtKlub.validator;
namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for MyBoatsAndDevicesWindow.xaml
    /// </summary>
    public partial class MyBoatsAndDevicesWindow : Window
    {
        public MyBoatsAndDevicesWindow(string email)
        {
            InitializeComponent();
            List<string> BoatNames = new List<string>();
            List<string> BoatImages = new List<string>();
            List<string> TransportNames = new List<string>();
            List<string> TransportImages = new List<string>();
            LoadMyBoatsAndTransportsService myBoatsAndTransportsService = new LoadMyBoatsAndTransportsService(email);
            for (int i = 0; i < Convert.ToInt32(myBoatsAndTransportsService.ResponseMessage["BoatsCount"]); i++)
            {
                BoatNames.Add(myBoatsAndTransportsService.ResponseMessage["boatName" + Convert.ToString(i)]);
                BoatImages.Add(myBoatsAndTransportsService.ResponseMessage["boatImage" + Convert.ToString(i)]);
            }
            for (int i = 0; i < Convert.ToInt32(myBoatsAndTransportsService.ResponseMessage["TransportsCount"]); i++)
            {
                TransportNames.Add(myBoatsAndTransportsService.ResponseMessage["TransportName" + Convert.ToString(i)]);
                TransportImages.Add(myBoatsAndTransportsService.ResponseMessage["TransportImage" + Convert.ToString(i)]);
            }
            ListData[] BoatLister = new ListData[Convert.ToInt32(myBoatsAndTransportsService.ResponseMessage["BoatsCount"])];
            for (int i = 0; i < BoatLister.Length; i++)
            {
                BoatLister[i] = new ListData { text = BoatNames[i], imageData = LoadImage(BoatImages[i]) };
            }
           

            this.lvBoats.ItemsSource = BoatLister;
            lvBoats.Items.Refresh();

            ListData[] TransportLister = new ListData[Convert.ToInt32(myBoatsAndTransportsService.ResponseMessage["TransportsCount"])];
            for (int i = 0; i < TransportLister.Length; i++)
            {
                TransportLister[i] = new ListData { text = TransportNames[i], imageData = LoadImage(TransportImages[i]) };
            }


            this.lvTransports.ItemsSource = TransportLister;
            lvTransports.Items.Refresh();
            


        }

        private void btUploadPicture_Click(object sender, RoutedEventArgs e)
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

        private BitmapImage LoadImage(string newFileName)
    {
        var uri = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName, UriKind.Absolute);
        var bitmap = new BitmapImage(uri);
        return bitmap;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
