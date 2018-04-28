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
                    if (Requests.HowManyPersonWillTravel > 0)
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
                        tbStartPlace.Text = Requests.FromWhere;
                        tbEndPlace.Text = Requests.ToWhere;
                        tbPeople.Text = Requests.HowManyPersonWillTravel.ToString();
<<<<<<< HEAD
                        tbBoatName.Text = Requests.ToWhere;

=======
                        dpEnd.DisplayDate = Requests.EndDate;
>>>>>>> ffaa775ff5d840969b039925b1f3c4bcc1f151cd
                        LoadSelectedBoatService loadSelectedBoatService = new LoadSelectedBoatService(Convert.ToString(Requests.BoatToBorrow.BoatId));
                        imgBoatPicture.Source = LoadImage(loadSelectedBoatService.ResponseMessage["BoatImage"]);
                        imgBoatPicture.Tag = loadSelectedBoatService.ResponseMessage["BoatImage"];

                    }
                }

            }



        }



        private BitmapImage LoadImage(string newFileName)
        {
            var uri = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName, UriKind.Absolute);
            var bitmap = new BitmapImage(uri);
            return bitmap;
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}