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
using System.IO;
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
            catch (Exception ex) { }
        }

        private void btChangePassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordChangeWindow ToPasswordChangeWindow = new PasswordChangeWindow(tbEmail.Text);
            ToPasswordChangeWindow.Show();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            
            LoginWindow ToLoginWindow = new LoginWindow();
            ToLoginWindow.Show();
            this.Close();
        }

        private void btUploadProfilePicture_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = "*.jpg";
            dlg.Filter = " Pictures (.jpg)|*.jpg";
            Nullable<bool> result = dlg.ShowDialog();
            string filename = dlg.FileName;
        }
    }
}
