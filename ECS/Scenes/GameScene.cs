using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Scenes
{
    class GameScene : Scene
    {
        private Color BackgroundColor = Color.Blue;
        private SpriteFont font;

        public GameScene(string sceneName, bool isActive)
        {
            IsActive = isActive;
            SceneName = sceneName;
        }

        public override void Initialize()
        {
            content = GameServices.GetService<ContentManager>();
        }

        public override void LoadContent(SpriteBatch spriteBatch)
        {
            Console.WriteLine("Load Content");
            font = content.Load<SpriteFont>("arial");
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(BackgroundColor);
            spriteBatch.DrawString(font, "HELLO", new Vector2(400, 400), Color.White);
        }
    }
}
