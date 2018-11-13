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
    public class Player : Character
    {        
        private Weapon[] weapons = { new Standard(), new Sniper(), new Machinegun(), new Shotgun() };      
        private Weapon weapon;
        private const float jumpPower = 1000;
        private double jumpForce = jumpPower;
        private bool canJump = false;
        private bool takingDamage = false;
        private float immortalDuration = 1.0f;
        private double immortalTime;
        public bool isImmortal;


        public Player() : base(4, 10, new Vector2(Gameworld.ScreenSize.Width / 2, 870), "PlayerRunSW")
        {
            weapon = weapons[0];

            health = 110;

        }  
        

        public override void Update(GameTime gameTime)
        {
                base.Update(gameTime);               
                HandleMovement(gameTime);

                immortalTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (immortalTime > immortalDuration)
                {
                    isImmortal = false;
                    immortalTime = 0;
                }
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


            if (otherObject is Enemy && !isImmortal)
            {
                Enemy enemy = (Enemy)otherObject;
                health -= enemy.enemyDamage;               
                isImmortal = true;

                if (enemy.enemyHealth > 0)
                {
                    takingDamage = true;
                }
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

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
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
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (isImmortal == true && isFacingRight == false && takingDamage == true)
            {

                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.Red, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.FlipHorizontally, 0f);

            }

            if (isImmortal == true && isFacingRight == true && takingDamage == true)
            {

                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.Red, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0f);

            }

        }
    }
}
