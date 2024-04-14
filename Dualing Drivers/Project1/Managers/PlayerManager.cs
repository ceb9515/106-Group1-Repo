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

        public Player Player1 { get { return player1; } }
        public Player Player2 { get { return player2; } }

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
        public PlayerManager(Texture2D playerText1, Texture2D playerText2, Vector2 player1Position, Vector2 player2Position, Texture2D bulletTexture, Texture2D playerCrashedText1, Texture2D playerCrashedText2)
        {
            playerList = new List<Player>();
            player1 = new Player(playerText1, 320, 360, 40, 40, 5, 2, 1, 0, player1Position, player1Controls, bulletTexture, playerCrashedText1);
            player2 = new Player(playerText2, 960, 360, 40, 40, 5, 2, 1, 180, player2Position, player2Controls, bulletTexture, playerCrashedText2);
            playerList.Add(player1);
            playerList.Add(player2);
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
            PlayerList[0].BlockPlayer(PlayerList[1]);
            PlayerList[1].BlockPlayer(PlayerList[0]);
        }
    }
}