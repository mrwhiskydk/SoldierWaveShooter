using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpeedoAlienPrisonShootout
{
    public class Machinegun : Weapon
    {
        public Machinegun() : base("Machinegun", "Sound/Weapons/submachinegun")
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

        /// <summary>
        /// Constructor for spawning a weapon in the world to later pick up as ammo
        /// </summary>
        /// <param name="startPosition">Position</param>
        /// <param name="isAmmo">True if spawned as a pickup from enemy for ammo</param>
        public Machinegun(Vector2 startPosition, bool isAmmo) : base(startPosition, "Machinegun", isAmmo)
        {
            this.isAmmo = isAmmo;
        }
    }
}