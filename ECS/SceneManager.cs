using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS
{
    class SceneManager
    {

        Dictionary<string, Scene> SceneCollection = new Dictionary<string, Scene>();
        Scene activeScene;
        GraphicsDeviceManager graphics;
        List<Scene> SceneList = new List<Scene>();

        public SceneManager(Dictionary<string, Scene> sceneDict, GraphicsDeviceManager graphics, int screenWidth, int screenHeight)
        {
            this.graphics = graphics;
            SetScreenSize(screenWidth, screenHeight);
            SceneCollection = sceneDict;
            foreach (KeyValuePair<string, Scene> sceneEntry in sceneDict)
            {
                if (sceneEntry.Value.IsActive)
                    activeScene = sceneEntry.Value;
            }
        }

        public void Initialize()
        {
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            Console.WriteLine("Active Scene is: " + activeScene);
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
            SceneCollection.Add(scene.SceneName, scene);
        }

        public void SetActiveScene(string name)
        {
            Scene scene;
            SceneCollection.TryGetValue(name, out scene);

            SetAllScenesInactive();

            scene.IsActive = true;
            activeScene = scene;
        }

        private void SetAllScenesInactive()
        {
            foreach (KeyValuePair<string, Scene> sceneEntry in SceneCollection)
            {
                sceneEntry.Value.IsActive = false;
            }
        }

        public void Print()
        {
            foreach (KeyValuePair<string, Scene> sceneEntry in SceneCollection)
            {
                sceneEntry.Value.Print();
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
