using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YachtKlub
{
    class RoutedEventUCIndex : RoutedEventArgs
    {
        public int Index { get; set; }

        public RoutedEventUCIndex(RoutedEvent routedEvent, int index) : base(routedEvent)
        {
            Index = index;
        }
    }
}
