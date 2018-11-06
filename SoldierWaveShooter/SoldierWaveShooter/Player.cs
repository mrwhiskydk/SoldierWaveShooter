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
        protected Vector2 velocity = new Vector2(0, 0);
        private Weapon[] weapons = { new Standard() };
        private Weapon weapon;

        private double jumpForce = 100;

        public Player() : base(8, 10, new Vector2(Gameworld.ScreenSize.Width / 2, Gameworld.ScreenSize.Height / 2), "PlayerRun")
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

            jumpForce -= gameTime.ElapsedGameTime.TotalSeconds / 2;
            if (Keyboard.GetState().IsKeyDown(Keys.W) && isGrounded && jumpForce > 0)
            {                
                position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
                velocity.Y -= 5;
                jumpForce -= 5;
                isGrounded = false;
                gravity = true;
            }

            position += direction * (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            position += velocity * (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform && !isGrounded)
            {
                isGrounded = true;
                gravity = false;

                jumpForce = 100;
            }
            
            
        }


    }
}
