using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public abstract class Character : AnimatedGameObject
    {
        protected float movementSpeed;
        protected bool isGrounded;
        protected bool isAlive;
        protected bool isFacingRight;
        protected int health;

        public Character(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
            gravity = true;
        }

        
    }
}