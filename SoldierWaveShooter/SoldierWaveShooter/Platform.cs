using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoldierWaveShooter
{
    public class Platform : GameObject
    {
        private float destructionDuration = 4.0f;
        private double destructionTime;

        public Platform(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            destructionTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (destructionTime > destructionDuration)
            {
                destructionTime = 0;
               
            }

        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.5f);
        }
    }
}