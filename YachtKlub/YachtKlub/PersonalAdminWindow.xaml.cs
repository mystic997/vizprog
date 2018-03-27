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
    /// Interaction logic for PersonalAdminWindow.xaml
    /// </summary>
    public partial class PersonalAdminWindow : Window
    {
        public PersonalAdminWindow(string email)
        {
            InitializeComponent();

            try
            {
                // user data load service
            }
            catch (Exception ex)
            {

            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
