using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MichaelTerraria
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Terrain terrain;
        KeyboardState KS;
        KeyboardState PK;
        Player player;
        SpriteFont font;
        ToolBar tb;
        string seeds = "";
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 2000;
            graphics.PreferredBackBufferWidth = 4000;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";

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
            //Content.Load<Texture2D>("")
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            terrain = new Terrain(Content.Load<Texture2D>("WaterTile"), Content.Load<Texture2D>("BaseTile"), Content.Load<Texture2D>("GreenTile"), Content.Load<Texture2D>("SGTile"), Content.Load<Texture2D>("Village"));
            player = new Player(Content.Load<Texture2D>("PlayerA"), Content.Load<Texture2D>("PlayerB"), Content.Load<Texture2D>("PlayerC"), Content.Load<Texture2D>("PlayerD"),Content.Load<Texture2D>("pixel"),new Rectangle(100,100,50,50));
            font = Content.Load<SpriteFont>("Font");
            terrain.makeRandTerrain();
            terrain.WriteAllTerrain();
            tb = new ToolBar(player.inventory);
            terrain.CreateTerrain();
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
            seeds = terrain.seedsToStrind();
            player.inuse = tb.inuse;
            KS = Keyboard.GetState();
            this.IsMouseVisible = true;
            tb.SetInv(player.inventory);
            if (KS.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            if(KS.IsKeyUp(Keys.Space) && PK.IsKeyDown(Keys.Space))
            {
                tb.Next();
            }
            player.Move(KS,PK , ref terrain,2950,1470);
            

            // TODO: Add your update logic here
            PK = KS;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
           
            terrain.Draw(spriteBatch);
            player.Draw(spriteBatch);
            tb.Draw(spriteBatch);
            spriteBatch.DrawString(font, "Selection: " + tb.inuse,new Vector2(0,1800), Color.White);
            spriteBatch.DrawString(font, "X: " + player.rect.X + " Y: " + player.rect.Y + " Platform ID: " + player.x+player.y +"Seeds 1-9 " + seeds, new Vector2(0, 20),Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
