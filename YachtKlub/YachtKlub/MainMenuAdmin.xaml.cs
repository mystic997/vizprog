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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenuAdmin : Window
    {
        private string adminEmain;

        public MainMenuAdmin(string email)
        {
            InitializeComponent();
            this.adminEmain = email;
            MouseDown += Window_MouseDown; //az ablak mozgatásához kell

            try
            {
                LoadUserDataService loadUserDataService = new LoadUserDataService(email);
                imgProfilePicture.Tag = loadUserDataService.ResponseMessage["MemberImage"];
                var uri = new Uri(Convert.ToString(imgProfilePicture.Tag), UriKind.Absolute);
                var bitmap = new BitmapImage(uri);
                imgProfilePicture.Source = bitmap;

                lbUdvozlet.Content = "Üdvözöljük " + loadUserDataService.ResponseMessage["lastname"] + loadUserDataService.ResponseMessage["firstname"] + "!";

                welcome udv = new welcome();
                spMenu.Children.Clear();
                spMenu.Children.Add(udv);

            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //az ablak mozgatásához kell
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void btProfil_Click(object sender, RoutedEventArgs e)
        {
            PersonalAdminWindow profilom = new PersonalAdminWindow(adminEmain);
            spMenu.Children.Clear();
            spMenu.Children.Add(profilom);
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            Close();
        }

        private void btMyShips_Click(object sender, RoutedEventArgs e)
        {
            MyBoatsAndDevicesWindow hajoim = new MyBoatsAndDevicesWindow(adminEmain);
            spMenu.Children.Clear();
            spMenu.Children.Add(hajoim);
        }

        private void btBooking_Click(object sender, RoutedEventArgs e)
        {
            Booking foglalas = new Booking(adminEmain);
            spMenu.Children.Clear();
            spMenu.Children.Add(foglalas);
        }


        private void btNotifications_Click(object sender, RoutedEventArgs e)
        {
            NotificationWindow ertesitesek = new NotificationWindow(adminEmain);
            spMenu.Children.Clear();
            spMenu.Children.Add(ertesitesek);
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterUC regisztralas = new RegisterUC(adminEmain);
            spMenu.Children.Clear();
            spMenu.Children.Add(regisztralas);
        }
    }
}
