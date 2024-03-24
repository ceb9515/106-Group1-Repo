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
        public enum GameState { Title, Menu, Game, Editor, LevelSelect }
        public GameState gameState = GameState.Title;

        //Setup keyboard + mouse states
        KeyboardState kb = Keyboard.GetState();
        KeyboardState previousKbState = Keyboard.GetState();
        MouseState mouseState;
        MouseState previousMS;

        //Create Title Texture
        private Texture2D titleTexture;


        //Create Button Textures + fields
        private Texture2D testButtonTexture;
        private Texture2D testButtonHTexture;
        private Button testButton;

        //Create TileSet Textures
        private Texture2D groundText;
        private Texture2D wallText;
        private Texture2D halfText;
        private Texture2D breakableText;
        private Texture2D selectedText;
        private LevelEditor.TileType currentTile = 0;

        //Create player and bullet textures
        private Texture2D Playertext;
        private Texture2D Bullettext;

        //Create Gamestate manager objects
        private LevelEditor levelEditor;
        private TitleScreen titleScreen;
        private TileManager tileManager;
        private BulletManager bulletManager;
        private PlayerManager playerManager;

        bool testing = true;

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


            //Load the test button textures
            testButtonTexture = Content.Load<Texture2D>("Button");
            testButtonHTexture = Content.Load<Texture2D>("ButtonHovered");
            testButton = new Button(testButtonTexture, testButtonHTexture, 550, 300, 128, 64);

            //load tile textures
            groundText = Content.Load<Texture2D>("TESTgroundTexture");
            wallText = Content.Load<Texture2D>("TESTwallTexture");
            halfText = Content.Load<Texture2D>("TESThalfTexture");
            breakableText = Content.Load<Texture2D>("TESTbreakableTexture");
            selectedText = Content.Load<Texture2D>("TESTselectedTile");

            //load game object texture
            Bullettext = Content.Load<Texture2D>("");
            Playertext = Content.Load<Texture2D>("tank");

            //load the tile textures into the level editor
            levelEditor = new LevelEditor(groundText, halfText, wallText, breakableText, selectedText, testButtonTexture);

            //load title screen textures
            titleScreen = new TitleScreen(testButtonTexture, testButtonTexture, titleTexture);

            // loads tile manager
            tileManager = new TileManager();
            //tileManager.LoadTiles(fileName, breakableText, wallText, groundText, halfText);
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
                    if (titleScreen.levelEditorButton.Clicked(mouseState))
                    {
                        gameState = GameState.Editor;
                    }
                    if (titleScreen.startGameButton.Clicked(mouseState))
                    {
                        gameState = GameState.Game;
                    }
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

                case GameState.Game:
                    bulletManager.ProcessCollision(tileManager.GetTiles(),playerManager.PlayerList,bulletManager.BulletList);
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
            Player player1 = new Player(Playertext, 0, 0, 0, 0, 5, 1, 1, 0, player1Position, playerManager.player1Controls);
            Player player2 = new Player(Playertext, 0, 0, 0, 0, 5, 1, 1, 0, player2Position, playerManager.player2Controls);
            bulletManager = new BulletManager();
            playerManager = new PlayerManager(player1, player2);
        }

    }
}