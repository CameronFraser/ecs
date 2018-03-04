using System;
using System.Collections.Generic;
using ECS.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS
{
    /// <summary>
    /// Manages loading of scenes, toggling of active scenes,
    /// and the screen size
    /// </summary>
    class SceneManager
    {
        readonly Dictionary<string, Scene> Scenes;
        Scene ActiveScene;
        GraphicsDeviceManager Graphics;
        SpriteBatch SpriteBatch;

        public SceneManager(Dictionary<string, Scene> scenes, GraphicsDeviceManager graphics, int screenWidth, int screenHeight)
        {
            this.Scenes = scenes;
            this.Graphics = graphics;
            SetScreenSize(screenWidth, screenHeight);

            foreach (var scene in this.Scenes.Values)
            {
                if (scene.IsActive)
                    ActiveScene = scene;
            }
        }

        public void Initialize()
        {
            if (ActiveScene != null)
                ActiveScene.Initialize();
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            this.SpriteBatch = spriteBatch;
            if (ActiveScene != null)
                ActiveScene.LoadContent(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            if (ActiveScene != null)
                ActiveScene.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (ActiveScene != null)
                ActiveScene.Draw(spriteBatch);
        }

        public void Add(Scene scene)
        {
            Scenes.Add(scene.SceneName, scene);
        }

        public void SetActiveScene(string name)
        {
            Scene scene;
            if (!Scenes.TryGetValue(name, out scene))
                throw new Exception("Attempted to set an active scene that doesn't exist in the scene list");

            ActiveScene.UnloadContent();
            ActiveScene.IsActive = false;

            scene.IsActive = true;
            scene.Initialize();
            if (SpriteBatch == null)
            {
                throw new Exception("LoadContent must be called first.");
            }
            scene.LoadContent(SpriteBatch);
            ActiveScene = scene;
        }

        public void PrintDebug()
        {
            foreach (var scene in Scenes.Values)
            {
                scene.PrintDebug();
            }
        }

        public void SetScreenSize(int width, int height)
        {
            Graphics.PreferredBackBufferWidth = width;
            Graphics.PreferredBackBufferHeight = height;
            Graphics.ApplyChanges();
        }
    }
}
