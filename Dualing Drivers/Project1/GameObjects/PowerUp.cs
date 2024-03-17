using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class PowerUp : GameObject
    {
        /// <summary>
        /// Basic PowerUp Constructor
        /// </summary>
        /// <param name="texture">texture of game object</param>
        /// <param name="x">x value of position rectangle</param>
        /// <param name="y">y value of position rectangle</param>
        /// <param name="width">width of position rectangle</param>
        /// <param name="height">height of position rectangle</param>
        public PowerUp(Texture2D texture, int x, int y, int width, int height) : base(texture, x, y, width, height)
        {

        }
    }
}
