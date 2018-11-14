using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    /// <summary>
    /// The Flying class describes all flying enemies in the game. It has been overridden from the Enemy class, because it has unique features.
    /// </summary>
    public class Flying : Enemy
    {        
        private bool goDown = false;

        public Flying() : base(3, 9, new Vector2(1850,50), "FlyingGreen")
        {
            isFacingRight = true;
            enemyHealth = 50;
            enemyDamage = 5;
            movementSpeed = 30;
        }

        /// <summary>
        /// The update method for Flying enemies. Has been overridden from the Enemy class, since Flying enemies has unique features.
        /// </summary>
        /// <param name="gameTime">Time elapsed since the last call in the Update.</param>
        public override void Update(GameTime gameTime)
        {
            if (Gameworld.isAlive)
            {
                base.Update(gameTime);
                HandleMovement(gameTime);

                if (enemyHealth <= 0)
                {
                    Gravity = true;
                    enemyDamage = 0;
                }

                if (!Gameworld.ScreenSize.Intersects(CollisionBox) && enemyHealth <= 0)
                {
                    Destroy();
                }

                if (Gameworld.player.Position.Y >= position.Y)
                {
                    goDown = true;
                }

                else
                {
                    goDown = false;
                }
            }

            else
            {
                Destroy();
            }
            
        }

        /// <summary>
        /// The method for handling movement for Flying enemies. Has been overridden from the Enemy class, since Flying enemies has unique features.
        /// </summary>
        /// <param name="gameTime">Time elapsed since the last call in the Update.</param>
        protected override void HandleMovement(GameTime gameTime)
        {
            Gravity = false;
            base.HandleMovement(gameTime);

            if (goDown == true && goToPlayer == true)
            {
                position.Y += (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (goDown == false && goToPlayer == true)
            {
                position.Y -= (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

        }

        /// <summary>
        /// The method for handling collision between Flying enemies and other game objects.
        /// </summary>
        /// <param name="otherObject">otherObject is refering to other objects than objects of a diferent class.</param>
        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Player && enemyHealth > 0)
            {
                enemyHealth -= enemyHealth;

                //Generate a random number to see if we should drop something
                int random = rnd.Next(0, 10);
                if (random == 7 || random == 8)
                {
                    random = rnd.Next(0, 3);
                    switch (random)
                    {
                        case 0:
                            new Machinegun(position, true);
                            break;
                        case 1:
                            new Shotgun(position, true);
                            break;
                        case 2:
                            new Sniper(position, true);
                            break;
                        default:
                            break;
                    }
                }
                else if (random == 9)
                {
                    random = rnd.Next(0, 2);
                    if (random == 0)
                    {
                        new PowerUp2x(position);
                    }
                    else
                    {
                        new PowerUpMedkit(position);
                    }
                }
            }

            else if (otherObject is Projectile)
            {
                Projectile bullet = (Projectile)otherObject;
                if (bullet.team == "player")
                {
                    enemyHealth -= bullet.damage;
                    bullet.Destroy();
                }
            }
        }
    }
}