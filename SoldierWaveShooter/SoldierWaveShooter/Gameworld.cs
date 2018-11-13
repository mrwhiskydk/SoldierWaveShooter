using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SoldierWaveShooter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Gameworld : Game
    {
        static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont font;
        private Texture2D bar;
        private Texture2D barMid;
        private Texture2D barTop;
        public List<GameObject> gameObjects = new List<GameObject>();
        private static List<GameObject> toBeAdded = new List<GameObject>();
        private static List<GameObject> toBeRemoved = new List<GameObject>();
        public static Player player;
        private Enemy enemyMelee;
        private Enemy enemyRanged;
        private Enemy enemyFlying;
        private Enemy boss;
        private Platform platform;
        private UI ui;
        private Texture2D collisionTexture;
        public static Crosshair mouse;
        private float gravityStrength = 5f;
        private float respawnDuration = 3.0f;   //Field used for player respawn in update
        private double respawnTime; //Field used for player respawn in update

        private Vector2 barPosition;
        private Rectangle barPos;


        public static Rectangle ScreenSize
        {
            get
            {
                return graphics.GraphicsDevice.Viewport.Bounds;
            }
        }

        private static ContentManager _content;
        public static ContentManager ContentManager
        {
            get
            {
                return _content;
            }
        }

        public Gameworld()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1020;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            _content = Content;
        }

        public static void AddGameObject(GameObject go)
        {
            toBeAdded.Add(go);
        }

        public static void RemoveGameObject(GameObject go)
        {
            toBeRemoved.Add(go);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("ExampleFont");
            bar = Content.Load<Texture2D>("barBaseSW");
            barMid = Content.Load<Texture2D>("barMidLayer");
            barTop = Content.Load<Texture2D>("barTopLayer");
            collisionTexture = Content.Load<Texture2D>("CollisionTexture");
            mouse = new Crosshair();

            // Castle platforme
            for (int i = 0; i < 28; i++)
            {
                new Platform(new Vector2((i*70) + 35, 1016), "castle");
            }
            platform = new Platform(new Vector2(120, 760), "castleHalf");
            platform = new Platform(new Vector2(260, 890), "castleHalf");
            platform = new Platform(new Vector2(400, 760), "castleHalf");
            platform = new Platform(new Vector2(540, 890), "castleHalf");
            platform = new Platform(new Vector2(680, 760), "castleHalf");
            platform = new Platform(new Vector2(820, 890), "castleHalf");
            platform = new Platform(new Vector2(Gameworld.ScreenSize.Width/2, 760), "castleHalf");
            platform = new Platform(new Vector2(1080, 890), "castleHalf");
            platform = new Platform(new Vector2(1220, 760), "castleHalf");
            platform = new Platform(new Vector2(1360, 890), "castleHalf");
            platform = new Platform(new Vector2(1500, 760), "castleHalf");
            platform = new Platform(new Vector2(1640, 890), "castleHalf");
            platform = new Platform(new Vector2(1780, 760), "castleHalf");
            platform = new Platform(new Vector2(120, 280), "castleHalf");
            platform = new Platform(new Vector2(190, 280), "castleHalf");
            platform = new Platform(new Vector2(330, 380), "castleHalf");
            platform = new Platform(new Vector2(400, 380), "castleHalf");
            platform = new Platform(new Vector2(540, 480), "castleHalf");
            platform = new Platform(new Vector2(610, 480), "castleHalf");
            platform = new Platform(new Vector2(750, 580), "castleHalf");
            platform = new Platform(new Vector2(820, 580), "castleHalf");
            platform = new Platform(new Vector2(1080, 580), "castleHalf");
            platform = new Platform(new Vector2(1150, 580), "castleHalf");
            platform = new Platform(new Vector2(1290, 480), "castleHalf");
            platform = new Platform(new Vector2(1360, 480), "castleHalf");
            platform = new Platform(new Vector2(1500, 380), "castleHalf");
            platform = new Platform(new Vector2(1570, 380), "castleHalf");
            platform = new Platform(new Vector2(1710, 280), "castleHalf");
            platform = new Platform(new Vector2(1780, 280), "castleHalf");
            platform = new Platform(new Vector2(910, 350), "castleHalf");
            platform = new Platform(new Vector2(980, 350), "castleHalf");


            // Kæder
            platform = new Platform(new Vector2(120, 540), "chain");
            platform = new Platform(new Vector2(120, 470), "chain");
            platform = new Platform(new Vector2(120, 400), "chain");
            platform = new Platform(new Vector2(120, 330), "chain");

            platform = new Platform(new Vector2(1780, 540), "chain");
            platform = new Platform(new Vector2(1780, 470), "chain");
            platform = new Platform(new Vector2(1780, 400), "chain");
            platform = new Platform(new Vector2(1780, 330), "chain");

            player = new Player();
            enemyMelee = new Melee();
            enemyRanged = new Ranged();
            enemyFlying = new Flying();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
      

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (player.Health <= 0)
            {
                
                RemoveGameObject(player);
                
                respawnTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (respawnTime > respawnDuration)
                {
                    player = new Player();

                        
                    respawnTime = 0;
                 }
                    
                
            }           

            
            //Directional Rectangle for the healthbar
            barPos = new Rectangle((int)barPosition.X, (int)barPosition.Y, player.Health * 2, barTop.Height);
            barPosition = new Vector2(94, 59);
            
            foreach (GameObject go in gameObjects)
            {
                //Apply gravity
                if (go.Gravity)
                {
                    go.Position = new Vector2(go.Position.X, go.Position.Y + gravityStrength);

                }

                go.Update(gameTime);
                foreach (GameObject other in gameObjects)
                {
                    
                    if (go != other && go.IsColliding(other))
                    {
                        go.DoCollision(other);

                    }
                }
            }
            
            foreach (GameObject go in toBeRemoved)
            {
                gameObjects.Remove(go);
            }
            toBeRemoved.Clear();

            gameObjects.AddRange(toBeAdded);
            toBeAdded.Clear();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();
            foreach (GameObject go in gameObjects)
            {
                go.Draw(spriteBatch);
#if DEBUG
                DrawCollisionBox(go);
#endif
            }
            
            
            
            //Add spriteBatch for healthbar
            spriteBatch.Draw(bar, new Vector2(70, 35), Color.White);
            spriteBatch.Draw(barMid, new Vector2(94, 59), Color.White);
            spriteBatch.Draw(barTop, barPos, Color.White);
            //spriteBatch.DrawString(font, $"Health:{player.Health}", new Vector2(165, 75), Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }


        private void DrawCollisionBox(GameObject go)
        {
            Rectangle collisionBox = go.CollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }
    }
}
