using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    public class Shotgun : Weapon
    {
        public Shotgun() : base("Shotgun")
        {
            firerate = 0.75f;
            projectileSpeed = 20;
            damage = 10;
            spread = 80f;
            bulletAmount = 8;
        }
    }
}