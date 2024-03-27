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
        public event Action<Bullet, Player> OnShoot;

        private int health;
        private int speed;
        private int damage;
        private Vector2 playerPosition;
        private float playerAngle;
        private Rectangle playerRect;
        private Texture2D playerTexture;
        private Texture2D bulletTexture;
        private Dictionary<string, Keys> playerControl;
        private KeyboardState previousKB;
        private int reloadNum = 0;
        private int bulletNum = 5;
        private bool reload;

        
        public float PlayerAngle { get { return playerAngle; } set { playerAngle = value; } }
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
        public Player(Texture2D texture, int x, int y, int width, int height, int health, int speed, int damage, int playerAngle, Vector2 playerPosition, Dictionary<string, Keys> playerControl, Texture2D bulletTexture) : base(texture, x, y, width, height)
        {
            Health = health;
            Speed = speed;
            this.damage = damage;
            this.playerPosition = playerPosition;
            this.playerAngle = playerAngle;
            playerTexture = texture;
            PlayerRect = new Rectangle((int)(playerPosition.X - texture.Width / 2), (int)(playerPosition.Y - texture.Height / 2), texture.Width, texture.Height);
            this.playerControl = playerControl;
            this.bulletTexture = bulletTexture;
        }

        public override void Move()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(playerControl["Up"]))
            {
                playerPosition.X += speed * (float)Math.Cos(MathHelper.ToRadians(playerAngle));
                playerPosition.Y += speed * (float)Math.Sin(MathHelper.ToRadians(playerAngle));
            }
            if (state.IsKeyDown(playerControl["Down"]))
            {
                playerPosition.X -= speed * (float)Math.Cos(MathHelper.ToRadians(playerAngle));
                playerPosition.Y -= speed * (float)Math.Sin(MathHelper.ToRadians(playerAngle));
            }
            if (state.IsKeyDown(playerControl["Left"]))
            {
                playerAngle -= 1f;
            }
            if (state.IsKeyDown(playerControl["Right"]))
            {
                playerAngle += 1f;
            }
        }

        public void TakeDamage(Player player)
        {
            player.Health -= damage;
        }

        public void Shoot()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(playerControl["Shoot"]) && previousKB.IsKeyUp(playerControl["Shoot"]) && bulletNum > 0)
            {
                Bullet bullet = new Bullet(bulletTexture, (int)this.playerPosition.X - 20, (int)playerPosition.Y - 20, 10, 10, playerAngle);
                OnShoot?.Invoke(bullet,this);
                bulletNum--;
            }
            if (bulletNum <= 0 && reload == false)
            {
                reloadNum = 100;
                reload = true;
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
            if (playerAngle < 0)
            {
                playerAngle += 360;
            }
            playerAngle = playerAngle % 360;
            this.playerRect.X = (int)(playerPosition.X - playerRect.Width / 2);
            this.playerRect.Y = (int)(playerPosition.Y - playerRect.Height / 2);
            Move();
            Shoot();
            previousKB = Keyboard.GetState();
            if (reload == true)
            {
                reloadNum--;
            }
            if (reloadNum <= 0)
            {
                reload = false;
            }
            if (bulletNum <= 0 && reload == false)
            {
                bulletNum += 5;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            Vector2 origin = new Vector2(playerTexture.Width / 2f, playerTexture.Height / 2f);
            sb.Draw(playerTexture, PlayerRect, null, Color.White, playerAngle * (float)Math.PI / 180, origin, SpriteEffects.None, 1);
        }

    }
}
