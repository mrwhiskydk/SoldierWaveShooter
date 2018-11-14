using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoldierWaveShooter
{
    public class Boss : Enemy
    {
        private bool goDown = false;
        private double lastShot;
        private double attackCooldown = 1;
        private float spread = 1000;
        private int projectileSpeed = 350;
        private int bulletAmount = 12;
        private int projectileDamage = 5;
        private Random rnd = new Random();

        public Boss() : base(5, 5, new Vector2(Gameworld.ScreenSize.Width / 2, 150), "Boss")
        {
            isFacingRight = false;
            enemyHealth = 20;
            enemyDamage = 25;
            movementSpeed = 5;
        }

        public override void Update(GameTime gameTime)
        {

            if (Gameworld.isAlive)
            {
                base.Update(gameTime);
                HandleMovement(gameTime);

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

                //shooting
                lastShot += gameTime.ElapsedGameTime.TotalSeconds;
                if (lastShot >= attackCooldown)
                {
                    for (int i = 0; i < bulletAmount; i++)
                    {
                        //get the direction to shoot
                        Vector2 direction = Gameworld.player.Position - position;
                        direction.Normalize();
                        //Send the bullet in a random direction depending on weapon spread
                        float rndSpread = (float)rnd.Next(-(int)spread, (int)spread) / 1000;
                        float rndSpread2 = (float)rnd.Next(-(int)spread, (int)spread) / 1000;

                        new Projectile(position, "Bullet", new Vector2(direction.X + rndSpread, direction.Y + rndSpread2), projectileDamage, projectileSpeed, "enemy");
                    }

                    //Spawn a bullet casing flying in a semi random upwards direction
                    new BulletCasing(position);

                    lastShot = 0;
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isFacingRight == true)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0.91f);
            }
            else if (isFacingRight == false)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.FlipHorizontally, 0.91f);
            }
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }
}