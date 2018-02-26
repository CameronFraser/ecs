using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Scenes
{
    class GameScene : Scene
    {
        private Color BackgroundColor = Color.Blue;

        public GameScene(string sceneName, bool isActive)
        {
            IsActive = isActive;
            SceneName = sceneName;
        }

        public override void LoadContent(SpriteBatch spriteBatch)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(BackgroundColor);
        }
    }
}
