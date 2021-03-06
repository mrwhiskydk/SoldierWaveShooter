﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpeedoAlienPrisonShootout
{
    /// <summary>
    /// Abstract Super-class that represents common methods, fields and properties between the player and enemy objects
    /// </summary>
    public abstract class Character : AnimatedGameObject
    {
        /// <summary>
        /// Field that sets movementspeed of player and enemy GameObjects
        /// </summary>
        protected float movementSpeed;       
        
        /// <summary>
        /// Field used for player and enemy health
        /// </summary>
        protected int health;
        protected int maxHealth;

        /// <summary>
        /// Property that returns the health value
        /// </summary>
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value >= maxHealth)
                {
                    health = maxHealth;
                }
                else
                {
                    health = value;
                }
            }
        }

        /// <summary>
        /// Character constructor that enables gravity as default
        /// </summary>
        /// <param name="frameCount">Counts each frame of the current GameObject</param>
        /// <param name="animationFPS">Sets how fast each frame is counted in the current GameObject</param>
        /// <param name="startPostion">Default position of the current GameObject</param>
        /// <param name="spriteName">sprite name of the current GameObject</param>
        public Character(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
            gravity = true;
            
            
        }


        /// <summary>
        /// Update method that makes sure gravity stays true, should it be enabled
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            gravity = true;
        }

        /// <summary>
        /// Draw method that prints sprites to the screen
        /// </summary>
        /// <param name="spriteBatch">The spritebatch that is used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch); 
        }

        /// <summary>
        /// Abstract method for player and enemy movement
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        protected abstract void HandleMovement(GameTime gameTime);


    }
}