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

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for PersonalWindow.xaml
    /// </summary>
    /// 

    public partial class PersonalWindow : Window
    {
        public PersonalWindow(string email)
        {
            InitializeComponent();

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

        private void btChangePassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordChangeWindow PasswordChangetoWindow = new PasswordChangeWindow(tbEmail.Text);
            PasswordChangetoWindow.Show();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
