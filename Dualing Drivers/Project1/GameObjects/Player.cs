using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Player : GameObject
    {
        private int health;
        private int speed;
        private Vector2 velocity;
        private int playerNumber;
        private float playerAngle;
        private Rectangle playerRect;
        private Texture2D playerTexture;

        public int Health { get { return health; } set { health = value; } }
        public int Speed { get { return speed; } set { speed = value; } }

        /// <summary>
        /// Basic Player Constructor
        /// </summary>
        /// <param name="texture">texture of game object</param>
        /// <param name="x">x value of position rectangle</param>
        /// <param name="y">y value of position rectangle</param>
        /// <param name="width">width of position rectangle</param>
        /// <param name="height">height of position rectangle</param>
        public Player(Texture2D texture, int x, int y, int width, int height, int health, int speed, int playerNumber, int playerAngle) : base(texture, x, y, width, height)
        {
            Health = health;
            Speed = speed;
            this.playerNumber = playerNumber;
            this.playerAngle = playerAngle;
            playerTexture = texture;
            playerRect = new Rectangle(x, y, texture.Width, texture.Height);
        }

        public void Move(int playerNumber)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.W) && playerNumber == 1)
            {
                
            }
            if (state.IsKeyDown(Keys.S) && playerNumber == 1)
            {
                
            }
            if (state.IsKeyDown(Keys.A) && playerNumber == 1)
            {
                playerAngle -= 0.5f;
            }
            if (state.IsKeyDown(Keys.D) && playerNumber == 1)
            {
                playerAngle += 0.5f;
            }
        }

        public void TakeDamage(Bullet bullet)
        {
            /*
            if (IsColliding(bullet.rect))
            {

            }
            */
            
        }

        public void Shoot()
        {
            Bullet bullet = new Bullet(texture, rect.X, rect.Y, 10, 10, 0);
        }

        public void Crash()
        {

        }

        public void Update()
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, rect, Microsoft.Xna.Framework.Color.White);
        }

    }
}
