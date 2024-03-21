using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class GameObject : Object
    {
        Rectangle rectangle;

        /// <summary>
        /// Basic GameObject Constructor w/ hovering texture
        /// </summary>
        /// <param name="texture">texture of game object</param>
        /// <param name="x">x value of position rectangle</param>
        /// <param name="y">y value of position rectangle</param>
        /// <param name="width">width of position rectangle</param>
        /// <param name="height">height of position rectangle</param>
        public GameObject(Texture2D texture, int x, int y, int width, int height) : base(texture, x, y, width, height)
        {

        }

        /*public virtual void Draw(SpriteBatch sb)
        {

        }*/

        public virtual void Move()
        {

        }

        public void Destroy()
        {

        }

        public bool IsColliding(Rectangle rectangle)
        {
            if(this.rectangle.IntersectsWith(rectangle))
            {
                return true;
            }
            else { return false; }
        }

        
    }
}
