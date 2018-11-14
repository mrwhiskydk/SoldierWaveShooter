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
    /// <summary>
    /// Class that represents the Player
    /// </summary>
    public class Player : Character
    {        
        private Weapon[] weapons = { new Standard(), new Machinegun(), new Shotgun(), new Sniper() };      
        public Weapon weapon;
        public int fireRateMultiplier = 1;
        public double fireRateMultiplierTimer;
        private Player[] playerAnimations = new Player[6];

        private const float jumpPower = 1000;
        private double jumpForce = jumpPower;
        private bool canJump = false;
        private bool takingDamage = false;
        private float immortalDuration = 1.0f;
        private double immortalTime;
        /// <summary>
        /// Sets player immunity on and off
        /// </summary>
        public bool isImmortal;

        /// <summary>
        /// Player constructor that sets player animation values, position and sprite name
        /// </summary>
        public Player() : base(4, 10, new Vector2(Gameworld.ScreenSize.Width / 2, 500), "PlayerRunSW")
        {
            weapon = weapons[0];

            maxHealth = 110;   //Maximum amount of player health.
            health = maxHealth;

            movementSpeed = 300;
        }  
        
        /// <summary>
        /// Update method that enables player movement, reload and change weapons. Makes the player immortal for a short time, if damage is taken
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);               
            HandleMovement(gameTime);

            immortalTime += gameTime.ElapsedGameTime.TotalSeconds;  //Adding +1 second to immortalTime, until it reaches 3 seconds
            if (immortalTime > immortalDuration)
            {
                isImmortal = false;
                immortalTime = 0;   //Upon reaching 3 seconds, immortalTime is reset to 0
            }
            WeaponSystem();

            fireRateMultiplierTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (fireRateMultiplierTimer >= 5)
            {
                fireRateMultiplier = 1;
            }
        }

        /// <summary>
        /// Method that sets the player movement on both the X and Y axis, and reload functionality
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
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
            if (Keyboard.GetState().IsKeyDown(Keys.W) && canJump)
            {
                position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (Keyboard.GetState().IsKeyUp(Keys.W))
            {
                canJump = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                weapon.Reload();
            }
        }

        /// <summary>
        /// Method used to remove both player and weapon objects from the game
        /// </summary>
        public override void Destroy()
        {
            foreach(Weapon weapon in weapons)
            {
                weapon.Destroy();
            }
            base.Destroy();           
        }

        /// <summary>
        /// Method that handles player collision with other GameObjects. Used to handle damage taken from Enemy collision
        /// </summary>
        /// <param name="otherObject">The GameObject that the player object collides with</param>
        public override void DoCollision(GameObject otherObject)
        {

            if (otherObject is Platform)
            {              
                Gravity = false;
                jumpForce = jumpPower;
                canJump = true;
            }

            else if (otherObject is Enemy && !isImmortal)
            {
                Enemy enemy = (Enemy)otherObject;
                
                if (enemy.enemyHealth > 0)
                {
                    takingDamage = true;
                    health -= enemy.enemyDamage;
                    isImmortal = true;
                }
            }

            else if (otherObject is Projectile && !isImmortal)
            {
                Projectile bullet = (Projectile)otherObject;
                if (bullet.team == "enemy")
                {
                    health -= bullet.damage;
                    bullet.Destroy();
                    isImmortal = true;
                    takingDamage = true;
                }
            }

            else if (otherObject is Weapon)
            {
                Weapon obj = (Weapon)otherObject;
                if (obj.isAmmo)
                {
                    foreach (Weapon weap in weapons)
                    {
                        if (obj.GetType() == weap.GetType())
                        {
                            weap.ammo += weap.magazineCapacity;
                            obj.Destroy();
                            break;
                        }
                    }
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

        /// <summary>
        /// Draws the player sprite in a red color while immortal, to indicate player immunity, while allowing the sprite to flip horizontally
        /// </summary>
        /// <param name="spriteBatch">The spritebatch that is used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (isImmortal == true && isFacingRight == false && takingDamage == true)
            {

                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.Red, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.FlipHorizontally, 0.95f);

            }

            if (isImmortal == true && isFacingRight == true && takingDamage == true)
            {

                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.Red, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0.95f);

            }

        }
    }
}
