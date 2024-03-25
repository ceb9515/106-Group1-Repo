using Microsoft.Xna.Framework;
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

        //Create Titlescreen Textures
        private Texture2D titleTexture;
        private Texture2D playButtonTexture;
        private Texture2D LEButtonTexture;


        //Create Button Textures + fields
        private Texture2D testButtonTexture;
        private Texture2D testButtonHTexture;
        private Button testButton;
        private Texture2D exitButtonTexture;
        private Texture2D saveButtonTexture;
        private Texture2D loadButtonTexture;

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

        //
        private Player player1;
        private Player player2;

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
            playButtonTexture = Content.Load<Texture2D>("playButton");
            LEButtonTexture = Content.Load<Texture2D>("LEButton");


            //Load the test button textures
            testButtonTexture = Content.Load<Texture2D>("Button");
            testButtonHTexture = Content.Load<Texture2D>("ButtonHovered");
            testButton = new Button(testButtonTexture, testButtonHTexture, 550, 300, 128, 64);
            exitButtonTexture = Content.Load<Texture2D>("exitButton");
            saveButtonTexture = Content.Load<Texture2D>("SaveButton");
            loadButtonTexture = Content.Load<Texture2D>("loadButton");


            //load tile textures
            groundText = Content.Load<Texture2D>("TESTgroundTexture");
            wallText = Content.Load<Texture2D>("TESTwallTexture");
            halfText = Content.Load<Texture2D>("TESThalfTexture");
            breakableText = Content.Load<Texture2D>("TESTbreakableTexture");
            selectedText = Content.Load<Texture2D>("TESTselectedTile");

            //load game object texture
            Bullettext = Content.Load<Texture2D>("Bullet");
            Playertext = Content.Load<Texture2D>("tank");

            //load the tile textures into the level editor
            levelEditor = new LevelEditor(groundText, halfText, wallText, breakableText, selectedText, exitButtonTexture,saveButtonTexture,loadButtonTexture);

            //load title screen
            titleScreen = new TitleScreen(playButtonTexture, LEButtonTexture, titleTexture);


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
                    if (titleScreen.levelEditorButton.Clicked(mouseState))
                    {
                        gameState = GameState.Editor;
                    }
                    if (titleScreen.startGameButton.Clicked(mouseState))
                    {
                        gameState = GameState.Game;
                        LoadGame();
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
                    playerManager.Update();
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
                    
                    bulletManager.DrawBullet(_spriteBatch);
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
            player1 = new Player(Playertext, 320, 360, 40, 40, 5, 1, 1, 0, player1Position, playerManager.player1Controls, Bullettext);
            player2 = new Player(Playertext, 960, 360, 40, 40, 5, 1, 1, 180, player2Position, playerManager.player2Controls, Bullettext);
            bulletManager = new BulletManager();
            playerManager.AddPlayer(player1);
            playerManager.AddPlayer(player2);
            player1.OnShoot += bulletManager.AddBullet;
            player2.OnShoot += bulletManager.AddBullet;
        }

    }
}