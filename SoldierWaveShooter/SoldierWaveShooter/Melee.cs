using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Melee : Enemy
    {
        private const float jumpPower = 1000;
        private double jumpForce = jumpPower;
        private bool climb = false;


        public Melee() : base(3, 12, new Vector2(1600, 870), "Melee2")
        {
            enemyHealth = 100;
            enemyDamage = 10;
        }

        public override void Update(GameTime gameTime)
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

            jumpForce -= gameTime.ElapsedGameTime.TotalSeconds * 1500;
            if (climb == true)
            {
                position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
 
            }

        }

        protected override void HandleMovement(GameTime gameTime)
        {
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