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


        public PlayerManager(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
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
