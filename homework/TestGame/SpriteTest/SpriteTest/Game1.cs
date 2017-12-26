using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SpriteTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D backgroundImage;

        //private Player player = new Player();
        //Camera camera = new Camera(); // single player

        Player[] player = new Player[2] { new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right), new Player (Keys.W, Keys.S, Keys.A, Keys.D) };
        Camera[] camera = new Camera[2] { new Camera(), new Camera() };

        private Viewport defaultView, player1View, player2View;

        private Texture2D divider;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            //player.Initialize(); // single player

            foreach (Player play in player)
                play.Initialize();

            defaultView = player1View = player2View = GraphicsDevice.Viewport;
            player1View.Width = player2View.Width = defaultView.Width / 2;
            player2View.X = defaultView.Width / 2;

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

            // TODO: use this.Content to load your game content here
            //player.LoadContent(Content); // single player
            foreach (Player play in player)
                play.LoadContent(Content);

            backgroundImage = Content.Load<Texture2D>("Sprites/bg");
            divider = Content.Load<Texture2D>("Sprites/div");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //player.Update(gameTime);
            //camera.Update(player.Position); //single player

            Viewport[] view = new Viewport[2] {player1View, player2View};

            for (int i = 0; i < player.Length; i++)
            {
                player[i].Update(gameTime);
                camera[i].Update(player[i].Position, player[i].Image, view[i]);
            }

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
            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.ViewMatrix);

            //spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White);
            //player.Draw(spriteBatch);

            //spriteBatch.End(); // single player

            GraphicsDevice.Viewport = player1View;
            DrawScene(player, camera[0], gameTime);

            GraphicsDevice.Viewport = player2View;
            DrawScene(player, camera[1], gameTime);

            GraphicsDevice.Viewport = defaultView;
            spriteBatch.Begin();
            spriteBatch.Draw(divider, new Vector2(camera[0].ScreenWidth / 2 - 1, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawScene(Player[] player, Camera camera, GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.ViewMatrix);
            spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White);
            foreach (Player play in player)
                play.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }
    }
}
