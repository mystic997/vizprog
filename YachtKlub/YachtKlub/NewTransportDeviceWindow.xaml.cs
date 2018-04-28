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
using YachtKlub.dao;
using YachtKlub.entity;
using YachtKlub.service;
using YachtKlub.validator;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for NewTransportDeviceWindow.xaml
    /// </summary>
    public partial class NewTransportDeviceWindow : Window
    {
        DatabaseContext dbc;
        string email;
        public NewTransportDeviceWindow(string email)
        {
            this.email = email;
            InitializeComponent();
            tbOwnerName.Text = email;

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Validator registerValidator = new Validator();
                if (imgBoatPicture.Tag == null)
                {
                    imgBoatPicture.Tag = "Stock_transport_image.png";
                }
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(imgBoatPicture.Tag.ToString(), "fénykép"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatLenght.Text, "Hossz"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatWidth.Text, "Szélesség"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatManpower.Text, "Kapacitás"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatName.Text, "Név"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatType.Text, "Típus"));

                registerValidator.ValidateElements();

                BoatsDao boatsDao = new BoatsDaoImpl();
                TransportDevicesEntity NewEntity = new TransportDevicesEntity();
                dbc = AliveContext.Context;

                NewEntity.TransportDeviceId = dbc.Boats.OrderByDescending(u => u.BoatId).FirstOrDefault().BoatId;
                if (imgBoatPicture.Tag == null)
                {
                    imgBoatPicture.Tag = "stock_boat_image.png";
                }
                NewEntity.TransportDeviceImage = imgBoatPicture.Tag.ToString();
                NewEntity.TransportDeviceLength = Convert.ToInt32(tbBoatLenght.Text);
                NewEntity.TransportDeviceWidth = Convert.ToInt32(tbBoatWidth.Text);
                NewEntity.TransportDeviceName = tbBoatName.Text;
                //boatsEntity.BoatRentals = null;
                NewEntity.TransportDeviceType = tbBoatType.Text;

                MembersDao membersDao = new MembersDaoImpl();
                MembersEntity member = membersDao.getMemberByEmail(email);

                NewEntity.FKOwner = member;
                NewEntity.CarryingCapacity = Convert.ToInt32(tbBoatManpower.Text);




                RegisterTrasportDeviceService registerService = new RegisterTrasportDeviceService(ref NewEntity);
                MyBoatsAndDevicesWindow ToMyBoatsAndDevicesWindow = new MyBoatsAndDevicesWindow(email);
                //ToMyBoatsAndDevicesWindow.Show(); ;
                this.Close();
            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
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
