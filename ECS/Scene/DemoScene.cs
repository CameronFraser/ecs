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
        private Color BackgroundColor = new Color(40, 53, 147);
        private SpriteFont Font;
        private World World;

        public DemoScene(string sceneName, bool isActive)
        {
            IsActive = isActive;
            SceneName = sceneName;
            var appearanceComponent = new Appearance("player");
            var positionComponent = new Position(300, 300);
            var positionComponent1 = new Position(200, 200);
            var positionComponent2 = new Position(400, 400);
            var renderSystem = new Render();

            World = new World(); // A whole new world!!!
            World.AddEntity(new Entity(new List<IEntityComponent> { appearanceComponent, positionComponent }));
            World.AddEntity(new Entity(new List<IEntityComponent> { appearanceComponent, positionComponent1 }));
            World.AddEntity(new Entity(new List<IEntityComponent> { appearanceComponent, positionComponent2 }));
            World.AddSystem(renderSystem);
        }

        public override void Initialize()
        {
            Content = GameServices.GetService<ContentManager>();
            World.Initialize();
        }

        public override void LoadContent(SpriteBatch spriteBatch)
        {
            Font = Content.Load<SpriteFont>("arial");
            World.LoadContent(spriteBatch);
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            World.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(BackgroundColor);
            spriteBatch.DrawString(Font, "Sandbox", new Vector2(20, 20), new Color(238, 238, 238));
            World.Draw(spriteBatch);
        }
    }
}
