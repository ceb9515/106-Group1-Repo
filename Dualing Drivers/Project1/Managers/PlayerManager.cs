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
        Dictionary<string, Keys> player1Controls;
        Dictionary<string, Keys> player2Controls;

        public PlayerManager(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;

            player1Controls = new Dictionary<string, Keys>
            {
                {"Up", Keys.W},
                {"Down", Keys.S},
                {"Left", Keys.A},
                {"Right", Keys.D}
            };

            player2Controls = new Dictionary<string, Keys>
            {
                {"Up", Keys.Up},
                {"Down", Keys.Down},
                {"Left", Keys.Left},
                {"Right", Keys.Right}
            };
        }


        /*
        public void Update()
        {
            player1.Move(player1);
            player2.Move(player2);
            player1.Update();
            player2.Update();
        }
        */

        




    }
}
