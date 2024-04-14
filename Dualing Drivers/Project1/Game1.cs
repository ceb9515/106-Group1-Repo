﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ms = Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input;
using Project1.Managers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Metrics;
using System;
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
        public enum GameState { Title, Menu, Game, Editor, GameOver, LevelSelect }
        public GameState gameState = GameState.Title;

        //Setup keyboard + mouse states
        KeyboardState kb = Keyboard.GetState();
        KeyboardState previousKbState = Keyboard.GetState();
        MouseState mouseState;
        MouseState previousMS;

        //Create Titlescreen Textures
        private Texture2D titleTexture;
        private Texture2D playButtonTexture;
        private Texture2D LEButtonTexture;


        //Create Button Textures + fields
        private Texture2D exitButtonTexture;
        private Texture2D saveButtonTexture;
        private Texture2D loadButtonTexture;

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

        //Create Gamestate manager objects
        private LevelEditor levelEditor;
        private TitleScreen titleScreen;
        private GameOver gameOver;
        private TileManager tileManager;
        private BulletManager bulletManager;
        private PlayerManager playerManager;

        //Create players
        private Player player1;
        private Player player2;

        //variable for menu selection delays
        private int menuDelay = 0;

        //test variables
        bool testing = true;
        private int testCount = 0;

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

            //load the tile textures into the level editor
            levelEditor = new LevelEditor(groundText, halfText, wallText, breakableText, selectedText, exitButtonTexture,saveButtonTexture,loadButtonTexture);

            //load title screen
            titleScreen = new TitleScreen(playButtonTexture, LEButtonTexture, titleTexture);

            //load game over screen
            gameOver = new GameOver(playButtonTexture, LEButtonTexture, titleTexture);

            // loads tile manager
            tileManager = new TileManager(wallText,breakableText,halfText,groundText);

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
            //gameState = GameState.Title;

            //FINITE STATE MACHINE (for GameStates)
            switch (gameState)
            {
                case GameState.Title:
                    if(menuDelay > 15)
                    {
                        if (titleScreen.levelEditorButton.Clicked(mouseState))
                        {
                            gameState = GameState.Editor;
                        }
                        if (titleScreen.startGameButton.Clicked(mouseState))
                        {
                            gameState = GameState.LevelSelect;
                            LoadGame();
                        }
                    }
                    menuDelay++;
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
                        if (levelEditor.selectTiles[i].Clicked(mouseState))
                        {
                            currentTile = (LevelEditor.TileType)i;
                        }
                    }
                    //loop through buttons to check collisions
                    if(levelEditor.exitButton.Clicked(mouseState))
                    {
                        gameState = GameState.Title;
                    }
                    if (levelEditor.saveButton.Clicked(mouseState))
                    {
                        //open save file window
                        SaveFileDialog saving = new SaveFileDialog();
                        saving.Title = "Save a level file.";
                        saving.Filter = "Level files (*.level)|*.level|All files (*.*)|*.*";
                        saving.FileName = "myLevel";
                        saving.FileOk += levelEditor.Save;
                        saving.ShowDialog();
                    }
                    if (levelEditor.loadButton.Clicked(mouseState))
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
                    //open load file window
                    OpenFileDialog loadingM = new OpenFileDialog();
                    loadingM.Title = "Load a level file.";
                    loadingM.Filter = "Level files (*.level)|*.level|All files (*.*)|*.*";
                    loadingM.FileOk += tileManager.LoadTiles;
                    loadingM.ShowDialog();
                    gameState = GameState.Game;
                    break;

                case GameState.Game:
                    bulletManager.ProcessCollision(tileManager.GetTiles(),playerManager.PlayerList,bulletManager.BulletList);
                    playerManager.Update();

                    //ADD A GAME OVER CONDITION HERE
                    testCount++;
                    if(testCount >= 1000)
                    {
                        gameState = GameState.GameOver;
                    }
                    break;

                case GameState.GameOver:
                    //reset test variable (can remove in final version)
                    testCount = 0;

                    //check button to restart the game
                    if (gameOver.restartGameButton.Clicked(mouseState))
                    {
                        gameState = GameState.LevelSelect;
                        LoadGame();
                    }
                    //check button to go back to the title screen
                    if (gameOver.titleButton.Clicked(mouseState))
                    {
                        gameState = GameState.Title;
                    }

                    break;
            }

            previousMS = mouseState;
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
                    player1.Draw(_spriteBatch);
                    player2.Draw(_spriteBatch);
                    tileManager.HandlePlayerCollision(player1);
                    tileManager.HandlePlayerCollision(player2);
                    bulletManager.DrawBullet(_spriteBatch);
                    break;
                case GameState.GameOver:
                    //draw players and tiles but without adding new collisions
                    tileManager.DrawTiles(_spriteBatch);
                    player1.Draw(_spriteBatch);
                    player2.Draw(_spriteBatch);
                    gameOver.Draw(_spriteBatch);
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void LoadGame()
        {
            //load the game
            Vector2 player1Position = new Vector2(320, 360);
            Vector2 player2Position = new Vector2(960, 360);
            playerManager = new PlayerManager();
            player1 = new Player(PlayerText1, 320, 360, 40, 40, 5, 2, 1, 0, player1Position, playerManager.player1Controls, Bullettext, PlayerCrash1);
            player2 = new Player(PlayerText2, 960, 360, 40, 40, 5, 2, 1, 180, player2Position, playerManager.player2Controls, Bullettext, PlayerCrash2);
            bulletManager = new BulletManager();
            playerManager.AddPlayer(player1);
            playerManager.AddPlayer(player2);
            player1.OnShoot += bulletManager.AddBullet;
            player2.OnShoot += bulletManager.AddBullet;
        }

    }
}