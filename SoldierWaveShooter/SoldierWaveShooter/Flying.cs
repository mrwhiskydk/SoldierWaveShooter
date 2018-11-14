using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Flying : Enemy
    {
        private bool goDown = false;

        public Flying() : base(3, 9, new Vector2(1850,50), "FlyingGreen")
        {
            isFacingRight = true;
            enemyHealth = 50;
            enemyDamage = 5;
            movementSpeed = 30;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleMovement(gameTime);

            if (enemyHealth <= 0)
	        {
                Gravity = true;
                enemyDamage = 0;
	        }

            if (!Gameworld.ScreenSize.Intersects(CollisionBox) && enemyHealth <= 0)
            {
                Gameworld.RemoveGameObject(this);
            }

            if (Gameworld.player.Position.Y >= position.Y)
            {
                goDown = true;            
            }
            else
            {
                goDown = false;
            }
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            Gravity = false;
            base.HandleMovement(gameTime);

            if (goDown == true && goToPlayer == true)
            {
                position.Y += (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (goDown == false && goToPlayer == true)
            {
                position.Y -= (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Player && enemyHealth > 0)
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