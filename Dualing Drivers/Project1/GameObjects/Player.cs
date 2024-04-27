using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Managers.PlayerManager;
using static System.Windows.Forms.AxHost;

namespace Project1
{

    internal class Player : GameObject
    {
        // event
        public event Action<Bullet, Player> OnShoot;

        // fields
        private int health;
        private float speed;
        private int damage;
        private Vector2 playerPosition;
        private Vector2 playerCrashedPosition;
        private float playerAngle;
        private float playerCrashedAngle;
        private Rectangle playerRect;
        private Texture2D playerTexture;
        private Texture2D bulletTexture;
        private Texture2D crashed;
        private Dictionary<string, Keys> playerControl;
        private Dictionary<string, Microsoft.Xna.Framework.Input.Buttons> controllerControl;
        private KeyboardState previousKB;
        private GamePadState previousGB;
        private int reloadNum = 100;
        private int currentBulletNum = 3;
        private int maxBulletNum = 3;
        private bool reload;
        private bool moving = false;

        // properties
        public float PlayerAngle { get { return playerAngle; } set { playerAngle = value; } }
        public int Health { get { return health; } set { health = value; } }
        public int Ammo { get { return currentBulletNum; } }
        public int MaxAmmo { get { return maxBulletNum; } set { maxBulletNum = value; } }
        public float Speed { get { return speed; } set { speed = value; } }
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
        public Player(Texture2D texture, int x, int y, int width, int height, int health, float speed, int damage, int playerAngle, Vector2 playerPosition, Dictionary<string, Keys> playerControl, Texture2D bulletTexture, Texture2D crashed) : base(texture, x, y, width, height)
        {
            Health = health;
            Speed = speed;
            this.damage = damage;
            this.playerPosition = playerPosition;
            currentBulletNum = maxBulletNum;
            this.playerAngle = playerAngle;
            playerTexture = texture;
            this.crashed = crashed;
            PlayerRect = new Rectangle((int)(playerPosition.X - texture.Width / 2), (int)(playerPosition.Y - texture.Height / 2), texture.Width, texture.Height);
            this.playerControl = playerControl;
            this.bulletTexture = bulletTexture;
        }
        

