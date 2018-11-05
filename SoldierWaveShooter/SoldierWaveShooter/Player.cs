using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SoldierWaveShooter
{
    class Player : Character
    {
        private int test;
        private string text;
        private int testInt;

        public Player(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(8, 10, new Vector2(Gameworld.ScreenSize.Width / 2, Gameworld.ScreenSize.Height / 2), spriteName)
        {
        }

        public override void Update(GameTime gameTime)
        {
            HandleMovement(gameTime);
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
              
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }


            position += direction * (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
        }
        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform)
            {

            }
        }
    }
}
