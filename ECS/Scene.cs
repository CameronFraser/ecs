using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS
{
    abstract class Scene : IScene
    {
        public bool IsActive { get; set; }
        public string SceneName { get; set; }

        public abstract void LoadContent(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        public void Print()
        {
            Console.WriteLine("==============");
            Console.WriteLine("Scene Name: " + SceneName);
            Console.WriteLine("IsActive: " + IsActive.ToString());
            Console.WriteLine("==============");
        }
    }
}
