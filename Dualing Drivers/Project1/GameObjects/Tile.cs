using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    enum TileType
    {
        solid,
        breakable,
        semiSolid,
        background
    }
    internal class Tile : GameObject
    {
        // fields
        private int health;
        private TileType tileType;

        // constructor

        /// <summary>
        /// Basic Tile Constructor
        /// </summary>
        /// <param name="texture">texture of game object</param>
        /// <param name="x">x value of position rectangle</param>
        /// <param name="y">y value of position rectangle</param>
        /// <param name="width">width of position rectangle</param>
        /// <param name="height">height of position rectangle</param>
        public Tile(Texture2D texture, int x, int y, int width, int height, TileType tileType) : base(texture, x, y, width, height)
        {
            if (tileType == TileType.breakable)
            {
                health = 9;
            }

            this.tileType = tileType;
        }

        // methods

        /// <summary>
        /// breakable tiles take damage and destroy after three hits
        /// </summary>
        public void TakeDamage()
        {
            if (tileType == TileType.breakable)
            {
                health -= 3;
                if (health <= 0)
                {
                    Destroy();
                }
            }
        }

        public void BlockPlayer()
        {
            
        }
    }
}
