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
        Player player1;
        Player player2;
        public Dictionary<string, Keys> player1Controls = new Dictionary<string, Keys>
        {
                {"Up", Keys.W},
                {"Down", Keys.S},
                {"Left", Keys.A},
                {"Right", Keys.D},
                {"Shoot", Keys.Space}
        };
        public Dictionary<string, Keys> player2Controls = new Dictionary<string, Keys>
        {
                {"Up", Keys.Up},
                {"Down", Keys.Down},
                {"Left", Keys.Left},
                {"Right", Keys.Right},
                {"Shoot", Keys.RightControl}
        };

        private List<Player> playerList;
        public List<Player> PlayerList { get { return playerList; } }

        public PlayerManager(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            playerList = new List<Player>
            {
                player1,
                player2
            };
        }


        public void Update()
        {
            player1.Update();
            player2.Update();
        }

        




    }
}
