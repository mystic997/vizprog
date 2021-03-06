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
using YachtKlub.dao;
using YachtKlub.entity;
using YachtKlub.service;
using YachtKlub.validator;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : UserControl
    {
        private DateTime startingDate;
        private DateTime endingDate;
        public static int SelectedBoatIndex { get; set; }
        private BoatsEntity selectedBoat;
        private TransportDevicesEntity selectedDevice; // TO DO!!!!
        private string whoBorrowsEmail { get; set; }

        public Booking(string whoBorrowsEmail)
        {
            InitializeComponent();

            this.whoBorrowsEmail = whoBorrowsEmail;

            DateTime projectStart = System.DateTime.Today;
            DateTime projectEnd = new DateTime(9999, 12, 31);

            dpStart.DisplayDateStart = projectStart;
            dpStart.DisplayDateEnd = projectEnd;

            dpEnd.DisplayDateStart = projectStart;
            dpEnd.DisplayDateEnd = projectEnd;

            //dpStart.DisplayDate = projectStart;
            //dpEnd.DisplayDate = projectStart.AddDays(1);
        }

        // esemeny, amely akkor kovetkezik be, ha a UserControlban masik elemet valasztottunk
        // ekkor toltodik fel a SelectedBoatIndex a megfelelo ertekkel
        private void SelectionChanged(object sender, RoutedEventArgs e)
        {
            // kivalasztott hajo entity
            BoatsEntity selectedBoat = LoadBookableBoatsService.BookableBoats[SelectedBoatIndex];
            this.selectedBoat = selectedBoat;

            tbOwnerName.Text = selectedBoat.FKOwner.MemberName;
            tbOwnerEmail.Text = selectedBoat.FKOwner.Email;
            tbOwnerResidency.Text = selectedBoat.FKOwner.Country + ", " + selectedBoat.FKOwner.City + ", " + selectedBoat.FKOwner.Street + " " + selectedBoat.FKOwner.HouseNumber + ".";

            LoadUserDataService loadUserDataService = new LoadUserDataService(whoBorrowsEmail);

            imgOwnerPicture.Tag = loadUserDataService.ResponseMessage["MemberImage"];
            var uri = new Uri(Convert.ToString(imgOwnerPicture.Tag), UriKind.Absolute);
            var bitmap = new BitmapImage(uri);
            imgOwnerPicture.Source = bitmap;


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

            LoadSelectedBoatService loadSelectedBoatService = new LoadSelectedBoatService(selectedBoat.BoatId.ToString());


            imgBoatPicture.Source = LoadImage(loadSelectedBoatService.ResponseMessage["BoatImage"]);
            imgBoatPicture.Tag = loadSelectedBoatService.ResponseMessage["BoatImage"];

            //imgBoatPicture = Image;

            e.Handled = true;
        }

        private BitmapImage LoadImage(string newFileName)
        {
            var uri = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName, UriKind.Absolute);
            var bitmap = new BitmapImage(uri);
            return bitmap;
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
            //this.Close();
        }

        private void btBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fromWhere = tbFromPlace.Text;
                string toWhere = tbToPlace.Text;
                string personNumber = tbNumberOfPerson.Text;

                Validator bookingValidator = new Validator();
                bookingValidator.ValidationComponents.Add(new EmptyFieldValidator(fromWhere, "indulási település"));
                bookingValidator.ValidationComponents.Add(new EmptyFieldValidator(toWhere, "érkezési település"));
                bookingValidator.ValidationComponents.Add(new EmptyFieldValidator(personNumber, "személyek száma"));
                bookingValidator.ValidationComponents.Add(new NumberFormatValidator(personNumber));
                bookingValidator.ValidationComponents.Add(new IsDatepickerSetValidator(dpStart));
                bookingValidator.ValidationComponents.Add(new IsDatepickerSetValidator(dpEnd));
                bookingValidator.ValidationComponents.Add(new EnoughSpaceValidator(int.Parse(tbNumberOfPerson.Text), int.Parse(tbBoatManpower.Text)));
                //bookingValidator.ValidationComponents.Add(new EmptyFieldValidator(tbOwnerEmail.Text, "foglalható hajók"));
                bookingValidator.ValidateElements();

                BookingService bookingService = new BookingService(whoBorrowsEmail, DateTime.Parse(dpStart.ToString()), DateTime.Parse(dpEnd.ToString()), selectedBoat, fromWhere, toWhere, int.Parse(personNumber));
            }
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }
    }
}
