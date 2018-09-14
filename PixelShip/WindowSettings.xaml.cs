using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PixelShip
{
    /// <summary>
    /// Interaction logic for WindowSettings.xaml
    /// </summary>
    public partial class WindowSettings : Window
    {
        SaveGame data;

        public WindowSettings()
        {
            InitializeComponent();
            data = new SaveGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            data.Ship = "falcon.png";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            data.Ship = "xwing.png";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            data.Iras(data.atalakit(data));
        }
    }
}
