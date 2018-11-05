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

        public Player(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(8, 10, new Vector2(Gameworld.ScreenSize.Width / 2, Gameworld.ScreenSize.Height / 2), spriteName)
        {
        }

        public void Update()
        {

        }
    }
}
