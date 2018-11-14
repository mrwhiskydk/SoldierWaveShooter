using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Boss : Enemy
    {
        public Boss() : base(5, 5, new Vector2(Gameworld.ScreenSize.Width / 2, 150), "Boss")
        {
            isFacingRight = false;
            enemyHealth = 2000;
            enemyDamage = 25;
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            HandleMovement(gameTime);
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            Gravity = false;
           
        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

        }
    }
}