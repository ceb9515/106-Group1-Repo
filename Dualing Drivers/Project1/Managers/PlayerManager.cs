using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Managers
{
    internal class PlayerManager
    {
        // fields
        Player player1;
        Player player2;

        /// <summary>
        /// Dictionary of player 1 controls
        /// </summary>
        public Dictionary<string, Keys> player1Controls = new Dictionary<string, Keys>
        {
                {"Up", Keys.W},
                {"Down", Keys.S},
                {"Left", Keys.A},
                {"Right", Keys.D},
                {"Shoot", Keys.Space}
        };

        /// <summary>
        /// Dictionary of player 2 controls
        /// </summary>
        public Dictionary<string, Keys> player2Controls = new Dictionary<string, Keys>
        {
                {"Up", Keys.Up},
                {"Down", Keys.Down},
                {"Left", Keys.Left},
                {"Right", Keys.Right},
                {"Shoot", Keys.RightControl}
        };

        // properties
        private List<Player> playerList;
        public List<Player> PlayerList { get { return playerList; } }

        /// <summary>
        /// Basic Player Manager Constructor
        /// </summary>
        public PlayerManager()
        {
            playerList = new List<Player>();
        }

        /// <summary>
        /// method to add a player to the player list
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }

        /// <summary>
        /// method to update all players in the player list
        /// </summary>
        public void Update()
        {
            foreach (Player player in playerList)
            {
                player.Update();
            }
        }

        




    }
}
