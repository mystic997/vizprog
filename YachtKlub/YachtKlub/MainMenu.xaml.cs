﻿using System;
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
    public partial class MainMenu : Window
    {
        private string email;

        public MainMenu(string email)
        {
            InitializeComponent();
            this.email = email;

            try
            {
                LoadUserDataService loadUserDataService = new LoadUserDataService(email);
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

        private void btProfil_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow Login = new LoginWindow();
            Login.Show();
            Close();
        }

        private void btMyShips_Click(object sender, RoutedEventArgs e)
        {
            MyBoatsAndDevicesWindow hajoim = new MyBoatsAndDevicesWindow(email);
            spMenu.Children.Clear();
            spMenu.Children.Add(hajoim);
        }
    }
}
