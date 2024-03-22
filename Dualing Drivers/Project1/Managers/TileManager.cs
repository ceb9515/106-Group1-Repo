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

        //public void LoadTiles(string fileName)
        //{
        //    StreamReader input = new StreamReader(fileName);
        //    string line = null;
        //    int x = 0;
        //    int y = 0;
        //    TileType tileType;
        //    while((line = input.ReadLine()) != null)
        //    {
        //        if (x == )
        //    }
        //}

    }
}
