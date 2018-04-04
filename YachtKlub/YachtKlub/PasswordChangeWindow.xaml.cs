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
using YachtKlub.dao;
using YachtKlub.entity;
using YachtKlub.service;
using YachtKlub.validator;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for PasswordChangeWindow.xaml
    /// </summary>
    public partial class PasswordChangeWindow : Window
    {
        private string Email { get; set; }

        public PasswordChangeWindow(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string oldPassword = tbOldPassword.Text;
                string password = tbPassword.Text;
                string passwordAgain = tbPasswordAgain.Text;

                Validator PasswordChangeValidator = new Validator();

                PasswordChangeValidator.ValidationComponents.Add(new EmptyFieldValidator(oldPassword, "régi jelszó"));
                PasswordChangeValidator.ValidationComponents.Add(new EmptyFieldValidator(password, "új jelszó"));
                PasswordChangeValidator.ValidationComponents.Add(new EmptyFieldValidator(passwordAgain, "új jelszó megerősítése"));

                PasswordChangeValidator.ValidationComponents.Add(new SameFieldValidator(password, passwordAgain, "jelszó"));

                // kivetelt dob, ha a validalas hibara fut, egyuttal ki is irja a hibauzeneteket
                PasswordChangeValidator.ValidateElements();
                // kivetelt dob, ha sikertelen a service, egyuttal ki is irja a hibauzeneteket
                PasswordChangeService passwordChangeService = new PasswordChangeService(oldPassword, password, Email);
                if (passwordChangeService.ServiceStatus == Status.OK)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }
    }
}
