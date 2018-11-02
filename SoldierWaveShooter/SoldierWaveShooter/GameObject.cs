using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldierWaveShooter
{
    public class GameObject
    {
        protected Texture2D sprite;
        protected float rotation;

        public Vector2 position;

        /// <summary>
        /// Property that gets the position of GameObject
        /// </summary>
        public Vector2 Position { get; set; }








        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime)
        {

        }


    }
}
