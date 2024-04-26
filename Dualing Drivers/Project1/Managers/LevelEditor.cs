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
        public enum TileType { Ground, Half, Wall, Breakable, Ammo, Health, Speed, Delete }

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
        private Texture2D speedTexture;
        private Texture2D ammoTexture;
        private Texture2D healthTexture;
        private Texture2D deleteTexture;
        private Texture2D exitTexture;
        private Texture2D saveTexture;
        private Texture2D loadTexture;
        private Texture2D PlayerText1;
        private Texture2D PlayerText2;

        //create internal array fields
        public TileType[,] powerUps = new TileType[25, 17];
        public TileType[,] tileTypes = new TileType[25, 17];
        public Button[,] mapTiles = new Button[25,17];
        public Button[] selectTiles = new Button[8];
        public Button exitButton;
        public Button saveButton;
        public Button loadButton;
        public Button clearButton;
        private Button selectedTile;

        /// <summary>
        /// Basic LevelEditor Constructor
        /// </summary>
        public LevelEditor(Texture2D groundTexture, Texture2D halfTexture, Texture2D wallTexture, Texture2D breakableTexture, Texture2D speedTexture, Texture2D healthTexture, Texture2D ammoTexture, Texture2D deleteTexture, Texture2D selectedTexture, Texture2D exitTexture, Texture2D saveTexture, Texture2D loadTexture, Texture2D PlayerText1, Texture2D PlayerText2)
        {
            //set internal fields to the constructor input
            this.wallTexture = wallTexture;
            this.groundTexture = groundTexture;
            this.halfTexture = halfTexture;
            this.breakableTexture = breakableTexture;
            this.selectedTexture = selectedTexture;
            this.exitTexture = exitTexture;
            this.saveTexture = saveTexture;
            this.loadTexture = loadTexture;
            this.speedTexture = speedTexture;
            this.healthTexture = healthTexture;
            this.ammoTexture = ammoTexture;
            this.deleteTexture = deleteTexture;
            this.PlayerText1 = PlayerText1;
            this.PlayerText2 = PlayerText2;
            //create a basic array
            for(int i = 0; i < mapWidth; i++)
            {
                for (int k = 0; k < mapHeight; k++)
                {
                    //check if the tiles are the game's border
                    if(i == 0 || i == mapWidth - 1 || k == 0 || k == mapHeight - 1)
                    {
                        tileTypes[i, k] = TileType.Wall;
                        mapTiles[i, k] = new Button(wallTexture, 260 + 40 * i, 20 + 40 * k, 40, 40);
                    }
                    else
                    {
                        tileTypes[i, k] = TileType.Ground;
                        mapTiles[i, k] = new Button(groundTexture, 260 + 40 * i, 20 + 40 * k, 40, 40);
                    }
                    powerUps[i, k] = TileType.Delete;
                }
            }

            //create the selecting Tiles array 
            selectTiles[0] = new Button(groundTexture, groundTexture, 45, 20, 80, 80);
            selectTiles[1] = new Button(halfTexture, halfTexture, 125, 20, 80, 80);
            selectTiles[2] = new Button(wallTexture, wallTexture, 45, 100, 80, 80);
            selectTiles[3] = new Button(breakableTexture, breakableTexture, 125, 100, 80, 80);
            selectTiles[4] = new Button(ammoTexture, ammoTexture, 45, 180, 80, 80);
            selectTiles[5] = new Button(healthTexture, healthTexture, 125, 180, 80, 80);
            selectTiles[6] = new Button(speedTexture, speedTexture, 45, 260, 80, 80);
            selectTiles[7] = new Button(deleteTexture, speedTexture, 125, 260, 80, 80);

            //Create the buttons
            exitButton = new Button(exitTexture, 15, 700 - exitTexture.Height, exitTexture.Width, exitTexture.Height);
            saveButton = new Button(saveTexture, 15, 620 - saveTexture.Height, saveTexture.Width, saveTexture.Height);
            loadButton = new Button(loadTexture, 15, 540 - loadTexture.Height, loadTexture.Width, loadTexture.Height);
            clearButton = new Button(loadTexture, 15, 460 - loadTexture.Height, loadTexture.Width, loadTexture.Height);
        }

        /// <summary>
        /// Switches a tile in the internal arrays for a different tile
        /// </summary>
        /// <param name="x">x value in array</param>
        /// <param name="y">y value in array</param>
        /// <param name="t">tiletype to swap in</param>
        public void SwitchTile(int x, int y, TileType t)
        {
            if(x!= 0 && x != mapWidth - 1 && y != 0 && y != mapHeight - 1) 
            { 
                if((x >= 3 || y >= 3) && (x <= 21 || y <= 13 ))
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
                    else if (t == TileType.Ammo)
                    {
                        powerUps[x, y] = TileType.Ammo;
                    }
                    else if (t == TileType.Health)
                    {
                        powerUps[x, y] = TileType.Health;
                    }
                    else if (t == TileType.Speed)
                    {
                        powerUps[x, y] = TileType.Speed;
                    }
                    else if (t == TileType.Delete)
                    {
                        powerUps[x, y] = TileType.Delete;
                    }

                    //set ground for "else" as a failsafe
                    else
                    {
                        tileTypes[x, y] = TileType.Ground;
                        this.mapTiles[x, y].texture = this.groundTexture;
                    }

                }
            }
        }

        /// <summary>
        /// Clears all map tiles to a blank map
        /// </summary>
        public void ClearTiles()
        {
            //create a basic array
            for (int i = 0; i < mapWidth; i++)
            {
                for (int k = 0; k < mapHeight; k++)
                {
                    //check if the tiles are the game's border
                    if (i == 0 || i == mapWidth - 1 || k == 0 || k == mapHeight - 1)
                    {
                        tileTypes[i, k] = TileType.Wall;
                        mapTiles[i, k] = new Button(wallTexture, 260 + 40 * i, 20 + 40 * k, 40, 40);
                    }
                    else
                    {
                        tileTypes[i, k] = TileType.Ground;
                        mapTiles[i, k] = new Button(groundTexture, 260 + 40 * i, 20 + 40 * k, 40, 40);
                    }
                    powerUps[i, k] = TileType.Delete;
                }
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
                    if (powerUps[i,k] != TileType.Ground)
                    {
                        if (powerUps[i, k] == TileType.Ammo)
                        {
                            sb.Draw(ammoTexture, new Rectangle(i * 40 + 260,
                            k * 40 + 20, 40, 40), Color.White);
                        }
                        else if (powerUps[i, k] == TileType.Health)
                        {
                            sb.Draw(healthTexture, new Rectangle(i * 40 + 260,
                            k * 40 + 20, 40, 40), Color.White);
                        }
                        else if (powerUps[i, k] == TileType.Speed)
                        {
                            sb.Draw(speedTexture, new Rectangle(i * 40 + 260,
                            k * 40 + 20, 40, 40), Color.White);
                        }
                    }
                }
           }
            
            //draw the players to the screen
            sb.Draw(PlayerText1, new Vector2(60 + 280,
            60 + 40), null, Color.White, 45 * (float)Math.PI / 180, new Vector2(20,
            20), new Vector2(1, 1), SpriteEffects.None, 1);
            sb.Draw(PlayerText2, new Vector2(900 + 280,
            580 + 40), null, Color.White, 225 * (float)Math.PI / 180, new Vector2(20,
            20), new Vector2(1, 1), SpriteEffects.None, 1);
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
            //loop through the tiles to print
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
            //loop through powerups to print
            output.Write("\n");
            for (int i = 0; i < mapWidth; i++)
            {
                for (int k = 0; k < mapHeight; k++)
                {
                    if (powerUps[i, k] != TileType.Delete)
                    {
                        if(powerUps[i, k] == TileType.Ammo)
                        {
                            output.WriteLine("ammo|" + i + "|" + k);
                        }
                        else if (powerUps[i, k] == TileType.Health)
                        {
                            output.WriteLine("health|" + i + "|" + k);
                        }
                        else if (powerUps[i, k] == TileType.Speed)
                        {
                            output.WriteLine("speed|" + i + "|" + k);
                        }
                    }
                }
            }
            output.Close();
            MessageBox.Show("File Saved Successfully", "File Saved");
        }

        /// <summary>
        /// Read level data from an external file
        /// </summary>
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

            //reset all powerups
            for (int i = 0; i < mapWidth; i++)
            {
                for (int k = 0; k < mapHeight; k++)
                {
                    powerUps[i, k] = TileType.Delete;
                }
            }

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
            //loop through to get powerups
            List<string> powerUpData = new List<string>();
            while (rows.Count > 17)
            {
                powerUpData.Add(rows[17]);
                rows.RemoveAt(17);
            }
            //load power ups if there are any
            if (powerUpData.Count > 0)
            {
                string[] rowData;
                // goes through every string in powerUpData
                for (int x = 0; x < powerUpData.Count; x++)
                {
                    // splits each string
                    rowData = powerUpData[x].Split("|");

                    //insert the powerUp into the correct list
                    if (rowData[0] == "ammo")
                    {
                        powerUps[int.Parse(rowData[1]), int.Parse(rowData[2])] = TileType.Ammo;
                    }
                    else if (rowData[0] == "health")
                    {
                        powerUps[int.Parse(rowData[1]), int.Parse(rowData[2])] = TileType.Health;
                    }
                    else if (rowData[0] == "speed")
                    {
                        powerUps[int.Parse(rowData[1]), int.Parse(rowData[2])] = TileType.Speed;
                    }
                }
            }
            //show message box that loading was successful
            MessageBox.Show("File Loaded Successfully", "File Loaded");
        }
    }
}
