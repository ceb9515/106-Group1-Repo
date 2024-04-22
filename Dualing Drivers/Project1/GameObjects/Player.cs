﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Managers.PlayerManager;

namespace Project1
{

    internal class Player : GameObject
    {
        // event
        public event Action<Bullet, Player> OnShoot;

        // fields
        private int health;
        private int speed;
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
        private int reloadNum = 0;
        private int bulletNum = 3;
        private bool reload;
        private bool moving = false;

        // properties
        public float PlayerAngle { get { return playerAngle; } set { playerAngle = value; } }
        public int Health { get { return health; } set { health = value; } }
        public int Ammo { get { return bulletNum; } set { bulletNum = value; } }
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
        public Player(Texture2D texture, int x, int y, int width, int height, int health, int speed, int damage, int playerAngle, Vector2 playerPosition, Dictionary<string, Microsoft.Xna.Framework.Input.Buttons> controllercontrol, Texture2D bulletTexture, Texture2D crashed) : base(texture, x, y, width, height)
        {
            Health = health;
            Speed = speed;
            this.damage = damage;
            this.playerPosition = playerPosition;
            this.playerAngle = playerAngle;
            playerTexture = texture;
            this.crashed = crashed;
            PlayerRect = new Rectangle((int)(playerPosition.X - texture.Width / 2), (int)(playerPosition.Y - texture.Height / 2), texture.Width, texture.Height);
            this.controllerControl = controllercontrol;
            this.bulletTexture = bulletTexture;
        }
        public Player(Texture2D texture, int x, int y, int width, int height, int health, int speed, int damage, int playerAngle, Vector2 playerPosition, Dictionary<string, Keys> playerControl, Texture2D bulletTexture, Texture2D crashed) : base(texture, x, y, width, height)
        {
            Health = health;
            Speed = speed;
            this.damage = damage;
            this.playerPosition = playerPosition;
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
            KeyboardState state = Keyboard.GetState(PlayerIndex.One);
            
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
                playerAngle -= 2f;
            }
            if (state.IsKeyDown(playerControl["Right"]))
            {
                playerAngle += 2f;
            }
            //controller control
            

            
        }
        public void moveC()
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.Two);
            float leftThumbX = gamePadState.ThumbSticks.Left.X;
            float leftThumbY = gamePadState.ThumbSticks.Left.Y;
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
                    playerAngle += 2f;
                }
                else if (angleDifference < 0)
                {
                    playerAngle -= 2f;
                }

                if (moving == true && angleDifference < 15 && angleDifference > -15)
                {
                    playerPosition.X += speed * leftThumbX;
                    playerPosition.Y -= speed * leftThumbY;
                }
                else if (angleDifference < 10 && angleDifference > -10)
                {
                    moving = true;
                    playerPosition.X += speed * leftThumbX;
                    playerPosition.Y -= speed * leftThumbY;
                }

            }
            else
            {
                moving = false;
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
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.Two);
            if (state.IsKeyDown(playerControl["Shoot"]) && previousKB.IsKeyUp(playerControl["Shoot"]) && bulletNum > 0)
            {
                Bullet bullet = new Bullet(bulletTexture, (int)this.playerPosition.X, (int)playerPosition.Y, 10, 10, playerAngle);
                OnShoot?.Invoke(bullet, this);
                bulletNum--;
            }
            
            if (bulletNum <= 0 && reload == false)
            {
                reloadNum = 100;
                reload = true;
            }
        }
        public void ShootC()
        {
            KeyboardState state = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.Two);
            if (gamePadState.Buttons.A == ButtonState.Pressed && previousGB.Buttons.A == ButtonState.Released && bulletNum > 0)
            {
                Bullet bullet = new Bullet(bulletTexture, (int)this.playerPosition.X, (int)playerPosition.Y, 10, 10, playerAngle);
                OnShoot?.Invoke(bullet, this);
                bulletNum--;
            }
            if (bulletNum <= 0 && reload == false)
            {
                reloadNum = 50;
                reload = true;
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
                bulletNum += 1;
            }

            previousKB = Keyboard.GetState();
            previousGB = GamePad.GetState(PlayerIndex.Two);
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

