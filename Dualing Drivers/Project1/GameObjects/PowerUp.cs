using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class PowerUp : GameObject
    {
        public enum PowerUpType
        {
            health,
            speed,
            ammo
        }

        // fields
        private PowerUpType type;
        private bool active;

        // properties
        
        /// <summary>
        /// gets active status of power up
        /// </summary>
        public bool Active { get { return active; } set { active = value; } }

        // constructor

        /// <summary>
        /// Basic PowerUp Constructor
        /// </summary>
        /// <param name="texture">texture of game object</param>
        /// <param name="x">x value of position rectangle</param>
        /// <param name="y">y value of position rectangle</param>
        /// <param name="width">width of position rectangle</param>
        /// <param name="height">height of position rectangle</param>
        public PowerUp(Texture2D texture, int x, int y, int width, int height, PowerUpType type) 
            : base(texture, x, y, width, height)
        {
            this.type = type;
            active = true;
        }

        // methods

        /// <summary>
        /// power ups the player based on power up type
        /// </summary>
        /// <param name="player">player who picked up power up</param>
        public void PowerUpPlayer(Player player)
        {
            if (player.PlayerRect.Intersects(this.rect) && this.Active)
            {
                if (this.type == PowerUpType.health)
                {
                    // gives player 3 health or sets their health to 5
                    if (player.Health + 3 <= 5)
                    {
                        player.Health += 3;
                    }
                    else
                    {
                        player.Health = 5;
                    }
                }
                else if (this.type == PowerUpType.speed)
                {
                    // increase player speed
                    if(player.Speed < 3.8f)
                    {
                        player.Speed = 3.8f;
                    }
                    else if (player.Speed < 4.3f)
                    {
                        player.Speed = 4.3f;
                    }

                }
                else if (this.type == PowerUpType.ammo)
                {
                    // increase player's max ammo
                    player.MaxAmmo = 5;
                }
                this.active = false;
            }
        }

       
    }
}
