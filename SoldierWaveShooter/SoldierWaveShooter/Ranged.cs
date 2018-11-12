using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Ranged : Enemy
    {
        public Ranged() : base(4, 4, new Vector2(50, 870), "Ranged")
        {
            isFacingRight = true;
            enemyHealth = 100;
            enemyDamage = 10;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Gameworld.player.Position.X <= position.X)
            {
                isFacingRight = false;
            }
            else if (Gameworld.player.Position.X == position.X)
            {
                isFacingRight = true;
            }
            else
            {
                isFacingRight = true;
            }
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            base.HandleMovement(gameTime);

        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

        }
    }
}