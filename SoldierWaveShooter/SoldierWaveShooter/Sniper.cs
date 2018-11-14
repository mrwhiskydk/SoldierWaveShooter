using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    public class Sniper : Weapon
    {
        public Sniper() : base("Sniper rifle", "Sound/Weapons/sniper")
        {
            firerate = 1f;
            projectileSpeed = 2500;
            damage = 100;
            spread = 0f;
            bulletSprite = "BulletTrail";
            infiniteAmmo = false;
            magazineCapacity = 5;
            magazine = 0;
            timeToReload = 2;
        }

        public Sniper(Vector2 startPosition, bool isAmmo) : base(startPosition, "Sniper rifle", isAmmo)
        {
            this.isAmmo = isAmmo;
        }
    }
}