using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YachtKlub.validator;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for PopupMessage.xaml
    /// </summary>
    public partial class PopupMessage : Window
    {
        //private Status status;

        public PopupMessage(string message, Status status)
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.Top = 0;
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;

            if (status == Status.OK)
                this.gird.Background = new SolidColorBrush(Color.FromRgb(85, 145, 210));
            else
                this.gird.Background = new SolidColorBrush(Color.FromRgb(215, 50, 50));

            this.msg.FontWeight = FontWeights.Bold;
            this.msg.Foreground = Brushes.White;
            this.msg.FontSize = 15;
            this.msg.Content = message;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 3000;
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.Start();
        }

        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                this.Close();
            }), null);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(1));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);

            PopupMargin.Count--;
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window_Closing(this, new System.ComponentModel.CancelEventArgs(true));
        }
    }
}
