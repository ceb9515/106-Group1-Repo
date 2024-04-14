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

        public Texture2D restartTexture;
        public Texture2D titleTexture;


        /// <summary>
        /// Constructor for TitleScreen
        /// </summary>
        /// <param name="restartTexture"> texture for restart button </param>
        /// <param name="titleTexture"> texture for back to title button</param>
        public GameOver(Texture2D restartTexture, Texture2D titleTexture)
        {
            this.restartTexture = restartTexture;
            this.titleTexture = titleTexture;


            restartGameButton = new Button(restartTexture, 400, 500, restartTexture.Width, restartTexture.Height);
            titleButton = new Button(titleTexture, 700, 500, titleTexture.Width, titleTexture.Height);
        }

        //Draws the title screen's elements and buttons
        public void Draw(SpriteBatch sb)
        {
            restartGameButton.Draw(sb);
            titleButton.Draw(sb);
        }
    }
}

