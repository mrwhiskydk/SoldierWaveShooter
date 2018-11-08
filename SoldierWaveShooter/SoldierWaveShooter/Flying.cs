using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Flying : Enemy
    {
        public Flying() : base(5, 12, new Vector2(1600,600), "bat2")
        {
            isFacingRight = true;
            enemyHealth = 100;

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleMovement(gameTime);

            if (enemyHealth == 0)
            {
                Gameworld.RemoveGameObject(this);
            }
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            Gravity = false;
            if (isFacingRight == false)
            {
                position.X += (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            else if (isFacingRight == true)
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