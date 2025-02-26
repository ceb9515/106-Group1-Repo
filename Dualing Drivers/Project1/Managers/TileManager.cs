﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project1.Managers.LevelEditor;

namespace Project1
{
    internal class TileManager
    {
        // fields
        private List<List<Tile>> tiles;
        private Texture2D solid;
        private Texture2D semiSolid;
        private Texture2D breakable;
        private Texture2D background;
        public PowerUpManager PowerUps;

        /// <summary>
        /// creates a new tile manager
        /// </summary>
        public TileManager(Texture2D solid, Texture2D breakable, Texture2D semiSolid, Texture2D background, PowerUpManager PowerUps)
        {
            tiles = new List<List<Tile>>();
            this.solid = solid;
            this.breakable = breakable;
            this.semiSolid = semiSolid;
            this.background = background;
            this.PowerUps = PowerUps;
        }

        // methods

        /// <summary>
        /// adds tile to list of tiles
        /// </summary>
        /// <param name="tile">tile to be added</param>
        public void AddTile(Tile tile, int row)
        {
            tiles[row].Add(tile);
        }

        /// <summary>
        /// changes a tile to a background tile
        /// </summary>
        /// <param name="tile">tile to be changed</param>
        public void RemoveTile(Tile tile)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                for(int k = 0; k < tiles[i].Count; k++)
                {
                    if (tiles[i][k] == tile)
                    {
                        tiles[i][k].Type = TileType.background;
                    }
                }
            }
        }

        /// <summary>
        /// Read level data from an internal file
        /// </summary>
        public void PreLoad(int levelNum)
        {
            //clear power ups
            PowerUps.Clear();
            //reset the current tiles list
            tiles.Clear();
            //get the filename based on the input
            string filename = "";
            if(levelNum == 0){
                filename = "Content/Dockyard.level";
            }
            else if(levelNum == 1)
            {
                filename = "Content/L2_Courtyard.level";
            }
            else if (levelNum == 2)
            {
                filename = "Content/L3_Bridged.level";
            }
            else if (levelNum == 3)
            {
                filename = "Content/L4_Pirate'sCove.level";
            }
            else if (levelNum == 4)
            {
                filename = "Content/L5_Labyrinth.level";
            }
            else if (levelNum == 5)
            {
                filename = "Content/L6_Cavern.level";
            }
            else if (levelNum == 6)
            {
                filename = "Content/L7_SnipersDuel.level";
            }

            //load variables from a file
            StreamReader input = new StreamReader(filename);
            string[] textTiles = new string[25];
            int x = 220 + 40;
            int y = -20 + 40;
            TileType tileType = TileType.background;
            Texture2D texture = background;
            int row = 0;
            int mapHeight = 18 - 1;
            int mapWidth = 26 - 1;

            for (int i = 0; i < mapHeight; i++)
            {
                tiles.Add(new List<Tile>());
            }

            //get the data into a list of the correct rows
            List<string> rows = new List<string>();
            string readLine = null;
            while ((readLine = input.ReadLine()) != null)
            {
                rows.Add(readLine);
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
                    TileType loadTileType = TileType.background;
                    texture = background;
                    //read the type of tile to input
                    if (rowData[k] == "Half")
                    {
                        loadTileType = TileType.semiSolid;
                        texture = semiSolid;
                    }
                    else if (rowData[k] == "Wall")
                    {
                        loadTileType = TileType.solid;
                        texture = solid;
                    }
                    else if (rowData[k] == "Breakable")
                    {
                        loadTileType = TileType.breakable;
                        texture = breakable;
                    }

                    // adds tile to list
                    AddTile(new Tile(texture, x, y, 40, 40, loadTileType, background), i);

                    x += 40;
                }
                x = 220 + 40;
                y += 40;
            }

            //Loop for PowerUps
            List<string> powerUpData = new List<string>();
            while (rows.Count > 17)
            {
                powerUpData.Add(rows[17]);
                rows.RemoveAt(17);
            }
            //load power ups if there are any
            if (powerUpData.Count > 0)
            {
                PowerUps.LoadPowerUps(powerUpData);
            }

            input.Close();
        }

        /// <summary>
        /// Read level data from an external file
        /// </summary>
        public void LoadTiles(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            //clear power ups
            PowerUps.Clear();
            //reset the current tiles list
            tiles.Clear();
            //get the streamreader from file
            string filename = (sender as OpenFileDialog).FileName;
            //load variables from a file
            StreamReader input = new StreamReader(filename);
            string[] textTiles = new string[25];
            int x = 220 + 40;
            int y = -20 + 40;
            TileType tileType = TileType.background;
            Texture2D texture = background;
            int row = 0;
            int mapHeight = 18 - 1;
            int mapWidth = 26 - 1;

            for (int i = 0; i < mapHeight; i++)
            {
                tiles.Add(new List<Tile>());
            }

            //get the data into a list of the correct rows
            List<string> rows = new List<string>();
            string readLine = null;
            while ((readLine = input.ReadLine()) != null)
            {
                rows.Add(readLine);
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
                    TileType loadTileType = TileType.background;
                    texture = background;
                    //read the type of tile to input
                    if (rowData[k] == "Half")
                    {
                        loadTileType = TileType.semiSolid;
                        texture = semiSolid;
                    }
                    else if (rowData[k] == "Wall")
                    {
                        loadTileType = TileType.solid;
                        texture = solid;
                    }
                    else if (rowData[k] == "Breakable")
                    {
                        loadTileType = TileType.breakable;
                        texture = breakable;
                    }

                    // adds tile to list
                    AddTile(new Tile(texture, x, y, 40, 40, loadTileType, background), i);

                    x += 40;
                }
                x = 220 + 40;
                y += 40;
            }

            //Loop for PowerUps
            List<string> powerUpData = new List<string>();
            while (rows.Count > 17)
            {
                powerUpData.Add(rows[17]);
                rows.RemoveAt(17);
            }
            //load power ups if there are any
            if(powerUpData.Count > 0)
            {
                PowerUps.LoadPowerUps(powerUpData);
            }
            input.Close();
        }

        /// <summary>
        /// draws all the tiles to the screen
        /// </summary>
        /// <param name="sb">sprite batch object</param>
        public void DrawTiles(SpriteBatch sb)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                for(int k = 0; k < tiles[i].Count; k++)
                {
                    tiles[i][k].Draw(sb);
                }
            }
            PowerUps.DrawPowerUps(sb);
        }

        /// <summary>
        /// checks if player is colliding with a tile
        /// </summary>
        /// <param name="playerRect">players position and size</param>
        /// <returns>players new position</returns>
        public void HandlePlayerCollision(Player player)
        {
            for (int i = 0; i < tiles.Count; i++) 
            {
                for(int k = 0; k < tiles[i].Count; k++)
                {
                    if (tiles[i][k].IsColliding(player.PlayerRect) && tiles[i][k].Type != TileType.background)
                    {
                         tiles[i][k].BlockPlayer(player);
                    }
                }
            }
        }

        /// <summary>
        /// gets the lists of tiles
        /// </summary>
        /// <returns>lists of tiles</returns>
        public List<List<Tile>> GetTiles()
        {
            return tiles;
        }

        public void TestMap()
        {
            int mapHeight = 17;
            int mapWidth = 25;
            int x = 260;
            int y = 20;

            for (int i = 0; i < mapHeight; i++)
            {
                tiles.Add(new List<Tile>());
            }

            for (int i = 0; i < mapHeight; i++)
            {
                for (int k = 0; k < mapWidth; k++)
                {
                    // adds tile to list
                    AddTile(new Tile(background, x, y, 40, 40, TileType.background, background), i);
                    x += 40;
                }
                x = 260;
                y += 40;
            }
        }
    }
}
