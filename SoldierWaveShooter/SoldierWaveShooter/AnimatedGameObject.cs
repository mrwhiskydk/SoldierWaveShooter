﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    /// <summary>
    /// Class that enables animated sprites through the use of a sprite strip
    /// </summary>
    public class AnimatedGameObject : GameObject
    {
        protected Rectangle[] animationRectangles;
        protected bool isFacingRight;
        protected float animationFPS;
        protected int currentAnimationIndex = 0;
        double timeElapsed = 0;
        protected float walkingspeed = 50;

        public override Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - animationRectangles[0].Width * 0.5), (int)(position.Y - animationRectangles[0].Height * 0.5), animationRectangles[0].Width, animationRectangles[0].Height);
            }
        }

        public AnimatedGameObject(int frameCount, float animationFPS, string spriteName) : this(frameCount, animationFPS, Vector2.Zero, spriteName)
        {

        }

        public AnimatedGameObject(int frameCount, float animationFPS, string spriteName, float walkingspeed) : this(frameCount, animationFPS, Vector2.Zero, spriteName)
        {

        }

        public AnimatedGameObject(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(startPostion, spriteName)
        {
            this.animationFPS = animationFPS;
            animationRectangles = new Rectangle[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                animationRectangles[i] = new Rectangle(i * (sprite.Width / frameCount), 0, (sprite.Width / frameCount), sprite.Height);
            }
            currentAnimationIndex = 0;
        }

        public AnimatedGameObject(int frameCount, float animationFPS, Vector2 startPostion, string spriteName, float walkingspeed) : base(startPostion, spriteName)
        {
            this.animationFPS = animationFPS;
            animationRectangles = new Rectangle[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                animationRectangles[i] = new Rectangle(i * (sprite.Width / 3), 0, (sprite.Width / 3), (sprite.Height / 4));
            }
            currentAnimationIndex = 0;
        }


        /// <summary>
        /// Updates the GameObject's logic and progresses the animation cycle
        /// </summary>
        /// <param name="gameTime">Takes a GameTime the provides the timespan since last call to update </param>
        public override void Update(GameTime gameTime)
        {
            

            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimationIndex = (int)(timeElapsed * animationFPS);

            if (currentAnimationIndex > animationRectangles.Count() - 1)
            {
                currentAnimationIndex = 0;
                timeElapsed = 0;
            }
            base.Update(gameTime);
        }

        public override void DoCollision(GameObject otherObject)
        {

            base.DoCollision(otherObject);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isFacingRight == true)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0f);
            }
            else if(isFacingRight == false)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.FlipHorizontally, 0f);
            }

        }


    }
}