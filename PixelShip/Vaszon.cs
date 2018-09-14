using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PixelShip
{
    class Vaszon:FrameworkElement
    {
        ImageBrush falconbrush;
        ImageBrush enemy;
        ImageBrush hatterbrush;
       
        JatekLogika VM;

        public void Init(JatekLogika VM,SaveGame data)
        {
            this.VM = VM;

            falconbrush = new ImageBrush(
                new BitmapImage(new Uri
                (data.Ship, UriKind.RelativeOrAbsolute)
                ));

          falconbrush.Stretch = Stretch.UniformToFill;
            //falconbrush.TileMode = TileMode.Tile;

            enemy = new ImageBrush(
               new BitmapImage(new Uri
               ("enemybrush.png", UriKind.RelativeOrAbsolute)
               ));
           enemy.Stretch = Stretch.UniformToFill;

            hatterbrush = new ImageBrush(
               new BitmapImage(new Uri
               ("hatter.png", UriKind.RelativeOrAbsolute)
               ));
            
        }

        protected override void OnRender(DrawingContext drawingContext)
        {

            //ellenfelek
            if(VM!=null)
                {

                drawingContext.DrawRectangle(
                    hatterbrush,
                    null,
                    new Rect(0, 0, this.ActualWidth, this.ActualHeight)
                    );

                


                foreach (Enemy item in VM.Enemies)
                {
                    
                   

                    if (item is BossEnemy)
                    {
                       
                        drawingContext.DrawEllipse(
                       enemy,
                       null,
                        item.Center,
                       80,
                       80
                       );
                    }
                    else 
                    {
                        drawingContext.DrawEllipse(
                       enemy,
                       null,
                       item.Center,
                       40,
                       40
                       );
                    }
                   
                }
                //lovesek

                foreach (Lovedek item in VM.Lovedekek)
                {
                    if (item.Id == true)
                    {
                        drawingContext.DrawEllipse(
                               Brushes.Blue,
                                 null,
                                 item.Center,
                               3,
                               7
                            );
                    }
                    else
                    {
                        drawingContext.DrawEllipse(
                            Brushes.Red,
                            null,
                            item.Center,
                            3,
                            7
                            );
                    }
                }

                Rect urhajorect = new Rect(VM.Hajo.X, VM.Hajo.Y, 80, 80);
                drawingContext.DrawRectangle(falconbrush, null, urhajorect);

            }

            //teszt
            if (VM!=null)
            {
                for (int i = 0; i < VM.Enemies.Count; i++)
                {
                    
                    drawingContext.DrawText(
                        new FormattedText(VM.Enemies[i].Healthpower.ToString(), System.Globalization.CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight, new Typeface(
                            new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold,
                            FontStretches.Normal), 15, Brushes.Green), new Point
                            (VM.Enemies[i].Center.X, VM.Enemies[i].Center.Y-50)
                            );
                }


                drawingContext.DrawText(
                    new FormattedText(VM.Hajo.Healthpower.ToString(), System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight, new Typeface(
                        new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold,
                        FontStretches.Normal), 15, Brushes.Red), new Point
                        (20, 40)
                        );

                drawingContext.DrawText(
                    new FormattedText(VM.Pontok.ToString(), System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight, new Typeface(
                        new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold,
                        FontStretches.Normal), 15, Brushes.GreenYellow), new Point
                        (70, 40)
                        );
                drawingContext.DrawText(
                    new FormattedText(VM.Hajo.Shield.ToString(), System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight, new Typeface(
                        new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold,
                        FontStretches.Normal), 15, Brushes.Blue), new Point
                        (120, 40)
                        );


            }

         
            
           



        }
    }
}
