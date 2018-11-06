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
        protected float firerate = 0.2f;
        protected int projectileSpeed = 20;
        protected int damage = 10;
        protected double lastShot;

        public Weapon(string spriteName) : base(spriteName)
        {
            Gameworld.AddGameObject(this);
        }

        public void Shoot()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            lastShot += gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && lastShot > firerate)
            {
                Gameworld.AddGameObject(new Projectile(position, "Bullet", new Vector2(1, 0), damage, projectileSpeed));
                lastShot = 0;
            }
        }
    }
}