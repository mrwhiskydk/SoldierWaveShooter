using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SoldierWaveShooter
{
    public abstract class Weapon : GameObject
    {
        protected float firerate = 0.2f;
        protected int projectileSpeed = 1000;
        protected int damage = 10;
        protected float spread = 30f;
        protected string bulletSprite = "Bullet";
        protected int bulletAmount = 1;
        protected double lastShot;
        public int ammo = 0;
        protected bool infiniteAmmo = true;
        public int magazineCapacity = 10;
        public int magazine = 10;
        protected double timeToReload = 0.5;
        private double reloadTimer;
        protected bool isReloading = false;
        public bool isAmmo;
        protected Random rnd = new Random();
        
        public bool equipped = false;

        public Weapon(string spriteName) : base(spriteName)
        {
            
        }

        public Weapon(Vector2 startPosition, string spriteName, bool isAmmo) : base(startPosition, spriteName)
        {

        }

        public virtual void Shoot()
        {
            if (lastShot > firerate)
            {
                if (magazine > 0 || infiniteAmmo)
                {
                    for (int i = 0; i < bulletAmount; i++)
                    {
                        Vector2 mousePos = Gameworld.mouse.Position - position;
                        mousePos.Normalize();
                        //Send the bullet in a random direction depending on weapon spread
                        float rndSpread = (float)rnd.Next(-(int)spread, (int)spread) / 1000;
                        float rndSpread2 = (float)rnd.Next(-(int)spread, (int)spread) / 1000;

                        //Console.WriteLine("spread : " + rndSpread);

                        new Projectile(position, bulletSprite, new Vector2(mousePos.X + rndSpread, mousePos.Y + rndSpread2), damage, projectileSpeed);
                        lastShot = 0;
                    }

                    //Spawn a bullet casing flying in a semi random upwards direction
                    new BulletCasing(position);
                    if (!infiniteAmmo)
                    {
                        magazine--;
                    }
                    
                }
                else if (ammo > 0 && !infiniteAmmo)
                {
                    Reload();
                }
            }
        }

        public virtual void Reload()
        {
            if (reloadTimer > timeToReload)
            {
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
                if (ammo > magazineCapacity)
                {
                    magazine = magazineCapacity;
                    ammo -= magazine;
                }
                else
                {
                    magazine = ammo;
                    ammo -= magazine;
                }
                reloadTimer = 0;
                isReloading = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (equipped || isAmmo)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}