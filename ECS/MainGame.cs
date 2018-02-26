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
        string[] scenes = new string[3] { "MainScene", "LoadingScene", "GameScene" };
        int currentSceneIndex = 1;
        
        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Dictionary<string, Scene> sceneCollection = new Dictionary<string, Scene>();

            sceneCollection.Add("LoadingScene", new LoadingScene("LoadingScene", false));
            sceneCollection.Add("MainScene", new MainScene("MainScene", true));
            sceneCollection.Add("GameScene", new GameScene("GameScene", false));

            sceneManager = new SceneManager(sceneCollection, graphics, 1024, 768);
            sceneManager.Print();
        }
        
        protected override void Initialize()
        {
            base.Initialize();
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
                sceneManager.SetActiveScene(scenes[currentSceneIndex]);
                if (currentSceneIndex == 2)
                {
                    currentSceneIndex = 0;
                } else
                {
                    currentSceneIndex++;
                }
                mReleased = false;

                sceneManager.Print();
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
            sceneManager.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
