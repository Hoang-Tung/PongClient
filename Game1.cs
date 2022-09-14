using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Manager;

namespace Pong
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private ManagerNetwork _managerNetwork;
        private ManagerInput _managerInput;
        private ManagerPlayers _managerPlayers;
        private ManagerEnemies _managerEnemies;
        private ManagerMissles _managerMissles;

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _managerNetwork = new ManagerNetwork();
            _managerInput = new ManagerInput();
            _managerPlayers = new ManagerPlayers(_managerNetwork);
            _managerEnemies = new ManagerEnemies(_managerNetwork);
            _managerMissles = new ManagerMissles(_managerNetwork);
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //ballTexture = Content.Load<Texture2D>("ball");
            _managerPlayers.LoadContent(Content);
            _managerEnemies.LoadContent(Content);
            _managerMissles.LoadContent(Content);
            _managerNetwork.Start();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _managerNetwork.Update();
            _managerInput.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerPlayers.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerEnemies.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerMissles.Update(gameTime.ElapsedGameTime.Milliseconds);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            if (_managerNetwork.Active)
            {
                _managerPlayers.Draw(_spriteBatch);
                _managerEnemies.Draw(_spriteBatch);
                _managerMissles.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}