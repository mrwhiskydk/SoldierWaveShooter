using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    public class Sniper : Weapon
    {
        
        public Sniper() : base("HuntingRifle")
        {
            firerate = 1f;
            projectileSpeed = 50;
            damage = 100;
        }
    }
}