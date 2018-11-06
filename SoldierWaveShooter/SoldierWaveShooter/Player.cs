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
        protected Vector2 direction = new Vector2(0, 0);
        private Weapon[] weapons = { new Standard() };
        private Weapon weapon;

        
        public Player() : base(8, 10, new Vector2(Gameworld.ScreenSize.Width / 2, 860), "Player")
        {
            weapon = weapons[0];
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            HandleMovement(gameTime);
            weapon.Position = position;


        }

        protected override void HandleMovement(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                isFacingRight = false;
                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                isFacingRight = true;
                position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && isGrounded == true)
            {
                position.Y -= (float)(10000 * gameTime.ElapsedGameTime.TotalSeconds);
                isGrounded = false;
                gravity = true;
            }
            else
            {

            }

            position += direction * (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform && !isGrounded)
            {
                isGrounded = true;
                gravity = false;
            }
        }

    }
}
