using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Flying : Enemy
    {
        public Flying() : base(3, 9, new Vector2(1600,600), "FlyingGreen")
        {
            isFacingRight = true;
            enemyHealth = 100;
            enemyDamage = 5;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleMovement(gameTime);

            if (enemyHealth <= 0)
	        {
                Gravity = true;
                
	        }

            if (!Gameworld.ScreenSize.Intersects(CollisionBox))
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
            if (otherObject is Player)
            {
                enemyHealth -= enemyHealth;
            }

            if (otherObject is Projectile)
            {
                Projectile bullet = (Projectile)otherObject;
                enemyHealth -= bullet.damage;
            }

            if (otherObject is Projectile)
            {
                Gameworld.RemoveGameObject(otherObject);
            }


             
        }
    }
}