using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    public class Machinegun : Weapon
    {
        public Machinegun() : base("Mp5Pixel")
        {
            firerate = 0.1f;
            projectileSpeed = 1500;
            damage = 8;
            spread = 60f;
        }
    }
}