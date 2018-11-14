using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Ranged : Enemy
    {
        public Ranged() : base(4, 4, new Vector2(120, 200), "Ranged")
        {
            enemyHealth = 100;
            enemyDamage = 10;
            movementSpeed = 20;
        }

        public override void Update(GameTime gameTime)
        {
            if (Gameworld.isAlive)
            {
                if (Gameworld.player.Position.X <= position.X)
                {
                    isFacingRight = false;
                }
                else
                {
                    isFacingRight = true;
                }
            }
            else
            {
                Gameworld.RemoveGameObject(this);
            }
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