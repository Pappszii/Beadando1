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
using System.Windows.Threading;

namespace PixelShip
{
    /// <summary>
    /// Interaction logic for playWindow.xaml
    /// </summary>
    public partial class playWindow : Window
    {

        JatekLogika JL;
        DispatcherTimer dt;
        SaveGame data;
       


        public SaveGame Data { get => data; set => data = value; }

        public playWindow()
        {
            InitializeComponent();

            data = new SaveGame();
        }
        private void Dt_Tick(object sender, EventArgs e)
        {
            JL.Frissites();
            vaszon.InvalidateVisual();
            
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            JL = new JatekLogika(new Size(this.ActualWidth,this.ActualHeight),data);
            vaszon.Init(JL,data);
            vaszon.InvalidateVisual();
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(20);
            dt.Tick += Dt_Tick;
            dt.Start();
            JL.Jatekvege += JatekVegeter;

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           
                JL = new JatekLogika(new Size(this.ActualWidth, this.ActualHeight),data);
            vaszon.Init(JL,data);
            JL.Jatekvege += JatekVegeter;
                
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

           // JL.Billentyu(e.Key);
            vaszon.InvalidateVisual();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            double x = e.GetPosition(this.vaszon).X;
            double y = e.GetPosition(this.vaszon).Y;
            JL.EgerMozog(e,x, y);
            vaszon.InvalidateVisual();
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            JL.Tuzel();
           

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            data.Coins = JL.Pontok;
            data.Iras(data.atalakit(data));
        }

        private void JatekVegeter(object sender, EventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Játék vége...");
            if (mbr == MessageBoxResult.OK)
            {
                this.Close();
                dt.Tick -= Dt_Tick;
            }
        }

       
    }
}
