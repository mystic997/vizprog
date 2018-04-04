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
    /// Interaction logic for MemberRegisterWindow.xaml
    /// </summary>
    public partial class MemberRegisterWindow : Window
    {
        public MemberRegisterWindow()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow LogintoWindow = new LoginWindow();
            LogintoWindow.Show();
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
                string password = tbPassword.Text;
                string passwordCheck = tbPasswordAgain.Text;
                string country = tbCountry.Text;
                string city = tbCity.Text;
                string street = tbStreet.Text;
                string houseNumber = tbStreetNumber.Text;

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

                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(password, "jelszó"));
                registerValidator.ValidationComponents.Add(new FieldCharacterLimitValidator(password, 8, 40, "jelszó"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(passwordCheck, "jelszó megerősítése"));
                registerValidator.ValidationComponents.Add(new SameFieldValidator(password, passwordCheck, "jelszó"));

                // need to validate by a regular expression
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(country, "ország"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(city, "város"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(street, "utca"));
                registerValidator.ValidationComponents.Add(new EmptyFieldValidator(houseNumber, "házszám"));

                registerValidator.ValidateElements();

                RegisterService registerService = new RegisterService(firstname, lastname, email, password, country, city, street, houseNumber);
            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }
    }
}
