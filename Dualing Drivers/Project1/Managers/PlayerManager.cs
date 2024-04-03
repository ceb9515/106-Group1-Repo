using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Managers
{
    internal class PlayerManager
    {
        // fields
        Player player1;
        Player player2;
        Texture2D playerCrash1;
        Texture2D playerCrash2;
        Player crash1;
        Player crash2;

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

        public Dictionary<string, Keys> playerCrashControls = new Dictionary<string, Keys>
        {
                {"Up", Keys.F1},
                {"Down", Keys.F2},
                {"Left", Keys.F3},
                {"Right", Keys.F4},
                {"Shoot", Keys.F5}
        };

        // properties
        private List<Player> playerList;
        public List<Player> PlayerList { get { return playerList; } }

        /// <summary>
        /// Basic Player Manager Constructor
        /// </summary>
        public PlayerManager(Texture2D playerCrash1, Texture2D playerCrash2)
        {
            playerList = new List<Player>();
            this.playerCrash1 = playerCrash1;
            this.playerCrash2 = playerCrash2;
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
        /// method to check if player is dead
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        /*public bool IsPlayerCrash(Player player)
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
        */


        /// <summary>
        /// method to update all players in the player list
        /// </summary>
        public void Update()
        {
            foreach (Player player in playerList)
            {
                player.Update();
                
            }
            /*
            if (IsPlayerCrash(player1))
            {
                crash1 = new Player(playerCrash1, (int)player1.PlayerPosition.X, (int)player1.PlayerPosition.Y, 40, 40, 1000000000, 0, 0, (int)player1.PlayerAngle, player1.PlayerPosition, playerCrashControls, playerCrash2);
            }
            if (IsPlayerCrash(player2))
            {
                crash2 = new Player(playerCrash1, (int)player2.PlayerPosition.X, (int)player2.PlayerPosition.Y, 40, 40, 1000000000, 0, 0, (int)player2.PlayerAngle, player2.PlayerPosition, playerCrashControls, playerCrash2);
            }
            */
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerCrash1, crash1.PlayerPosition, Color.White);
            spriteBatch.Draw(playerCrash2, crash2.PlayerPosition, Color.White);
        }

        




    }
}
