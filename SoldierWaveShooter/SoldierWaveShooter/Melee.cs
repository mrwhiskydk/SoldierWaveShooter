using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Melee : Enemy
    {
        
        public Melee() : base(3, 12, new Vector2(1600, 870), "p2_walk2", 50)
        {
            enemyHealth = 100;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleMovement(gameTime);
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            if (isFacingRight == true)
            {
                position.X += (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            else
	        {
                position.X -= (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
           
        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

        }
    }
}