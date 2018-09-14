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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace PixelShip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VirtualModel VM;
        System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();
        
        public MainWindow()
        {
            InitializeComponent();
            VM = new VirtualModel();
            soundPlayer.SoundLocation = "hatterzene.wav";
            soundPlayer.Play();

            
           
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window options = new OptionsWindow();
            options.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new ControlPage();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WindowSettings ws = new WindowSettings();
            ws.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            playWindow pw = new playWindow();
            pw.Show();
            
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            VM.BlurEffectAdd(sender);
        }

        private void Button_MouseEnter_1(object sender, MouseEventArgs e)
        {
            VM.BlurEffectAdd(sender);
        }

        private void Button_MouseEnter_2(object sender, MouseEventArgs e)
        {
            VM.BlurEffectAdd(sender);
        }

        private void Button_MouseEnter_3(object sender, MouseEventArgs e)
        {
            VM.BlurEffectAdd(sender);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            VM.BlurEffectRemove(sender);
        }

        private void Button_MouseLeave_1(object sender, MouseEventArgs e)
        {
            VM.BlurEffectRemove(sender);
        }

        private void Button_MouseLeave_2(object sender, MouseEventArgs e)
        {
            VM.BlurEffectRemove(sender);
        }

        private void Button_MouseLeave_3(object sender, MouseEventArgs e)
        {
            VM.BlurEffectRemove(sender);
        }

        private void Button_MouseEnter_4(object sender, MouseEventArgs e)
        {
            VM.BlurEffectAdd(sender);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
