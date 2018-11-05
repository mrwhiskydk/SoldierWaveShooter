using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    public class PowerUp : GameObject
    {
        public PowerUp(string spriteName) : base(spriteName)
        {
            gravity = true;
        }
    }
}