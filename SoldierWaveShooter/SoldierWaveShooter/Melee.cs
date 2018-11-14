using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    /// <summary>
    /// The Melee class describes all melee enemies in the game. It overrides a lot of methods from the Enemy class, because it has unique features.
    /// </summary>
    public class Melee : Enemy
    {
        private bool climb = false;

        public Melee() : base(3, 12, new Vector2(1830, 950), "Melee2")
        {
            enemyHealth = 100;
            enemyDamage = 10;
            movementSpeed = 70;

        }

        /// <summary>
        /// The update method for Melee enemies. Has been overrided from the Enemy class, since Melee enemies has unique features.
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
                    climb = true;
                }
                else
                {
                    climb = false;
                }
            }
            else
            {
                Gameworld.RemoveGameObject(this);
            }            
        }

        /// <summary>
        /// The method for handling movement for Melee enemies. Has been overridden from the Enemy class, since Melee enemies has unique features.
        /// </summary>
        /// <param name="gameTime">Time elapsed since the last call in the Update.</param>
        protected override void HandleMovement(GameTime gameTime)
        {
            base.HandleMovement(gameTime);
            if (climb == true && goToPlayer == true)
            {
                position.Y += (float)(movementSpeed / 2 * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (climb == false && goToPlayer == true)
            {
                position.Y -= (float)(movementSpeed / 2 * gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        /// <summary>
        /// The method for handling collision between Melee enemies and other game objects.
        /// </summary>
        /// <param name="otherObject">otherObject is refering to other objects than objects of a diferent class.</param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            if (otherObject is Platform && Gameworld.player.Position.Y > position.Y)
            {
                climb = true;
            }

        }
    }
}