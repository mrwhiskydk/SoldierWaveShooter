﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpeedoAlienPrisonShootout
{
    public class Projectile : GameObject
    {
        private Vector2 direction;
        public int damage;
        private int speed;
        public string team;

        public Projectile(Vector2 startPosition, string spriteName, Vector2 direction, int damage, int speed, string team) : base(startPosition, spriteName)
        {
            this.direction = direction;
            this.damage = damage;
            this.speed = speed;
            this.team = team;

            if (direction != Vector2.Zero)
            {
                this.direction.Normalize();
                rotation = (float)Math.Atan2(direction.Y, direction.X);
            }
        }

        public override void Update(GameTime gameTime)
        {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!Gameworld.ScreenSize.Intersects(CollisionBox))
            {
                Gameworld.RemoveGameObject(this);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.86f);
        }
    }
}