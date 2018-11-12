using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SoldierWaveShooter
{
    public class Crosshair : GameObject
    {
        public Crosshair() : base("Crosshair")
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            position = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0f);
        }
    }
}
