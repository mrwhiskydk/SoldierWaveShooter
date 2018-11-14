using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoldierWaveShooter
{
    class PowerUpMedkit : PowerUp
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        public PowerUpMedkit(Vector2 startPosition) : base(startPosition, "Medkit")
        {

        }

        /// <summary>
        /// Override Draw to set layer depth
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.911f);
        }
    }
}
