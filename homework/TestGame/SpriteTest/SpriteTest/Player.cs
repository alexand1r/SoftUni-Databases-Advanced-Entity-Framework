using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteTest
{
    public class Player
    {
        private Texture2D playerImage;
        private Vector2 playerPosition, tempCurrentFrame;

        private KeyboardState keyState;
        private float moveSpeed;
        private float speed;

        private Keys up, down, left, right;

        public Player(Keys up, Keys down, Keys left, Keys right)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
        }

        public Vector2 Position
        {
            get { return playerPosition; }
        }

        public Texture2D Image
        {
            get { return playerImage; }
        }
        private Texture2D Crop(Texture2D image, Rectangle source)
        {
            Texture2D croppedImage = new Texture2D(image.GraphicsDevice, source.Width, source.Height);
            Color[] imageData = new Color[image.Width * image.Height];
            Color[] cropData = new Color[source.Width * source.Height];

            image.GetData<Color>(imageData);

            int index = 0;

            for (int y = source.Y; y < source.Y + source.Height; y++)
            {
                for (int x = source.X; x < source.X + source.Width; x++)
                {
                    cropData[index] = imageData[y * image.Width + x];
                    index++;
                }
            }
            croppedImage.SetData<Color>(cropData);
            return croppedImage;
        }

        Animation playerAnimation  = new Animation();
        public void Initialize()
        {
            playerPosition = new Vector2(10, 10);
            playerAnimation.Initialize(playerPosition, new Vector2(4, 4));
            tempCurrentFrame = Vector2.Zero;
            speed = 100f;
        }

        public void LoadContent(ContentManager Content)
        {
            playerImage = Content.Load<Texture2D>("Sprites/sprite");
            playerAnimation.AnimationImage = playerImage;
        }

        public void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();
            playerAnimation.Active = true;

            moveSpeed = speed * (float) gameTime.ElapsedGameTime.TotalSeconds; 

            if (keyState.IsKeyDown(down))//Keys.Down))
            {
                playerPosition.Y += moveSpeed;
                tempCurrentFrame.Y = 0;
            }
            else if (keyState.IsKeyDown(up))//Keys.Up))
            {
                playerPosition.Y -= moveSpeed;
                tempCurrentFrame.Y = 3;
            }
            else if (keyState.IsKeyDown(right))//Keys.Right))
            {
                playerPosition.X += moveSpeed;
                tempCurrentFrame.Y = 2;
            }
            else if (keyState.IsKeyDown(left))//Keys.Left))
            {
                playerPosition.X -= moveSpeed;
                tempCurrentFrame.Y = 1;
            }
            else
                playerAnimation.Active = false;

            tempCurrentFrame.X = playerAnimation.CurrentFrame.X;

            playerAnimation.Position = playerPosition;
            playerAnimation.CurrentFrame = tempCurrentFrame;

            playerAnimation.Update(gameTime);
            //playerAnimation.AnimationImage = Crop(playerImage, playerAnimation.Source);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)//new
        {
            playerAnimation.Draw(spriteBatch);
        }
    }
}
