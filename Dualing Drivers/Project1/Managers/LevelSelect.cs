using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Managers
{
    /// <summary>
    /// LevelSelect Manager
    /// </summary>
    internal class LevelSelect
    {
        public List<Button> levelButtons;
        public List<Texture2D> levelTextures;
        private Texture2D levelTextHover;

        /// <summary>
        /// Constructor for LevelSelect
        /// </summary>
        public LevelSelect(List<Texture2D> levelTextures, Texture2D levelTextHover)
        {
            this.levelTextures = levelTextures;
            levelButtons = new List<Button>();
            int row = 0;
            int col = 0;
            this.levelTextHover = levelTextHover;
            //loop through to create the level buttons
            for(int i = 0; i < levelTextures.Count; i++)
            {
                levelButtons.Add(new Button(levelTextures[i], 55 + 150 * col, 200 + 150 * row, 120, 120));
                col++;
                //move to a new row after 8 buttons
                if(col > 7)
                {
                    row++;
                    col = 0;
                }
            }
        }

        //Draws the level select screen's elements and buttons
        public void Draw(SpriteBatch sb, MouseState mouseState)
        {
            int col = 0;
            int row = 0;
            for (int i = 0; i < levelButtons.Count; i++)
            {
                //draw the buttons
                levelButtons[i].Draw(sb);
                //if hovering, draw hovering texture
                if (levelButtons[i].IsHovering(mouseState))
                {
                    sb.Draw(levelTextHover, new Microsoft.Xna.Framework.Vector2(55 + 150 * col, 200 + 150 * row), Microsoft.Xna.Framework.Color.White);
                }

                col++;
                //move to a new row after 8 buttons
                if (col > 7)
                {
                    row++;
                    col = 0;
                }
            }
        }
    }
}