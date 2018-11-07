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
        private Weapon[] weapons = { new Standard(), new Sniper(), new Machinegun() };
        //protected Vector2 velocity = new Vector2(0, 0);       
        private Weapon weapon;

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
            Gravity = true;
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

            jumpForce -= gameTime.ElapsedGameTime.TotalSeconds * 750;
            if (Keyboard.GetState().IsKeyDown(Keys.W) && isGrounded && jumpForce > 0)
            {                
                position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
 
                isGrounded = false;
            }

            position += direction * (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            //position += velocity * (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
            //velocity += gravityScale * (float)(gameTime.ElapsedGameTime.TotalSeconds);
            
        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform)
            {
                isGrounded = true;
                Gravity = false;
            }

        }

        private void WeaponSystem()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                CheckSlot(0);
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

            //Used to check if the pressed key contains a weapon in our inventory "weapons"
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




    }
}
