using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Button : UIelement
    {
        /// <summary>
        /// Basic UIElement Constructor
        /// </summary>
        /// <param name="texture">texture of game object</param>
        /// <param name="x">x value of position rectangle</param>
        /// <param name="y">y value of position rectangle</param>
        /// <param name="width">width of position rectangle</param>
        /// <param name="height">height of position rectangle</param>
        public Button(Texture2D texture, Texture2D hTexture, int x, int y, int width, int height) : base(texture, hTexture, x, y, width, height)
        {
        }

        /// <summary>
        /// Draws the Object to SpriteBatch
        /// </summary>
        /// <param name="sb">SpriteBatch to draw to</param>
        public void Draw(SpriteBatch sb, bool hover)
        {
            if(hover == true)
            {
                sb.Draw(this.hTexture, rect, Color.White);
            }
            else
            {
                sb.Draw(this.texture, rect, Color.White);
            }
        }
    }
}
