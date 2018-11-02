using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    class Player : Character
    {
        private int test;
        private string text;
        private int testInt;

        public Player(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
        }

        public void Update()
        {

        }
    }
}
