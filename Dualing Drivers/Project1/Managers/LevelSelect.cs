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
        public Button exitButton;
        public Button editButton;
        public Button loadButton;
        private Texture2D levelTextHover;
        private Texture2D exitTexture;
        private Texture2D exitHTexture;
        private Texture2D loadTexture;
        private Texture2D loadHTexture;
        private Texture2D editTexture;
        private Texture2D editHTexture;
        private Texture2D logoTexture;
        //extra y value boost since we only have 1 row of levels instead of 3
        int yboost;

        /// <summary>
        /// Constructor for LevelSelect
        /// </summary>
        public LevelSelect(List<Texture2D> levelTextures, Texture2D levelTextHover, Texture2D exitTexture, Texture2D exitHTexture, Texture2D loadTexture, Texture2D loadHTexture, Texture2D editTexture, Texture2D editHTexture, Texture2D logoTexture)
        {
            //save all textures
            this.exitTexture = exitTexture;
            this.exitHTexture = exitHTexture;
            this.editTexture = editTexture;
            this.editHTexture = editHTexture;
            this.loadTexture = loadTexture;
            this.loadHTexture = loadHTexture;
            this.levelTextures = levelTextures;
            this.levelTextHover = levelTextHover;
            this.logoTexture = logoTexture;

            //extra y value boost since we only have 1 row of levels instead of 3
            yboost = 100;

            //setup buttons
            loadButton = new Button(loadTexture, 1000, 20 + yboost, loadTexture.Width, loadTexture.Height);
            editButton = new Button(editTexture, 1000, 100 + yboost, editTexture.Width, editTexture.Height);
            exitButton = new Button(exitTexture, 1000, 180 + yboost, exitTexture.Width, exitTexture.Height);
            levelButtons = new List<Button>();

            //loop through to create the level buttons
            //int row = 0;
            int col = 0;
            int row = 1;
            for(int i = 0; i < levelTextures.Count; i++)
            {
                levelButtons.Add(new Button(levelTextures[i], 55 + 150 * col, 275 + 150 * row, 120, 120));
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
            //int row = 0;
            int row = 1;
            for (int i = 0; i < levelButtons.Count; i++)
            {
                //draw the buttons
                levelButtons[i].Draw(sb);
                exitButton.Draw(sb);
                //check if the exit button is hovering)
                if (exitButton.IsHovering(mouseState))
                {
                    exitButton.Texture = exitHTexture;
                    exitButton.Draw(sb);
                }
                else
                {
                    exitButton.Texture = exitTexture;
                    exitButton.Draw(sb);
                }
                //check if the edit button is hovering)
                if (editButton.IsHovering(mouseState))
                {
                    editButton.Texture = editHTexture;
                    editButton.Draw(sb);
                }
                else
                {
                    editButton.Texture = editTexture;
                    editButton.Draw(sb);
                }
                //check if the load button is hovering)
                if (loadButton.IsHovering(mouseState))
                {
                    loadButton.Texture = loadHTexture;
                    loadButton.Draw(sb);
                }
                else
                {
                    loadButton.Texture = loadTexture;
                    loadButton.Draw(sb);
                }
                //if level button is hovering, draw hovering texture
                if (levelButtons[i].IsHovering(mouseState))
                {
                    sb.Draw(levelTextHover, new Microsoft.Xna.Framework.Vector2(55 + 150 * col, 275 + 150 * row), Microsoft.Xna.Framework.Color.White);
                }

                sb.Draw(logoTexture, new Microsoft.Xna.Framework.Vector2(90, 10 + yboost), Microsoft.Xna.Framework.Color.White);

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