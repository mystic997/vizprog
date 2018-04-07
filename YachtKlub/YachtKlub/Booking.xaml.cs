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
using YachtKlub.dao;
using YachtKlub.entity;
using YachtKlub.service;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        private DateTime startingDate;
        private DateTime endingDate;
        public static int SelectedBoatIndex { get; set; }

        public Booking()
        {
            InitializeComponent();
        }

        // esemeny, amely akkor kovetkezik be, ha a UserControlban masik elemet valasztottunk
        // ekkor toltodik fel a SelectedBoatIndex a megfelelo ertekkel
        private void SelectionChanged(object sender, RoutedEventArgs e)
        {
            // kivalasztott hajo entity
            BoatsEntity selectedBoat = LoadBookableBoatsService.BookableBoats[SelectedBoatIndex];

            tbOwnerName.Text = selectedBoat.FKOwner.MemberName;
            tbOwnerEmail.Text = selectedBoat.FKOwner.Email;
            tbOwnerResidency.Text = selectedBoat.FKOwner.Country + ", " + selectedBoat.FKOwner.City + ", " + selectedBoat.FKOwner.Street + " " + selectedBoat.FKOwner.HouseNumber + ".";
            //imgOwnerPicture = Image;

            tbBoatName.Text = selectedBoat.BoatName;
            tbBoatPrice.Text = selectedBoat.DailyPrice.ToString();
            tbBoatConsumption.Text = selectedBoat.Consumption.ToString();
            tbBoatType.Text = selectedBoat.BoatType;
            tbBoatManpower.Text = selectedBoat.MaxPerson.ToString();
            tbBoatSpeed.Text = selectedBoat.MaxSpeed.ToString();
            tbBoatWidth.Text = selectedBoat.BoatWidth.ToString();
            tbBoatLenght.Text = selectedBoat.BoatLength.ToString();
            tbBoatYear.Text = selectedBoat.YearOfManufacture.ToString();
            tbBoatDept.Text = selectedBoat.DiveDepth.ToString();
            tbBoatPlace.Text = selectedBoat.WhereIsNowTheBoat;

            //imgBoatPicture = Image;

            e.Handled = true;
        }

        private void dpStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            startingDate = dpStart.SelectedDate.Value.Date;

            if (endingDate != null)
                if (DateTime.Compare(startingDate, endingDate) < 0)
                    ListBookableBoats();
                else
                    new PrintMessageBox("A kezdődátum nem kisebb, mint a végdátum!", validator.Status.Error);
        }

        private void dpEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            endingDate = dpEnd.SelectedDate.Value.Date;
            if (startingDate != null)
                if (DateTime.Compare(startingDate, endingDate) < 0)
                    ListBookableBoats();
                else
                    new PrintMessageBox("A kezdődátum nem kisebb, mint a végdátum!", validator.Status.Error);
        }

        private void ListBookableBoats()
        {
            this.spBookableBoatsUC.Children.Clear();

            LoadBookableBoatsService loadBookableBoats = new LoadBookableBoatsService(startingDate, endingDate);

            this.spBookableBoatsUC.Children.Add(loadBookableBoats.BookableBoatsUC);
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btBook_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
