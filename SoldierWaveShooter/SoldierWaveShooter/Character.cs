using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public abstract class Character : AnimatedGameObject, IPhysics
    {
        protected float movementSpeed;
        protected bool isGrounded;
        protected bool isAlive;
        protected bool isFacingRight;
        protected Vector2 direction = new Vector2(0, 0);
        protected int health;

        public Character(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
        }


        public override void Update(GameTime gameTime)
        {
            HandleMovement(gameTime);

            base.Update(gameTime);
        }


        protected virtual void HandleMovement(GameTime gameTime)
        {
            if(isGrounded && isFacingRight)
            {

            }


            position += direction * (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
        }


    }
}