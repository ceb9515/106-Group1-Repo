using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Managers;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Setup the GameState enum
        public enum GameState { Title, Menu, Game, Editor, LevelSelect}
        public GameState gameState = GameState.Title;

        //Setup keyboard + mouse states
        KeyboardState kb = Keyboard.GetState();
        KeyboardState previousKbState = Keyboard.GetState();
        MouseState mouseState;

        //Create Button Textures + fields
        private Texture2D testButtonTexture;
        private Texture2D testButtonHTexture;
        private Button testButton;

        //Create TileSet Textures
        private Texture2D groundText;
        private Texture2D wallText;
        private Texture2D halfText;
        private Texture2D breakableText;

        //Create LevelEditor object
        private LevelEditor levelEditor;

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


            //Load the test button textures
            testButtonTexture = Content.Load<Texture2D>("Button");
            testButtonHTexture = Content.Load<Texture2D>("ButtonHovered");
            testButton = new Button(testButtonTexture, testButtonHTexture, 550, 300, 128, 64);

            //load tile textures
            groundText = Content.Load<Texture2D>("TESTgroundTexture");
            wallText = Content.Load<Texture2D>("TESTwallTexture");

            levelEditor = new LevelEditor(groundText, groundText, wallText, groundText);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();

            // TODO: Add your update logic here

            //TESTING GAMESTATE(S)
            gameState = GameState.Editor;

            //FINITE STATE MACHINE (for GameStates)
            switch (gameState)
            {
                case GameState.Title:
                    break;

                case GameState.Editor:

                    //loop through the editor to check collisions
                    for(int i = 0; i < 25; i++)
                    {
                        for(int k = 0; k < 15; k++)
                        {
                            if (levelEditor.mapTiles[i, k].Clicked(mouseState))
                            {
                                levelEditor.SwitchTile(i, k, LevelEditor.TileType.Wall);
                            }
                        }
                    }
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            testButton.Draw(_spriteBatch);
            _spriteBatch.End();

            //FINITE STATE MACHINE (for GameStates)
            switch (gameState)
            {
                case GameState.Title:
                    break;

                case GameState.Editor:
                    _spriteBatch.Begin();
                    testButton.Draw(_spriteBatch, testButton.IsHovering(mouseState));
                    levelEditor.Draw(_spriteBatch);
                    _spriteBatch.End();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}