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

            // Setting up player entity

            // Create components; generally want to do this automatically by reading in XML or JSON data and generating your game objects
            var playerAppearanceComponent = new Appearance("player");
            var playerPositionComponent = new Position(300, 300);
            var playerControlledComponent = new PlayerControlled();
            var velocityComponent = new Velocity(3, new List<string> { "Up" }); // How to Enum so both this class and the Velocity component know about it?
            // Create systems; same as components in that it should be read in from somewhere else and generated, aint no1 got time to type all this out
            var renderSystem = new Render();
            var keyboardInputSystem = new KeyboardPlayerInput();
            var motionSystem = new Motion();

            World = new World(); // A whole new world!!!
            World.AddEntity(new Entity(new List<IEntityComponent> { playerAppearanceComponent, playerControlledComponent, playerPositionComponent, velocityComponent })); // Player Entity added

            // Setting up mouse cursor entity
            var cursorAppearanceComponent = new Appearance("cursor");
            var cursorPositionComponent = new Position(0, 0);
            var mouseControlledComponent = new MouseControlled();
            var mouseInputSystem = new MouseInput();

            World.AddEntity(new Entity(new List<IEntityComponent> { cursorAppearanceComponent, cursorPositionComponent, mouseControlledComponent })); // Mouse cursor entity added

            World.AddSystems(new List<IEntitySystem> { keyboardInputSystem, mouseInputSystem, motionSystem, renderSystem }); // Need to ensure these are executed in a specific order, should I use SortedList here?
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
