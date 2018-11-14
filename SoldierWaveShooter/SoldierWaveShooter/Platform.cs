using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoldierWaveShooter
{
    /// <summary>
    /// Class that represents a Platform
    /// </summary>
    public class Platform : GameObject
    {

        /// <summary>
        /// Platform Constructor that sets the start position, and name of Platform
        /// </summary>
        /// <param name="startPosition">Default position of current Platform</param>
        /// <param name="spriteName">Name of current Platform</param>
        public Platform(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
        }

        /// <summary>
        /// Enabled the Platform to have game logic defined
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Method that handles Platform collision to collide with other GameObjects
        /// </summary>
        /// <param name="otherObject"></param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
        }

        /// <summary>
        /// Draws the Platform sprite
        /// </summary>
        /// <param name="spriteBatch">The spritebatch that is used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.5f);
        }
    }
}