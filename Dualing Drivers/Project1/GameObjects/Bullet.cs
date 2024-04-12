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
        private int Speed = 7;
        private Vector2 activePosition;
        private Vector2 currentPosition;
        
        
        

        /// <summary>
        /// property
        /// </summary>
        public Microsoft.Xna.Framework.Rectangle Bulletrec 
        {
        get { return BulletRec; }set { BulletRec = value; }
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
            this.currentPosition = this.activePosition;
            BulletRec = new Microsoft.Xna.Framework.Rectangle ((int)(currentPosition.X - BulletRec.Width / 2), (int)(currentPosition.Y - BulletRec.Height / 2), BulletTexture.Width,BulletTexture.Height);
            this.Active = true;
           
        }
        
        public void moveBullet()
        {
            // Calculate new position
            float deltaX = Speed * (float)Math.Cos(MathHelper.ToRadians(Angle));
            float deltaY = Speed * (float)Math.Sin(MathHelper.ToRadians(Angle));

            // Update the BulletRec position
            currentPosition.X += deltaX;
            currentPosition.Y += deltaY;
            BulletRec.X = (int)(currentPosition.X - BulletRec.Width / 2);
            BulletRec.Y = (int)(currentPosition.Y - BulletRec.Height / 2);
        }
        /// <summary>
        /// draw the bullet itself
        /// </summary>
        /// <param name="sb"></param>
        public override void Draw(SpriteBatch sb)
        {
            if(this.Active)
            {
                Vector2 origin = new Vector2(BulletTexture.Width / 2f, BulletTexture.Height / 2f);
                sb.Draw(BulletTexture, currentPosition, null, Color.White, (float)(MathHelper.ToRadians(Angle)), origin, new Vector2(1, 1), SpriteEffects.None, 1);
            }
        }

        public override bool IsColliding(Rectangle rectangle)
        {
            if (this.BulletRec.Intersects(rectangle))
            {
                return true;
            }
            else { return false; }
        }
    }
}
