using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
        private Texture2D exitTexture;

        //create internal array fields
        public TileType[,] tileTypes = new TileType[25, 17];
        public Button[,] mapTiles = new Button[25,17];
        public Button[] selectTiles = new Button[4];
        public Button exitButton;
        public Button saveButton;
        public Button loadButton;
        private Button selectedTile;

        /// <summary>
        /// Basic LevelEditor Constructor
        /// </summary>
        public LevelEditor(Texture2D groundTexture, Texture2D halfTexture, Texture2D wallTexture, Texture2D breakableTexture, Texture2D selectedTexture, Texture2D exitTexture)
        {
            //set internal fields to the constructor input
            this.wallTexture = wallTexture;
            this.groundTexture = groundTexture;
            this.halfTexture = halfTexture;
            this.breakableTexture = breakableTexture;
            this.selectedTexture = selectedTexture;
            this.exitTexture = exitTexture;

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
            selectTiles[0] = new Button(groundTexture, groundTexture, 30, 20, 80, 80);
            selectTiles[1] = new Button(halfTexture, halfTexture, 140, 20, 80, 80);
            selectTiles[2] = new Button(wallTexture, wallTexture, 30, 130, 80, 80);
            selectTiles[3] = new Button(breakableTexture, breakableTexture, 140, 130, 80, 80);

            //Create the buttons
            exitButton = new Button(exitTexture, 30, 700 - exitTexture.Height*2, exitTexture.Width*2, exitTexture.Height*2);
            saveButton = new Button(exitTexture, 30, 500 - exitTexture.Height * 2, exitTexture.Width * 2, exitTexture.Height * 2);
            loadButton = new Button(exitTexture, 30, 300 - exitTexture.Height * 2, exitTexture.Width * 2, exitTexture.Height * 2);
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

        /// <summary>
        /// Save level data to an external file
        /// </summary>
        /// <param name="filename">filepath to write to</param>
        public void Save(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            string filename = (sender as SaveFileDialog).FileName;
            StreamWriter output = new StreamWriter(filename);
            for (int i = 0; i < mapHeight; i++)
            {
                for(int k = 0; k < mapWidth; k++)
                {
                    if(k == 0)
                    {
                        output.Write("\n" + tileTypes[k, i].ToString());
                    }
                    else
                    {
                        output.Write("|" + tileTypes[k, i].ToString());
                    }
                }
            }
            output.Close();
            MessageBox.Show("File Saved Successfully", "File Saved");
        }

        /// <summary>
        /// Read level data from an external file
        /// </summary>
        /// <param name="filename">filepath to read from</param>
        public void Load(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            //get the streamreader from file
            string filename = (sender as OpenFileDialog).FileName;
            StreamReader input = new StreamReader(filename);

            //get the data into a list of the correct rows
            List<string> rows = new List<string>();
            string line = null;
            while ((line = input.ReadLine()) != null)
            {
                rows.Add(line);
            }
            rows.RemoveAt(0);

            //loop through the rows and add tiles to the map
            for (int i = 0; i < mapHeight; i++)
            {
                for (int k = 0; k < mapWidth; k++)
                {
                    //get this row of data for tiles
                    string[] rowData = rows[i].Split("|");
                    //default tile type = ground
                    TileType loadTileType = TileType.Ground;
                    //read the type of tile to input
                    if (rowData[k] == "Half")
                    {
                        loadTileType = TileType.Half;
                    }
                    else if (rowData[k] == "Wall")
                    {
                        loadTileType = TileType.Wall;
                    }
                    else if (rowData[k] == "Breakable")
                    {
                        loadTileType = TileType.Breakable;
                    }
                    //switch to the correct type of tiles
                    this.SwitchTile(k, i, loadTileType);
                }
            }
            //show message box that loading was successful
            MessageBox.Show("File Loaded Successfully", "File Loaded");
        }
    }
}
