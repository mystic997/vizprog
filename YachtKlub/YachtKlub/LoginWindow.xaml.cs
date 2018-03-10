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

            /*Ellenőrizni kell a jelszót és ha helyes beengedni, ha hibás akkor */
            if (tbEmailLogin.Text == "teszt" && tbPasswordLogin.Text == "teszt"
                || tbEmailLogin.Text == "admin" && tbPasswordLogin.Text == "admin")
            {
                if (tbEmailLogin.Text == "teszt" && tbPasswordLogin.Text == "teszt")
                {
                    tbErrorLogin.Visibility = System.Windows.Visibility.Hidden;
                    PersonalWindow PersonalWindow = new PersonalWindow(tbEmailLogin.Text);
                    PersonalWindow.Show();
                    this.Close();
                }
                if (tbEmailLogin.Text == "admin" && tbPasswordLogin.Text == "admin")
                {
                    tbErrorLogin.Visibility = System.Windows.Visibility.Hidden;
                    PersonalAdminWindow PersonalAdmintoWindow = new PersonalAdminWindow(tbEmailLogin.Text);
                    PersonalAdmintoWindow.Show();
                    this.Close();
                }
            }
            else
            {
                tbErrorLogin.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
            MemberRegisterWindow registerWindow = new MemberRegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}
