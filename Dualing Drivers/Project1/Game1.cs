using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ms = Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input;
using Project1.Managers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Metrics;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.DataFormats;
using System.IO;
using System.Reflection;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Setup the GameState enum
        public enum GameState { Title, Menu, Game, Editor, GameOver, LevelSelect, Controls }
        public GameState gameState = GameState.Title;

        //Setup keyboard + mouse states
        KeyboardState kb = Keyboard.GetState();
        KeyboardState previousKbState = Keyboard.GetState();
        MouseState mouseState;
        MouseState mouseLastState;

        //Create Titlescreen Textures
        private Texture2D titleTexture;
        private Texture2D playButtonTexture;
        private Texture2D LEButtonTexture;


        //Create Button Textures + fields
        private Texture2D exitButtonTexture;
        private Texture2D saveButtonTexture;
        private Texture2D loadButtonTexture;
        private Texture2D titleButtonTexture;
        private Texture2D restartButtonTexture;
        private Texture2D controlsButtonTexture;
        private Texture2D Leftcontrol;
        private Texture2D Rightcontrol;

        //UI textures
        private Texture2D healthFullText;
        private Texture2D healthFourText;
        private Texture2D healthThreeText;
        private Texture2D healthTwoText;
        private Texture2D healthOneText;
        private Texture2D healthZeroText;
        private Texture2D magFullText;
        private Texture2D magFourText;
        private Texture2D magThreeText;
        private Texture2D magTwoText;
        private Texture2D magOneText;
        private Texture2D magEmptyText;
        private Texture2D gameOverText;
        private Texture2D healthPowerUpText;
        private Texture2D ammoPowerUpText;
        private Texture2D speedPowerUpText;
        private Texture2D controlsText;
        private Texture2D playerOneLabel;
        private Texture2D playerTwoLabel;


        //Create TileSet Textures
        private Texture2D groundText;
        private Texture2D wallText;
        private Texture2D halfText;
        private Texture2D breakableText;
        private Texture2D selectedText;
        private LevelEditor.TileType currentTile = 0;

        //Create player and bullet textures
        private Texture2D PlayerText1;
        private Texture2D PlayerText2;
        private Texture2D PlayerCrash1;
        private Texture2D PlayerCrash2;
        private Texture2D Bullettext;

        //Create Level Select Preview Textures
        private Texture2D levelExitTexture;
        private Texture2D levelExitHTexture;
        private Texture2D levelLoadTexture;
        private Texture2D levelLoadHTexture;
        private Texture2D levelEditTexture;
        private Texture2D levelEditHTexture;
        private Texture2D levelTextCustom;
        private Texture2D levelTextHover;
        private Texture2D levelTextBlank;
        private Texture2D levelSelectLogo;
        private List<Texture2D> levelTextures;
        private Texture2D levelText1;
        private Texture2D levelText2;
        private Texture2D levelText3;
        private Texture2D levelText4;

        //Create Gamestate manager objects
        private LevelEditor levelEditor;
        private TitleScreen titleScreen;
        private LevelSelect levelSelect;
        private GameOver gameOver;
        private TileManager tileManager;
        private BulletManager bulletManager;
        private PlayerManager playerManager;
        private Controls controls;

        //Create players
        private Player player1;
        private Player player2;

        //Player ui
        private UIManager UIPOne;
        private UIManager UIPTwo;
        private Button menuButton;

        //variable for menu selection delays
        private int menuDelay = 0;

        //test variables
        bool testing = true;
        private int testCount = 0;
        private bool player1C = true;
        private bool player2C = true;
        // text fonts
        private SpriteFont text;

        // create power up manager
        PowerUpManager powerUpManager;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            //change window size
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //Load Title Screen Textures
            titleTexture = Content.Load<Texture2D>("altLogo");
            playButtonTexture = Content.Load<Texture2D>("playButton");
            LEButtonTexture = Content.Load<Texture2D>("LEButton");
            restartButtonTexture = Content.Load<Texture2D>("PlayAgainButton");
            titleButtonTexture = Content.Load<Texture2D>("MenuButton");
            controlsButtonTexture = Content.Load<Texture2D>("ControlsButton");

            //Load the test button textures
            exitButtonTexture = Content.Load<Texture2D>("exitButton");
            saveButtonTexture = Content.Load<Texture2D>("SaveButton");
            loadButtonTexture = Content.Load<Texture2D>("loadButton");

            //Load UI Textures
            healthFullText = Content.Load<Texture2D>("HealthFull");
            healthFourText = Content.Load<Texture2D>("HealthFour");
            healthThreeText = Content.Load<Texture2D>("HealthThree");
            healthTwoText = Content.Load<Texture2D>("HealthTwo");
            healthOneText = Content.Load<Texture2D>("HealthOne");
            healthZeroText = Content.Load<Texture2D>("HealthEmpty");
            magFullText = Content.Load<Texture2D>("MagFull");
            magFourText = Content.Load<Texture2D>("MagFour");
            magThreeText = Content.Load<Texture2D>("MagThree");
            magTwoText = Content.Load<Texture2D>("MagTwo");
            magOneText = Content.Load<Texture2D>("MagOne");
            magEmptyText = Content.Load<Texture2D>("MagEmpty");
            gameOverText = Content.Load<Texture2D>("GameOver");
            ammoPowerUpText = Content.Load<Texture2D>("PU_Ammo");
            healthPowerUpText = Content.Load<Texture2D>("PU_Health");
            speedPowerUpText = Content.Load<Texture2D>("PU_Speed");
            controlsText = Content.Load<Texture2D>("Controls");
            playerOneLabel = Content.Load<Texture2D>("Player1");
            playerTwoLabel = Content.Load<Texture2D>("Player2");
            Leftcontrol = Content.Load<Texture2D>("leftcontrol");
            Rightcontrol = Content.Load<Texture2D>("rightcontrol");

            //load tile textures
            groundText = Content.Load<Texture2D>("ground");
            wallText = Content.Load<Texture2D>("Wall");
            halfText = Content.Load<Texture2D>("HalfWallter");
            breakableText = Content.Load<Texture2D>("BreakWall");
            selectedText = Content.Load<Texture2D>("selectedTile");


            //load game object texture
            Bullettext = Content.Load<Texture2D>("Bullet");
            PlayerText1 = Content.Load<Texture2D>("tank");
            PlayerText2 = Content.Load<Texture2D>("tankAlt");
            PlayerCrash1 = Content.Load<Texture2D>("tankExplosion");
            PlayerCrash2 = Content.Load<Texture2D>("tankAltExplosion");

            //load level select textures
            levelTextCustom = Content.Load<Texture2D>("Level_Custom");
            levelTextHover = Content.Load<Texture2D>("Level_Hover");
            levelTextBlank = Content.Load<Texture2D>("Level0_Blank");
            levelText1 = Content.Load<Texture2D>("Level1_Dockside");
            levelText2 = Content.Load<Texture2D>("Level2_Courtyard");
            levelText3 = Content.Load<Texture2D>("Level3_Bridged");
            levelText4 = Content.Load<Texture2D>("Level4_Pirate'sCove");
            levelExitTexture = Content.Load<Texture2D>("Exit");
            levelExitHTexture = Content.Load<Texture2D>("Exit_Hover");
            levelEditTexture = Content.Load<Texture2D>("Edit");
            levelEditHTexture = Content.Load<Texture2D>("Edit_Hovering");
            levelLoadTexture = Content.Load<Texture2D>("Load");
            levelLoadHTexture = Content.Load<Texture2D>("Load_Hovering");
            levelSelectLogo = Content.Load<Texture2D>("Level Select LOGO");

            //create the list of level textures
            levelTextures = new List<Texture2D>();
            levelTextures.Add(levelText1);
            levelTextures.Add(levelText2);
            levelTextures.Add(levelText3);
            levelTextures.Add(levelText4);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextBlank);
            levelTextures.Add(levelTextCustom);

            // load text fonts
            text = Content.Load<SpriteFont>("text");

            //load the tile textures into the level editor
            levelEditor = new LevelEditor(groundText, halfText, wallText, breakableText, speedPowerUpText, healthPowerUpText, ammoPowerUpText, ammoPowerUpText, 
                selectedText, exitButtonTexture,saveButtonTexture,loadButtonTexture);

            //load title screen
            titleScreen = new TitleScreen(playButtonTexture, LEButtonTexture, titleTexture, controlsButtonTexture);

            //load controls screen
            controls = new Controls(controlsText, titleButtonTexture,Leftcontrol,Rightcontrol);

            //load level select screen
            levelSelect = new LevelSelect(
                levelTextures, levelTextHover, levelExitTexture, levelExitHTexture, 
                levelLoadTexture, levelLoadHTexture, levelEditTexture, levelEditHTexture, 
                levelSelectLogo);

            //load game over screen
            gameOver = new GameOver(restartButtonTexture, titleButtonTexture);

            // loads power up manager
            powerUpManager = new PowerUpManager(healthPowerUpText, speedPowerUpText, ammoPowerUpText);

            // loads tile manager
            tileManager = new TileManager(wallText, breakableText, halfText, groundText, powerUpManager);

            // makes a test map with only background tiles
            tileManager.TestMap();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ms.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(ms.Keys.Escape))
                Exit();
  
            mouseState = Mouse.GetState();

            // TODO: Add your update logic here

            //TESTING GAMESTATE(S)
            //gameState = GameState.Controls;

            //FINITE STATE MACHINE (for GameStates)
            switch (gameState)
            {
                case GameState.Title:
                    if(menuDelay > 15)
                    {
                        if (titleScreen.levelEditorButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                        {
                            gameState = GameState.Editor;
                        }
                        if (titleScreen.startGameButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                        {
                            gameState = GameState.LevelSelect;
                            LoadGame();
                        }
                        if (titleScreen.controlsButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                        {
                            gameState = GameState.Controls;
                        }
                        
                    }
                    menuDelay++;
                    testCount = 0;
                    break;

                case GameState.Editor:
                    
                    //loop through the editor to check collisions
                    for (int i = 0; i < levelEditor.MapWidth; i++)
                    {
                        for (int k = 0; k < levelEditor.MapHeight; k++)
                        {
                            if (levelEditor.mapTiles[i, k].Clicked(mouseState))
                            {
                                levelEditor.SwitchTile(i, k, currentTile);
                            }
                        }
                    }
                    //loop through the tile selection to check collisions
                    for (int i = 0; i < levelEditor.selectTiles.Length; i++)
                    {
                        if (levelEditor.selectTiles[i].Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                        {
                            currentTile = (LevelEditor.TileType)i;
                        }
                    }
                    //loop through buttons to check collisions
                    if(levelEditor.exitButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        gameState = GameState.Title;
                    }
                    if (levelEditor.saveButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        //open save file window
                        SaveFileDialog saving = new SaveFileDialog();
                        saving.Title = "Save a level file.";
                        saving.Filter = "Level files (*.level)|*.level|All files (*.*)|*.*";
                        saving.FileName = "myLevel";
                        saving.FileOk += levelEditor.Save;
                        saving.ShowDialog();
                    }
                    if (levelEditor.loadButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        //open load file window
                        OpenFileDialog loading = new OpenFileDialog();
                        loading.Title = "Load a level file.";
                        loading.Filter = "Level files (*.level)|*.level|All files (*.*)|*.*";
                        loading.FileOk += levelEditor.Load;
                        loading.ShowDialog();
                    }
                    break;

                case GameState.LevelSelect:
                    //quit to title
                    if (levelSelect.exitButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        gameState = GameState.Title;
                    }
                    //quit to level editor
                    else if (levelSelect.editButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        gameState = GameState.Editor;
                    }
                    //load a custom level
                    else if (levelSelect.levelButtons[23].Clicked(mouseState) || levelSelect.loadButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        //open load file window
                        OpenFileDialog loadingM = new OpenFileDialog();
                        loadingM.Title = "Load a level file.";
                        loadingM.Filter = "Level files (*.level)|*.level|All files (*.*)|*.*";
                        loadingM.FileOk += tileManager.LoadTiles;
                        loadingM.ShowDialog();
                        gameState = GameState.Game;
                    }
                    //load levels
                    else
                    {
                        for(int i = 0; i < 5; i++)
                        {
                            if (levelSelect.levelButtons[i].Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                            {
                                tileManager.PreLoad(i);
                                gameState = GameState.Game;
                                menuButton = new Button(titleButtonTexture, 50, 20, titleButtonTexture.Width, titleButtonTexture.Height);
                            }
                        }
                    }
                    break;

                case GameState.Game:
                    bulletManager.ProcessCollision(tileManager.GetTiles(),playerManager.PlayerList,bulletManager.BulletList);
                    playerManager.Update();

                    // ends game if either player dies
                    if (playerManager.Player1.Health == 0 || playerManager.Player2.Health == 0)
                    {
                        gameState = GameState.GameOver;
                    }
                    if(menuButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        gameState = GameState.Title;
                    }
                    UpdateUI();

                    break;

                case GameState.GameOver:

                    //check button to restart the game
                    if (gameOver.restartGameButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        gameState = GameState.LevelSelect;
                        LoadGame();
                    }
                    //check button to go back to the title screen
                    if (gameOver.titleButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        gameState = GameState.Title;
                    }

                    break;

                case GameState.Controls:
                    if (controls.menuButton.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        gameState = GameState.Title;
                    }
                    if (controls.leftControl1.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        player1C = false;
                    }
                    if (controls.rightControl1.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        player1C = true;
                    }
                    if (controls.leftControl2.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        player2C = false;
                    }
                    if (controls.rightControl2.Clicked(mouseState) && (mouseLastState.LeftButton != ms.ButtonState.Pressed))
                    {
                        player2C = true;
                    }
                    break;
            }

            mouseLastState = mouseState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            //FINITE STATE MACHINE (for GameStates)
            switch (gameState)
            {
                case GameState.Title:
                    titleScreen.DrawTitle(_spriteBatch);
                    break;

                case GameState.Editor:
                    //draw map and tiles
                    levelEditor.DrawMap(_spriteBatch);
                    levelEditor.DrawTiles(_spriteBatch, (int)currentTile);
                    //draw buttons
                    _spriteBatch.Draw(levelEditor.exitButton.texture, levelEditor.exitButton.rect, Color.White);
                    _spriteBatch.Draw(levelEditor.saveButton.texture, levelEditor.saveButton.rect, Color.White);
                    _spriteBatch.Draw(levelEditor.loadButton.texture, levelEditor.loadButton.rect, Color.White);
                    break;
                case GameState.Game:
                    // draws all the tiles to the screen
                    tileManager.DrawTiles(_spriteBatch);
                    playerManager.Player1.Draw(_spriteBatch);
                    playerManager.Player2.Draw(_spriteBatch);
                    tileManager.HandlePlayerCollision(playerManager.Player1);
                    tileManager.HandlePlayerCollision(playerManager.Player2);
                    bulletManager.DrawBullet(_spriteBatch);
                    UIPOne.Draw(_spriteBatch);
                    _spriteBatch.Draw(playerOneLabel, new Vector2(25, 100), Color.White);
                    UIPTwo.Draw(_spriteBatch);
                    _spriteBatch.Draw(playerTwoLabel, new Vector2(25, 400), Color.White);
                    menuButton.Draw(_spriteBatch);
                    // draws all power ups to screen if they're active
                    powerUpManager.DrawPowerUps(_spriteBatch);
                    break;

                case GameState.LevelSelect:
                    levelSelect.Draw(_spriteBatch, mouseState);
                    break;

                case GameState.GameOver:
                    //draw players and tiles but without adding new collisions
                    tileManager.DrawTiles(_spriteBatch);
                    playerManager.Player1.Draw(_spriteBatch);
                    playerManager.Player2.Draw(_spriteBatch);
                    gameOver.Draw(_spriteBatch);
                    _spriteBatch.Draw(gameOverText, new Rectangle(100, 50, 607, 459), Color.White);

                    // prints game over message
                    _spriteBatch.DrawString(text, "Game Over", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 100, 10), Color.White);

                    // win message for player 2
                    if (playerManager.Player1.Health == 0 && playerManager.Player2.Health != 0)
                    {
                        _spriteBatch.DrawString(text, "Player 2 Wins!", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 125, 100), Color.White);
                    }

                    // win message for player 1
                    if (playerManager.Player2.Health == 0 && playerManager.Player1.Health != 0)
                    {
                        _spriteBatch.DrawString(text, "Player 1 Wins!", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 125, 100), Color.White);
                    }

                    if (playerManager.Player2.Health == 0 && playerManager.Player1.Health == 0)
                    {
                        _spriteBatch.DrawString(text, "It's a tie!", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 90, 100), Color.White);
                    }
                    break;

                case GameState.Controls:
                    {
                        controls.Draw(_spriteBatch, _graphics);
                        break;
                    }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void LoadGame()
        {

            //load the game
            Vector2 player1Position = new Vector2(340, 100);
            Vector2 player2Position = new Vector2(1180, 620);
            // loads power ups
            /*ammoPowerUp = new PowerUp(ammoPowerUpText, _graphics.PreferredBackBufferWidth / 2, 60, 40, 40, PowerUp.PowerUpType.ammo);
            healthPowerUp = new PowerUp(healthPowerUpText, _graphics.PreferredBackBufferWidth / 2, 60, 40, 40, PowerUp.PowerUpType.health);
            speedPowerUp = new PowerUp(speedPowerUpText, _graphics.PreferredBackBufferWidth / 2, 60, 40, 40, PowerUp.PowerUpType.speed);
            ammoPowerUp.Active = false;
            healthPowerUp.Active = false;
            speedPowerUp.Active = false;
            List<PowerUp> powerUps = new List<PowerUp>();
            powerUps.Add(ammoPowerUp);
            powerUps.Add(healthPowerUp);
            powerUps.Add(speedPowerUp);*/
            playerManager = new PlayerManager(PlayerText1, PlayerText2, player1Position, player2Position, Bullettext, PlayerCrash1, PlayerCrash2, powerUpManager.GetPowerUps(),player1C, player2C);
            bulletManager = new BulletManager();
            playerManager.Player1.OnShoot += bulletManager.AddBullet;
            playerManager.Player2.OnShoot += bulletManager.AddBullet;
            UIPOne = new UIManager(healthFullText, magFullText, 
                new Rectangle(100, 200, healthFullText.Width, healthFullText.Height), 
                new Rectangle(100, 230, magFullText.Width, magFullText.Height));
            UIPTwo = new UIManager(healthFullText, magFullText,
                new Rectangle(100, 500, healthFullText.Width, healthFullText.Height),
                new Rectangle(100, 530, magFullText.Width, magFullText.Height));

        }

        /// <summary>
        /// Helper Method to update health and ammo UI of both players
        /// </summary>
        public void UpdateUI()
        {

            switch (playerManager.Player1.Health)
            {
                case 4:
                    {
                        UIPOne.HealthTexture = healthFourText;
                        break;
                    }

                case 3:
                    {
                        UIPOne.HealthTexture = healthThreeText;
                        break;
                    }

                case 2:
                    {
                        UIPOne.HealthTexture = healthTwoText;
                        break;
                    }

                case 1:
                    {
                        UIPOne.HealthTexture = healthOneText;
                        break;
                    }

                case 0:
                    {
                        UIPOne.HealthTexture = healthZeroText;
                        break;
                    }

                default:
                    {
                        UIPOne.HealthTexture = healthFullText;
                        break;
                    }
            }

            switch (playerManager.Player2.Health)
            {
                case 4:
                    {
                        UIPTwo.HealthTexture = healthFourText;
                        break;
                    }

                case 3:
                    {
                        UIPTwo.HealthTexture = healthThreeText;
                        break;
                    }

                case 2:
                    {
                        UIPTwo.HealthTexture = healthTwoText;
                        break;
                    }

                case 1:
                    {
                        UIPTwo.HealthTexture = healthOneText;
                        break;
                    }

                case 0:
                    {
                        UIPTwo.HealthTexture = healthZeroText;
                        break;
                    }

                default:
                    {
                        UIPTwo.HealthTexture = healthFullText;
                        break;
                    }
            }

            switch (playerManager.Player1.Ammo)
            {
                case 4:
                    {
                        UIPOne.AmmoTexture = magFourText;
                        break;
                    }

                case 3:
                    {
                        UIPOne.AmmoTexture = magThreeText;
                        break;
                    }

                case 2:
                    {
                        UIPOne.AmmoTexture = magTwoText;
                        break;
                    }

                case 1:
                    {
                        UIPOne.AmmoTexture = magOneText;
                        break;
                    }

                case 0:
                    {
                        UIPOne.AmmoTexture = magEmptyText;
                        break;
                    }

                default:
                    {
                        UIPOne.AmmoTexture = magFullText;
                        break;
                    }
            }

            switch (playerManager.Player2.Ammo)
            {
                case 4:
                    {
                        UIPTwo.AmmoTexture = magFourText;
                        break;
                    }

                case 3:
                    {
                        UIPTwo.AmmoTexture = magThreeText;
                        break;
                    }

                case 2:
                    {
                        UIPTwo.AmmoTexture = magTwoText;
                        break;
                    }

                case 1:
                    {
                        UIPTwo.AmmoTexture = magOneText;
                        break;
                    }

                case 0:
                    {
                        UIPTwo.AmmoTexture = magEmptyText;
                        break;
                    }

                default:
                    {
                        UIPTwo.AmmoTexture = magFullText;
                        break;
                    }
            }
        }
    }
}