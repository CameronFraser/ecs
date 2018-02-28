using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECS.Scenes;

namespace ECS
{
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SceneManager sceneManager;

        bool mReleased = true;

        // Temporary variables below for testing that I can switch between scenes
        readonly string[] scenes = { "MainScene", "LoadingScene", "GameScene" };
        int currentSceneIndex = 1;
        
        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            var sceneCollection = new Dictionary<string, Scene>
            {
                { "LoadingScene", new LoadingScene("LoadingScene", false) },
                { "MainScene", new MainScene("MainScene", true) },
                { "GameScene", new GameScene("GameScene", false) }
            };

            sceneManager = new SceneManager(sceneCollection, graphics, 1024, 768);
            sceneManager.PrintDebug();
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            sceneManager.Initialize();
            GameServices.AddService(GraphicsDevice);
            GameServices.AddService(Content);
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sceneManager.LoadContent(spriteBatch);
        }
        
        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mState = Mouse.GetState();

            if (mState.LeftButton == ButtonState.Pressed && mReleased)
            {
                sceneManager.SetActiveScene(scenes[currentSceneIndex++]);
                if (currentSceneIndex == 3)
                    currentSceneIndex = 0;
                mReleased = false;

                sceneManager.PrintDebug();
            }

            if (mState.LeftButton == ButtonState.Released)
            {
                mReleased = true;
            }

            sceneManager.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);
            spriteBatch.Begin();
            sceneManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
