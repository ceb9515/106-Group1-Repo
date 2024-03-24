using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace Project1
{
    internal class Bullet : GameObject
    {
        //fields
        private Texture2D BulletTexture;
        private Microsoft.Xna.Framework.Rectangle BulletRec;
        private float Angle;
        private int Speed = 4;
        private Vector2 activePosition;
        private Vector2 currentPosition;
        private bool active;
        
        

        /// <summary>
        /// property
        /// </summary>
        public Microsoft.Xna.Framework.Rectangle Bulletrec 
        {
        get { return BulletRec; }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="angle"></param>
        public Bullet(Texture2D BulletTex, int inputX, int inputY, int width, int height, float angle) : base(BulletTex, inputX, inputY, width, height)
        {
           
            Angle = angle;
            BulletTexture = BulletTex;
            this.activePosition = new Vector2(inputX, inputY);
            int x = (int)Math.Floor(this.activePosition.X);
            int y = (int)Math.Floor(this.activePosition.Y);
            BulletRec = new Microsoft.Xna.Framework.Rectangle (x,y,BulletTexture.Width,BulletTexture.Height);
            this.active = true;
           
        }

        public void moveBullet()
        {
            // Assuming Angle is in degrees and normalized between 0 and 360.
            // Normalize speed components based on direction without using trigonometry
            float dx = 0, dy = 0;

            // Simplified direction calculation (works accurately for right angles)
            if (Angle == 0) { dx = Speed; } // Right
            else if (Angle == 90) { dy = -Speed; } // Up
            else if (Angle == 180) { dx = -Speed; } // Left
            else if (Angle == 270) { dy = Speed; } // Down
            else
            {
                // For non-cardinal directions, this is a very rough approximation and not recommended
                // Consider reverting to using trigonometric functions for better accuracy
                dx = Speed * (float)Math.Cos(Angle * Math.PI / 180);
                dy = Speed * (float)Math.Sin(Angle * Math.PI / 180);
            }

            // Update the BulletRec position
            BulletRec = new Rectangle(BulletRec.X + (int)dx, BulletRec.Y + (int)dy, BulletRec.Width, BulletRec.Height);
            currentPosition = new Vector2(BulletRec.X, BulletRec.Y);
        }
        /// <summary>
        /// draw the bullet itself
        /// </summary>
        /// <param name="sb"></param>
        public override void Draw(SpriteBatch sb)
        {
            if(active)
            {
                sb.Draw(BulletTexture,BulletRec, BulletRec, Color.White,Angle,currentPosition,SpriteEffects.None,0);
            }
        }
    }
}
