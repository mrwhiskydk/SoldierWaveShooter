using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Ranged : Enemy
    {
        private double lastShot;
        private double attackCooldown = 1;
        private float spread = 50f;
        private int projectileSpeed = 500;
        private Random rnd = new Random();

        public Ranged() : base(4, 4, new Vector2(120, 200), "Ranged")
        {
            enemyHealth = 70;
            enemyDamage = 10;
            movementSpeed = 20;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Gameworld.player.Position.X <= position.X)
            {
                isFacingRight = false;
            }
            else
            {
                isFacingRight = true;
            }

            lastShot += gameTime.ElapsedGameTime.TotalSeconds;
            if (lastShot >= attackCooldown)
            {
                //get the direction to shoot
                Vector2 direction = Gameworld.player.Position - position;
                direction.Normalize();
                //Send the bullet in a random direction depending on weapon spread
                float rndSpread = (float)rnd.Next(-(int)spread, (int)spread) / 1000;
                float rndSpread2 = (float)rnd.Next(-(int)spread, (int)spread) / 1000;

                new Projectile(position, "Bullet", new Vector2(direction.X + rndSpread, direction.Y + rndSpread2), enemyDamage, projectileSpeed, "enemy");

                //Spawn a bullet casing flying in a semi random upwards direction
                new BulletCasing(position);

                lastShot = 0;
            }
        }

            if (Gameworld.isAlive)
            {
                if (Gameworld.player.Position.X <= position.X)
                {
                    isFacingRight = false;
                }
                else
                {
                    isFacingRight = true;
                }
            }
            else
            {
                Gameworld.RemoveGameObject(this);
            }
            base.Update(gameTime);

            
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            base.HandleMovement(gameTime);

        }


        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

        }
    }
}