using Microsoft.Xna.Framework.Graphics;
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
        public Button level1Button;
        public Button level2Button;
        public Button level3Button;
        public Button levelCustomButton;

        public Texture2D level1Text;
        public Texture2D level2Text;
        public Texture2D level3Text;
        public Texture2D levelCustomText;


        /// <summary>
        /// Constructor for LevelSelect
        /// </summary>
        public LevelSelect(Texture2D levelCustomText, Texture2D level1Text, Texture2D level2Text, Texture2D level3Text)
        {
            this.level1Text = level1Text;
            this.level2Text = level2Text;
            this.level3Text = level3Text;
            this.levelCustomText = levelCustomText;

            level1Button = new Button(level1Text, 80, 150, level1Text.Width, level1Text.Height);
            level2Button = new Button(level2Text, 380, 150, level2Text.Width, level2Text.Height);
            level3Button = new Button(level3Text, 680, 150, level3Text.Width, level3Text.Height);
            levelCustomButton = new Button(levelCustomText, 980, 150, levelCustomText.Width, levelCustomText.Height);
        }

        //Draws the level select screen's elements and buttons
        public void Draw(SpriteBatch sb)
        {
            level1Button.Draw(sb);
            level2Button.Draw(sb);
            level3Button.Draw(sb);
            levelCustomButton.Draw(sb);
        }
    }
}