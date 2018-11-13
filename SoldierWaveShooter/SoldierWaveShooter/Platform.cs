using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SoldierWaveShooter
{
    public class Platform : GameObject
    {
        private float destructionDuration = 4.0f;
        private double destructionTime;

        public Platform(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            destructionTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (destructionTime > destructionDuration)
            {
                destructionTime = 0;
               
            }

        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
        }
    }
}