using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Boss : Enemy
    {
        public Boss() : base(5, 5, new Vector2(200, 600), "Boss")
        {
            isFacingRight = false;
            enemyHealth = 2000;
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            HandleMovement(gameTime);
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            Gravity = false;
            /*if (isFacingRight == true)
            {
                position.X += (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            else
	        {
                position.X -= (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }*/
           
        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

        }
    }
}