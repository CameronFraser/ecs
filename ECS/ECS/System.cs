using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.ECS
{
    abstract class System
    {
        abstract public List<string> ComponentNames { get;  }
        abstract public void Initialize(List<IComponent> components);
        abstract public void LoadContent(List<IComponent> components, SpriteBatch spriteBatch);
        abstract public void Update(List<IComponent> components, GameTime gameTime);
        abstract public void Draw(List<IComponent> components, SpriteBatch spriteBatch);
    }
}
