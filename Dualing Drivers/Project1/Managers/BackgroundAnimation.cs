using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Managers
{
    internal class BackgroundAnimation
    {
        private List<Rectangle> tilePositions;
        private Texture2D backgroundTexture;

        /// <summary>
        /// Basic BackgroundAnimation Constructor
        /// </summary>
        /// <param name="backgroundTexture"></param>
        public BackgroundAnimation(Texture2D backgroundTexture)
        {
            this.backgroundTexture = backgroundTexture;
            tilePositions = new List<Rectangle>();
            for(int i = 0; i < 12; i++)
            {
                for(int k = 0; k < 7; k++){
                    tilePositions.Add(new Rectangle(i * backgroundTexture.Width, k * backgroundTexture.Height, backgroundTexture.Width, backgroundTexture.Height));
                }
            }
        }

        /// <summary>
        /// Draws the background to the screen + loops tile
        /// </summary>
        /// <param name="sb">spritebatch to draw to</param>
        public void Draw(SpriteBatch sb, Color color)
        {
            for (int i = 0; i < tilePositions.Count; i++)
            {
                if (tilePositions[i].X >= 0 - backgroundTexture.Width)
                {
                    tilePositions[i] = new Rectangle(tilePositions[i].X - 1, tilePositions[i].Y, backgroundTexture.Width, backgroundTexture.Height);
                }
                else
                {
                    tilePositions[i] = new Rectangle(1318, tilePositions[i].Y, backgroundTexture.Width, backgroundTexture.Height);
                }
                sb.Draw(backgroundTexture, tilePositions[i], color);
            }
        }
    }
}