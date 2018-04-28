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
using YachtKlub.dao;
using YachtKlub.entity;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for NotificationWindow.xaml
    /// </summary>
    public partial class NotificationWindow : Window
    {
        string email;
        public NotificationWindow(string email)
        {
            InitializeComponent();
            this.email = email;
            MembersDaoImpl Members = new MembersDaoImpl();
            RentRequestsDaoImpl RentRequests = new RentRequestsDaoImpl();
            BoatsDaoImpl Boats = new BoatsDaoImpl();
            


            foreach (var Hajok in Boats.GetAllBoatsByOwner(Members.getMemberByEmail(email)))
            {
                
                foreach (var Requests in RentRequests.GetAllRentRequestsByBoatToBorrow(Hajok))
                {
                    if (Requests.HowManyPersonWillTravel>0)
                    {
                        lbNotification.Visibility = Visibility.Hidden;
                        btAccept.Visibility = Visibility.Visible;
                        btDecline.Visibility = Visibility.Visible;
                        cv1.Visibility = Visibility.Visible;
                        cv2.Visibility = Visibility.Visible;
                        cv3.Visibility = Visibility.Visible;
                        tbRenterEmail.Text = Requests.WhoBorrows.Email;
                        tbRenterName.Text = Requests.WhoBorrows.MemberName;
                        tbRenterResidency.Text = Requests.WhoBorrows.City;
                    }
                }

            }

            
            
        }
    }
}
