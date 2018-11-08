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
        public int damage = 10;
        protected double lastShot;
        protected Random rnd = new Random();
        protected float spread = 30f;
        public bool equipped = false;

        public Weapon(string spriteName) : base(spriteName)
        {
            Gameworld.AddGameObject(this);
        }

        public void Shoot()
        {
            if (lastShot > firerate)
            {
                float rndSpread = (float)rnd.Next(-100 + (100 - (int)spread) , 100 - (100 - (int)spread)) / 100;

                if(rndSpread > spread || rndSpread < -spread)
                { 
                    Console.WriteLine("Out of range " + rndSpread);
                }
                Console.WriteLine(rndSpread);
                Gameworld.AddGameObject(new Projectile(position, "Bullet", new Vector2(1, rndSpread), damage, projectileSpeed));
                lastShot = 0;
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