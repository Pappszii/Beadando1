using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PixelShip
{
    class Enemy
    {
      protected  Point center;
       protected Vector sebesseg;
        static Random r = new Random();
       protected Size jatektermeret;
        protected int healthpower;
        protected int firepower;

        public Point Center { get => center; set => center = value; }
        public Vector Sebesseg { get => sebesseg; set => sebesseg = value; }
        public int Healthpower { get => healthpower; set => healthpower = value; }

        void Elhelyez()
        {
            //honnan induljon? milyen sebességvektorral?

            int y = (int)jatektermeret.Height;
            int x = (int)jatektermeret.Width;



            int poziciox = r.Next(0,x);
            
            //sorsoljunk egy poziciot
            center = new Point(poziciox,0);
            Sebesseg = new Vector(r.Next(-3, 3), r.Next(1,2));
            

        }


        public  Enemy(Size jatekmeret,int healthpower,int firepower)
        {
            this.jatektermeret = jatekmeret;
            this.healthpower = healthpower;
            this.firepower = firepower;
            Elhelyez();
        }



        Lovedek torlendo;

        public int  Mozgas(Size jatekter, List<Lovedek> lovedekek, Rect ship, List<Enemy> enemies)
        {
            

           // ütközik - e éppen lövedékkel?
             foreach (Lovedek item in lovedekek)
            {

               
                Rect lovedekrect = new Rect(item.Center.X, item.Center.Y+5,
                    3, 7);
                Rect enemyrect = new Rect(Center.X-25, Center.Y-25,
                    50, 50);
                //jobb hittbox miatt nagyobb a rect


                // mi lőttünk e id true...
                 if (lovedekrect.IntersectsWith(enemyrect)&&item.Id==true)
                {
                    //találkoznak
                    

                    healthpower -= item.FirePower;
                   
                    if (healthpower<=0)
                    {
                        enemies.Remove(this);
                        return 10;
                    }

                    torlendo = item;

                }
                
            }

             if(torlendo!= null)
                {
                lovedekek.Remove(torlendo);
                }
            

            /*tközik - e éppen a hajónkkal?*/
              Rect enemyrect2 = new Rect(Center.X , Center.Y ,
                      50, 50);

            
            if (enemyrect2.IntersectsWith(ship))
            {

                enemies.Remove(this);
                return -30;
                
               
            }

            //hova kerülne az enemy
            Point newcenter = new Point(Center.X + Sebesseg.X, Center.Y + Sebesseg.Y);
            if (newcenter.X >= 0 &&
                newcenter.Y >= 0 &&
                newcenter.X <= jatektermeret.Width &&
                newcenter.Y <= jatektermeret.Height)
            {
                 
                // Random kaphat egy új vectort
                center = newcenter;
                if (r.Next(0,200)==1)
                {
                    Sebesseg = new Vector(r.Next(-3, 3), r.Next(-1, 2));
                }
            }

            // pálya szélén pedig új vectort kap ellentétes irányba +-50 hogy ne lógjon ki
            else if(newcenter.X+100<0) 
            {
                Sebesseg = new Vector(r.Next(1, 3), r.Next(-1, 2));
            }
            else if (newcenter.X-100>jatektermeret.Width)
            {
                Sebesseg = new Vector(r.Next(-3, -1), r.Next(-1, 2));
            }
            else if (newcenter.Y+100<jatektermeret.Height)
            {
                Sebesseg = new Vector(r.Next(-3, 3), r.Next(1, 2));
            }


            // mirt nem jó more
            // valamiért nem érzékeli a pálya szélét..
            // kimegy a pályáról törlés.

             if (Center.Y>jatekter.Height)
            {
                enemies.Remove(this);
            }


            return 0;
        }

    }


    
}
