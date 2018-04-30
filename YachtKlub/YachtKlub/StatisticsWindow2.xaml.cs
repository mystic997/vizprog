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

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for StatisticsWindow2.xaml
    /// </summary>
    public partial class StatisticsWindow2 : Window
    {
        private ListData listDataGlobal;

        public StatisticsWindow2(ListData listData, string timeSpan)
        {
            listDataGlobal = listData;

            BoatRentalsDao boatRentalsDao = new BoatRentalsDaoImpl();
            
            InitializeComponent();
            if (timeSpan == "yearly")
            {
                var gridView = new GridView();
                this.lwIncome.View = gridView;
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Id",
                    DisplayMemberBinding = new Binding("Id")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Bevétel",
                    DisplayMemberBinding = new Binding("Income")
                });

                gridView.Columns[1].Width = 150;
                int j = 0;
                for (int i = 2015; i < 2019; i++)
                {
                    this.lwIncome.Items.Add(new StatisticsListItem { Id = i.ToString(), Income = Convert.ToString(boatRentalsDao.GetIncomeBoatRentalsByYearAndBoat(i, Convert.ToInt32(listData.id))) + " FT" });

                    j++;



                }
            }
            if (timeSpan == "monthly")
            {
                var gridView = new GridView();
                this.lwIncome.View = gridView;
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Id",
                    DisplayMemberBinding = new Binding("Id")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Bevétel",
                    DisplayMemberBinding = new Binding("Income")
                });
                gridView.Columns[1].Width = 150;
                System.Globalization.DateTimeFormatInfo mfi = new
            System.Globalization.DateTimeFormatInfo();
                for (int i = 0; i < 12; i++)
                {

                    this.lwIncome.Items.Add(new StatisticsListItem { Id = mfi.GetMonthName(i + 1), Income = Convert.ToString(boatRentalsDao.GetIncomeBoatRentalsByMonthAndBoat(i, Convert.ToInt32(listData.id))) + " FT" });

                }
            }
            if (timeSpan == "weekly")
            {
                var gridView = new GridView();
                this.lwIncome.View = gridView;
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Hét",
                    DisplayMemberBinding = new Binding("Id")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Bevétel",
                    DisplayMemberBinding = new Binding("Income")
                });
                gridView.Columns[1].Width = 150;
                for (int i = 0; i < 52; i++)
                {
                    this.lwIncome.Items.Add(new StatisticsListItem { Id = (i + 1).ToString() + ".", Income = Convert.ToString(boatRentalsDao.GetIncomeBoatRentalsByWeekAndBoat(i, Convert.ToInt32(listData.id))) + " FT" });

                }
            }
            if (timeSpan == "dayly")
            {
                var gridView = new GridView();
                this.lwIncome.View = gridView;
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Nap",
                    DisplayMemberBinding = new Binding("Id")
                });
                gridView.Columns[0].Width = 100;

                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Bevétel",
                    DisplayMemberBinding = new Binding("Income")
                });
                gridView.Columns[1].Width = 150;
                System.Globalization.DateTimeFormatInfo mfi = new
System.Globalization.DateTimeFormatInfo();
                for (int k = 0; k < 12; k++)
                {
                    
                    for (int i = 0; i < DateTime.DaysInMonth(2018, k+1); i++)/*szökőév nincs számolva*/
                    {
                        this.lwIncome.Items.Add(new StatisticsListItem { Id = mfi.GetMonthName(k + 1) + " " + (i + 1).ToString() + ".", Income = Convert.ToString(boatRentalsDao.GetIncomeBoatRentalsByDayAndBoat(i, k, Convert.ToInt32(listData.id))) + " FT" });

                    }
                }
                
            }
            MouseDown += Window_MouseDown; //az ablak mozgatásához kell


        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //az ablak mozgatásához kell
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    
    }
}
