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
        protected double lastShot;
        protected Random rnd = new Random();
        protected float accuracy = 0.9f;
        public bool equipped = false;

        public Weapon(string spriteName) : base(spriteName)
        {
            Gameworld.AddGameObject(this);
        }

        public void Shoot()
        {
            if (lastShot > firerate)
            {
                float spread = (float)rnd.NextDouble();
                //float spread = rnd.Next(99, 101) / 100;
                
                Console.WriteLine(spread);
                Gameworld.AddGameObject(new Projectile(position, "Bullet", new Vector2(1, spread), damage, projectileSpeed));
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