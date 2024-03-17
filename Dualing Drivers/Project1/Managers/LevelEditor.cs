using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Managers
{
    internal class LevelEditor
    {
        public enum TileType { Ground, Half, Wall, Breakable }

        private Texture2D groundTexture;
        private Texture2D halfTexture;
        private Texture2D wallTexture;
        private Texture2D breakableTexture;

        public TileType[,] tileTypes = new TileType[25, 15];
        public Button[,] mapTiles = new Button[25,15];

        /// <summary>
        /// Basic LevelEditor Constructor
        /// </summary>
        public LevelEditor(Texture2D groundTexture, Texture2D halfTexture, Texture2D wallTexture, Texture2D breakableTexture)
        {
            for(int i = 0; i < 25; i++)
            {
                for (int k = 0; k < 15; k++)
                {
                    tileTypes[i, k] = TileType.Ground;
                    mapTiles[i, k] = new Button(groundTexture, groundTexture, 250 + 40*i, 50 + 40*k, 40, 40);
                }
            }
        }

        /// <summary>
        /// Switches a tile in the internal arrays for a different tile
        /// </summary>
        /// <param name="x">x value in array</param>
        /// <param name="y">y value in array</param>
        /// <param name="t">tiletype to swap in</param>
        public void SwitchTile(int x, int y, TileType t)
        {
            if(t == TileType.Breakable)
            {
                tileTypes[x, y] = TileType.Breakable;
            }
            else if (t == TileType.Half)
            {
                tileTypes[x, y] = TileType.Half;
            }
            else if (t == TileType.Wall)
            {
                tileTypes[x, y] = TileType.Wall;
                Button b = new Button(wallTexture, wallTexture, 250 + 40 * x, 50 + 40 * y, 40, 40);
                mapTiles[x, y] = b;

            }
            //set ground for "else" as a failsafe
            else
            {
                tileTypes[x, y] = TileType.Ground;
                mapTiles[x, y] = new Button(groundTexture, groundTexture, 250 + 40 * x, 50 + 40 * y, 40, 40);
            }
        }

        /// <summary>
        /// Draws the Map to SpriteBatch
        /// </summary>
        /// <param name="sb">SpriteBatch to draw to</param>
        public virtual void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < 25; i++)
            {
                for (int k = 0; k < 15; k++)
                {
                    try
                    {
                        sb.Draw(mapTiles[i, k].texture, mapTiles[i, k].rect, Color.White);
                    }
                    catch { }
                }
            }
        }
    }
}
