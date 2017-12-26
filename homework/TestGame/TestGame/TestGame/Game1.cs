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

namespace TestGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //string Text;

        private static DateTime DateTimeNow = DateTime.Now;
        private string Date = DateTimeNow.ToLongDateString();

        //private Texture2D myImage;
        //Rectangle Player1, Player2;

        //private Vector2 buttonPosition;
        //private Vector2 Position;
        //private Vector2 Velocity;
        //float moveSpeed = 100;
        //private KeyboardState keyState;
        //private KeyboardState prevKeyState;
        private MouseState MouseState;
        private MouseState prevMouseState;
        //private bool horizontal = false, vertical = false;

        private Texture2D customCursor;
        private int counter = 0;
        //Color buttonColor = new Color(0, 0, 0);
        private bool display = false;
        private bool displayText = false;
        private string buttonText = "Show Text";
        //private string text = "Hello World I just activated a button";
        private SpriteFont gameFont;
        //private string distance, negate, min, max, length;
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
            //Position = new Vector2(0, 0);
            //Text = "This is XNA";
            //------------------------------------------
            //Position = new Vector2(100, 50);
            //Position2 = new Vector2(600, 300);
            //------------------------------------------
            //Position = new Vector2(100, 50);
            //buttonPosition = new Vector2(10, 10);
            this.IsMouseVisible = true;
            //this.IsMouseVisible = false;

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

            gameFont = Content.Load<SpriteFont>("Font/SpriteFont");
            //myImage = Content.Load<Texture2D>("Sprites/Rect");
            //customCursor = Content.Load<Texture2D>("Sprites/CR_Cursor");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            //distance = Vector2.Distance(Position, Position2).ToString();
            //negate = Vector2.Negate(Position).ToString();
            //min = Vector2.Min(Position, Position2).ToString();
            //max = Vector2.Max(Position, Position2).ToString();
            //length = Position.Length().ToString();
            //-------------------------------------------
            //keyState = Keyboard.GetState();

            //if (keyState.IsKeyDown(Keys.Right))
            //{
            //    //Position.X += moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            //    Velocity.X = moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            //    vertical = false;
            //    horizontal = true;
            //}
            //else if (keyState.IsKeyDown(Keys.Left))
            //{
            //    //Position.X -= moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            //    Velocity.X = -moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //    vertical = false;
            //    horizontal = true;
            //}
            //else if (keyState.IsKeyDown(Keys.Up))
            //{
            //    //Position.Y += moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            //    Velocity.Y = -moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //    vertical = true;
            //    horizontal = false;
            //}
            //else if (keyState.IsKeyDown(Keys.Down))
            //{
            //    //Position.Y -= moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            //    Velocity.Y = moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //    vertical = true;
            //    horizontal = false;
            //}

            //if (horizontal)
            //    Velocity.Y = 0;
            //else
            //{
            //    Velocity.X = 0;
            //}

            //Position.X += Velocity.X;
            //Position.Y += Velocity.Y;

            //// Boundaries

            //if (Position.X < 0 || Position.X > graphics.GraphicsDevice.Viewport.Width - gameFont.MeasureString(Date).X)
            //{
            //    if (Velocity.X < 0)
            //        Velocity.X = moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            //    else
            //        Velocity.X = -moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            //}

            //if (Position.Y < 0 || Position.Y > graphics.GraphicsDevice.Viewport.Height - gameFont.MeasureString(Date).Y)
            //{
            //    if (Velocity.Y < 0)
            //        Velocity.Y = moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            //    else
            //        Velocity.Y = -moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            //}
            //------------------------------------------
            //MouseState mouse = Mouse.GetState();

            //if (mouse.X < buttonPosition.X || mouse.Y < buttonPosition.Y ||
            //    mouse.X > buttonPosition.X + gameFont.MeasureString(buttonText).X ||
            //    mouse.Y > buttonPosition.Y + gameFont.MeasureString(buttonText).Y)
            //{
            //    //the mouse is not hovering the text
            //    buttonColor = new Color(0, 0, 0);
            //}
            //else
            //{
            //    buttonColor = new Color(0, 255, 255);
            //    if (mouse.LeftButton == ButtonState.Pressed)
            //    {
            //        display = (display == false) ? true : false;
            //    }
            //}
            //----------------------------------------
            //prevKeyState = keyState;
            //keyState = Keyboard.GetState();

            //if (keyState.IsKeyDown(Keys.Down) && prevKeyState.IsKeyUp(Keys.Down))
            //    displayText = true;
            //else if (keyState.IsKeyUp(Keys.Down) && prevKeyState.IsKeyDown(Keys.Down))
            //    displayText = false;
            
            //---------------------------------------
            prevMouseState = MouseState;
            MouseState = Mouse.GetState();

            if (MouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                counter++;
            //else if (MouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
            //    counter--;

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
            //spriteBatch.DrawString(font1, Text, Position, Color.White);
            //-------------------------------------------
            //spriteBatch.Draw(myImage, Position, Color.White);
            //-------------------------------------------
            //spriteBatch.Draw(myImage, Position, Color.White);
            //spriteBatch.Draw(myImage, Position2, Color.Blue);
            //spriteBatch.DrawString(gameFont, distance, new Vector2(0, 0), Color.BlueViolet);
            //spriteBatch.DrawString(gameFont, negate, new Vector2(0, 50), Color.BlueViolet);
            //spriteBatch.DrawString(gameFont, min, new Vector2(0, 100), Color.BlueViolet);
            //spriteBatch.DrawString(gameFont, max, new Vector2(0, 150), Color.BlueViolet);
            //spriteBatch.DrawString(gameFont, length, new Vector2(0, 200), Color.BlueViolet);
            //-------------------------------------------
            //spriteBatch.Draw(myImage, Position, Color.White);
            //spriteBatch.Draw(myImage, Position2, Color.Blue);
            //-------------------------------------------
            //spriteBatch.DrawString(gameFont, Date, Position, Color.White);
            //-------------------------------------------
            //spriteBatch.DrawString(gameFont, buttonText, buttonPosition, buttonColor);
            //if (display)
            //{
            //    spriteBatch.DrawString(gameFont, text, Position, Color.White);
            //}
            //spriteBatch.Draw(customCursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
            //-------------------------------------------
            //if (displayText)
            //    spriteBatch.DrawString(gameFont, buttonText, new Vector2(10, 10), Color.Black);
            //-------------------------------------------
            spriteBatch.DrawString(gameFont, counter.ToString(), new Vector2(10, 10), Color.Black);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
