using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    internal class UIelement : Object
    {
        protected Texture2D hTexture;
        protected bool canHover;

        /// <summary>
        /// Basic UIElement Constructor
        /// </summary>
        /// <param name="texture">texture of game object</param>
        /// <param name="x">x value of position rectangle</param>
        /// <param name="y">y value of position rectangle</param>
        /// <param name="width">width of position rectangle</param>
        /// <param name="height">height of position rectangle</param>
        public UIelement(Texture2D texture, int x, int y, int width, int height) : base(texture, x, y, width, height)
        {
            canHover = false;
        }

        /// <summary>
        /// Basic UIElement Constructor w/ hovering texture
        /// </summary>
        /// <param name="texture">texture of game object</param>
        /// <param name="x">x value of position rectangle</param>
        /// <param name="y">y value of position rectangle</param>
        /// <param name="width">width of position rectangle</param>
        /// <param name="height">height of position rectangle</param>
        public UIelement(Texture2D texture, Texture2D hTexture, int x, int y, int width, int height) : base(texture, x, y, width, height)
        {
            this.hTexture = hTexture;
            canHover = true;
        }

        /// <summary>
        /// Checks if the mouse is hovering over the UI element
        /// </summary>
        /// <param name="m">current mouseState to check hovering</param>
        /// <returns>true if mouse overlaps UI, false if not</returns>
        public bool IsHovering(MouseState m)
        {
            //check if mouse cursor is within UI element's bounds + hoverTexture exists
            if (m.X >= this.X && m.X <= this.X + this.width
                && m.Y >= this.Y && m.Y <= this.Y + this.height)
            {
                return true;
            }
            return false;
        }
    }
}
