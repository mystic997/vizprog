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
    /// Interaction logic for NewBoatWindow.xaml
    /// </summary>
    public partial class NewBoatWindow : Window
    {
        DatabaseContext dbc;
        string email;
        public NewBoatWindow(string email)
        {
            this.email = email;
            InitializeComponent();

        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try { 
            BoatsDao boatsDao = new BoatsDaoImpl();
            BoatsEntity boatsEntity = new BoatsEntity();

            boatsEntity.BoatId = dbc.Boats.OrderByDescending(u => u.BoatId).FirstOrDefault().BoatId;
            boatsEntity.BoatImage = imgBoatPicture.Tag.ToString();
            boatsEntity.BoatLength = Convert.ToInt32(tbBoatLenght.Text);
            boatsEntity.BoatWidth = Convert.ToInt32(tbBoatWidth.Text);
            boatsEntity.BoatName = tbBoatName.Text;
            //boatsEntity.BoatRentals = null;
            boatsEntity.BoatType = tbBoatType.Text;
            boatsEntity.Consumption = Convert.ToInt32(tbBoatConsumption.Text);
            boatsEntity.DailyPrice = Convert.ToInt32(tbBoatPrice.Text);
            boatsEntity.DiveDepth = Convert.ToInt32(tbBoatDept.Text);

                MembersDao membersDao = new MembersDaoImpl();
                MembersEntity member = membersDao.getMemberByEmail(email);

                boatsEntity.FKOwner = member;
                boatsEntity.IsLoan = tbIsLoan.IsChecked ?? false;
                boatsEntity.MaxPerson = Convert.ToInt32(tbBoatManpower.Text);
                boatsEntity.MaxSpeed = Convert.ToInt32(tbBoatSpeed.Text);
                boatsEntity.WhereIsNowTheBoat = tbBoatPlace.Text;
                boatsEntity.YearOfManufacture = Convert.ToInt32(tbBoatYear.Text);
                Validator registerValidator = new Validator();

            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(imgBoatPicture.Tag.ToString(), "fénykép"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatLenght.Text, "Hossz"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatLenght.Text, "Hossz"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatConsumption.Text, "Fogyasztás"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatPrice.Text, "Ár"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatDept.Text, "Merülési mélység"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatManpower.Text, "Max. Létszám"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatSpeed.Text, "Max. sebesség"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatPlace.Text, "Tartózkodási helye"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(tbBoatYear.Text, "Gyártási év"));





                RegisterBoatService registerService = new RegisterBoatService(ref boatsEntity);

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
