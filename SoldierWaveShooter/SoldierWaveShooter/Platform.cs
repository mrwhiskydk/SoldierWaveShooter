﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Platform : GameObject
    {
        public Platform(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
        }
    }
}