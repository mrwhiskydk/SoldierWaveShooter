using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldierWaveShooter
{
    /// <summary>
    /// Super-class that represents a GameObject
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// used to set the loaded texture of current GameObject
        /// </summary>
        protected Texture2D sprite;

        /// <summary>
        /// 
        /// </summary>
        protected float rotation;

        /// <summary>
        /// used to set position of current GameOject
        /// </summary>
        protected Vector2 position;

        /// <summary>
        /// Sets the default gravity as disabled, for current GameObject
        /// </summary>
        protected bool gravity = false;       

        /// <summary>
        /// Property for the position of current GameObject
        /// </summary>
        public Vector2 Position { get => position; set => position = value; }

        /// <summary>
        /// Property for the gravity of current GameObject
        /// </summary>
        public bool Gravity { get => gravity; set => gravity = value; }

        /// <summary>
        /// The Collision Box of the GameObject. The default box is based upon the GameObject position and sprite size
        /// </summary>
        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - sprite.Width * 0.5), (int)(position.Y - sprite.Height * 0.5), sprite.Width, sprite.Height);
            }
        }

        /// <summary>
        /// Checks if the current object collides with another object
        /// </summary>
        /// <param name="otherObject">The other GameObject that should be tested against</param>
        /// <returns>Returns true if current object collides with otherObject otherwise false</returns>
        public virtual bool IsColliding(GameObject otherObject)
        {
            return CollisionBox.Intersects(otherObject.CollisionBox);
        }

        /// <summary>
        /// Enabled the GameObject to handle collisions in a custom way
        /// </summary>
        /// <param name="otherObject">The GameObject that the current GameObject collides with</param>
        public virtual void DoCollision(GameObject otherObject)
        {

        }

        /// <summary>
        /// The default constructor for a GameObject
        /// </summary>
        /// <param name="spriteName">The name of the texture resource the should be used for the sprite</param>
        public GameObject(string spriteName) : this(Vector2.Zero, spriteName)
        {
            
        }

        /// <summary>
        /// Constructor the sets the staring position of the GameObject
        /// </summary>
        /// <param name="startPosition">Default position of the current GameObject</param>
        /// <param name="spriteName">The name of the texture resource the should be used for the sprite</param>
        public GameObject(Vector2 startPosition, string spriteName)
        {
            position = startPosition;
            sprite = Gameworld.ContentManager.Load<Texture2D>(spriteName);
            Gameworld.AddGameObject(this);
        }

        /// <summary>
        /// Method used to remove current GameObject from the game
        /// </summary>
        public virtual void Destroy()
        {
            Gameworld.RemoveGameObject(this);
        }

        /// <summary>
        /// Enabled the GameObject to have game logic defined
        /// </summary>
        /// <param name="gameTime">The elasped time since last update call</param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Enables the GameObject to be drawn. The std. functionality is to draw its sprite.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to use for drawing</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0f);
        }


    }
}
