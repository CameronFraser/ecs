using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECS.Scenes;

namespace ECS
{
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
        
        protected override void Initialize()
        {
            GameServices.AddService(GraphicsDevice);
            GameServices.AddService(Content);
            SceneManager.Initialize();
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            SceneManager.LoadContent(SpriteBatch);
        }
        
        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            SceneManager.Update(gameTime);

            base.Update(gameTime);
        }
        
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
