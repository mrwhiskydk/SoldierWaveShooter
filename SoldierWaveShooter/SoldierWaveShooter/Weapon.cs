using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SoldierWaveShooter
{
    public abstract class Weapon : GameObject
    {
        protected int ammo;
        protected float firerate;
        protected float projectileSpeed;
        protected int damage;
        protected double lastShot;

        public Weapon(string spriteName) : base(spriteName)
        {
        }

        public void Shoot()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            lastShot += gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && lastShot > 0.2f)
            {
                Gameworld.AddGameObject(new Projectile(position, "Bullet", new Vector2(1, 0), 10, 10));
                lastShot = 0;
            }
        }
    }
}