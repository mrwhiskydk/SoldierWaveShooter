using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpeedoAlienPrisonShootout
{
    class PowerUpMedkit : PowerUp
    {
        private int healthBoost = 25;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        public PowerUpMedkit(Vector2 startPosition) : base(startPosition, "Medkit")
        {

        }

        public override void DoCollision(GameObject otherObject)
        {
            //if we collide with a player then give him health
            if (otherObject is Player)
            {
                Player player = (Player)otherObject;
                player.Health += healthBoost;
                Destroy();
            }
            base.DoCollision(otherObject);
        }
    }
}
