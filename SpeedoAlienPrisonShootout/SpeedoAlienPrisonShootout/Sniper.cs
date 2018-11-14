using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedoAlienPrisonShootout
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

        /// <summary>
        /// Constructor for spawning a weapon in the world to later pick up as ammo
        /// </summary>
        /// <param name="startPosition">Position</param>
        /// <param name="isAmmo">True if spawned as a pickup from enemy for ammo</param>
        public Sniper(Vector2 startPosition, bool isAmmo) : base(startPosition, "Sniper rifle", isAmmo)
        {
            this.isAmmo = isAmmo;
        }
    }
}