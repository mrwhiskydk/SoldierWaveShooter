using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedoAlienPrisonShootout
{
    public class Shotgun : Weapon
    {
        public Shotgun() : base("ShotgunPiskelSW", "Sound/Weapons/shotgun")
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

        /// <summary>
        /// Constructor for spawning a weapon in the world to later pick up as ammo
        /// </summary>
        /// <param name="startPosition">Position</param>
        /// <param name="isAmmo">True if spawned as a pickup from enemy for ammo</param>
        public Shotgun(Vector2 startPosition, bool isAmmo) : base(startPosition, "ShotgunPiskelSW", isAmmo)
        {
            this.isAmmo = isAmmo;
        }
    }
}