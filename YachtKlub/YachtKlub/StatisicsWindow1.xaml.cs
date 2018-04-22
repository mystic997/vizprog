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

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for StatisicsWindow1.xaml
    /// </summary>
    public partial class StatisicsWindow1 : Window
    {
        public StatisicsWindow1()
        {
            InitializeComponent();
            towerChart(20, 550, 30);

        }

        public void towerChart(double x, double y, double height)
        {
            Rectangle tower = new Rectangle();
            tower.Width = 20;
            tower.Height = height;
            tower.Stroke = Brushes.Azure;
            tower.Fill = Brushes.Azure;
            tower.StrokeThickness = 2;
            tower.SetValue(Canvas.LeftProperty, (double)(x));
            tower.SetValue(Canvas.TopProperty, (double)(y));
            cvLap.Children.Add(tower);

        }
    }
}
