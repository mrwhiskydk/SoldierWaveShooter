using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoldierWaveShooter
{
    public abstract class PowerUp : GameObject
    {
        public PowerUp(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
            gravity = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0f, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.911f);
        }
    }
}