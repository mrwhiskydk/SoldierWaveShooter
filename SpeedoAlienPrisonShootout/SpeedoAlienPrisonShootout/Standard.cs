using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedoAlienPrisonShootout
{
    public class Standard : Weapon
    {
        public Standard() : base("ColtPiskel", "Sound/Weapons/standard")
        {
            equipped = true;
        }
    }
}