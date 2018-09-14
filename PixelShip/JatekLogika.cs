using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PixelShip
{
    class JatekLogika:Bindable
    {
        Size jatektermeret;

        List<Lovedek> lovedekek;
        List<Enemy> enemies;
        Random r = new Random();
        Ship hajo;
        int pontok;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer("sajatpiu.wav");
        

        public event EventHandler Jatekvege;




        public JatekLogika(Size Jatekmeret,SaveGame data)
        {
            this.jatektermeret = Jatekmeret;
            Lovedekek = new List<Lovedek>();
            Enemies = new List<Enemy>();
            Hajo = new Ship(jatektermeret,data);
            
            for (int i = 0; i < r.Next(1,10); i++)
            {
                Enemies.Add(new Enemy(Jatekmeret, r.Next(50, 200), r.Next(1, 50)));

            }
            Pontok = data.Coins;
        }

        internal List<Lovedek> Lovedekek { get => lovedekek; set => lovedekek = value; }
        internal List<Enemy> Enemies { get => enemies; set => enemies = value; }
        internal Ship Hajo { get => hajo; set => hajo = value ; }
        public int Pontok { get => pontok; set => pontok = value; }

        public void Frissites()
        {
            for (int i = 0; i < lovedekek.Count; i++)
            {
                bool belulvan = lovedekek[i].Mozgas(jatektermeret);
                if (!belulvan)
                {
                    lovedekek.Remove(lovedekek[i]);
                    
                }
            }

            for (int i = 0; i < enemies.Count; i++)
            {


                if (enemies[i] is BossEnemy)
                {
                    BossTuzel(enemies[i]);

                   Pontok+=enemies[i].Mozgas(jatektermeret, lovedekek, new Rect(hajo.X, hajo.Y, 80, 100)
                       , enemies
                        );
                }
                else
                {
                    if (r.Next(0,70) == 1)
                    {
                        //false az id == enemy lőtte.
                        Lovedekek.Add(new Lovedek(new Point(enemies[i].Center.X, enemies[i].Center.Y), new Vector(0, 6), r.Next(5, 50), false));
                    }
                    Pontok+= enemies[i].Mozgas(jatektermeret, lovedekek,
                        new Rect(hajo.X, hajo.Y, 80, 80), enemies
                        );
                }
              }

            
            hajo.Utkozike(lovedekek);

            // Meghalt -e mind?
            // Boss jön vagy újabb x enemy

            if (Enemies.Count==0)
            {
                if (r.Next(0,5)==1)
                {
                    enemies.Add(new BossEnemy(jatektermeret, r.Next(1000, 2000), r.Next(50, 400)));
                    if (r.Next(1,3)==1)
                    {
                        enemies.Add(new Enemy(jatektermeret, r.Next(50, 100), r.Next(5, 50)));
                        enemies.Add(new Enemy(jatektermeret, r.Next(50, 100), r.Next(5, 50)));
                    }

                }
                else
                {
                    for (int i = 0; i < r.Next(3,12); i++)
                    {
                        enemies.Add(new Enemy(jatektermeret, r.Next(50, 100), r.Next(10, 25)));
                    }
                }
            }

            if (hajo.Healthpower <= 0 || Pontok < 0)
            {
                Jatekvege?.Invoke(this, new EventArgs());
            }
        }
        

       

        public void EgerMozog(MouseEventArgs e , double x, double y)
        {

            // 80*80 as hogy középen legyen -40 -40
            hajo.X = (int)x - 40;
            hajo.Y = (int)y - 40;
        }

        public void Tuzel()
        {
            Lovedekek.Add(new Lovedek(new Point(hajo.X, hajo.Y), new Vector(0, -6), hajo.Firepower, true));

           // player.Play();
        }

        public void BossTuzel(Enemy enemy)
        {
            if (r.Next(0,50)==1)
            {
                Lovedekek.Add(new Lovedek(new Point(enemy.Center.X, enemy.Center.Y), new Vector(0, 6), r.Next(10, 50), false));
            }

            if (lovedekek.Count!=0 && lovedekek[lovedekek.Count-1].Id==false &&r.Next(0,20)==1)
            { 
                Lovedekek.Add(new Lovedek(new Point(lovedekek[lovedekek.Count-1].Center.X, lovedekek[lovedekek.Count-1].Center.Y), new Vector(-1.0, 6), r.Next(50, 100), false));
                Lovedekek.Add(new Lovedek(new Point(lovedekek[lovedekek.Count-1].Center.X, lovedekek[lovedekek.Count-1].Center.Y), new Vector(-1.5, 6), r.Next(50, 100), false));
                Lovedekek.Add(new Lovedek(new Point(lovedekek[lovedekek.Count-1].Center.X, lovedekek[lovedekek.Count-1].Center.Y), new Vector(-2.0, 6), r.Next(50, 100), false));
                Lovedekek.Add(new Lovedek(new Point(lovedekek[lovedekek.Count-1].Center.X, lovedekek[lovedekek.Count-1].Center.Y), new Vector(1.0, 6), r.Next(50, 100), false));
                Lovedekek.Add(new Lovedek(new Point(lovedekek[lovedekek.Count-1].Center.X, lovedekek[lovedekek.Count-1].Center.Y), new Vector(1.5, 6), r.Next(50, 100), false));
                Lovedekek.Add(new Lovedek(new Point(lovedekek[lovedekek.Count-1].Center.X, lovedekek[lovedekek.Count-1].Center.Y), new Vector(2.0, 6), r.Next(50, 100), false));
            }
        }

        public void Eger(MouseEventArgs e)
        {
            Point x =e.GetPosition(null);
        }
    }
}
