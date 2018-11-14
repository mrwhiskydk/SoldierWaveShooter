using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SoldierWaveShooter
{
    /// <summary>
    /// This is the main type for the game
    /// </summary>
    public class Gameworld : Game
    {

        static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont font;
        private Texture2D bar;
        private Texture2D barMid;
        private Texture2D barTop;

        /// <summary>
        /// Used to set the texture of the default background sprite
        /// </summary>
        private Texture2D backGround;
        private Rectangle BackGroundRect;

        /// <summary>
        /// List that contains the different GameObjects in the game
        /// </summary>
        public List<GameObject> gameObjects = new List<GameObject>();

        private static List<GameObject> toBeAdded = new List<GameObject>();
        private static List<GameObject> toBeRemoved = new List<GameObject>();

        /// <summary>
        /// Enables access to the Player in other classes
        /// </summary>
        public static Player player;

        /// <summary>
        /// Enables acces to the Boss in other classes
        /// </summary>
        public static Boss boss;

        private Enemy enemyMelee;
        private Enemy enemyRanged;
        private Enemy enemyFlying;
        private Enemy enemyBoss;
        private Platform platform;
        private Texture2D collisionTexture;
        private Sound winSound;
        private bool winSoundPlayed;
        private Sound loseSound;
        private bool loseSoundPlayed;
        private SoundEffect musicLoop;
        private SoundEffectInstance music;


        /// <summary>
        /// Enables acces to the Crosshair in other classes
        /// </summary>
        public static Crosshair mouse;

        private float gravityStrength = 5f;
        private double spawnMeleeTimer;
        private const float spawnMeleeCooldown = 7.0f;
        private bool spawnMelee = false;
        private double spawnFlyingTimer;
        private const float spawnFlyingCooldown = 3.0f;
        private bool spawnFlying = false;
        private double spawnRangedTimer;
        private const float spawnRangedCooldown = 5.0f;
        private bool spawnRanged = false;
        private double spawnBossTimer;
        private const float spawnBossCooldown = 10.0f;
        private bool spawnBoss = true;
        private bool wavePhase = true;
        private float respawnDuration = 10.0f;   //Field used for player respawn in update
        private double respawnTime; //Field used for player respawn in update
        private Texture2D winScreen;
        private Rectangle winRect;
        private Texture2D loseScreen;
        private Rectangle loseRect;
        private Vector2 barPosition;
        private Rectangle barPos;

        /// <summary>
        /// Enables use access in other classes. Handles player and enemy deaths and spawns in Gameworld update method
        /// </summary>
        public static bool isAlive = true;
        
        private bool winGame = false;


        private bool bossIsAlive = false;

        /// <summary>
        /// Sets the screensize of the game
        /// </summary>
        public static Rectangle ScreenSize
        {
            get
            {
                return graphics.GraphicsDevice.Viewport.Bounds;
            }
        }

        private static ContentManager _content;

        /// <summary>
        /// Method that enables loading of resources
        /// </summary>
        public static ContentManager ContentManager
        {
            get
            {
                return _content;
            }
        }

        /// <summary>
        /// Constructor for the Gameworld
        /// </summary>
        public Gameworld()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1020;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            _content = Content;
        }

        /// <summary>
        /// Method that adds the current GameObject to the game
        /// </summary>
        /// <param name="go">GameObject that should be added to the game</param>
        public static void AddGameObject(GameObject go)
        {
            toBeAdded.Add(go);
        }

        /// <summary>
        /// Method that removes current GameObject from the game
        /// </summary>
        /// <param name="go">GameObject that should be removed from the game</param>
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
            // TODO: use this.Content to load your game content here

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            winScreen = Content.Load<Texture2D>("YouWin");
            loseScreen = Content.Load<Texture2D>("GameOver");
            backGround = Content.Load<Texture2D>("PrisonBackground");
            BackGroundRect = new Rectangle(0, 0, 1920, 1080);
            font = Content.Load<SpriteFont>("ExampleFont");
            bar = Content.Load<Texture2D>("barBaseSW");
            barMid = Content.Load<Texture2D>("barMidLayer");
            barTop = Content.Load<Texture2D>("barTopLayer");
            collisionTexture = Content.Load<Texture2D>("CollisionTexture");
            winSound = new Sound("Sound/Weapons/win");
            loseSound = new Sound("Sound/Weapons/lose");
            musicLoop = Content.Load<SoundEffect>("Sound/Weapons/music");
            music = musicLoop.CreateInstance();
            music.IsLooped = true;
            music.Play();


            // Castle Platforms
            for (int i = 0; i < 28; i++)
            {
                new Platform(new Vector2((i*70) + 35, 1016), "castle");
            }
            platform = new Platform(new Vector2(260, 890), "castleHalf");
            platform = new Platform(new Vector2(540, 890), "castleHalf");
            platform = new Platform(new Vector2(820, 890), "castleHalf");
            platform = new Platform(new Vector2(1080, 890), "castleHalf");
            platform = new Platform(new Vector2(1360, 890), "castleHalf");
            platform = new Platform(new Vector2(1640, 890), "castleHalf");
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
            platform = new Platform(new Vector2(750, 150), "castleHalf");
            platform = new Platform(new Vector2(680, 150), "castleHalf");
            platform = new Platform(new Vector2(1150, 150), "castleHalf");
            platform = new Platform(new Vector2(1220, 150), "castleHalf");



            // Chains
            platform = new Platform(new Vector2(120, 540), "chain");
            platform = new Platform(new Vector2(120, 470), "chain");
            platform = new Platform(new Vector2(120, 400), "chain");
            platform = new Platform(new Vector2(120, 330), "chain");
            platform = new Platform(new Vector2(120, 610), "chain");
            platform = new Platform(new Vector2(120, 680), "chain");
            platform = new Platform(new Vector2(120, 750), "chain");

            platform = new Platform(new Vector2(330, 430), "chain");
            platform = new Platform(new Vector2(330, 500), "chain");
            platform = new Platform(new Vector2(330, 570), "chain");
            platform = new Platform(new Vector2(330, 640), "chain");
            platform = new Platform(new Vector2(330, 710), "chain");

            platform = new Platform(new Vector2(540, 530), "chain");
            platform = new Platform(new Vector2(540, 600), "chain");
            platform = new Platform(new Vector2(540, 670), "chain");
            platform = new Platform(new Vector2(540, 740), "chain");

            platform = new Platform(new Vector2(750, 630), "chain");
            platform = new Platform(new Vector2(750, 700), "chain");
            platform = new Platform(new Vector2(750, 770), "chain");

            platform = new Platform(new Vector2(1150, 630), "chain");
            platform = new Platform(new Vector2(1150, 700), "chain");
            platform = new Platform(new Vector2(1150, 770), "chain");

            platform = new Platform(new Vector2(1360, 530), "chain");
            platform = new Platform(new Vector2(1360, 600), "chain");
            platform = new Platform(new Vector2(1360, 670), "chain");
            platform = new Platform(new Vector2(1360, 740), "chain");

            platform = new Platform(new Vector2(1570, 430), "chain");
            platform = new Platform(new Vector2(1570, 500), "chain");
            platform = new Platform(new Vector2(1570, 570), "chain");
            platform = new Platform(new Vector2(1570, 640), "chain");
            platform = new Platform(new Vector2(1570, 710), "chain");

            platform = new Platform(new Vector2(1780, 540), "chain");
            platform = new Platform(new Vector2(1780, 470), "chain");
            platform = new Platform(new Vector2(1780, 400), "chain");
            platform = new Platform(new Vector2(1780, 330), "chain");
            platform = new Platform(new Vector2(1780, 610), "chain");
            platform = new Platform(new Vector2(1780, 680), "chain");
            platform = new Platform(new Vector2(1780, 750), "chain");

            platform = new Platform(new Vector2(750, 200), "chain");
            platform = new Platform(new Vector2(750, 270), "chain");
            platform = new Platform(new Vector2(750, 340), "chain");
            platform = new Platform(new Vector2(750, 410), "chain");

            platform = new Platform(new Vector2(1150, 200), "chain");
            platform = new Platform(new Vector2(1150, 270), "chain");
            platform = new Platform(new Vector2(1150, 340), "chain");
            platform = new Platform(new Vector2(1150, 410), "chain");

            player = new Player();
            

            mouse = new Crosshair();
            new Machinegun(new Vector2(player.Position.X + 50, player.Position.Y), true);
            new PowerUpMedkit(new Vector2(500, 500));
            new PowerUpMedkit(new Vector2(500, 700));
            new PowerUpMedkit(new Vector2(300, 500));
            new PowerUp2x(new Vector2(300, 300));
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.T))
            {
                player.Health = 0;
            }

            // TODO: Add your update logic here

            //Statement below checks if player is dead, and removes him from the game if true
            if (player.Health <= 0) 
            {
                if (!loseSoundPlayed)
                {
                    music.Stop();
                    loseSound.Play();
                    loseSoundPlayed = true;
                }
                player.Destroy();
                isAlive = false;

                //Statement below adds the player to the game once respawnTime reaches the value of respawnDuration
                respawnTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (respawnTime > respawnDuration)
                {
                    player = new Player();
                    music.Play();
                    loseSoundPlayed = false;
                    isAlive = true;

                    respawnTime = 0;

                        //Statement below enables the boss to spawn again if the player dies
                        if (!wavePhase && !spawnBoss)
                        {
                            spawnBoss = true;
                        }
                    }

                } 

            //Statement below enables win sprite to be drawn when the boss is defeated
            if (bossIsAlive == true)
            {
                if (enemyBoss.enemyHealth <= 0)
                {
                    enemyBoss.Destroy();
                    enemyBoss.enemyDamage = 0;
                    winGame = true;
                }
            }

            if (winGame == true)
            {
                if (!winSoundPlayed)
                {
                    music.Stop();
                    winSound.Play();
                    winSoundPlayed = true;
                }
                
                foreach (GameObject gameobject in gameObjects)
                {
                    if (gameobject is Projectile)
                    {
                        gameobject.Destroy();
                    }

                    if (gameobject is Enemy)
                    {
                        gameobject.Destroy();
                    }

                }
            }

            //Directional Rectangle for the healthbar
            barPos = new Rectangle((int)barPosition.X, (int)barPosition.Y, player.Health * 2, barTop.Height);
            barPosition = new Vector2(94, 59);
            foreach (GameObject go in gameObjects)
            {
                //Applies gravity to GameObject
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

            //Statement below enables different enemy GameObjects to spawn (depending on their timer) if the player is alive
            if (isAlive)
            {
                // Spawns the Melee GameObject, once spawnMeleeTimer is up
                spawnMeleeTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (spawnMeleeTimer >= spawnMeleeCooldown)
                {
                    spawnMelee = true;
                    spawnMeleeTimer = 0;
                }

                if (spawnMelee == true && wavePhase == true)
                {
                    enemyMelee = new Melee();
                    spawnMelee = false;
                }

                // Spawns the Ranged GameObject, once spawnRangedTimer is up
                spawnRangedTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (spawnRangedTimer >= spawnRangedCooldown)
                {
                    spawnRanged = true;
                    spawnRangedTimer = 0;
                }

                if (spawnRanged == true && wavePhase == true)
                {
                    enemyRanged = new Ranged();
                    spawnRanged = false;
                }

                // Spawns the Flying GameObject, once spawnFlyingTimer is up
                spawnFlyingTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (spawnFlyingTimer >= spawnFlyingCooldown)
                {
                    spawnFlying = true;
                    spawnFlyingTimer = 0;
                }

                if (spawnFlying == true && wavePhase == true)
                {
                    enemyFlying = new Flying();
                    spawnFlying = false;
                }

                
                // Spawns the Boss GameObject, once spawnBossTimer is up, and disables other Enemy GameObjects from spawning
                spawnBossTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (spawnBossTimer >= spawnBossCooldown)
                {
                    wavePhase = false;
                }

                if (spawnBoss == true && wavePhase == false)
                {
                    enemyBoss = new Boss();
                    spawnBoss = false;
                    bossIsAlive = true;
                }


            }
        

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack);


            foreach (GameObject go in gameObjects)
            {
                go.Draw(spriteBatch);
#if DEBUG
                DrawCollisionBox(go);
#endif
            }
            
            
            spriteBatch.DrawString(font, $"Health:{player.Health}", new Vector2(70, 35), Color.White);
            spriteBatch.DrawString(font, $"Ammo:{player.weapon.ammo}", new Vector2(350, 60), Color.White);
            spriteBatch.DrawString(font, $"magazine:{player.weapon.magazine}", new Vector2(350, 90), Color.White);
            spriteBatch.Draw(bar, new Vector2(70, 35), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.99f);
            spriteBatch.Draw(barMid, new Vector2(94, 59), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.991f);
            spriteBatch.Draw(barTop, barPosition, barPos, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.992f);
            //spriteBatch.DrawString(font, $"Health:{player.Health}", new Vector2(165, 75), Color.White);            
            spriteBatch.Draw(backGround, Vector2.Zero, BackGroundRect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.01f);
           
            loseRect = new Rectangle(0, 0, 1920, 1080);
            if (isAlive == false)
            {
                spriteBatch.Draw(loseScreen, Vector2.Zero, loseRect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }

            winRect = new Rectangle(0, 0, 1920, 1080);
            if (winGame == true)
            {
                spriteBatch.Draw(winScreen, Vector2.Zero, winRect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }

            spriteBatch.End();




            base.Draw(gameTime);

        }

        /// <summary>
        /// Method that draws the CollisionBox of the GameObject
        /// </summary>
        /// <param name="go">CollisionBox of the GameObject</param>
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
