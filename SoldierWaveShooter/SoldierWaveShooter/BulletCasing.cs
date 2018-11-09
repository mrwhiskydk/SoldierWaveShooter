using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoldierWaveShooter
{
    class BulletCasing : GameObject
    {
        private bool hitTheGround = false;
        private double jumpForce = 300;
        private double timeAlive;
        private Vector2 direction;
        private Random rnd = new Random();

        public BulletCasing(Vector2 startPosition, Vector2 direction) : base(startPosition, "BulletCasing")
        {
            this.direction = direction;
            rotation = rnd.Next(0, 360);
        }

        public override void Update(GameTime gameTime)
        {
            timeAlive += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeAlive > 3)
            {
                Gameworld.RemoveGameObject(this);
            }

            if (!hitTheGround)
            {
                rotation += (float)gameTime.ElapsedGameTime.TotalSeconds * 10;

                jumpForce -= gameTime.ElapsedGameTime.TotalSeconds * 1000;
                position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
                position.X += MathHelper.ToRadians(direction.X);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0f);
        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform)
            {
                hitTheGround = true;
            }
        }
    }
}
