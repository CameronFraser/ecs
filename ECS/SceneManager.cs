using System;
using System.Collections.Generic;
using ECS.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS
{
    class SceneManager
    {
        readonly Dictionary<string, Scene> scenes;
        Scene activeScene;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public SceneManager(Dictionary<string, Scene> scenes, GraphicsDeviceManager graphics, int screenWidth, int screenHeight)
        {
            this.scenes = scenes;
            this.graphics = graphics;
            SetScreenSize(screenWidth, screenHeight);

            foreach (var scene in this.scenes.Values)
            {
                if (scene.IsActive)
                    activeScene = scene;
            }
        }

        public void Initialize()
        {
            if (activeScene != null)
                activeScene.Initialize();
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            if (activeScene != null)
                activeScene.LoadContent(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            if (activeScene != null)
                activeScene.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (activeScene != null)
                activeScene.Draw(spriteBatch);
        }

        public void Add(Scene scene)
        {
            scenes.Add(scene.SceneName, scene);
        }

        public void SetActiveScene(string name)
        {
            Scene scene;
            if (!scenes.TryGetValue(name, out scene))
                throw new Exception("Attempted to set an active scene that doesn't exist in the scene list");

            activeScene.UnloadContent();
            activeScene.IsActive = false;

            scene.IsActive = true;
            scene.Initialize();
            //This assumes you've called loadContent before and you have a spriteBatch, there may be a better way, sprite batch could be null here
            scene.LoadContent(spriteBatch);
            activeScene = scene;
        }

        public void PrintDebug()
        {
            foreach (var scene in scenes.Values)
            {
                scene.PrintDebug();
            }
        }

        public void SetScreenSize(int width, int height)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
        }
    }
}
