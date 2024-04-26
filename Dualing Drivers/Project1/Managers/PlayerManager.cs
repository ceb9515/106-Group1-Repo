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
        private bool player1Control;
        private bool player2Control;
        GamePadState gamePadState1 = GamePad.GetState(PlayerIndex.One);
        GamePadState gamePadState2 = GamePad.GetState(PlayerIndex.Two);
        GamePadState prevGamePadState1 = GamePad.GetState(PlayerIndex.One);
        GamePadState prevGamePadState2 = GamePad.GetState(PlayerIndex.Two);
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
        
        public Dictionary<string, Microsoft.Xna.Framework.Input.Buttons> controllerControl = new Dictionary<string, Microsoft.Xna.Framework.Input.Buttons>
        {
            {"Up", Microsoft.Xna.Framework.Input.Buttons.LeftThumbstickUp},
            {"Down", Microsoft.Xna.Framework.Input.Buttons.LeftThumbstickDown},
            {"Left", Microsoft.Xna.Framework.Input.Buttons.RightThumbstickUp},
            {"Right", Microsoft.Xna.Framework.Input.Buttons.RightThumbstickDown},
            // Add more controls as needed
        };


        // properties
        private List<Player> playerList;
        public List<Player> PlayerList { get { return playerList; } }

        private List<PowerUp> powerUpList;

        /// <summary>
        /// Basic Player Manager Constructor
        /// </summary>
        public PlayerManager(Texture2D playerText1, Texture2D playerText2, Microsoft.Xna.Framework.Vector2 player1Position, Microsoft.Xna.Framework.Vector2 player2Position, Texture2D bulletTexture, Texture2D playerCrashedText1, Texture2D playerCrashedText2, List<PowerUp> powerUps,bool player1C,bool player2C)
        {
            playerList = new List<Player>();
            player1 = new Player(playerText1, 320, 360, 40, 40, 3, 2.8f, 1, 0, player1Position, player1Controls, bulletTexture, playerCrashedText1);
            player2 = new Player(playerText2, 960, 360, 40, 40, 3, 2.8f, 1, 180, player2Position, player2Controls, bulletTexture, playerCrashedText2);

            player1Control = player1C;
            player2Control = player2C;
            playerList.Add(player1);
            playerList.Add(player2);
            this.powerUpList = powerUps;
        }

        /// <summary>
        /// method to update all players in the player list
        /// </summary>
        public void Update()
        {
            gamePadState1 = GamePad.GetState(PlayerIndex.One);
            gamePadState2 = GamePad.GetState(PlayerIndex.Two);

            //old player movement code
            /*
             if (gamePadState1.IsConnected&& gamePadState2.IsConnected)
             {
                 player2.moveC(gamePadState2);
                 player2.Shoot(gamePadState2, prevGamePadState2);
                 player1.moveC(gamePadState1);    
                 player1.Shoot(gamePadState1, prevGamePadState1);
             }
             else if (gamePadState1.IsConnected&&!gamePadState2.IsConnected)
             {
                 player2.moveC(gamePadState1);
                 player2.Shoot(gamePadState1, prevGamePadState1);
                 player1.Move();
                 player1.Shoot();

             }
             else if(!gamePadState1.IsConnected)
             {
                 player1.Move();
                 player1.Shoot();
                 player2.Move();
                 player2.Shoot();
             }
            */

            //UPDATED MOVEMENT CODE
            //if there's a gamepad1, update using that
            if (gamePadState1.IsConnected&&player1Control)
            {
                player1.Move(gamePadState1);
                player1.Shoot(gamePadState1, prevGamePadState1);
                //player1.Move();
            }
            else if(gamePadState1.IsConnected && !player1Control)
            {
                player1.moveC(gamePadState1);
                player1.Shoot(gamePadState1, prevGamePadState1);
            }
            //else update using keyboard
            else
            {
                player1.Move();
                player1.Shoot();
            }
            //if there's a gamepad2, update using that
            if (gamePadState2.IsConnected&&player2Control)
            {
                player2.Move(gamePadState2);
                player2.Shoot(gamePadState2, prevGamePadState2);
            }
            else if(gamePadState2.IsConnected && !player2Control)
            {
                player2.moveC(gamePadState2);
                player2.Shoot(gamePadState2, prevGamePadState2);
            }
            //else update using keyboard
            else
            {
                player2.Move();
                player2.Shoot();
            }
            foreach (Player player in playerList)
            {
                
                foreach (PowerUp powerUp in powerUpList)
                {
                    powerUp.PowerUpPlayer(player);
                }
                player.Update();
            }
            PlayerList[0].BlockPlayer(PlayerList[1]);
            PlayerList[1].BlockPlayer(PlayerList[0]);

            prevGamePadState1 = gamePadState1;
            prevGamePadState2 = gamePadState2;
        }
    }
}