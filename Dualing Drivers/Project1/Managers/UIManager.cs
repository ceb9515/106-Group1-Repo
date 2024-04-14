using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Managers
{
    internal class UIManager
    {

        private Texture2D healthTexture;
        private Texture2D ammoTexture;
        private Rectangle healthPosition;
        private Rectangle ammoPosition;

        public Texture2D HealthTexture { get { return healthTexture; } set { healthTexture = value; } }
        public Texture2D AmmoTexture { get { return ammoTexture; } set { ammoTexture = value; } }


        public UIManager(Texture2D healthTexture, Texture2D ammoTexture, Rectangle healthPos, Rectangle ammoPos)
        {
            this.healthTexture = healthTexture;
            this.ammoTexture = ammoTexture;
            healthPosition = healthPos;
            ammoPosition = ammoPos;
        }


        /// <summary>
        /// Draws the Object to SpriteBatch
        /// </summary>
        /// <param name="sb">SpriteBatch to draw to</param>
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(healthTexture, healthPosition, Color.White);
            sb.Draw(ammoTexture, ammoPosition, Color.White);
        }
    }
}
