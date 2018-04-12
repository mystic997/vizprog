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
using YachtKlub.service;
using YachtKlub.validator;
using System.IO;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for PersonalAdminWindow.xaml
    /// </summary>
    public partial class PersonalAdminWindow : Window
    {
        private List<TextBox> fields;
        private string adminEmain;

        public PersonalAdminWindow(string email)
        {
            InitializeComponent();

            this.adminEmain = email;

            try
            {
                btCloseAdminRegister.Visibility = Visibility.Hidden;

                tbEmail.IsEnabled = false;
                tbEmailAgain.IsEnabled = false;
                cbPermission.IsEnabled = false;

                fields = new List<TextBox>();
                fields.Add(tbLastname);
                fields.Add(tbFirstname);
                fields.Add(tbCountry);
                fields.Add(tbCity);
                fields.Add(tbStreet);
                fields.Add(tbStreetNumber);

                fields.ForEach(i => i.IsEnabled = false);

                fillFieldsWithUserData(adminEmain);
            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }

        private void fillFieldsWithUserData(string email)
        {
            LoadUserDataService loadUserDataService = new LoadUserDataService(email);
            tbLastname.Text = loadUserDataService.ResponseMessage["firstname"];
            tbFirstname.Text = loadUserDataService.ResponseMessage["lastname"];
            tbEmail.Text = loadUserDataService.ResponseMessage["email"];
            tbEmailAgain.Text = loadUserDataService.ResponseMessage["email"];
            cbPermission.Text = loadUserDataService.ResponseMessage["permission"];
            tbCountry.Text = loadUserDataService.ResponseMessage["country"];
            tbCity.Text = loadUserDataService.ResponseMessage["city"];
            tbStreet.Text = loadUserDataService.ResponseMessage["street"];
            tbStreetNumber.Text = loadUserDataService.ResponseMessage["houseNumber"];

            // TO DO: IMAGE, COUNTRY
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow ToLoginWindow = new LoginWindow();
            ToLoginWindow.Show();
            this.Close();
        }

        private void btChangePassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordChangeWindow PasswordChangetoWindow = new PasswordChangeWindow(tbEmail.Text);
            PasswordChangetoWindow.Show();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstname = tbLastname.Text;
                string lastname = tbFirstname.Text;
                string email = tbEmail.Text;
                string emailCheck = tbEmailAgain.Text;
                string country = tbCountry.Text;
                string city = tbCity.Text;
                string street = tbStreet.Text;
                string houseNumber = tbStreetNumber.Text;

                if (btSave.Content.Equals("Adatok módosítása"))
                {
                    btAdminRegiszter.IsEnabled = false;
                    btBooking.IsEnabled = false;
                    btMyShips.IsEnabled = false;
                    btSave.Content = "Változtatások mentése";
                    fields.ForEach(i => i.IsEnabled = true);
                    btChangePassword.IsEnabled = false;
                    btMyShips.IsEnabled = false;
                    btBooking.IsEnabled = false;
                }
                else
                {
                    ValidateFields(firstname, lastname, email, emailCheck, country, city, street, houseNumber);

                    UpdateUserDataService updateUserService = new UpdateUserDataService(firstname, lastname, email, country, city, street, houseNumber, 0); // 0 is admin

                    btAdminRegiszter.IsEnabled = true;
                    btBooking.IsEnabled = true;
                    btMyShips.IsEnabled = true;
                    btSave.Content = "Adatok módosítása";
                    fields.ForEach(i => i.IsEnabled = false);
                    btChangePassword.IsEnabled = true;
                    btMyShips.IsEnabled = true;
                    btBooking.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }

        private void ValidateFields(string firstname, string lastname, string email, string emailCheck, string country, string city, string street, string houseNumber)
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
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(emailCheck, "e-mail megerősítése"));
            registerValidator.ValidationComponents.Add(new EmailFormatValidator(emailCheck));
            registerValidator.ValidationComponents.Add(new SameFieldValidator(email, emailCheck, "e-mail cím"));

            // need to validate by a regular expression
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(country, "ország"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(city, "város"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(street, "utca"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(houseNumber, "házszám"));

            registerValidator.ValidateElements();
        }

        private void ValidateFields(string firstname, string lastname, string email, string emailCheck, string country, string city, string street, string houseNumber, string password, string passwordCheck)
        {
            ValidateFields(firstname, lastname, email, emailCheck, country, city, street, houseNumber);

            Validator registerValidator = new Validator();

            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(password, "jelszó"));
            registerValidator.ValidationComponents.Add(new FieldCharacterLimitValidator(password, 8, 40, "jelszó"));
            registerValidator.ValidationComponents.Add(new EmptyFieldValidator(passwordCheck, "jelszó megerősítése"));
            registerValidator.ValidationComponents.Add(new SameFieldValidator(password, passwordCheck, "jelszó"));

            registerValidator.ValidateElements();
        }

        private void btAdminRegiszter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstname = tbFirstname.Text;
                string lastname = tbLastname.Text;
                string email = tbEmail.Text;
                string emailCheck = tbEmailAgain.Text;
                string password = tbPassword.Text;
                string passwordCheck = tbPasswordAgain.Text;
                string country = tbCountry.Text;
                string city = tbCity.Text;
                string street = tbStreet.Text;
                string houseNumber = tbStreetNumber.Text;
                int permission;
                try
                {
                    permission = int.Parse(cbPermission.Text);
                }
                catch (Exception)
                {
                    permission = 0;
                }

                if (btAdminRegiszter.Content.Equals("Felhasználó regisztrálása"))
                {
                    btSave.IsEnabled = false;
                    btBooking.IsEnabled = false;
                    btMyShips.IsEnabled = false;
                    btAdminRegiszter.Content = "Változtatások mentése";
                    fields.ForEach(i => i.IsEnabled = true);
                    fields.ForEach(i => i.Text = "");
                    cbPermission.IsEnabled = true;
                    cbPermission.Text = "";
                    tbEmail.IsEnabled = true;
                    tbEmail.Text = "";
                    tbEmailAgain.IsEnabled = true;
                    tbEmailAgain.Visibility = Visibility.Visible;
                    lbEmailAgain.Visibility = Visibility.Visible;
                    tbEmailAgain.Text = "";
                    btChangePassword.Visibility = Visibility.Hidden;
                    lbPassword.Visibility = Visibility.Visible;
                    tbPassword.Visibility = Visibility.Visible;
                    lbPasswordAgain.Visibility = Visibility.Visible;
                    tbPasswordAgain.Visibility = Visibility.Visible;

                    btCloseAdminRegister.Visibility = Visibility.Visible;
                }
                else
                {
                    ValidateFields(firstname, lastname, email, emailCheck, country, city, street, houseNumber, password, passwordCheck);

                    RegisterService registerService = new RegisterService(firstname, lastname, email, password, country, city, street, houseNumber, permission);

                    if (registerService.ServiceStatus == Status.Error)
                        throw new Exception();

                    btSave.IsEnabled = true;
                    btBooking.IsEnabled = true;
                    btMyShips.IsEnabled = true;
                    btAdminRegiszter.Content = "Felhasználó regisztrálása";
                    fields.ForEach(i => i.IsEnabled = false);
                    cbPermission.IsEnabled = false;
                    tbEmail.IsEnabled = false;
                    tbEmailAgain.IsEnabled = false;
                    tbEmailAgain.Visibility = Visibility.Hidden;
                    lbEmailAgain.Visibility = Visibility.Hidden;

                    btCloseAdminRegister.Visibility = Visibility.Hidden;

                    fillFieldsWithUserData(adminEmain);
                }
            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }

        private void btCloseAdminRegister_Click(object sender, RoutedEventArgs e)
        {
            btSave.IsEnabled = true;
            btAdminRegiszter.Content = "Felhasználó regisztrálása";
            fields.ForEach(i => i.IsEnabled = false);
            cbPermission.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbEmailAgain.IsEnabled = false;

            btChangePassword.Visibility = Visibility.Visible;
            btBooking.IsEnabled = true;
            btMyShips.IsEnabled = true;
            lbPassword.Visibility = Visibility.Hidden;
            tbPassword.Visibility = Visibility.Hidden;
            lbPasswordAgain.Visibility = Visibility.Hidden;
            tbPasswordAgain.Visibility = Visibility.Hidden;
            tbEmailAgain.Visibility = Visibility.Hidden;
            lbEmailAgain.Visibility = Visibility.Hidden;

            btCloseAdminRegister.Visibility = Visibility.Hidden;

            fillFieldsWithUserData(adminEmain);
        }

        private void btUploadProfilePicture_Click(object sender, RoutedEventArgs e)
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

        private void btBooking_Click(object sender, RoutedEventArgs e)
        {
            Booking ToBooking = new Booking();
            ToBooking.Show();
        }

        private void btMyShips_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewBoatWindow ToNewBoatWindow = new NewBoatWindow();
            ToNewBoatWindow.Show();
        }
    }
}
