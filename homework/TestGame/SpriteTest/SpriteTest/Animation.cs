using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteTest
{
    public class Animation
    {
        private int frameCounter;
        private int switchFrame;

        private Vector2 position, amountOfFrames, currentFrame;
        private Texture2D Image;
        private Rectangle sourceRect;

        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public Vector2 CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public int FrameWidth
        {
            get { return Image.Width / (int) amountOfFrames.X; }
        }

        public int FrameHeight
        {
            get { return Image.Height / (int) amountOfFrames.Y; }
        }

        public Texture2D AnimationImage
        {
            set { Image = value; }
        }

        public Rectangle Source
        {
            get { return sourceRect; }
        }
        public void Initialize(Vector2 position, Vector2 Frames)
        {
            active = false;
            switchFrame = 100;
            this.position = position;
            this.amountOfFrames = Frames;
        }

        public void Update(GameTime gameTime)
        {
            if (active)
                frameCounter += (int) gameTime.ElapsedGameTime.TotalMilliseconds;
            else
            {
                frameCounter = 0;
                //currentFrame.X = 0; // New
            }
            if (frameCounter >= switchFrame)
            {
                frameCounter = 0;
                currentFrame.X += FrameWidth;
                if (currentFrame.X >= Image.Width)
                    currentFrame.X = 0;
                //frameCounter = 0;
                //currentFrame.X ++;
                //if (currentFrame.X >= 4)
                //    currentFrame.X = 0;
            }
            sourceRect = new Rectangle((int)currentFrame.X, (int)currentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
            //sourceRect = new Rectangle((int) currentFrame.X * 48, (int) 
            //currentFrame.Y * 72, 50, 72); //new
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, position, sourceRect, Color.White);
        }
    }
}
