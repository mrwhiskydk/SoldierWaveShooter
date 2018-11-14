using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SpeedoAlienPrisonShootout
{
    class PowerUp2x : PowerUp
    {
        public PowerUp2x(Vector2 startPosition) : base(startPosition, "2x")
        {

        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Player)
            {
                Console.WriteLine(Gameworld.player.Health);
                Player player = (Player)otherObject;
                player.fireRateMultiplier = 2;
                player.fireRateMultiplierTimer = 0;
                Destroy();

                Console.WriteLine("After collision " + Gameworld.player.Health);
            }
            base.DoCollision(otherObject);
        }
    }
}
