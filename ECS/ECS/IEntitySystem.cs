using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.ECS
{
    interface IEntitySystem
    {
        List<string> ComponentNames { get;  }
        void Initialize(List<IEntityComponent> components, Guid entityId);
        void LoadContent(List<IEntityComponent> components, Guid entityId, SpriteBatch spriteBatch);
        void Update(List<IEntityComponent> components, Guid entityId, GameTime gameTime);
        void Draw(List<IEntityComponent> components, Guid entityId, SpriteBatch spriteBatch);
    }
}
