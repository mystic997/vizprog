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
        List<TextBox> lbfields;
        List<Button> btfields;
        List<ListView> lvfields;

        public MyBoatsAndDevicesWindow(string email)
        {
            InitializeComponent();
            List<string> BoatNames = new List<string>();
            List<string> BoatImages = new List<string>();
            List<string> BoatIds = new List<string>();

            List<string> TransportNames = new List<string>();
            List<string> TransportImages = new List<string>();
            List<string> TransportIds = new List<string>();
            LoadMyBoatsService myBoatsService = new LoadMyBoatsService(email);
            LoadMyTransportDevicesService myTransportDevicesService = new LoadMyTransportDevicesService(email);
            for (int i = 0; i < Convert.ToInt32(myBoatsService.ResponseMessage["BoatsCount"]); i++)
            {
                BoatNames.Add(myBoatsService.ResponseMessage["boatName" + Convert.ToString(i)]);
                BoatImages.Add(myBoatsService.ResponseMessage["boatImage" + Convert.ToString(i)]);
                BoatIds.Add(myBoatsService.ResponseMessage["boatId" + Convert.ToString(i)]);

            }
            for (int i = 0; i < Convert.ToInt32(myTransportDevicesService.ResponseMessage["TransportsCount"]); i++)
            {
                TransportNames.Add(myTransportDevicesService.ResponseMessage["TransportName" + Convert.ToString(i)]);
                TransportImages.Add(myTransportDevicesService.ResponseMessage["TransportImage" + Convert.ToString(i)]);
                TransportIds.Add(myTransportDevicesService.ResponseMessage["TransportId" + Convert.ToString(i)]);
            }
            ListData[] BoatLister = new ListData[Convert.ToInt32(myBoatsService.ResponseMessage["BoatsCount"])];
            for (int i = 0; i < BoatLister.Length; i++)
            {
                BoatLister[i] = new ListData { text = BoatNames[i], imageData = LoadImage(BoatImages[i]), id = BoatIds[i]   };
            }
           

            this.lvBoats.ItemsSource = BoatLister;
            lvBoats.Items.Refresh();

            ListData[] TransportLister = new ListData[Convert.ToInt32(myTransportDevicesService.ResponseMessage["TransportsCount"])];
            for (int i = 0; i < TransportLister.Length; i++)
            {
                TransportLister[i] = new ListData { text = TransportNames[i], imageData = LoadImage(TransportImages[i]), id = TransportIds[i] };
            }


            this.lvTransports.ItemsSource = TransportLister;
            lvTransports.Items.Refresh();



            lbfields = new List<TextBox>();
            lbfields.Add(tbBoatConsumption);
            lbfields.Add(tbBoatDept);
            lbfields.Add(tbBoatLenght);
            lbfields.Add(tbBoatManpower);
            lbfields.Add(tbBoatName);
            lbfields.Add(tbBoatPlace);
            lbfields.Add(tbBoatPrice);
            lbfields.Add(tbBoatSpeed);
            lbfields.Add(tbBoatType);
            lbfields.Add(tbBoatWidth);
            lbfields.Add(tbBoatYear);

            lbfields.ForEach(i => i.IsEnabled = false);

            btfields = new List<Button>();
            btfields.Add(btModify);
            btfields.Add(btSave);
            btfields.Add(btUploadPic);
            btfields.Add(btExit);

            btfields.ForEach(i => i.IsEnabled = false);

            lvfields = new List<ListView>();
            lvfields.Add(lvBoats);
            lvfields.Add(lvTransports);

            lvfields.ForEach(i => i.IsEnabled = true);

           
            btExit.IsEnabled = true;
            btModify.IsEnabled = true;




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

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (btSave.IsEnabled)
            {
                lbfields.ForEach(i => i.IsEnabled = false);
                btfields.ForEach(i => i.IsEnabled = false);

                /*Módosítások előtti adatok visszatöltése*/
                lvfields.ForEach(i => i.IsEnabled = true);
                btModify.IsEnabled = true;
                btExit.IsEnabled = true;
                btExit.Content = "Kilépés";
            }
            else
            {
                this.Close();
            }
            
        }

        
        private void Modify_Click(object sender, RoutedEventArgs e)
        {

            lbfields.ForEach(i => i.IsEnabled = true);
            btfields.ForEach(i => i.IsEnabled = false);
            lvfields.ForEach(i => i.IsEnabled = false);

            btUploadPic.IsEnabled = true;
            btSave.IsEnabled = true;
            btExit.IsEnabled = true;
            btExit.Content = "Vissza";
        }
        

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            lbfields.ForEach(i => i.IsEnabled = false);
            btfields.ForEach(i => i.IsEnabled = false);

            /*Adatmódosítás kódja*/
            lvfields.ForEach(i => i.IsEnabled = true);
            btModify.IsEnabled = true;
            btExit.IsEnabled = true;
            btExit.Content = "Kilépés";

        }

        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        void Boats_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ListViewItem Chosen = ((ListViewItem)sender);
            ListData listData = (ListData)Chosen.DataContext;
            LoadSelectedBoatService loadSelectedBoatService = new LoadSelectedBoatService(listData.id);
            tbBoatName.Text = loadSelectedBoatService.ResponseMessage["BoatName"];


        }

        void TransportDevices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ListViewItem Chosen = ((ListViewItem)sender);
            ListData listData = (ListData)Chosen.DataContext;
            LoadSelectedTransportDeviceService loadSelectedTransportDeviceService = new LoadSelectedTransportDeviceService(listData.id);
            tbBoatName.Text = loadSelectedTransportDeviceService.ResponseMessage["TransportDeviceName"];


        }

    }
}
