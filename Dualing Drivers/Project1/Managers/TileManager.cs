using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class TileManager
    {
        // fields
        private List<Tile> tiles;

        /// <summary>
        /// creates a new tile manager
        /// </summary>
        public TileManager()
        {
            tiles = new List<Tile>();
        }

        // methods

        /// <summary>
        /// adds tile to list of tiles
        /// </summary>
        /// <param name="tile">tile to be added</param>
        public void AddTile(Tile tile)
        {
            tiles.Add(tile);
        }

        /// <summary>
        /// changes a tile to a background tile
        /// </summary>
        /// <param name="tile">tile to be changed</param>
        public void RemoveTile(Tile tile)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i] == tile)
                {
                    tiles[i].Type = TileType.background;
                }
            }
        }

        /// <summary>
        /// loads tiles from file and adds to list
        /// </summary>
        /// <param name="fileName">name of file to load from</param>
        /// <param name="breakable">breakable tile texture</param>
        /// <param name="solid">solid tile texture</param>
        /// <param name="background">background tile texture</param>
        /// <param name="semiSolid">semisolid tile texture</param>
        public void LoadTiles(string fileName, Texture2D breakable, Texture2D solid, Texture2D background, Texture2D semiSolid)
        {
            // variables needed to load a file
            StreamReader input = new StreamReader(fileName);
            string line = null;
            string[] tiles = new string[21];
            int x = 0;
            int y = 0;
            TileType tileType = TileType.background;
            Texture2D texture = null;

            // reads every line in the file
            while((line = input.ReadLine()) != null)
            {
                // splits line up into individual tile types
                tiles = line.Split("||");

                // checks every tile type in a line
                for (int i = 0; i < tiles.Length; i++)
                {
                    // checks the tile type that is saved in the file
                    if (tiles[i] == "solid")
                    {
                        tileType = TileType.solid;
                        texture = solid;
                    }
                    else if (tiles[i] == "semiSolid")
                    {
                        tileType = TileType.semiSolid;
                        texture = semiSolid;
                    }
                    else if (tiles[i] == "breakable")
                    {
                        tileType = TileType.breakable;
                        texture = breakable;
                    }
                    else if (tiles[i] == "background")
                    {
                        tileType = TileType.background;
                        texture = background;
                    }

                    // adds tile to list
                    AddTile(new Tile(texture, x, y, 40, 40, tileType));

                    // changes tile position
                    x += 40;
                    if (x == 1000)
                    {
                        x = 0;
                        y += 40;
                    }
                }
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
                tiles[i].Draw(sb);
            }
        }

        /// <summary>
        /// checks if player is colliding with a tile
        /// </summary>
        /// <param name="playerRect">players position and size</param>
        /// <returns>players new position</returns>
        public Rectangle HandlePlayerCollision(Microsoft.Xna.Framework.Rectangle playerRect)
        {
            for (int i = 0; i < tiles.Count; i++) 
            {
                if (tiles[i].IsColliding(playerRect) && tiles[i].Type != TileType.background)
                {
                    playerRect = tiles[i].BlockPlayer(playerRect);
                }
            }
            return playerRect;
        }
    }
}
