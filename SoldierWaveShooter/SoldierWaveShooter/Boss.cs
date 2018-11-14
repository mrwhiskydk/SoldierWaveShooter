using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Boss : Enemy
    {
        private bool goDown = false;

        public Boss() : base(5, 5, new Vector2(Gameworld.ScreenSize.Width / 2, 150), "Boss")
        {
            enemyHealth = 2000;
            enemyDamage = 25;
            movementSpeed = 7;
        }

        public override void Update(GameTime gameTime)
        {

            if (Gameworld.isAlive)
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

                if (Gameworld.player.Position.X <= position.X)
                {
                    isFacingRight = true;
                }
                else
                {
                    isFacingRight = false;
                }
            }
            else
            {
                Gameworld.RemoveGameObject(this);
            }
            
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            base.HandleMovement(gameTime);
            Gravity = false;
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
            base.DoCollision(otherObject);

        }
        
    }
}