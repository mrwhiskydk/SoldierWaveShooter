using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Ranged : Enemy
    {
        public Ranged() : base(6, 6, new Vector2(50, 870), "Ranged2")
        {
            isFacingRight = true;
            enemyHealth = 100;
            enemyDamage = 10;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

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