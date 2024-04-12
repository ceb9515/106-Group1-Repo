using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Managers
{
    /// <summary>
    /// Title Screen Manager
    /// </summary>
    internal class GameOver
    {
        public Button restartGameButton;
        public Button titleButton;

        public Texture2D startTexture;
        public Texture2D levelEditorTexture;
        public Texture2D titleLogo;


        /// <summary>
        /// Constructor for TitleScreen
        /// </summary>
        /// <param name="startTexture"> texture for start button </param>
        /// <param name="levelEditorTexture"> texture for level editor button</param>
        public GameOver(Texture2D startTexture, Texture2D levelEditorTexture, Texture2D titleLogo)
        {
            this.startTexture = startTexture;
            this.levelEditorTexture = levelEditorTexture;
            this.titleLogo = titleLogo;

            restartGameButton = new Button(startTexture, 400, 300, startTexture.Width, startTexture.Height);
            titleButton = new Button(levelEditorTexture, 716, 300, levelEditorTexture.Width, levelEditorTexture.Height);
        }

        //Draws the title screen's elements and buttons
        public void Draw(SpriteBatch sb)
        {
            restartGameButton.Draw(sb);
            titleButton.Draw(sb);
            sb.Draw(titleLogo, new Microsoft.Xna.Framework.Rectangle(640 - titleLogo.Width / 3, 50, 2 * titleLogo.Width / 3, 2 * titleLogo.Height / 3), Microsoft.Xna.Framework.Color.White);
        }
    }
}

