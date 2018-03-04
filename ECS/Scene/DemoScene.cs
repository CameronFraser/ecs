using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ECS.ECS;
using ECS.Components;
using ECS.Systems;

namespace ECS.Scenes
{
    class DemoScene : Scene
    {
        private Color BackgroundColor = Color.Blue;
        private SpriteFont font;
        private World world;

        public DemoScene(string sceneName, bool isActive)
        {
            IsActive = isActive;
            SceneName = sceneName;
            world = new World();
            var appearanceComponent = new Appearance("player");
            var positionComponent = new Position(300, 300);
            var positionComponent1 = new Position(200, 200);
            var positionComponent2 = new Position(400, 400);
            var renderSystem = new Render();
            world.AddEntity(new Entity(new List<IEntityComponent> { appearanceComponent, positionComponent }));
            world.AddEntity(new Entity(new List<IEntityComponent> { appearanceComponent, positionComponent1 }));
            world.AddEntity(new Entity(new List<IEntityComponent> { appearanceComponent, positionComponent2 }));
            world.AddSystem(renderSystem);
        }

        public override void Initialize()
        {
            content = GameServices.GetService<ContentManager>();
            world.Initialize();
        }

        public override void LoadContent(SpriteBatch spriteBatch)
        {
            font = content.Load<SpriteFont>("arial");
            world.LoadContent(spriteBatch);
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            world.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(BackgroundColor);
            spriteBatch.DrawString(font, "HELLO", new Vector2(400, 400), Color.White);
            world.Draw(spriteBatch);
        }
    }
}
