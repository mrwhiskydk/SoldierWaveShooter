﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpeedoAlienPrisonShootout
{
    public abstract class Weapon : GameObject
    {
        protected float firerate = 0.2f;
        protected float currentFirerate;
        protected int projectileSpeed = 1000;
        protected int damage = 10;
        protected float spread = 30f;
        protected string bulletSprite = "Bullet";
        protected int bulletAmount = 1;
        protected double lastShot;
        public int ammo = 0;
        protected bool infiniteAmmo = true;
        public int magazineCapacity = 0;
        public int magazine = 0;
        protected double timeToReload = 0.5;
        private double reloadTimer;
        protected bool isReloading = false;
        public bool isAmmo;
        protected Random rnd = new Random();
        protected Sound gunSound;
        protected Sound dryFire = new Sound("Sound/Weapons/dryfire");
        protected Sound reloadSound = new Sound("Sound/Weapons/reload");
        public bool equipped = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="spriteName"></param>
        /// <param name="sound">Sound of the gun firing</param>
        public Weapon(string spriteName, string sound) : base(spriteName)
        {
            gunSound = new Sound(sound);

        }

        /// <summary>
        /// Constructor for spawning a weapon in the world to later pick up as ammo
        /// </summary>
        /// <param name="startPosition">Position</param>
        /// <param name="spriteName">name of the sprite</param>
        /// <param name="isAmmo">True if spawned as a pickup from enemy for ammo</param>
        public Weapon(Vector2 startPosition, string spriteName, bool isAmmo) : base(startPosition, spriteName)
        {
            if (isAmmo)
            {
                gravity = true;
            }
        }

        /// <summary>
        /// Shoot our currently equipped gun
        /// </summary>
        public virtual void Shoot()
        {
            if (lastShot > currentFirerate)
            {
                if (magazine > 0 || infiniteAmmo)
                {
                    for (int i = 0; i < bulletAmount; i++)
                    {
                        //get the direction to shoot
                        Vector2 mousePos = Gameworld.mouse.Position - position;
                        mousePos.Normalize();
                        //Send the bullet in a random direction depending on weapon spread
                        float rndSpread = (float)rnd.Next(-(int)spread, (int)spread) / 1000;
                        float rndSpread2 = (float)rnd.Next(-(int)spread, (int)spread) / 1000;

                        new Projectile(position, bulletSprite, new Vector2(mousePos.X + rndSpread, mousePos.Y + rndSpread2), damage, projectileSpeed, "player");
                        lastShot = 0;
                    }

                    //Spawn a bullet casing flying in a semi random upwards direction
                    new BulletCasing(position);

                    //if we dont have infinite ammo substract from the bullets in our magazine
                    if (!infiniteAmmo)
                    {
                        magazine--;
                    }

                    gunSound.Play();
                }

                //if we dont have enough ammo to shoot then reload
                else if (ammo > 0 && !infiniteAmmo)
                {
                    Reload();
                }
                //if we dont have any ammo to reload with then dryfire
                else
                {
                    dryFire.Play();
                    lastShot = 0;
                }
            }
        }

        /// <summary>
        /// Reload our currently equipped weapon
        /// </summary>
        public virtual void Reload()
        {
            if (isReloading == false && magazine != magazineCapacity && ammo > 0)
            {
                reloadSound.Play();
                reloadTimer = 0;
                isReloading = true;
            }
        }


        public override void Update(GameTime gameTime)
        {
            lastShot += gameTime.ElapsedGameTime.TotalSeconds;


            //reload
            reloadTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (reloadTimer >= timeToReload && isReloading)
            {
                if (ammo > 0)
                {
                    int bulletsToReload = magazineCapacity - magazine;
                    if (ammo > bulletsToReload)
                    {
                        magazine += bulletsToReload;
                        ammo -= bulletsToReload;
                    }
                    else
                    {
                        magazine += ammo;
                        ammo -= ammo;
                    }
                }
                
                reloadTimer = 0;
                isReloading = false;
            }

            //if we have double firerate powerup
            if (Gameworld.player.fireRateMultiplier == 2)
            {
                currentFirerate = firerate / 2;
            }
            else
            {
                currentFirerate = firerate;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (equipped || isAmmo)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.96f);
            }
        }
    }
}