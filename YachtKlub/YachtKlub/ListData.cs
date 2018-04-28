using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace YachtKlub
{
    public class ListData
    {


        private string Text;
        public string text
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        private string Id;
        public string id
        {
            get { return this.Id; }
            set { this.Id = value; }
        }
        private BitmapImage ImageData;
        public BitmapImage imageData
        {
            get { return this.ImageData; }
            set { this.ImageData = value; }
        }


    }  
}

