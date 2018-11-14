using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoldierWaveShooter
{
    public class Enemy : Character
    {
        public int enemyHealth;
        public int enemyDamage;
        protected bool goToPlayer = false;
        protected bool goLeft = false;
        private Random rnd = new Random();


        public Enemy(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (Gameworld.player.Position.X != position.X && enemyHealth > 0)
            {
                goToPlayer = true;
            }
            else
            {
                goToPlayer = false;
            }

            if (Gameworld.player.Position.X <= position.X)
            {
                goLeft = true;
            }
            else
            {
                goLeft = false;
            }

            base.Update(gameTime);
            HandleMovement(gameTime);
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            if (goToPlayer == true && goLeft == true)
            {
                position.X -= (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (goToPlayer == true && goLeft == false)
            {
                position.X += (float)(walkingspeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform)
            {
                Gravity = false;
            }

            else if (otherObject is Projectile)
            {
                Projectile bullet = (Projectile)otherObject;
                if (bullet.team == "player")
                {
                    enemyHealth -= bullet.damage;
                    bullet.Destroy();
                    
                    //if we have 0 or less health then we die
                    if (enemyHealth <= 0)
                    {
                        Destroy();
                    }
                }
            }
        }

        public override void Destroy()
        {
            int random = rnd.Next(0, 10);
            if (random == 7 || random == 8)
            {
                random = rnd.Next(0, 3);
                switch (random)
                {
                    case 0:
                        new Machinegun(position, true);
                        break;
                    case 1:
                        new Shotgun(position, true);
                        break;
                    case 2:
                        new Sniper(position, true);
                        break;
                    default:
                        break;
                }
            }
            else if(random == 9)
            {
                random = rnd.Next(0, 2);
                if (random == 0)
                {
                    new PowerUp2x(position);
                }
                else
                {
                    new PowerUpMedkit(position);
                }
            }
            base.Destroy();
        }
    }
}