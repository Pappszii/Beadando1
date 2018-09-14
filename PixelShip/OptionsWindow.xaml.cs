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
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        SaveGame data;
        VirtualModel effektek;
       public SaveGame Data { get => data; set => data = value; }
        

        public OptionsWindow()
        {
            data = new SaveGame();
            effektek = new VirtualModel();
            this.DataContext = Data;

            InitializeComponent();
            
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // ha megtudjuk venni
            if (data.FirepowerAr<data.Coins)
            {
                data.Coins -= data.FirepowerAr;
                data.Firepower += 5;
                data.FirepowerAr += 100;
            }
            if (data.Coins<data.FirepowerAr)
            {
                effektek.BlurEffectAdd(sender);
                (sender as Button).Focusable = false;
                
            }

        }

        private void Button_Initialized(object sender, EventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (data.HealtpowerAr < data.Coins)
            {
                data.Coins -= data.HealtpowerAr;
                data.Healthpower += 10;
                data.HealtpowerAr += 100;
            }
            if (data.Coins < data.HealtpowerAr)
            {
                effektek.BlurEffectAdd(sender);
                (sender as Button).Focusable = false;

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (data.ShieldAr < data.Coins)
            {
                data.Coins -= data.ShieldAr;
                data.Shield += 5;
                data.ShieldAr += 250;
            }
            if (data.Coins < data.FirepowerAr)
            {
                effektek.BlurEffectAdd(sender);
                (sender as Button).Focusable = false;

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            data.Iras(data.atalakit(data));
        }
    }
}
