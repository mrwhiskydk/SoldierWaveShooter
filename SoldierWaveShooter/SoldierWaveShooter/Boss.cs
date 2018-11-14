using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoldierWaveShooter
{
    /// <summary>
    /// The Boss class describes the boss enemy. It overrides a lot of methods from the Enemy class, because it has unique features.
    /// </summary>
    public class Boss : Enemy
    {
        private bool goDown = false;
        private double lastShot;
        private double attackCooldown = 1;
        private float spread = 1000;
        private int projectileSpeed = 300;
        private int bulletAmount = 10;
        private int projectileDamage = 5;

        public Boss() : base(5, 5, new Vector2(Gameworld.ScreenSize.Width / 2, 150), "Boss")
        {
            isFacingRight = false;
            enemyHealth = 50;
            enemyDamage = 15;
            movementSpeed = 25;
        }

        /// <summary>
        /// The update method for the Boss enemy. it Has been overridden from the Enemy class, since the Boss enemy has unique features.
        /// </summary>
        /// <param name="gameTime">Time elapsed since the last call in the Update.</param>
        public override void Update(GameTime gameTime)
        {

            if (Gameworld.isAlive)
            {
                base.Update(gameTime);
                HandleMovement(gameTime);

                if (Gameworld.player.Position.Y >= position.Y)
                {
                    goDown = true;
                }

                else
                {
                    goDown = false;
                }

                if (Gameworld.player.Position.X <= position.X)
                {
                    isFacingRight = true;
                }

                else
                {
                    isFacingRight = false;
                }

                //shooting
                lastShot += gameTime.ElapsedGameTime.TotalSeconds;
                if (lastShot >= attackCooldown)
                {
                    for (int i = 0; i < bulletAmount; i++)
                    {
                        //get the direction to shoot
                        Vector2 direction = Gameworld.player.Position - position;
                        direction.Normalize();
                        //Send the bullet in a random direction depending on weapon spread
                        float rndSpread = (float)rnd.Next(-(int)spread, (int)spread) / 1000;
                        float rndSpread2 = (float)rnd.Next(-(int)spread, (int)spread) / 1000;

                        new Projectile(position, "Bullet", new Vector2(direction.X + rndSpread, direction.Y + rndSpread2), projectileDamage, projectileSpeed, "enemy");
                    }

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

        /// <summary>
        /// The method for handling movement for the Boss enemy. It has been overridden from the Enemy class, since the Boss enemy has unique features.
        /// </summary>
        /// <param name="gameTime">Time elapsed since the last call in the Update.</param>
        protected override void HandleMovement(GameTime gameTime)
        {
            base.HandleMovement(gameTime);
            Gravity = false;
            if (goDown == true && goToPlayer == true)
            {
                position.Y += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (goDown == false && goToPlayer == true)
            {
                position.Y -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
        }
    }
}