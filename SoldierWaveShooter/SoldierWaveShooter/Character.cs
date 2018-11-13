using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoldierWaveShooter
{
    public abstract class Character : AnimatedGameObject
    {
        protected float movementSpeed = 300;
        protected bool isGrounded;
        protected bool isAlive;
        protected int health;

        public int Health
        {
            get
            {
                return health;
            }

        }

        public Character(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
            gravity = true;
            isAlive = true;
            
        }

        public Character(int frameCount, float animationFPS, Vector2 startPostion, string spriteName, float walkingspeed) : base(frameCount, animationFPS, startPostion, spriteName, walkingspeed)
        {
            gravity = true;
            isAlive = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            gravity = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch); 
        }

        protected abstract void HandleMovement(GameTime gameTime);


    }
}