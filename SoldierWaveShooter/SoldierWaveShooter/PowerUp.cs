using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class PowerUp : GameObject
    {
        public PowerUp(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
            gravity = true;
        }
    }
}