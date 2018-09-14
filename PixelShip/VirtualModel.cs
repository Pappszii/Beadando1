using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace PixelShip
{
    class VirtualModel
    {
        // csak külön részbe raktam a windowon történő változtatásokat..
        public void BlurEffectAdd(object sender)
        {
            (sender as Button).BitmapEffect = new BlurBitmapEffect{ Radius = 5 };
        }
        public void BlurEffectRemove(object sender)
        {
            (sender as Button).BitmapEffect = new BlurBitmapEffect { Radius = 0 };
        }


        

    }
}
