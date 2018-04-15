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
    /// Interaction logic for PersonalWindow.xaml
    /// </summary>
    /// 

    public partial class PersonalWindow : Window
    {
        List<TextBox> fields;
        private string email;

        public PersonalWindow(string email)
        {
            InitializeComponent();

            this.email = email;

            try
            {
                tbEmail.IsEnabled = false;

                fields = new List<TextBox>();
                fields.Add(tbLastname);
                fields.Add(tbFirstname);
                fields.Add(tbCountry);
                fields.Add(tbCity);
                fields.Add(tbStreet);
                fields.Add(tbStreetNumber);

                fields.ForEach(i => i.IsEnabled = false);
                btUploadProfilePicture.IsEnabled = false;

                LoadUserDataService loadUserDataService = new LoadUserDataService(email);
                tbLastname.Text = loadUserDataService.ResponseMessage["firstname"];
                tbFirstname.Text = loadUserDataService.ResponseMessage["lastname"];
                tbEmail.Text = loadUserDataService.ResponseMessage["email"];
                tbCountry.Text = loadUserDataService.ResponseMessage["country"];
                tbCity.Text = loadUserDataService.ResponseMessage["city"];
                tbStreet.Text = loadUserDataService.ResponseMessage["street"];
                tbStreetNumber.Text = loadUserDataService.ResponseMessage["houseNumber"];
                imgProfilePicture.Tag = loadUserDataService.ResponseMessage["MemberImage"];
                var uri = new Uri(Convert.ToString(imgProfilePicture.Tag), UriKind.Absolute);
                var bitmap = new BitmapImage(uri);
                imgProfilePicture.Source = bitmap;
                
            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }

        private void btChangePassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordChangeWindow PasswordChangetoWindow = new PasswordChangeWindow(tbEmail.Text);
            PasswordChangetoWindow.Show();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow ToLoginWindow = new LoginWindow();
            ToLoginWindow.Show();
            this.Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstname = tbLastname.Text;
                string lastname = tbFirstname.Text;
                string email = tbEmail.Text;
                string country = tbCountry.Text;
                string city = tbCity.Text;
                string street = tbStreet.Text;
                string houseNumber = tbStreetNumber.Text;
                string picturePath = Convert.ToString(imgProfilePicture.Tag);

                if (btSave.Content.Equals("Adatok módosítása"))
                {
                    btSave.Content = "Módosítások mentése";
                    fields.ForEach(i => i.IsEnabled = true);
                    btChangePassword.IsEnabled = false;
                    btUploadProfilePicture.IsEnabled = true;
                    btMyShips.IsEnabled = false;
                    btBooking.IsEnabled = false;
                }
                else
                {
                    ValidateFields(firstname, lastname, email, country, city, street, houseNumber);

                    UpdateUserDataService updateUserService = new UpdateUserDataService(firstname, lastname, email, country, city, street, houseNumber, 1, picturePath); // not admin

                    btSave.Content = "Adatok módosítása";
                    fields.ForEach(i => i.IsEnabled = false);
                    btChangePassword.IsEnabled = true;
                    btUploadProfilePicture.IsEnabled = false;
                    btMyShips.IsEnabled = true;
                    btBooking.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }

        private void ValidateFields(string firstname, string lastname, string email, string country, string city, string street, string houseNumber)
        {
            Validator registerValidator = new Validator();
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(firstname, "vezetéknév"));
            registerValidator.ValidationComponents.Add(new NameFormatValidator(firstname));
            registerValidator.ValidationComponents.Add(new FieldCharacterLimitValidator(firstname, 2, 999, "vezetéknév"));

            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(lastname, "keresztnév"));
            registerValidator.ValidationComponents.Add(new NameFormatValidator(lastname));
            registerValidator.ValidationComponents.Add(new FieldCharacterLimitValidator(lastname, 2, 999, "keresztnév"));

            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(email, "e-mail"));
            registerValidator.ValidationComponents.Add(new EmailFormatValidator(email));
            

            // need to validate by a regular expression
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(country, "ország"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(city, "város"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(street, "utca"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(houseNumber, "házszám"));

            registerValidator.ValidateElements();
        }

        private void btUploadProfilePicture_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            dialog.DefaultExt = ".jpg";
            dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                // Open document
                imgProfilePicture.Tag = dialog.FileName;
                System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources");
                string fileName = System.IO.Path.GetFileName(Convert.ToString(imgProfilePicture.Tag));
                string newFileName = generateID() + ".jpg";
                File.Copy(Convert.ToString(imgProfilePicture.Tag), System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName, true);
                imgProfilePicture.Tag = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName;
                var uri = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName, UriKind.Absolute);
                var bitmap = new BitmapImage(uri);
                imgProfilePicture.Source = bitmap;
                
            }
        }
        private void btMyShips_Click(object sender, RoutedEventArgs e)
        {
            MyBoatsAndDevicesWindow ToMyBoatsAndDevicesWindow = new MyBoatsAndDevicesWindow();
            ToMyBoatsAndDevicesWindow.Show();
        }
        private void btBooking_Click(object sender, RoutedEventArgs e)
        {
            Booking ToBooking = new Booking();
            ToBooking.Show();
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
