﻿using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for NewTransportDeviceWindow.xaml
    /// </summary>
    public partial class NewTransportDeviceWindow : Window
    {
        public NewTransportDeviceWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UploadPic_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            dialog.DefaultExt = ".jpg";
            dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                // Open document
                imgBoatPicture.Tag = dialog.FileName;
                System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources");
                string fileName = System.IO.Path.GetFileName(Convert.ToString(imgBoatPicture.Tag));
                string newFileName = generateID() + ".jpg";
                File.Copy(Convert.ToString(imgBoatPicture.Tag), System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName, true);
                imgBoatPicture.Tag = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName;
                var uri = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + newFileName, UriKind.Absolute);
                var bitmap = new BitmapImage(uri);
                imgBoatPicture.Source = bitmap;
            }
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
