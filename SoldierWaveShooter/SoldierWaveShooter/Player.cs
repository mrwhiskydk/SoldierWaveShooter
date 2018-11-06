﻿using System;
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
        private Weapon weapon;

        public Player() : base(8, 10, new Vector2(Gameworld.ScreenSize.Width / 2, Gameworld.ScreenSize.Height / 2), "PlayerRun")
        {
            weapon = weapons[0];
        }

        public override void Update(GameTime gameTime)
        {
            HandleMovement(gameTime);
            WeaponSystem();
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {

                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);               

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && isGrounded == true)
            {
                position.Y -= (float)(10000 * gameTime.ElapsedGameTime.TotalSeconds);
                Gravity = true;
                isGrounded = false;
            }

            position += direction * (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
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

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform)
            {
                Gravity = false;
                isGrounded = true;
            }
        }
    }
}
