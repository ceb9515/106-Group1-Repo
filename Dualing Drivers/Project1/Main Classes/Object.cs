using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Object
    {
        //private fields to store rectangle and texture
        public Rectangle rect;
        public Texture2D texture;
        protected int width;
        protected int height;

        //accessors and setters for rectangle X and Y
        public int X { get { return rect.X; } set { rect.X = value; } }
        public int Y { get { return rect.Y; } set { rect.Y = value; } }

        /// <summary>
        /// Basic Object Constructor
        /// </summary>
        /// <param name="texture">texture of game object</param>
        /// <param name="x">x value of position rectangle</param>
        /// <param name="y">y value of position rectangle</param>
        /// <param name="width">width of position rectangle</param>
        /// <param name="height">height of position rectangle</param>
        public Object(Texture2D texture, int x, int y, int width, int height)
        {
            this.texture = texture;
            this.width = width;
            this.height = height;
            rect = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Draws the Object to SpriteBatch
        /// </summary>
        /// <param name="sb">SpriteBatch to draw to</param>
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, rect, Color.White);
        }
    }
}
