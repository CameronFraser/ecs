using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS
{
    class SceneManager
    {

        Dictionary<string, Scene> sceneCollection = new Dictionary<string, Scene>();
        Scene activeScene;

        public SceneManager(GraphicsDeviceManager graphics)
        {
          
        }

        public void Initialize()
        {

        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<string, Scene> sceneEntry in sceneCollection)
            {
                if (sceneEntry.Value.IsActive)
                {
                    sceneEntry.Value.LoadContent(spriteBatch);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<string, Scene> sceneEntry in sceneCollection)
            {
                if (sceneEntry.Value.IsActive)
                {
                    sceneEntry.Value.Update();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<string, Scene> sceneEntry in sceneCollection)
            {
                if (sceneEntry.Value.IsActive)
                {
                    sceneEntry.Value.Draw();
                }
            }
        }

        public void Add(Scene scene)
        {
            sceneCollection.Add(scene.SceneName, scene);
        }

        public void SetActiveScene(string name)
        {
            Scene scene;
            sceneCollection.TryGetValue(name, out scene);

            SetAllScenesInactive();

            scene.IsActive = true;
            activeScene = scene;
        }

        private void SetAllScenesInactive()
        {
            foreach (KeyValuePair<string, Scene> sceneEntry in sceneCollection)
            {
                sceneEntry.Value.IsActive = false;
            }
        }

        public void Print()
        {
            foreach (KeyValuePair<string, Scene> sceneEntry in sceneCollection)
            {
                sceneEntry.Value.Print();
            }
        }
    }
}
