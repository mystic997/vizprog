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

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for PersonalWindow.xaml
    /// </summary>
    /// 

    public partial class PersonalWindow : Window
    {
        List<TextBox> fields;

        public PersonalWindow(string email)
        {
            InitializeComponent();

            try
            {
                tbEmail.IsEnabled = false;
                tbEmailAgain.IsEnabled = false;

                fields = new List<TextBox>();
                fields.Add(tbLastname);
                fields.Add(tbFirstname);
                fields.Add(tbCountry);
                fields.Add(tbCity);
                fields.Add(tbStreet);
                fields.Add(tbStreetNumber);

                fields.ForEach(i => i.IsEnabled = false);

                LoadUserDataService loadUserDataService = new LoadUserDataService(email);
                tbLastname.Text = loadUserDataService.ResponseMessage["firstname"];
                tbFirstname.Text = loadUserDataService.ResponseMessage["lastname"];
                tbEmail.Text = loadUserDataService.ResponseMessage["email"];
                tbEmailAgain.Text = loadUserDataService.ResponseMessage["email"];
                tbCountry.Text = "null";
                tbCity.Text = loadUserDataService.ResponseMessage["city"];
                tbStreet.Text = loadUserDataService.ResponseMessage["street"];
                tbStreetNumber.Text = loadUserDataService.ResponseMessage["houseNumber"];
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
                string emailCheck = tbEmailAgain.Text;
                string country = tbCountry.Text;
                string city = tbCity.Text;
                string street = tbStreet.Text;
                string houseNumber = tbStreetNumber.Text;

                if (btSave.Content.Equals("Adatok módosítása"))
                {
                    btSave.Content = "Módosítások mentése";
                    fields.ForEach(i => i.IsEnabled = true);
                }
                else
                {
                    ValidateFields(firstname, lastname, email, emailCheck, country, city, street, houseNumber);

                    UpdateUserDataService updateUserService = new UpdateUserDataService(firstname, lastname, email, country, city, street, houseNumber, 1); // not admin

                    btSave.Content = "Adatok módosítása";
                    fields.ForEach(i => i.IsEnabled = false);
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

        private void btUploadProfilePicture_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Pictures (.jpg)|*.jpg";
            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
            }
        }
    }
}
