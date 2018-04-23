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
            for (int i = 0; i < 12; i++)
            {   
                towerChart(20 + i * 20, 50, boatRentalsDao.GetHowManyBoatRentalsByMonthAndBoat(i,Convert.ToInt32(listData.id)));

            }

        }

        public void towerChart(double x, double y, double height)
        {
            Rectangle tower = new Rectangle();
            tower.Width = 20;
            tower.Height = height;
            tower.Stroke = Brushes.CadetBlue;
            tower.Fill = Brushes.CadetBlue;
            tower.StrokeThickness = 2;
            tower.SetValue(Canvas.LeftProperty, (double)(x));
            tower.SetValue(Canvas.TopProperty, (double)(y));
            cvLap.Children.Add(tower);

        }
    }
}
