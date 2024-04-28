using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Project1.Managers
{
    internal class Controls
    {
        private Texture2D controlGraphic;
        private Texture2D menuButtonText;
        private Texture2D menuButtonHText;
        private Texture2D lefttext;
        private Texture2D righttext;
        private Texture2D leftHtext;
        private Texture2D rightHtext;

        public Texture2D controlAutomatic;
        public Texture2D controlTank;
        public Texture2D p1Label;
        public Texture2D p2Label;

        public Button menuButton;
        public Button leftControl1;
        public Button rightControl1;
        public Button leftControl2;
        public Button rightControl2;

        public Controls(Texture2D controlText, Texture2D menuText, Texture2D menuHText, Texture2D leftText, Texture2D leftHText, Texture2D rightText, Texture2D rightHText, Texture2D controlTank, Texture2D controlAutomatic, Texture2D p1Label, Texture2D p2Label)
        {
            controlGraphic = controlText;
            menuButtonText = menuText;
            menuButtonHText = menuHText;
            lefttext =leftText;
            righttext=rightText;
            leftHtext = leftHText;
            rightHtext = rightHText;
            this.controlAutomatic = controlAutomatic;
            this.controlTank = controlTank;
            this.p1Label = p1Label;
            this.p2Label = p2Label;

            menuButton = new Button(menuButtonText, 50, 50, menuButtonText.Width, menuButtonText.Height);
            leftControl1=new Button(lefttext,440,460,lefttext.Width,lefttext.Height);
            rightControl1 = new Button(righttext, 760, 460, righttext.Width, righttext.Height);
            leftControl2=new Button(lefttext,440,560,lefttext.Width,lefttext.Height);
            rightControl2=new Button(righttext,760,560,righttext.Width,righttext.Height);
        }

        /// <summary>
        /// Draws the controls screen elements to the screen
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="_graphics"></param>
        /// <param name="controlsP1"></param>
        /// <param name="controlsP2"></param>
        /// <param name="ms"></param>
        public void Draw(SpriteBatch sb, GraphicsDeviceManager _graphics, bool controlsP1, bool controlsP2, MouseState ms)
        {
            if (menuButton.IsHovering(ms))
            {
                menuButton.Texture = menuButtonHText;
            }
            else
            {
                menuButton.Texture = menuButtonText;
            }

            //display the correct selected controller options
            if (!controlsP1)
            {
                leftControl1.Texture = leftHtext;
                rightControl1.Texture = righttext;
            }
            else
            {
                leftControl1.Texture = lefttext;
                rightControl1.Texture = rightHtext;
            }
            if (!controlsP2)
            {
                leftControl2.Texture = leftHtext;
                rightControl2.Texture = righttext;
            }
            else
            {
                leftControl2.Texture = lefttext;
                rightControl2.Texture = rightHtext;
            }
 
            menuButton.Draw(sb);
            leftControl1.Draw(sb);
            rightControl1.Draw(sb);
            leftControl2.Draw(sb);
            rightControl2.Draw(sb);
            sb.Draw(controlGraphic, new Rectangle(_graphics.PreferredBackBufferWidth/2 - controlGraphic.Width, 50 ,controlGraphic.Width*2,controlGraphic.Height*2), Color.White);

            //draw labels
            sb.Draw(controlAutomatic, new Rectangle(75, 480, controlAutomatic.Width/3, controlAutomatic.Height/3), Color.White);
            sb.Draw(controlTank, new Rectangle(875, 480, controlTank.Width / 3, controlTank.Height / 3), Color.White);
            sb.Draw(p1Label, new Rectangle(565, 480, p1Label.Width, p1Label.Height), Color.White);
            sb.Draw(p2Label, new Rectangle(565, 570, p2Label.Width, p2Label.Height), Color.White);
        }
    }
}
