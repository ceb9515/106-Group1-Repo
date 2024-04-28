using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        public Button controlsButton;

        public Texture2D startTexture;
        public Texture2D levelEditorTexture;
        public Texture2D controlsTexture;
        public Texture2D startHTexture;
        public Texture2D levelEditorHTexture;
        public Texture2D controlsHTexture;

        public Texture2D titleLogo;

        /// <summary>
        /// Constructor for TitleScreen
        /// </summary>
        /// <param name="startTexture"> texture for start button </param>
        /// <param name="levelEditorTexture"> texture for level editor button</param>
        public TitleScreen(Texture2D startTexture, Texture2D startHTexture, Texture2D levelEditorTexture, Texture2D levelEditorHTexture, Texture2D controlsText, Texture2D controlsHText, Texture2D titleLogo)
        {
            this.startTexture = startTexture;
            this.levelEditorTexture = levelEditorTexture;
            this.titleLogo = titleLogo;
            controlsTexture = controlsText;
            this.startHTexture = startHTexture;
            this.levelEditorHTexture = levelEditorHTexture;
            controlsHTexture = controlsHText;

            startGameButton = new Button(startTexture, 410, 425, startTexture.Width, startTexture.Height);
            levelEditorButton = new Button(levelEditorTexture, 680, 425, levelEditorTexture.Width, levelEditorTexture.Height);
            controlsButton = new Button(controlsTexture, 450, 525, controlsTexture.Width, controlsTexture.Height);
        }

        //Draws the title screen's elements and buttons
        public void DrawTitle(SpriteBatch sb, MouseState ms)
        {
            //draw the buttons with hovering
            if (startGameButton.IsHovering(ms))
            {
                startGameButton.Texture = startHTexture;
            }
            else
            {
                startGameButton.Texture = startTexture;
            }
            if (levelEditorButton.IsHovering(ms))
            {
                levelEditorButton.Texture = levelEditorHTexture;
            }
            else
            {
                levelEditorButton.Texture = levelEditorTexture;
            }
            if (controlsButton.IsHovering(ms))
            {
                controlsButton.Texture = controlsHTexture;
            }
            else
            {
                controlsButton.Texture = controlsTexture;
            }

            levelEditorButton.Draw(sb);
            controlsButton.Draw(sb);
            startGameButton.Draw(sb);
            sb.Draw(titleLogo, new Microsoft.Xna.Framework.Rectangle(150, 50, (int)(titleLogo.Width * 1.2), (int)(titleLogo.Height * 1.2)), Microsoft.Xna.Framework.Color.White);

        }
    }
}
