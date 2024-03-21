using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ms = Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input;
using Project1.Managers;
using System.Windows.Forms;

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

        //Create Gamestate manager objects
        private LevelEditor levelEditor;
        private TitleScreen titleScreen;

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

            //load the tile textures into the level editor
            levelEditor = new LevelEditor(groundText, halfText, wallText, breakableText, selectedText);

            //load title screen textures
            titleScreen = new TitleScreen(testButtonTexture, testButtonTexture, titleTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ms.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(ms.Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();

            // TODO: Add your update logic here

            //TESTING GAMESTATE(S)
            //gameState = GameState.Title;

            if (testing)
            {
                /*SaveFileDialog saving = new SaveFileDialog();
                saving.Title = "Save a level file.";
                saving.Filter = "Level files (*.level)|*.level|All files (*.*)|*.*";
                saving.FileName = "myLevel";
                //saving.FileOk += SaveData;
                saving.ShowDialog();*/

                testing = false;
            }
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
                    break;
            }

            previousMS = mouseState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //FINITE STATE MACHINE (for GameStates)
            switch (gameState)
            {
                case GameState.Title:
                    _spriteBatch.Begin();
                    titleScreen.DrawTitle(_spriteBatch);
                    _spriteBatch.End();
                    break;

                case GameState.Editor:
                    _spriteBatch.Begin();
                    //testButton.Draw(_spriteBatch, testButton.IsHovering(mouseState));
                    levelEditor.DrawMap(_spriteBatch);
                    levelEditor.DrawTiles(_spriteBatch, (int)currentTile);
                    _spriteBatch.End();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}