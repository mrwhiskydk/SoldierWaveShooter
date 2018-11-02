using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    public abstract class Character : GameObject, IPhysics
    {
        protected float movementSpeed;
        protected bool isGrounded;
        protected bool isAlive;
        protected bool isFacingRight;
        protected int health;

        public Character(string spriteName) : base(spriteName)
        {
        }
    }
}