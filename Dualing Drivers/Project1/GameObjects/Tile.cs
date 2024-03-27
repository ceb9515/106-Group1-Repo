using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        // properties

        /// <summary>
        /// gets and sets a tiles type
        /// </summary>
        public TileType Type { get { return tileType; } set { tileType = value; } } 
        
        /// <summary>
        /// gets the tiles rectangle position and size
        /// </summary>
        public Microsoft.Xna.Framework.Rectangle Rect { get { return this.rect; } }

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
                    tileType = TileType.background;
                    // change the texture too
                }
            }
        }

        /// <summary>
        /// blocks player from going through tiles
        /// </summary>
        /// <param name="playerRect">players current position</param>
        /// <returns>players new position outside of rectangle</returns>
        public void BlockPlayer(Player player)
        {
            // finds where the objects overlap
            Microsoft.Xna.Framework.Rectangle overlap =
                Microsoft.Xna.Framework.Rectangle.Intersect(this.rect, player.PlayerRect);

            // moves player horizontally left or right
            // from conflicting tile
            if (overlap.Height >= overlap.Width)
            {
                if (this.rect.X > player.PlayerRect.X)
                {
                    Vector2 vector2 = new Vector2(player.PlayerPosition.X, player.PlayerPosition.Y);
                    vector2.X -= overlap.Width;
                    player.PlayerPosition = vector2;
                }
                else if (this.rect.X < player.PlayerRect.X)
                {
                    Vector2 vector2 = new Vector2(player.PlayerPosition.X, player.PlayerPosition.Y);
                    vector2.X += overlap.Width;
                    player.PlayerPosition = vector2;
                }
            }

            // moves player vertically up or down
            // from conflicting tile
            if (overlap.Width >= overlap.Height)
            {
                if (this.rect.Y > player.PlayerRect.Y)
                {
                    Vector2 vector2 = new Vector2(player.PlayerPosition.X, player.PlayerPosition.Y);
                    vector2.Y -= overlap.Height;
                    player.PlayerPosition = vector2;
                }
                else if (this.rect.Y < player.PlayerRect.Y)
                {
                    Vector2 vector2 = new Vector2(player.PlayerPosition.X, player.PlayerPosition.Y);
                    vector2.Y += overlap.Height;
                    player.PlayerPosition = vector2;
                }
            }
        }
    }
}
