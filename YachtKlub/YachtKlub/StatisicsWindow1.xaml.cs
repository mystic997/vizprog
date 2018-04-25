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
    /// Interaction logic for StatisicsWindow1.xaml
    /// </summary>
    public partial class StatisicsWindow1 : Window
    {
        public StatisicsWindow1(ListData listData)
        {
            BoatRentalsDao boatRentalsDao = new BoatRentalsDaoImpl();
            InitializeComponent();
            int j = 0;
            for (int i = 2015; i < 2019; i++)
            {   
                towerChart(115 + j * 25, 100  - boatRentalsDao.GetHowManyBoatRentalsByYearAndBoat(i, Convert.ToInt32(listData.id)) * 3, boatRentalsDao.GetHowManyBoatRentalsByYearAndBoat(i,Convert.ToInt32(listData.id))*3, ref YearlyIncomeCanvas,20,i);
                j++;


            }
            for (int i = 0; i < 12; i++)
            {
                towerChart(30 + i * 25, 100 - boatRentalsDao.GetHowManyBoatRentalsByMonthAndBoat(i, Convert.ToInt32(listData.id)) * 10, boatRentalsDao.GetHowManyBoatRentalsByMonthAndBoat(i, Convert.ToInt32(listData.id)) * 10, ref MonthlyIncomeCanvas,20, i);

            }
            for (int i = 0; i < 52; i++)
            {
                towerChart(20 + i * 25, 100 - boatRentalsDao.GetHowManyBoatRentalsByWeekAndBoat(i, Convert.ToInt32(listData.id)) * 10, boatRentalsDao.GetHowManyBoatRentalsByWeekAndBoat(i, Convert.ToInt32(listData.id)) * 10, ref WeeklyIncomeCanvas, 10, i);

            }
            

        }

        public void towerChart(double x, double y, double height, ref Canvas canvas, double width, int number)
        {
            Rectangle tower = new Rectangle();
            tower.Width = width;
            tower.Height = height;
            tower.Stroke = Brushes.CadetBlue;
            tower.Fill = Brushes.CadetBlue;
            tower.StrokeThickness = 2;
            tower.SetValue(Canvas.LeftProperty, (double)(x));
            tower.SetValue(Canvas.TopProperty, (double)(y));
            canvas.Children.Add(tower);

            
            TextBlock TB = new TextBlock();
            TB.SetValue(Canvas.LeftProperty, (double)(x)+10);
            TB.SetValue(Canvas.TopProperty, (double)(y)+20+height);

            TB.Text = " " + (number + 1).ToString() + " ";
            TB.RenderTransform = new RotateTransform { Angle = 45 };
            TB.Background = System.Windows.Media.Brushes.CadetBlue;
            TB.Foreground = System.Windows.Media.Brushes.Black;
            TB.Name = "tb"+ number;
            System.Globalization.DateTimeFormatInfo mfi = new
            System.Globalization.DateTimeFormatInfo();
            if (canvas == MonthlyIncomeCanvas)
            {
                string strMonthName = mfi.GetMonthName(number + 1);

                TB.Text = " " + strMonthName + " ";
            }
            canvas.Children.Add(TB);

        }

        private void btStatYearly_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btStatMonthly_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btStatWeekly_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btStatDayly_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
