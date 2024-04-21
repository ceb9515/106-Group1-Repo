﻿using Microsoft.Xna.Framework.Graphics;
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
        public bool Active { get { return active; } }

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
            if (player.PlayerRect.Intersects(this.rect))
            {
                if (this.type == PowerUpType.health)
                {
                    // gives player health
                    player.Health += 3;
                }
                else if (this.type == PowerUpType.ammo)
                {
                    // increase max ammo
                }
                else if (this.type == PowerUpType.speed)
                {
                    // increase player speed
                    player.Speed += 1;
                }
            }
        }
       
    }
}
