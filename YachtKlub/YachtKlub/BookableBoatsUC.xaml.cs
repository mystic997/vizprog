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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YachtKlub.entity;
using YachtKlub.service;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for BookableBoatsUC.xaml
    /// </summary>
    public partial class BookableBoatsUC : UserControl
    {
        //public static List<BoatsEntity> BookableBoats { get; set; }
        public BookableBoatsUC()
        {
            InitializeComponent();
        }

        private void lbBookalbeShipsUC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedElementIndex = this.lbBookalbeShipsUC.SelectedIndex;

            //Console.WriteLine("Element changed...");
            //var bookableBoats = LoadBookableBoatsService.BookableBoats;
        }
    }
}
