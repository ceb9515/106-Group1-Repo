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
        private Texture2D lefttext;
        private Texture2D righttext;

        public Button menuButton;
        public Button leftControl1;
        public Button rightControl1;
        public Button leftControl2;
        public Button rightControl2;


        public Controls(Texture2D controlText, Texture2D menuText,Texture2D leftText,Texture2D rightText)
        {
            controlGraphic = controlText;
            menuButtonText = menuText;
            lefttext=leftText;
            righttext=rightText;

            menuButton = new Button(menuButtonText, 50, 50, menuButtonText.Width, menuButtonText.Height);
            leftControl1=new Button(lefttext,450,500,lefttext.Width,lefttext.Height);
            rightControl1 = new Button(righttext, 750, 500, righttext.Width, righttext.Height);
            leftControl2=new Button(lefttext,450,600,lefttext.Width,lefttext.Height);
            rightControl2=new Button(righttext,750,600,righttext.Width,righttext.Height);
        }

        public void Draw(SpriteBatch sb, GraphicsDeviceManager _graphics)
        {
            menuButton.Draw(sb);
            leftControl1.Draw(sb);
            rightControl1.Draw(sb);
            leftControl2.Draw(sb);
            rightControl2.Draw(sb);
            sb.Draw(controlGraphic, new Rectangle(_graphics.PreferredBackBufferWidth/2 - controlGraphic.Width, 10 ,controlGraphic.Width*2,controlGraphic.Height*2), Color.White);
        }
    }
}
