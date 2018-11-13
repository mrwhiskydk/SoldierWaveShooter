using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Machinegun : Weapon
    {
        public Machinegun() : base("Machinegun")
        {
            firerate = 0.1f;
            projectileSpeed = 1500;
            damage = 8;
            spread = 60f;
            infiniteAmmo = false;
            magazineCapacity = 30;
            magazine = 0;
            timeToReload = 1;
        }

        public Machinegun(Vector2 startPosition, bool isAmmo) : base(startPosition, "Machinegun", isAmmo)
        {
            this.isAmmo = isAmmo;
        }
    }
}