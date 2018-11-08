using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoldierWaveShooter
{
    public class Projectile : GameObject
    {
        private Vector2 direction;
        public int damage;
        private int speed;

        public Projectile(Vector2 startPosition, string spriteName, Vector2 direction, int damage, int speed) : base(startPosition, spriteName)
        {
            this.direction = direction;
            this.damage = damage;
            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            position += new Vector2(direction.X + speed, direction.Y);

            if (!Gameworld.ScreenSize.Intersects(CollisionBox))
            {
                Gameworld.RemoveGameObject(this);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
            if (!Gameworld.ScreenSize.Intersects(CollisionBox))
            {
                Gameworld.RemoveGameObject(this);
            }
        }

        //public override void DoCollision(GameObject otherObject)
        //{
        //    if (otherObject is Enemy)
        //    {
        //        Enemy enemy = (Enemy)otherObject;
        //        enemy.enemyHealth -= damage;
        //        Console.WriteLine($"{enemy.enemyHealth}");
        //    }
        //}

    }
}