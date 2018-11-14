using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    /// <summary>
    /// The Ranged class describes all ranged enemies in the game. It overrides some methods from the Enemy class, because it has unique features.
    /// </summary>
    public class Ranged : Enemy
    {
        private double lastShot;
        private double attackCooldown = 1;
        private float spread = 50f;
        private int projectileSpeed = 500;

        public Ranged() : base(4, 4, new Vector2(120, 200), "Ranged")
        {
            enemyHealth = 70;
            enemyDamage = 10;
            movementSpeed = 20;
        }

        /// <summary>
        /// The update method for Ranged enemies. Has been overridden from the Enemy class, since Ranged enemies has unique features.
        /// </summary>
        /// <param name="gameTime">Time elapsed since the last call in the Update.</param>
        public override void Update(GameTime gameTime)
        {
            if (Gameworld.isAlive)
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

            else
            {
                Destroy();
            }
        }
    }
}