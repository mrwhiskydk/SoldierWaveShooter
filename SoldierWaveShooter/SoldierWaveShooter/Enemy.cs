using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Enemy : Character
    {
        protected Vector2 direction = new Vector2(0, 0);
        //protected Enemy[] enemies = {new Melee(), new Ranged()}
        public int enemyHealth;


        public Enemy(int frameCount, float animationFPS, Vector2 startPostion, string spriteName, float walkingspeed) : base(frameCount, animationFPS, startPostion, spriteName, walkingspeed)
        {
        }

        public Enemy(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            if (enemyHealth <= 0)
            {
                Gameworld.RemoveGameObject(this);
            }
        }

        protected override void HandleMovement(GameTime gameTime)
        {

        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform)
            {
                Gravity = false;
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