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

namespace CollisionTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D sprite1, sprite2;
        private Vector2 position;
        private KeyboardState keyState;
        private Color playerColor = Color.White;
        private float moveSpeed = 500f;
        private Rectangle player, enemy;

        private double distance;

        private bool PixelCollision(Texture2D sprite1, Texture2D sprite2, Rectangle player, Rectangle enemy)
        {
            Color[] colorData1 = new Color[sprite1.Width * sprite1.Height];
            Color[] colorData2 = new Color[sprite2.Width * sprite2.Height];
            sprite1.GetData<Color>(colorData1);
            sprite2.GetData<Color>(colorData2);

            int top, bottom, left, right;

            top = Math.Max(player.Top, enemy.Top);
            bottom = Math.Min(player.Bottom, enemy.Bottom);
            left = Math.Max(player.Left, enemy.Left);
            right = Math.Min(player.Right, enemy.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color A = colorData1[(y - player.Top) * (player.Width) + (x - player.Left)];
                    Color B = colorData2[(y - enemy.Top) * (enemy.Width) + (x - enemy.Left)];

                    if (A.A != 0 && B.A != 0)
                        return true;
                }
            }
            return false;
        }
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
            IsMouseVisible = true;
            base.Initialize();
            enemy = new Rectangle(100, 100, sprite2.Width, sprite2.Height);

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
            sprite1 = sprite2 = Content.Load<Texture2D>("Sprites/Rect");
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
            keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Right))
            {
                position.X += moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                position.X -= moveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (keyState.IsKeyDown(Keys.Up))
            {
                position.Y -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (keyState.IsKeyDown(Keys.Down))
            {
                position.Y += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            //// Pixel Collision
            player = new Rectangle((int)position.X, (int)position.Y, sprite1.Width, sprite1.Height);

            if (player.Intersects(enemy))
            {
                if (PixelCollision(sprite1, sprite2, player, enemy))
                    playerColor = Color.Turquoise;
                else
                    playerColor = Color.White;
            }
            else
                playerColor = Color.White;

            //// Circilar Collision
            //distance = Math.Sqrt(Math.Pow(position.X - 100, 2) + Math.Pow(position.Y - 100, 2));
            //distance = Math.Abs(position.X - 100) + Math.Abs(position.Y - 100);

            //if (distance <= sprite1.Width / 2 + sprite2.Width / 2)
            //{
            //    playerColor = Color.Turquoise;
            //}
            //else
            //{
            //    playerColor = Color.White;
            //}

            //// Rectangle Collision

            //if (player.Intersects(enemy))
            //{
            //    playerColor = Color.Turquoise;
            //}
            //else
            //{
            //    playerColor = Color.White;
            //}

            ////if (position.X + sprite1.Width < 100
            ////    || position.X > 100 + sprite2.Width
            ////    || position.Y + sprite1.Height < 100
            ////    || position.Y > 100 + sprite2.Height)
            ////{
            ////    // No Collision
            ////    playerColor = Color.White;
            ////}
            ////else
            ////{
            ////    playerColor = Color.Turquoise;
            ////}

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

            spriteBatch.Draw(sprite1, position, playerColor);
            spriteBatch.Draw(sprite2, new Vector2(100, 100), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
