﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public abstract class Character : AnimatedGameObject
    {
        protected float movementSpeed = 300;
        protected bool isGrounded;
        protected bool isAlive;
        protected bool canJump;
        
        protected int health;

        public Character(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
            gravity = true;

        }

        public Character(int frameCount, float animationFPS, Vector2 startPostion, string spriteName, float walkingspeed) : base(frameCount, animationFPS, startPostion, spriteName, walkingspeed)
        {
            gravity = true;

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            gravity = true;
        }


        protected abstract void HandleMovement(GameTime gameTime);


    }
}