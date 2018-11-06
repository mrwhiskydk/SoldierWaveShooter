using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Enemy : Character
    {
        protected Vector2 direction = new Vector2(0, 0);

        public Enemy(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
        }

        public override void Update(GameTime gameTime)
        {

        }

        //protected override void HandleMovement(GameTime gameTime)
        //{

        //}
    }
}