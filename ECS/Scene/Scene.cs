using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Scenes
{
    abstract class Scene : IScene
    {
        public bool IsActive { get; set; }
        public string SceneName { get; set; }
        public ContentManager Content { get; set; }
        public GraphicsDevice Graphics { get; set; }

        public abstract void Initialize();
        public abstract void LoadContent(SpriteBatch spriteBatch);
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        public void PrintDebug()
        {
            Console.WriteLine("==============");
            Console.WriteLine("Scene Name: " + SceneName);
            Console.WriteLine("IsActive: " + IsActive);
            Console.WriteLine("==============");
        }
    }
}
