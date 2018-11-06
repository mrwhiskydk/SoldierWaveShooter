using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    public class Standard : Weapon
    {
        public Standard() : base("ColtPixel")
        {
            equipped = true;
        }
    }
}