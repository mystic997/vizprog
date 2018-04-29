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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for RegisterUC.xaml
    /// </summary>
    public partial class RegisterUC : UserControl
    {
        private string adminEmain;

        public RegisterUC(string email)
        {
            InitializeComponent();
            this.adminEmain = email;
        }

        private void btHajo_Click(object sender, RoutedEventArgs e)
        {
            NewBoatWindow ToNewBoatWindow = new NewBoatWindow(adminEmain);
            ToNewBoatWindow.Show();
        }

        private void btUser_Click(object sender, RoutedEventArgs e)
        {
            NewTransportDeviceWindow ToNewBoatWindow = new NewTransportDeviceWindow(adminEmain);
            ToNewBoatWindow.Show();
        }
    }
}
