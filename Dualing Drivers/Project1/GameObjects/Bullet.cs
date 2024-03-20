using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project1
{
    internal class Bullet : GameObject
    {
        //fields
        private Texture2D BulletTexture;
        private Rectangle BulletRec;
        private float Angle;
        private int Speed = 4;
        private Vector2 activePosition;
        private Vector2 currentPosition;
        private bool active;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="angle"></param>
        public Bullet(Texture2D BulletTex, int inputX, int inputY, int width, int height, int angle) : base(BulletTex, inputX, inputY, width, height)
        {
            Angle = angle;
            BulletTexture = BulletTex;
            this.activePosition = new Vector2(inputX, inputY);
            int x = (int)Math.Floor(this.activePosition.X);
            int y = (int)Math.Floor(this.activePosition.Y);
            BulletRec = new Rectangle(x,y,BulletTexture.Width,BulletTexture.Height);
        }

        public override void move()
        {
            // Convert angle to radians
            double angleRadians = Math.PI * Angle / 180.0;

            // Calculate new position
            int deltaX = (int)(Math.Cos(angleRadians) * Speed);
            int deltaY = (int)(Math.Sin(angleRadians) * Speed);

            // Update the BulletRec position
            BulletRec = new Rectangle(BulletRec.X + deltaX, BulletRec.Y + deltaY, BulletRec.Width, BulletRec.Height);
            currentPosition = new Vector2(BulletRec.X, BulletRec.Y);
        }
            
        public override void Draw(SpriteBatch sb)
        {
            if(active)
            {
                sb.Draw(BulletTexture,BulletRec, BulletRec, Color.White,Angle,currentPosition,SpriteEffects.None,0);
            }
        }
    }
}
