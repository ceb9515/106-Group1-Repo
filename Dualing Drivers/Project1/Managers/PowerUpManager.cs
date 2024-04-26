using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Managers
{
    internal class PowerUpManager
    {
        // fields
        private List<PowerUp> powerUps;
        private Texture2D ammoTexture;
        private Texture2D healthTexture;
        private Texture2D speedTexture;

        // constructor

        /// <summary>
        /// creates a power up manager
        /// </summary>
        /// <param name="health">health texture</param>
        /// <param name="speed">speed texture</param>
        /// <param name="ammo">ammo texture</param>
        public PowerUpManager(Texture2D health, Texture2D speed, Texture2D ammo)
        {
            powerUps = new List<PowerUp>();
            healthTexture = health;
            ammoTexture = ammo;
            speedTexture = speed;
        }

        // methods

        /// <summary>
        /// clears power ups
        /// </summary>
        public void Clear()
        {
            powerUps.Clear();

        }
            /// <summary>
            /// loads power ups 
            /// </summary>
            /// <param name="powerUpInfo">string info on each power up</param>
            public void LoadPowerUps(List<string> powerUpInfo)
        {
            powerUps.Clear();
            string[] rowData;

            // goes through ever string in powerUpInfo
            for (int x = 0; x < powerUpInfo.Count; x++)
            {
                // splits each string
                rowData = powerUpInfo[x].Split("|");

                // creates new power up and adds to power up list
                // based on its type
                if (rowData[0] == "ammo")
                {
                    powerUps.Add(new PowerUp(ammoTexture, int.Parse(rowData[1]) * 40 + 220,
                        int.Parse(rowData[2]) * 40 + 20, 40, 40, PowerUp.PowerUpType.ammo));
                }
                else if (rowData[0] == "health")
                {
                    powerUps.Add(new PowerUp(healthTexture, int.Parse(rowData[1]) * 40 + 220,
                        int.Parse(rowData[2]) * 40 + 20, 40, 40, PowerUp.PowerUpType.health));
                }
                else if (rowData[0] == "speed")
                {
                    powerUps.Add(new PowerUp(speedTexture, int.Parse(rowData[1]) * 40 + 220,
                        int.Parse(rowData[2]) * 40 + 20, 40, 40, PowerUp.PowerUpType.speed));
                }
            }
        }

        /// <summary>
        /// gets list of all power ups
        /// </summary>
        /// <returns>all power ups</returns>
        public List<PowerUp> GetPowerUps()
        {
            return powerUps;
        }

        /// <summary>
        /// draws the power ups to the screen
        /// </summary>
        /// <param name="sb">sprite batch to draw with</param>
        public void DrawPowerUps(SpriteBatch sb)
        {
            foreach (PowerUp powerUp in powerUps)
            {
                if (powerUp.Active)
                {
                    powerUp.Draw(sb);
                }
            }
        }
    }
}
