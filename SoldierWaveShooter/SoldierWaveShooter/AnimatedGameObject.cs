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
        Rectangle[] animationRectangles;

        private float animationFPS;
        private int currentAnimationIndex;
        private double timeElapsed;

        public override Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - animationRectangles[0].Width * 0.5), (int)(position.Y - animationRectangles[0].Height * 0.5), animationRectangles[0].Width, animationRectangles[0].Height);
            }
        }

        public AnimatedGameObject(int frameCount, float animationFPS, ContentManager content, string spriteName) : this(frameCount, animationFPS, Vector2.Zero, content, spriteName)
        {

        }

        public AnimatedGameObject(int frameCount, float animationFPS, Vector2 startPostion, ContentManager content, string spriteName) : base(startPostion, content, spriteName)
        {
            this.animationFPS = animationFPS;
            animationRectangles = new Rectangle[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                animationRectangles[i] = new Rectangle(i * (sprite.Width / frameCount), 0, (sprite.Width / frameCount), sprite.Height);
            }
            currentAnimationIndex = 0;
        }



        /// <summary>
        /// Updates the GameObject's logic and progresses the animation cycle
        /// </summary>
        /// <param name="gameTime">Takes a GameTime the provides the timespan since last call to update </param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimationIndex = (int)(timeElapsed * animationFPS);

            if (currentAnimationIndex > animationRectangles.Count() - 1)
            {
                currentAnimationIndex = 0;
                timeElapsed = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, new SpriteEffects(), 0f);
        }


    }
}