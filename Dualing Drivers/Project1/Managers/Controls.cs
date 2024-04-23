using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Managers
{
    internal class Controls
    {
        private Texture2D controlGraphic;
        private Texture2D menuButtonText;

        public Button menuButton;



        public Controls(Texture2D controlText, Texture2D menuText)
        {
            controlGraphic = controlText;
            menuButtonText = menuText;

            menuButton = new Button(menuButtonText, 50, 50, menuButtonText.Width, menuButtonText.Height);
        }

        public void Draw(SpriteBatch sb, GraphicsDeviceManager _graphics)
        {
            menuButton.Draw(sb);
            sb.Draw(controlGraphic, new Rectangle(_graphics.PreferredBackBufferWidth/2 - controlGraphic.Width, 10 ,controlGraphic.Width*2,controlGraphic.Height*2), Color.White);
        }
    }
}
