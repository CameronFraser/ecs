using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Scenes
{
    class LoadingScene : Scene
    {
        private Color BackgroundColor = Color.BurlyWood;

        public LoadingScene(string sceneName, bool isActive)
        {
            IsActive = isActive;
            SceneName = sceneName;
        }

        public override void Initialize()
        {
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
