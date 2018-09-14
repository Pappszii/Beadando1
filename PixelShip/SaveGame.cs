using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PixelShip
{
   public class SaveGame:Bindable
    {
        int shield;
        int healthpower;
        int firepower;

        int shieldAr;
        int healtpowerAr;
        int firepowerAr;
        int coins;
        string ship;

        StreamWriter irstreamWriter;
        StreamReader bestreamReader;

        public int Shield { get => shield; set => shield = value; }
        public int Healthpower { get => healthpower; set => healthpower = value; }
        public int Firepower { get => firepower; set => firepower = value; }
        public int ShieldAr { get => shieldAr; set { shieldAr = value; OnPropertyChanged(); } }
        public int HealtpowerAr { get => healtpowerAr; set { healtpowerAr = value; OnPropertyChanged(); } }
        public int FirepowerAr { get => firepowerAr; set { firepowerAr = value; OnPropertyChanged(); } }
        public int Coins { get => coins; set { coins = value; OnPropertyChanged(); } }

        public string Ship { get => ship; set => ship = value; }

        public SaveGame()
        {
            if (!File.Exists("SaveGameFile.txt"))
            {
                // Ha még ninsc SaveGame iniciliazáljuk , kiírjuk a nulla adatkoat a fájlba

                irstreamWriter = new StreamWriter("SaveGameFile.txt");
                
                this.Coins = 0;
                this.Firepower = 10;
                this.FirepowerAr = 125;
                this.Healthpower = 100;
                this.HealtpowerAr = 125;
                this.Shield = 0;
                this.ShieldAr = 125;
                this.ship = "falcon.png";
                irstreamWriter.Write(Shield + "-" + Healthpower + "-" + Firepower + "-" + ShieldAr + "-" + HealtpowerAr + "-" + FirepowerAr + "-" + Coins+"-"+Ship);
                irstreamWriter.Close();

            }
            else
            {
                //betöltjük a SaveGamet. 
                bestreamReader = new StreamReader("SaveGameFile.txt");
                string adatnyers = bestreamReader.ReadLine();
                string[] adatok = adatnyers.Split('-');

                this.Shield = int.Parse(adatok[0]);
                this.Healthpower = int.Parse(adatok[1]);
                this.Firepower = int.Parse(adatok[2]);
                this.ShieldAr = int.Parse(adatok[3]);
                this.HealtpowerAr = int.Parse(adatok[4]);
                this.FirepowerAr = int.Parse(adatok[5]);
                this.Coins = int.Parse(adatok[6]);
                this.ship = adatok[7];

                bestreamReader.Close();
            }
           

            
           

        }

        public void Iras(string[] adatok)
        {

            irstreamWriter = new StreamWriter("SaveGameFile.txt");
            if (Coins<0)
            {
                Coins = 0;
            }
            irstreamWriter.Write(Shield+"-"+Healthpower+"-"+Firepower + "-"+ShieldAr + "-"+HealtpowerAr+"-"+FirepowerAr+"-"+Coins+"-"+Ship);
            irstreamWriter.Close();
        }


    public  string[] atalakit(SaveGame savegame)
        {
            string[] ki = new string[8];
            ki[0] = savegame.Shield.ToString();
            ki[1] = savegame.Healthpower.ToString();
            ki[2] = savegame.Firepower.ToString();
            ki[3] = savegame.ShieldAr.ToString();
            ki[4] = savegame.HealtpowerAr.ToString();
            ki[5] = savegame.FirepowerAr.ToString();
            ki[6] = savegame.Coins.ToString();
            ki[7] = savegame.Ship;

            return ki;
        }

        


    }
}
