using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoadingMapsTest
{
    public class Map
    {
        enum LoadState { Texture, Map };

        private LoadState state;
        //private Vector2 dimensions;
        //int[,] map = new int[100, 100];
        List<List<int>> map = new List<List<int>>();
        List<int> tempMap = new List<int>();
        List<Texture2D> textures = new List<Texture2D>();

        private Color drawColor;

        //private int lineIndex;

        public Map()
        {
            //lineIndex = 0;
        }

        public void LoadContent(ContentManager Content, string filename)
        {
            string line;
            string[] lineArray;
            //StreamReader reader = new StreamReader(filename);
            //line = reader.ReadLine().TrimEnd(' ');
            //lineArray = line.Split(' ');
            //dimensions = new Vector2(int.Parse(lineArray[0]), int.Parse(lineArray[1]));

            //line = reader.ReadLine().Trim(' ');
            //dimensions.X = line.Length;
            //reader.Close();
            try
            {
                using (StreamReader read = new StreamReader(filename))
                {
                    while (!read.EndOfStream)
                    {
                        line = read.ReadLine().TrimEnd(' ').TrimStart(' ');
                        while (line.IndexOf("  ") != -1)
                            line = line.Replace("  ", " ");

                        if (line.Contains("[Texture]"))
                        {
                            state = LoadState.Texture;
                            continue;
                        }
                        else if (line.Contains("[Map]"))
                        {
                            state = LoadState.Map;
                            continue;
                        }

                        switch (state)
                        {
                            case LoadState.Texture:
                                if (line != string.Empty)
                                    textures.Add(Content.Load<Texture2D>(line));
                                break;

                            case LoadState.Map:
                                lineArray = line.Split(' ');

                                for (int i = 0; i < lineArray.Length; i++)
                                    tempMap.Add(int.Parse(lineArray[i]));
                                //map[lineIndex, i] = int.Parse(lineArray[i]);

                                //lineIndex++;
                                map.Add(tempMap);
                                tempMap = new List<int>();
                                break;
                        }
                    }
                    //dimensions.Y = lineIndex;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Draw(SpriteBatch spriteBatch)//, Texture2D mapTexture)
        {
            //for (int i = 0; i < dimensions.X; i++)
            //{
            //    for (int j = 0; j < dimensions.Y; j++)
            //    {
            //        if (map[i, j] == 1)
            //            spriteBatch.Draw(mapTexture, new Vector2(j * mapTexture.Width, i * mapTexture.Height), Color.White);
            //    }
            //}

            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    //if (map[i][j] == 1)
                        //spriteBatch.Draw(mapTexture, new Vector2(j * mapTexture.Width, i * mapTexture.Height), Color.White);
                    if (map[i][j] == 0)
                        drawColor = Color.White;
                    else
                        drawColor = Color.Black;

                    spriteBatch.Draw(textures[map[i][j]], 
                        new Vector2(j * textures[map[i][j]].Width, i * textures[map[i][j]].Height), drawColor);
                }
            }
        }
    }
}
