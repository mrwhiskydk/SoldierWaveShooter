using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedoAlienPrisonShootout
{
    /// <summary>
    /// Class that enables animated sprites through the use of a sprite strip
    /// </summary>
    public class AnimatedGameObject : GameObject
    {
        /// <summary>
        /// Array that sets, draws and creates rectangle form of CollisionBox, and the GameObject itself
        /// </summary>
        protected Rectangle[] animationRectangles;

        /// <summary>
        /// Bool that checks for the current GameObjects direction on the X axis 
        /// </summary>
        public bool isFacingRight;

        /// <summary>
        /// Sets how fast each frame is counted
        /// </summary>
        protected float animationFPS;

        /// <summary>
        /// Counts frames, based on the FPS speed
        /// </summary>
        protected int currentAnimationIndex = 0;

        double timeElapsed = 0;

        /// <summary>
        /// ???
        /// </summary>
        protected float walkingspeed = 50;

        /// <summary>
        /// The Collision Box of the animated GameObject. The default box is based upon the GameObject position and sprite size
        /// </summary>
        public override Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - animationRectangles[0].Width * 0.5), (int)(position.Y - animationRectangles[0].Height * 0.5), animationRectangles[0].Width, animationRectangles[0].Height);
            }
        }

        /// <summary>
        /// Default constructor of the AnimatedGameObject
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="spriteName"></param>
        public AnimatedGameObject(int frameCount, float animationFPS, string spriteName) : this(frameCount, animationFPS, Vector2.Zero, spriteName)
        {

        }

        /// <summary>
        /// AnimatedGameObject constructor that sets the default animation of current GameObject
        /// </summary>
        /// <param name="frameCount">Counts each frame in the animationRectangles array</param>
        /// <param name="animationFPS">Sets how fast each frame is counted in the current GameObject</param>
        /// <param name="startPostion">default position of the current animatiod GameObject</param>
        /// <param name="spriteName">sprite name of the current GameObject</param>
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

        /// <summary>
        /// Collision method that enables GameObject to handle collision in a custom way
        /// </summary>
        /// <param name="otherObject">The GameObject that the current GameObject collides with</param>
        public override void DoCollision(GameObject otherObject)
        {

            base.DoCollision(otherObject);
        }

        /// <summary>
        /// Enables the animation of the current GameObject to be drawn, based on the current direction of the GameObject
        /// </summary>
        /// <param name="spriteBatch">The spritebatch that is used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isFacingRight == true)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0.9f);
            }
            else if(isFacingRight == false)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.FlipHorizontally, 0.9f);
            }

        }


    }
}