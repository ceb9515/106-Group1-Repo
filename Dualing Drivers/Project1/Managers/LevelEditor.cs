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

        //create fields for map width and height (will stay the same but is useful for testing possibilities)
        private int mapHeight = 17;
        private int mapWidth = 25;
        public int MapHeight { get { return mapHeight; } }
        public int MapWidth { get { return mapWidth; } }

        //create fields for the textures
        private Texture2D groundTexture;
        private Texture2D halfTexture;
        private Texture2D wallTexture;
        private Texture2D breakableTexture;
        private Texture2D selectedTexture;

        //create internal array fields
        public TileType[,] tileTypes = new TileType[25, 17];
        public Button[,] mapTiles = new Button[25,17];
        public Button[] selectTiles = new Button[4];
        private Button selectedTile;
        /// <summary>
        /// Basic LevelEditor Constructor
        /// </summary>
        public LevelEditor(Texture2D groundTexture, Texture2D halfTexture, Texture2D wallTexture, Texture2D breakableTexture, Texture2D selectedTexture)
        {
            //set internal fields to the constructor input
            this.wallTexture = wallTexture;
            this.groundTexture = groundTexture;
            this.halfTexture = halfTexture;
            this.breakableTexture = breakableTexture;
            this.selectedTexture = selectedTexture;

            //create a basic array
            for(int i = 0; i < mapWidth; i++)
            {
                for (int k = 0; k < mapHeight; k++)
                {
                    tileTypes[i, k] = TileType.Ground;
                    mapTiles[i, k] = new Button(groundTexture, 260 + 40*i, 20 + 40*k, 40, 40);
                }
            }

            //create the selecting Tiles array 
            selectTiles [0] = new Button(groundTexture, groundTexture, 30, 20, 80, 80);
            selectTiles[1] = new Button(halfTexture, halfTexture, 140, 20, 80, 80);
            selectTiles[2] = new Button(wallTexture, wallTexture, 30, 130, 80, 80);
            selectTiles[3] = new Button(breakableTexture, breakableTexture, 140, 130, 80, 80);
        }

        /// <summary>
        /// Switches a tile in the internal arrays for a different tile
        /// </summary>
        /// <param name="x">x value in array</param>
        /// <param name="y">y value in array</param>
        /// <param name="t">tiletype to swap in</param>
        public void SwitchTile(int x, int y, TileType t)
        {
            //switch the tile to the coorect tileType
            if (t == TileType.Breakable)
            {
                tileTypes[x, y] = TileType.Breakable;
                this.mapTiles[x, y].texture = this.breakableTexture;
            }
            else if (t == TileType.Half)
            {
                tileTypes[x, y] = TileType.Half;
                this.mapTiles[x, y].texture = this.halfTexture;
            }
            else if (t == TileType.Wall)
            {
                tileTypes[x, y] = TileType.Wall;
                this.mapTiles[x, y].texture = this.wallTexture;
            }
            //set ground for "else" as a failsafe
            else
            {
                tileTypes[x, y] = TileType.Ground;
                this.mapTiles[x, y].texture = this.groundTexture;
            }
        }

        /// <summary>
        /// Draws the Map to SpriteBatch
        /// </summary>
        /// <param name="sb">SpriteBatch to draw to</param>
        public virtual void DrawMap(SpriteBatch sb)
        {
           for (int i = 0; i < mapWidth; i++)
           {
               for (int k = 0; k < mapHeight; k++)
               {
                   mapTiles[i, k].Draw(sb, false);
               }
           }
        }

        /// <summary>
        /// Draws the Tile Select to SpriteBatch
        /// </summary>
        /// <param name="sb">SpriteBatch to draw to</param>
        public virtual void DrawTiles(SpriteBatch sb, int currentTile)
        {
           for (int i = 0; i < selectTiles.Length; i++)
           {
                if(i == currentTile)
                {
                    selectedTile = new Button(selectedTexture, selectTiles[i].X, selectTiles[i].Y, selectTiles[i].rect.Width, selectTiles[i].rect.Height);
                    selectTiles[i].Draw(sb);
                    selectedTile.Draw(sb);
                }
                else
                {
                    selectTiles[i].Draw(sb);
                }
           }
        }
    }
}
