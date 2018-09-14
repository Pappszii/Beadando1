using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PixelShip
{
    class Lovedek
    {
        Point center;
        Vector sebesseg;
        int firePower;
        bool id;



        //lovedeknek lesz egy IDja hogy enemy vagy mi lőttük , és lesz egy erőssége is.
        // egymást Enemey nem tudja majd szétdikházni.

        public Lovedek(Point center, Vector sebesseg,int firePower,bool id)
        {
            this.Center = center;
            this.sebesseg = sebesseg;
            this.FirePower = firePower;
            this.Id = id;
        }

        public Point Center { get => center; set => center = value; }
        public int FirePower { get => firePower; set => firePower = value; }
        public bool Id { get => id; set => id = value; }

        public bool Mozgas(Size jatekter)
        {
            //hova kerülne a lövedék
            Point newcenter = new Point(Center.X + sebesseg.X, Center.Y + sebesseg.Y);
            if (newcenter.X >= 0 &&
                newcenter.Y >= 0 &&
                newcenter.X <= jatekter.Width &&
                newcenter.Y <= jatekter.Height)
            {
                //pályán belül van -> áthelyezzük, igaz visszatérés
                center = newcenter;
                return true;
            }
            else
            {
                //elhagyta a pályát -> hamis visszatérés, VM törli a lövedéket
                return false;
            }
        }

    }
}
