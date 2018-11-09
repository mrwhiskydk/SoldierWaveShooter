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
        private Weapon[] weapons = { new Standard(), new Sniper(), new Machinegun(), new Shotgun() };      
        private Weapon weapon;
        private Player[] playerAnimations = new Player[6];

        private const float jumpPower = 1000;
        private double jumpForce = jumpPower;
        private bool canJump = false;
        private bool takingDamage = false;

       
        
        private int health;
        public int Health
        {
            get { return health; }
        }

        public Player() : base(4, 10, new Vector2(Gameworld.ScreenSize.Width / 2, 870), "PlayerRunSW")
        {
            weapon = weapons[0];
            health = 100;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleMovement(gameTime);
            WeaponSystem();
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            gravity = true;

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

            jumpForce -= gameTime.ElapsedGameTime.TotalSeconds * 1500;
            if (Keyboard.GetState().IsKeyDown(Keys.W) && isGrounded && canJump)
            {
                position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (Keyboard.GetState().IsKeyUp(Keys.W))
            {
                canJump = false;
            }

        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform)
            {
                isGrounded = true;
                Gravity = false;
                jumpForce = jumpPower;
                canJump = true;
            }

            if (otherObject is Enemy)
            {
                Enemy enemy = (Enemy)otherObject;
                health -= enemy.enemyDamage;
                takingDamage = true;
            }

            //if (otherObject is Melee)
            //{
            //    health -= 5;
            //}

            //if (otherObject is Ranged)
            //{
            //    health -= 1;
            //}

            //if (otherObject is Flying)
            //{
            //    health -= 10;
            //}

            //if (Keyboard.GetState().IsKeyUp(Keys.W))
            //{
            //    canJump = false;
            //}

            //if (otherObject is Boss)
            //{
            //    health -= 25;
            //}
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
