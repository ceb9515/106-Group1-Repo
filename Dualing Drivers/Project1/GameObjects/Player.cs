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
    internal class Player : GameObject
    {
        public event Action<Bullet> OnShoot;

        private int health;
        private int speed;
        private int damage;
        private Vector2 playerPosition;
        private float playerAngle;
        private Rectangle playerRect;
        private Texture2D playerTexture;
        private Dictionary<string, Keys> playerControl;
        

        public int Health { get { return health; } set { health = value; } }
        public int Speed { get { return speed; } set { speed = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public Rectangle PlayerRect { get { return playerRect; } set { playerRect = value; } }
        public Vector2 PlayerPosition { get { return playerPosition; } set { playerPosition = value; } }

        /// <summary>
        /// Basic Player Constructor
        /// </summary>
        /// <param name="texture">texture of game object</param>
        /// <param name="x">x value of position rectangle</param>
        /// <param name="y">y value of position rectangle</param>
        /// <param name="width">width of position rectangle</param>
        /// <param name="height">height of position rectangle</param>
        public Player(Texture2D texture, int x, int y, int width, int height, int health, int speed, int damage, int playerAngle, Vector2 playerPosition, Dictionary<string, Keys> playerControl) : base(texture, x, y, width, height)
        {
            Health = health;
            Speed = speed;
            this.damage = damage;
            this.playerPosition = playerPosition;
            this.playerAngle = playerAngle;
            playerTexture = texture;
            PlayerRect = new Rectangle(x, y, texture.Width, texture.Height);
            this.playerControl = playerControl;
        }

        public override void Move()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(playerControl["Up"]))
            {
                if (playerAngle < 0 && playerAngle> 90)
                {
                    playerPosition.X += speed * (float)Math.Cos(playerAngle * (float)Math.PI / 180);
                    playerPosition.Y += speed * (float)Math.Sin(playerAngle * (float)Math.PI / 180);
                }
                if (playerAngle > 90 && playerAngle < 180)
                {
                    playerPosition.X -= speed * (float)Math.Cos(180 - playerAngle * (float)Math.PI / 180);
                    playerPosition.Y += speed * (float)Math.Sin(180 - playerAngle * (float)Math.PI / 180);
                }
                if (playerAngle > 180 && playerAngle < 270)
                {
                    playerPosition.X -= speed * (float)Math.Cos(270 - playerAngle * (float)Math.PI / 180);
                    playerPosition.Y -= speed * (float)Math.Sin(270 - playerAngle * (float)Math.PI / 180);
                }
                if (playerAngle > 270 && playerAngle < 360)
                {
                    playerPosition.X += speed * (float)Math.Cos(360 - playerAngle * (float)Math.PI / 180);
                    playerPosition.Y -= speed * (float)Math.Sin(360 - playerAngle * (float)Math.PI / 180);
                }
            }
            if (state.IsKeyDown(playerControl["Down"]))
            {
                if (playerAngle < 0 && playerAngle > 90)
                {
                    playerPosition.X -= speed * (float)Math.Cos(playerAngle * (float)Math.PI / 180);
                    playerPosition.Y -= speed * (float)Math.Sin(playerAngle * (float)Math.PI / 180);
                }
                if (playerAngle > 90 && playerAngle < 180)
                {
                    playerPosition.X += speed * (float)Math.Cos(180 - playerAngle * (float)Math.PI / 180);
                    playerPosition.Y -= speed * (float)Math.Sin(180 - playerAngle * (float)Math.PI / 180);
                }
                if (playerAngle > 180 && playerAngle < 270)
                {
                    playerPosition.X += speed * (float)Math.Cos(270 - playerAngle * (float)Math.PI / 180);
                    playerPosition.Y += speed * (float)Math.Sin(270 - playerAngle * (float)Math.PI / 180);
                }
                if (playerAngle > 270 && playerAngle < 360)
                {
                    playerPosition.X -= speed * (float)Math.Cos(360 - playerAngle * (float)Math.PI / 180);
                    playerPosition.Y += speed * (float)Math.Sin(360 - playerAngle * (float)Math.PI / 180);
                }
            }
            if (state.IsKeyDown(playerControl["Left"]))
            {
                playerAngle -= 0.5f;
            }
            if (state.IsKeyDown(playerControl["Right"]))
            {
                playerAngle += 0.5f;
            }
        }

        public void TakeDamage(Player player)
        {
            player.Health -= damage;
        }

        public void Shoot()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(playerControl["Shoot"]))
            {
                Bullet bullet = new Bullet(texture, (int)this.playerPosition.X, (int)this.playerPosition.Y, 10, 10, 0);
                OnShoot?.Invoke(bullet);
            }
        }

        public bool IsPlayerCrash(Player player)
        {
            if (player.Health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update()
        {
            playerAngle = playerAngle % 360;
            this.playerRect.X = (int)(playerPosition.X - playerRect.Width / 2);
            this.playerRect.Y = (int)(playerPosition.Y - playerRect.Height / 2);
            Move();
            Shoot();
            
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(playerTexture, playerRect, playerRect, Color.White, playerAngle * (float)Math.PI / 180, playerPosition, SpriteEffects.None, 0);
        }

    }
}
