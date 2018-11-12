using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    public class Sniper : Weapon
    {
        public Sniper() : base("Sniper rifle")
        {
            firerate = 1f;
            projectileSpeed = 50;
            damage = 100;
            spread = 0f;
            bulletSprite = "BulletTrail";
        }
    }
}