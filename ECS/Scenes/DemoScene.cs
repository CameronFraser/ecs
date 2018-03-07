using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;
using ECS.Systems;
using ECS.Components;
using ECS.ECS;
using ECS.Services;

namespace ECS.Scenes
{
    class DemoScene : Scene
    {
        private Color backgroundColor = new Color(40, 53, 147);
        private SpriteFont font;
        private World world;
        private TmxMap map;
        private ILogger Logger;

        public DemoScene(string sceneName, bool isActive)
        {
            IsActive = isActive;
            SceneName = sceneName;

            world = new World(); // A whole new world!!!

            // Setting up Tile Engine Entity
            
            map = new TmxMap("../../../../TiledData/test.tmx"); // Loading TMX data
            
            var tileLayerNames = new List<string>();
            var tileRenderSystem = new TileRenderSystem();
            

            foreach (var tileset in map.Tilesets)
            {
                Console.WriteLine(tileset.Name);
                world.AddEntity(new Entity(new List<EntityComponent> { new TileSetComponent(tileset) }));
                Console.WriteLine("Creating tileset entity");
            }
            
            foreach (var layer in map.Layers)
            {
                world.AddEntity(new Entity(new List<EntityComponent> { new TileLayerComponent(layer, map.Width, map.Height) }));
                tileLayerNames.Add(layer.Name);
            }

            Console.WriteLine("Creating tilemap entity");

            // Setting up player entity

            // Create components; generally want to do this automatically by reading in XML or JSON data and generating your game objects
            /*var playerAppearanceComponent = new AppearanceComponent("player");
            var playerPositionComponent = new PositionComponent(300, 300);
            var playerControlledComponent = new PlayerControlledComponent();
            var velocityComponent = new VelocityComponent(3, new Vector2(0, -1));
            var cameraComponent = new CameraComponent(1, new Vector2(0, 0), 1024, 768);
            // Create systems; same as components in that it should be read in from somewhere else and generated, aint no1 got time to type all this out
            var renderSystem = new RenderSystem();
            var playerCameraSystem = new PlayerCameraSystem();

            List<EntityComponent> PlayerEntityComponents = new List<EntityComponent> { playerAppearanceComponent, playerControlledComponent, playerPositionComponent, velocityComponent, cameraComponent };
            Entity PlayerEntity = new Entity(PlayerEntityComponents);

            World.AddEntity(PlayerEntity); // Player Entity added
            */
            var cameraComponent = new CameraComponent(1);
            var positionComponent = new PositionComponent(0, 0);
            var playerControlledComponent = new PlayerControlledComponent();
            var velocityComponent = new VelocityComponent(5, new Vector2(0, -1));

            var motionSystem = new MotionSystem();
            var keyboardInputSystem = new KeyboardInputSystem();
            var renderSystem = new RenderSystem();

            world.AddEntity(new Entity(new List<EntityComponent> { cameraComponent, velocityComponent, positionComponent, playerControlledComponent }));
            // Setting up mouse cursor entity
            /*
            var cursorAppearanceComponent = new AppearanceComponent("cursor");
            var cursorPositionComponent = new PositionComponent(0, 0);
            var mouseControlledComponent = new MouseControlledComponent();
            var mouseInputSystem = new MouseInputSystem();

            World.AddEntity(new Entity(new List<EntityComponent> { cursorAppearanceComponent, cursorPositionComponent, mouseControlledComponent })); // Mouse cursor entity added
            */
            // Add the systems! Order MATTERS! YOU WOULDN'T DRAW A NOSE BEHIND A FACE WOULD YOU?
            // If order matters then add a z-index?
            world.AddSystems(new IEntitySystem [] { keyboardInputSystem, motionSystem, tileRenderSystem, renderSystem });
        }

        public override void Initialize()
        {
            Content = GameServices.GetService<ContentManager>();
            Logger = GameServices.GetService<ILogger>();
            world.Initialize();
        }

        public override void LoadContent(SpriteBatch spriteBatch)
        {
            font = Content.Load<SpriteFont>("sf-pixelate");
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
            spriteBatch.GraphicsDevice.Clear(backgroundColor);
            world.Draw(spriteBatch);
            spriteBatch.DrawString(font, "Sandbox", new Vector2(20, 20), new Color(238, 238, 238));
        }
    }
}
