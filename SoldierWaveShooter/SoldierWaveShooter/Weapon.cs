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
        protected int ammo;
        protected float firerate = 0.2f;
        protected int projectileSpeed = 20;
        protected int damage = 10;
        protected float spread = 30f;
        protected string bulletSprite = "Bullet";
        protected int bulletAmount = 1;
        protected double lastShot;
        protected Random rnd = new Random();
        
        public bool equipped = false;

        public Weapon(string spriteName) : base(spriteName)
        {
            Gameworld.AddGameObject(this);
        }

        public virtual void Shoot()
        {
            if (lastShot > firerate)
            {
                for (int i = 0; i < bulletAmount; i++)
                {
                    //Send the bullet in a random direction depending on weapon spread
                    float rndSpread = (float)rnd.Next(-100 + (100 - (int)spread), 100 - (100 - (int)spread)) / 100;

#if DEBUG
                if (rndSpread > spread || rndSpread < -spread)
                {
                    Console.WriteLine("Out of range " + rndSpread);
                }
                Console.WriteLine(rndSpread);
#endif
                    Gameworld.AddGameObject(new Projectile(position, bulletSprite, new Vector2(1, rndSpread), damage, projectileSpeed));
                    lastShot = 0;
                }
                

                //Spawn a bullet casing flying in a semi random upwards direction
                float direction = (float)(rnd.Next(0, 2) * 2 - 1) * rnd.Next(0, 135);
                Console.WriteLine(direction);
                Console.WriteLine("x direction is: " + MathHelper.ToRadians(direction));
                Gameworld.AddGameObject(new BulletCasing(position, new Vector2(direction, 0)));
            }
        }

        public override void Update(GameTime gameTime)
        {
            lastShot += gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (equipped)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}