using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteTest
{
    public class Camera
    {
        private Vector2 position;
        private Matrix viewMatrix;
        private float scale = 1.0f;

        public Matrix ViewMatrix
        {
            get { return viewMatrix; }
        }

        public int ScreenWidth
        {
            get { return GraphicsDeviceManager.DefaultBackBufferWidth; }
        }

        public int ScreenHeight
        {
            get { return GraphicsDeviceManager.DefaultBackBufferHeight; }
        }

        public void Update(Vector2 playerPosition, Texture2D playerImage,  Viewport view)
        {
            position.X = (playerPosition.X + playerImage.Width / 2) - (view.Width / 2);
            position.Y = (playerPosition.Y + playerImage.Height / 2) - (view.Height / 2);

            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;

            if (Keyboard.GetState().IsKeyDown(Keys.Z))
                scale += 0.01f;
            else if (Keyboard.GetState().IsKeyDown(Keys.X))
                scale -= 0.01f;

            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0)) * Matrix.CreateScale(scale);
        }
    }
}
