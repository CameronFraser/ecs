using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;
using ECS.ECS;
using ECS.Components;
using ECS.Systems;
using ECS.Services;

namespace ECS.Scenes
{
    class DemoScene : Scene
    {
        private Color BackgroundColor = new Color(40, 53, 147);
        private SpriteFont Font;
        private World World;
        TmxMap Map;
        ILogger Logger;

        public DemoScene(string sceneName, bool isActive)
        {
            IsActive = isActive;
            SceneName = sceneName;

            World = new World(); // A whole new world!!!

            // Setting up Tile Engine Entity
            
            Map = new TmxMap("../../../../TiledData/test.tmx"); // Loading TMX data
            
            var tileLayerNames = new List<string>();
            var tileRenderSystem = new TileRender();
            

            foreach (var tileset in Map.Tilesets)
            {
                Console.WriteLine(tileset.Name);
                World.AddEntity(new Entity(new List<EntityComponent> { new TileSet(tileset) }));
                Console.WriteLine("Creating tileset entity");
            }
            
            foreach (var layer in Map.Layers)
            {
                World.AddEntity(new Entity(new List<EntityComponent> { new TileLayer(layer) }));
                tileLayerNames.Add(layer.Name);
            }

            World.AddEntity(new Entity(new List<EntityComponent> { new TileMap(tileLayerNames) }));

            Console.WriteLine("Creating tilemap entity");
            
            // Setting up player entity

            // Create components; generally want to do this automatically by reading in XML or JSON data and generating your game objects
            var playerAppearanceComponent = new Appearance("player");
            var playerPositionComponent = new Position(300, 300);
            var playerControlledComponent = new PlayerControlled();
            var velocityComponent = new Velocity(3, new Vector2(0, -1)); // How to Enum so both this class and the Velocity component know about it?
            // Create systems; same as components in that it should be read in from somewhere else and generated, aint no1 got time to type all this out
            var renderSystem = new Render();
            var keyboardInputSystem = new KeyboardPlayerInput();
            var motionSystem = new Motion();

            World.AddEntity(new Entity(new List<EntityComponent> { playerAppearanceComponent, playerControlledComponent, playerPositionComponent, velocityComponent })); // Player Entity added

            // Setting up mouse cursor entity
            var cursorAppearanceComponent = new Appearance("cursor");
            var cursorPositionComponent = new Position(0, 0);
            var mouseControlledComponent = new MouseControlled();
            var mouseInputSystem = new MouseInput();

            World.AddEntity(new Entity(new List<EntityComponent> { cursorAppearanceComponent, cursorPositionComponent, mouseControlledComponent })); // Mouse cursor entity added

            // Add the systems! Order MATTERS! YOU WOULDN'T DRAW A NOSE BEHIND A FACE WOULD YOU?
            World.AddSystems(new List<IEntitySystem> { keyboardInputSystem, mouseInputSystem, motionSystem, renderSystem });
        }

        public override void Initialize()
        {
            Content = GameServices.GetService<ContentManager>();
            Logger = GameServices.GetService<ILogger>();
            World.Initialize();
        }

        public override void LoadContent(SpriteBatch spriteBatch)
        {
            Font = Content.Load<SpriteFont>("sf-pixelate");
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
