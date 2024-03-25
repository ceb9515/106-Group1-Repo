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
            this.Active = true;
           
        }
        
        public void moveBullet()
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
        /// <summary>
        /// draw the bullet itself
        /// </summary>
        /// <param name="sb"></param>
        public override void Draw(SpriteBatch sb)
        {
            if(this.Active)
            {
                Vector2 origin = new Vector2(BulletTexture.Width / 2f, BulletTexture.Height / 2f);
                sb.Draw(BulletTexture,BulletRec, null, Color.White, (float)(MathHelper.ToRadians(Angle)), origin,SpriteEffects.None, 1);
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
