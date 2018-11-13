using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    public class Shotgun : Weapon
    {
        public Shotgun() : base("ShotgunPiskelSW")
        {
            firerate = 0.75f;
            projectileSpeed = 1250;
            damage = 10;
            spread = 80f;
            bulletAmount = 8;
            infiniteAmmo = false;
            magazineCapacity = 8;
            magazine = 0;
            timeToReload = 2;
        }
    }
}