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
        private Weapon[] weapons = { new Standard(), new Sniper() };
        protected Vector2 velocity = new Vector2(0, 0);       
        private Weapon weapon;
        private bool objectPlatform = false;

        private double jumpForce = 1000;

        public Player() : base(8, 10, new Vector2(Gameworld.ScreenSize.Width / 2, 870), "PlayerRun")
        {
            weapon = weapons[0];
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleMovement(gameTime);
            WeaponSystem();
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
            if (Keyboard.GetState().IsKeyDown(Keys.W) && isGrounded && jumpForce > 0)
            {                
                position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
                velocity.Y -= 5;
                jumpForce -= 5;
                isGrounded = false;
                gravity = true;
                if(position.Y > 100)
                {
                    velocity.Y += 5;
                }
            }

            position += direction * (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            position += velocity * (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
            jumpForce -= gameTime.ElapsedGameTime.TotalSeconds / 2;
        }

        private void WeaponSystem()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                weapon = weapons[0];
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                CheckSlot(1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D3))
            {
                CheckSlot(2);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D4))
            {
                CheckSlot(3);
            }
            
            weapon.Position = position;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                weapon.Shoot();
            }


            // Used to check if the pressed key contains a weapon in our inventory "weapons"
            void CheckSlot(int slot)
            {
                if (slot < weapons.Length)
                {
                    if (weapons[slot] != null)
                    {
                        weapon.equipped = false;
                        weapon = weapons[slot];
                        weapon.equipped = true;
                    }
                    
                }
            }
        }
        private void CheckCollision(GameTime gameTime)
        {
            if (isColliding == true && isGrounded == true)
            {
                Gravity = false;
            }
            else
            {
                Gravity = true;
            }
        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform)
            {
                objectPlatform = true;
                isGrounded = true;
            }
            
            
        }


    }
}
