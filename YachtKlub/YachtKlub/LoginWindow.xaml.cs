﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = tbEmailLogin.Text;
                string password = tbPasswordLogin.Text;

                // ki kell majd venni!
                if (email.Equals("") && password.Equals(""))
                {
                    tbEmailLogin.Text = "user2@gmail.com";
                    tbPasswordLogin.Text = "user2";
                    btLogin_Click(sender, e);
                    return;
                }

                Validator loginValidator = new Validator();
                loginValidator.ValidationComponents.Add(new EmptyFieldValidator(email, "e-mail cím"));
                loginValidator.ValidationComponents.Add(new EmailFormatValidator(email));
                loginValidator.ValidationComponents.Add(new EmptyFieldValidator(password, "jelszó"));
                // kivetelt dob, ha a validalas hibara fut, egyuttal ki is irja a hibauzeneteket
                loginValidator.ValidateElements();

                // kivetelt dob, ha sikertelen a service, egyuttal ki is irja a hibauzeneteket VALTOZTATAS
                LoginService loginService = new LoginService(email, password);

                if (loginService.ResponseMessage["permission"].Equals("admin"))
                {
                    PersonalAdminWindow PersonalAdmintoWindow = new PersonalAdminWindow(tbEmailLogin.Text);
                    PersonalAdmintoWindow.Show();
                    Close();
                }
                else
                {
                    PersonalWindow PersonalWindow = new PersonalWindow(tbEmailLogin.Text);
                    PersonalWindow.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }

        private void tbPasswordLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btLogin_Click(sender, e);
        }

        private void tbEmailLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btLogin_Click(sender, e);
        }

        private void btLogin_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            tbEmailLogin.Text = "user0@gmail.com";
            tbPasswordLogin.Text = "user0";
            btLogin_Click(sender, e);
        }

        //private void btRegister_Click(object sender, RoutedEventArgs e)
        //{
        //    MemberRegisterWindow registerWindow = new MemberRegisterWindow();
        //    registerWindow.Show();
        //    this.Close();
        //}
    }
}
