using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PixelShip
{
    class Ship 
    {

        Size jatekmeret;
        int healthpower;
        int firepower;
        int shield;
        int x;
        int y;


        public int Healthpower { get => healthpower; set => healthpower = value; }
        public int Firepower { get => firepower; set => firepower = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Shield { get => shield; set => shield = value; }

        public Ship(Size jatekmeret, SaveGame data)
        {
            this.jatekmeret = jatekmeret;


            this.X = (int)jatekmeret.Width/2;
            this.Y = (int)jatekmeret.Height/2;
            //-100 mert hogy alulról beleférjen
            this.firepower = data.Firepower;
            this.healthpower = data.Healthpower;
            this.shield = data.Shield;

        }

        public void Utkozike(List<Lovedek> lovedekek)
        {

            Lovedek seged=null;

            foreach (Lovedek item in lovedekek)
            {
                Rect lovedekrect = new Rect(item.Center.X, item.Center.Y ,
                   3, 7);
                Rect shiprect = new Rect(X,Y,
                    80, 80);

                //false nem mi lőttük
                //Ha a shield nagyobb mint a lövés, akkor nem sebez minket viszont gyengül , egyébként pedig leszedi a hp-t.

                if (lovedekrect.IntersectsWith(shiprect) && item.Id == false)
                {

                    if (shield < item.FirePower)
                    {
                        this.Healthpower -= item.FirePower;
                        

                    }
                    else
                        shield -= 1;

                    seged = item;
                    
                    
                }
                
            }
            lovedekek.Remove(seged);
        }

    }
}