        /// <summary>
        /// method to move the player
        /// </summary>
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
                playerAngle -= (float)(4);
            }
            if (state.IsKeyDown(playerControl["Right"]))
            {
                playerAngle += (float)(4);
            }
            //controller control   
        }
        
        /// <summary>
        /// method to move the player using a controler
        /// </summary>
        /// <param name="gb">gamepad state to direct movement</param>
        public void Move(GamePadState gb)
        {
                if (gb.ThumbSticks.Left.Y > 0.1)
                {
                    playerPosition.X += speed * (float)Math.Cos(MathHelper.ToRadians(playerAngle));
                    playerPosition.Y += speed * (float)Math.Sin(MathHelper.ToRadians(playerAngle));
                }
                else if (gb.ThumbSticks.Left.Y < -0.1)
                {
                    playerPosition.X -= speed * (float)Math.Cos(MathHelper.ToRadians(playerAngle));
                    playerPosition.Y -= speed * (float)Math.Sin(MathHelper.ToRadians(playerAngle));
                }
                if (gb.ThumbSticks.Right.X < -0.1)
                {
                    //turns at a base speed of 3 + half of the speed buff, if a player has one
                    playerAngle -= (float)(4);
                }
                else if (gb.ThumbSticks.Right.X > 0.1)
                {
                    //turns at a base speed of 3 + half of the speed buff, if a player has one
                    playerAngle += (float)(4);
                }
        }

        public void moveC(GamePadState gb)
        {
           
            if (gb.IsConnected)
            {
                float leftThumbX = gb.ThumbSticks.Left.X;
                float leftThumbY = gb.ThumbSticks.Left.Y;
                double degrees = Math.Atan2(leftThumbX, leftThumbY) * (180 / Math.PI);
                degrees = (degrees + 360) % 360 - 90;
                if (Math.Abs(leftThumbX) > 0.1 || Math.Abs(leftThumbY) > 0.1)
                {
                    double angleDifference = degrees - playerAngle;
                    if (angleDifference > 180)
                    {
                        angleDifference -= 360;
                    }
                    else if (angleDifference < -180)
                    {
                        angleDifference += 360;
                    }

                    if (angleDifference > 0)
                    {
                        playerAngle += 4f;
                    }
                    else if (angleDifference < 0)
                    {
                        playerAngle -= 4f;
                    }

                    if (moving)
                    {
                        playerPosition.X += speed * (float)Math.Cos(MathHelper.ToRadians(playerAngle));
                        playerPosition.Y += speed * (float)Math.Sin(MathHelper.ToRadians(playerAngle));
                    }


                    if (angleDifference < 5 && angleDifference > -5)
                    {
                        speed = 2;
                    }
                    else if (angleDifference < 90 && angleDifference > -90)
                    {
                        moving = true;
                        speed = 1;
                    }

                }
                else
                {
                    moving = false;
                }
            }
            
        }

        /// <summary>
        /// method to take damage
        /// </summary>
        /// <param name="player"></param>
        public void TakeDamage(Player player)
        {
            player.Health -= damage;
        }

        /// <summary>
        /// method to shoot bullets
        /// </summary>
        public void Shoot()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(playerControl["Shoot"]) && previousKB.IsKeyUp(playerControl["Shoot"]) && currentBulletNum > 0)
            {
                Bullet bullet = new Bullet(bulletTexture, (int)this.playerPosition.X, (int)playerPosition.Y, 10, 10, playerAngle);
                OnShoot?.Invoke(bullet, this);
                currentBulletNum--;
            }
        }

        /// <summary>
        /// method to shoot bullets with a controller
        /// </summary>
        public void Shoot(GamePadState gb, GamePadState prev)
        {
            if (((gb.Buttons.A == ButtonState.Pressed && prev.Buttons.A == ButtonState.Released) || (gb.Triggers.Right > 0.2 && prev.Triggers.Right < 0.2)) && currentBulletNum > 0)
            {
                Bullet bullet = new Bullet(bulletTexture, (int)this.playerPosition.X, (int)playerPosition.Y, 10, 10, playerAngle);
                OnShoot?.Invoke(bullet, this);
                currentBulletNum--;
            }
        }

       

        /// <summary>
        /// method to judge if the tank is destroyed
        /// </summary>
        /// <returns></returns>
        public bool IsPlayerCrash()
        {
            if (Health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// method to update player
        /// </summary>
        public void Update()
        {
            if (playerAngle < 0)
            {
                playerAngle += 360;
            }
            playerAngle = playerAngle % 360;
            this.playerRect.X = (int)(playerPosition.X - playerRect.Width / 2);
            this.playerRect.Y = (int)(playerPosition.Y - playerRect.Height / 2);
            if (currentBulletNum < maxBulletNum)
            {
                reload = true;
            }
            else if (currentBulletNum == maxBulletNum)
            {
                reload = false;
            }
            if (reload && reloadNum > 0)
            {
                reloadNum--;
            }
            if (reloadNum <= 0)
            {
                currentBulletNum += 1;
                reloadNum = 100;
            }

            previousKB = Keyboard.GetState();
            previousGB = GamePad.GetState(PlayerIndex.One);
        }

        /// <summary>
        /// method to draw player
        /// </summary>
        /// <param name="sb"></param>
        public override void Draw(SpriteBatch sb)
        {
            Vector2 origin = new Vector2(playerRect.Width / 2f, playerRect.Height / 2f);
            if (!IsPlayerCrash())
            {
                sb.Draw(playerTexture, PlayerPosition, null, Color.White, playerAngle * (float)Math.PI / 180, origin, new Vector2(1, 1), SpriteEffects.None, 1);
            }
            else
            {
                sb.Draw(crashed, PlayerPosition, null, Color.White, playerAngle * (float)Math.PI / 180, origin, new Vector2(1, 1), SpriteEffects.None, 1);
            }

        }



        /// <summary>
        /// method to avoid two tanks can go through each other
        /// </summary>
        /// <param name="player"></param>
        public void BlockPlayer(Player player)
        {
            // finds where the objects overlap
            Microsoft.Xna.Framework.Rectangle overlap =
                Microsoft.Xna.Framework.Rectangle.Intersect(this.PlayerRect, player.PlayerRect);

            // moves player horizontally left or right
            // from conflicting player
            if (overlap.Height >= overlap.Width)
            {
                if (this.PlayerRect.X > player.PlayerRect.X)
                {
                    Vector2 vector2 = new Vector2(player.PlayerPosition.X, player.PlayerPosition.Y);
                    vector2.X -= overlap.Width;
                    player.PlayerPosition = vector2;
                }
                else if (this.PlayerRect.X < player.PlayerRect.X)
                {
                    Vector2 vector2 = new Vector2(player.PlayerPosition.X, player.PlayerPosition.Y);
                    vector2.X += overlap.Width;
                    player.PlayerPosition = vector2;
                }
            }

            // moves player vertically up or down
            // from conflicting player
            if (overlap.Width >= overlap.Height)
            {
                if (this.PlayerRect.Y > player.PlayerRect.Y)
                {
                    Vector2 vector2 = new Vector2(player.PlayerPosition.X, player.PlayerPosition.Y);
                    vector2.Y -= overlap.Height;
                    player.PlayerPosition = vector2;
                }
                else if (this.PlayerRect.Y < player.PlayerRect.Y)
                {
                    Vector2 vector2 = new Vector2(player.PlayerPosition.X, player.PlayerPosition.Y);
                    vector2.Y += overlap.Height;
                    player.PlayerPosition = vector2;
                }
            }
        }

    }
}

