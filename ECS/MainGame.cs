using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECS.Scenes;

namespace ECS
{
    /// <summary>
    /// The main game loop. Responsible for creating scenes,
    /// registering scenes with the scene manager, registering game services
    /// with the game services singleton
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager Graphics;
        SpriteBatch SpriteBatch;
        SceneManager SceneManager;
        
        public MainGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            var sceneCollection = new Dictionary<string, Scene>
            {
                { "DemoScene", new DemoScene("DemoScene", true) }
            };

            SceneManager = new SceneManager(sceneCollection, Graphics, 1024, 768);
            SceneManager.PrintDebug();
        }
        /// <summary>
        /// Called once after constructor is called
        /// </summary>
        protected override void Initialize()
        {
            GameServices.AddService(GraphicsDevice);
            GameServices.AddService(Content);
            SceneManager.Initialize();
            base.Initialize();
        }
        /// <summary>
        /// Called once after initialize
        /// </summary>
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            SceneManager.LoadContent(SpriteBatch);
        }
        
        /// <summary>
        /// Called once when game terminated
        /// </summary>
        protected override void UnloadContent()
        {
        }
        
        /// <summary>
        /// Called every tick and should contain logic that updates the state of components and/or game state
        /// </summary>
        /// <param name="gameTime">Time passed since last time update was called</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            SceneManager.Update(gameTime);

            base.Update(gameTime);
        }
        /// <summary>
        /// Called every tick after update and contains rendering logic
        /// </summary>
        /// <param name="gameTime">Time passed since last time draw was called</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);
            SpriteBatch.Begin();
            SceneManager.Draw(SpriteBatch);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
