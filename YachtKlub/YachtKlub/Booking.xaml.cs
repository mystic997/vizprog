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
        //public static readonly RoutedEvent ListBoxSelectionChangedEvent = EventManager.RegisterRoutedEvent("ListBoxSelectionChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BookableBoatsUC));
        //public event RoutedEvent ListBoxSelectionChanged
        //{
        //    add { AddHandler(ListBoxSelectionChangedEvent, value); }
        //    remove { RemoveHandler(ListBoxSelectionChangedEvent, value); }
        //}

        public Booking()
        {
            InitializeComponent();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btBook_Click(object sender, RoutedEventArgs e)
        {

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

        private static void LoadBoatData()
        {
            Console.WriteLine("...element changed...");
            //var selectedBoat = LoadBookableBoatsService.BookableBoats[BookableBoatIndex];
        }
    }
}
