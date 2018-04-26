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

        public StatisticsWindow2(ListData listData)
        {
            listDataGlobal = new ListData();

            BoatRentalsDao boatRentalsDao = new BoatRentalsDaoImpl();
            
            InitializeComponent();
            int j = 0;
            for (int i = 2015; i < 2019; i++)
            {
                boatRentalsDao.GetIncomeBoatRentalsByYearAndBoat(i, Convert.ToInt32(listData.id));
                j++;


            }
            for (int i = 0; i < 12; i++)
            {
                boatRentalsDao.GetIncomeBoatRentalsByMonthAndBoat(i, Convert.ToInt32(listData.id));
                
            }
            for (int i = 0; i < 52; i++)
            {
                boatRentalsDao.GetIncomeBoatRentalsByWeekAndBoat(i, Convert.ToInt32(listData.id));

            }

            for (int i = 0; i < 365; i++)
            {
                boatRentalsDao.GetIncomeBoatRentalsByDayAndBoat(i, Convert.ToInt32(listData.id));

            }

            InitializeComponent();
        }
    }
}
