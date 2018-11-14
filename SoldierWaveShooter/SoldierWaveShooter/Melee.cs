using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Melee : Enemy
    {
        private bool climb = false;

        public Melee() : base(3, 12, new Vector2(1830, 950), "Melee2")
        {
            enemyHealth = 100;
            enemyDamage = 10;
            walkingspeed = 70;
        }

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


        protected override void HandleMovement(GameTime gameTime)
        {
            Gravity = true;
            base.HandleMovement(gameTime);
            if (climb == true && goToPlayer == true)
            {
                position.Y += (float)(walkingspeed/2 * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (climb == false && goToPlayer == true)
            {
                position.Y -= (float)(walkingspeed/2 * gameTime.ElapsedGameTime.TotalSeconds);
            }

        }


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