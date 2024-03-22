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
    internal class TitleScreen
    {
        public Button startGameButton;
        public Button levelEditorButton;
        public Button settingsButton;

        public Texture2D startTexture;
        public Texture2D levelEditorTexture;
        public Texture2D titleLogo;


        /// <summary>
        /// Constructor for TitleScreen
        /// </summary>
        /// <param name="startTexture"> texture for start button </param>
        /// <param name="levelEditorTexture"> texture for level editor button</param>
        public TitleScreen(Texture2D startTexture, Texture2D levelEditorTexture, Texture2D titleLogo)
        {
            this.startTexture = startTexture;
            this.levelEditorTexture = levelEditorTexture;
            this.titleLogo = titleLogo;

            startGameButton = new Button(startTexture, 400, 300, startTexture.Width*2, startTexture.Height*2);
            levelEditorButton = new Button(levelEditorTexture, 716, 300, levelEditorTexture.Width*2, levelEditorTexture.Height*2);


            
        }

        public void DrawTitle(SpriteBatch sb)
        {
            startGameButton.Draw(sb);
            levelEditorButton.Draw(sb);
            sb.Draw(titleLogo, new Microsoft.Xna.Framework.Rectangle(640 - titleLogo.Width/3, 50, 2*titleLogo.Width/3, 2*titleLogo.Height/3), Microsoft.Xna.Framework.Color.White);
        }
    }
}
