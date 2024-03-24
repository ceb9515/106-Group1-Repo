﻿using Microsoft.Xna.Framework;
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

        public PlayerManager()
        {
            playerList = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }

        public void Update()
        {
            foreach (Player player in playerList)
            {
                player.Update();
            }
        }

        




    }
}
