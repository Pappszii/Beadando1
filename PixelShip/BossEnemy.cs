using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PixelShip
{
    class BossEnemy : Enemy
    {

        static Random r = new Random();

        public BossEnemy(Size jatekmeret, int healthpower, int firepower) : base(jatekmeret, healthpower, firepower)
        {


            Elhelyez();

             }


        Lovedek torlendo;

       

        public int Mozgas(Size jatekter, List<Lovedek> lovedekek, Rect ship, List<Enemy> enemies)
        {

            
            // ütközik - e éppen lövedékkel?
            foreach (Lovedek item in lovedekek)
                
            {
                Rect lovedekrect = new Rect(item.Center.X + 5, item.Center.Y + 5,
                    3, 7);
                Rect enemyrect = new Rect(Center.X, Center.Y,
                    90, 90);
                //+10 pixel nagyobb hitbox
                // mi lőttünk e id...
                if (lovedekrect.IntersectsWith(enemyrect) && item.Id == true)
                {
                    //találkoznak


                    healthpower -= item.FirePower;

                    if (healthpower <= 0)
                    {
                        enemies.Remove(this);
                        return 50;

                       
                    }

                    torlendo = item;

                }

            }

            if (torlendo != null)
            {
                lovedekek.Remove(torlendo);
            }


            //ütközünk -->torlés 
            Rect enemyrect2 = new Rect(Center.X - 15, Center.Y - 15,
                    150, 150);
            if (enemyrect2.IntersectsWith(ship))
            {
                enemies.Remove(this);
                return 0;
               // eseménmy gameover
            }

            //hova kerülne az aszteroida
            Point newcenter = new Point(Center.X + Sebesseg.X, Center.Y + Sebesseg.Y);
            if (newcenter.X >= 0 &&
                newcenter.Y >= 0 &&
                newcenter.X <= jatektermeret.Width &&
                newcenter.Y <= jatektermeret.Height)
            {
                //pályán belül van -> áthelyezzük 
                // Random kaphat egy új vectort
                center = newcenter;
                if (r.Next(0, 100) == 1)
                {
                    Sebesseg = new Vector(r.Next(1,3)/10, r.Next(1,3)/-10);
                }
            }

            // pálya szélén pedig új vectort kap ellentétes irányba +-150 hogy ne lógjon ki
            else if (newcenter.X + 150 == 0)
            {
                Sebesseg = new Vector(r.Next(1, 3) / 10, r.Next(1, 3) / 10);
            }
            else if (newcenter.X - 150 == jatektermeret.Width)
            {
                Sebesseg = new Vector(r.Next(1,3) / -10, r.Next(1, 3) / 10);
            }
            else if (newcenter.Y + 150 == jatektermeret.Height)
            {
                Sebesseg = new Vector(r.Next(1, 3) / 10, r.Next(1, 3) / 10);
            }


            return 0;
            
        }


        void Elhelyez()
        {
            //honnan induljon? milyen sebességvektorral?

            int y = (int)jatektermeret.Height;
            int x = (int)jatektermeret.Width;



            int poziciox = r.Next(150, x-150);

            //sorsoljunk egy poziciot
            center = new Point(poziciox, 100);
            Sebesseg = new Vector(r.Next(1, 3) / 10, r.Next(1, 3) / 10);


        }
    }
}
