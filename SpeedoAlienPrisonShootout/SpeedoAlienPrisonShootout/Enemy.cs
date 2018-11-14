using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpeedoAlienPrisonShootout
{
    /// <summary>
    /// The Enemy class is a superclass of all the enemies in the game. It sets standard fields and methods that all enemies need.
    /// </summary>
    public class Enemy : Character
    {
        /// <summary>
        /// A field refering to the enemies health in general.
        /// </summary>
        public int enemyHealth;
        /// <summary>
        /// A field refering to the enemies damage in general.
        /// </summary>
        public int enemyDamage;
        /// <summary>
        /// A field to determine if enemies should follow the player or not.
        /// </summary>
        protected bool goToPlayer = false;
        /// <summary>
        /// A field to determine if enemies should go to the left or not.
        /// </summary>
        protected bool goLeft = false;
        protected Random rnd = new Random();

        public Enemy(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
        }

        /// <summary>
        /// The standard update method for enemies.
        /// </summary>
        /// <param name="gameTime">Time elapsed since the last call in the Update.</param>
        public override void Update(GameTime gameTime)
        {
            if (Gameworld.player.Position.X != position.X && enemyHealth > 0)
            {
                goToPlayer = true;
            }
            else
            {
                goToPlayer = false;
            }

            if (Gameworld.player.Position.X <= position.X)
            {
                goLeft = true;
            }
            else
            {
                goLeft = false;
            }

            base.Update(gameTime);
            HandleMovement(gameTime);
        }

        /// <summary>
        /// The standard method for handling the movement of enemies.
        /// </summary>
        /// <param name="gameTime">Time elapsed since the last call in the Update.</param>
        protected override void HandleMovement(GameTime gameTime)
        {
            if (goToPlayer == true && goLeft == true)
            {
                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (goToPlayer == true && goLeft == false)
            {
                position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

        }

        /// <summary>
        /// Determine if killed enemy should drop loot
        /// </summary>
        public void DropLoot()
        {
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

        /// <summary>
        /// The standard method for handling collision between enemies and other objects.
        /// </summary>
        /// <param name="otherObject">otherObject is refering to other objects than objects of a diferent class.</param>
        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform)
            {
                Gravity = false;
            }

            else if (otherObject is Projectile)
            {
                Projectile bullet = (Projectile)otherObject;
                if (bullet.team == "player")
                {
                    enemyHealth -= bullet.damage;
                    bullet.Destroy();
                    
                    //if we have 0 or less health then we die
                    if (enemyHealth <= 0)
                    {
                        Destroy();
                    }
                }
            }
        }

        public override void Destroy()
        {
            DropLoot();
            base.Destroy();
        }
    }
}