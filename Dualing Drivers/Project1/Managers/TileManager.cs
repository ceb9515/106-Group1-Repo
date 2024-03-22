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
            int x = 0;
            int y = 0;
            TileType tileType = TileType.background;
            Texture2D texture = null;

            // reads every line in the file
            while((line = input.ReadLine()) != null)
            {
                // checks the tile type that is saved in the file
                if (line == "solid")
                {
                    tileType = TileType.solid;
                    texture = solid;
                }
                else if (line == "semiSolid")
                {
                    tileType = TileType.semiSolid;
                    texture = semiSolid;
                }
                else if (line == "breakable")
                {
                    tileType = TileType.breakable;
                    texture = breakable;
                }
                else if (line == "background")
                {
                    tileType = TileType.background;
                    texture = background;
                }

                // adds tile to list
                AddTile(new Tile(texture, x, y, 20, 20, tileType));

                // changes tile position
                x += 20;
                if (x == 420)
                {
                    x = 0;
                    y += 20;
                }
            }

            input.Close();
        }

    }
}
