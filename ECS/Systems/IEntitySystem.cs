using System;
using System.Collections.Generic;
using ECS.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Systems
{
    interface IEntitySystem
    {
        List<string> ComponentNames { get;  }
        void Initialize(List<EntityComponent> components, Guid entityId);
        void LoadContent(List<EntityComponent> components, Guid entityId, SpriteBatch spriteBatch);
        void Update(List<EntityComponent> components, Guid entityId, GameTime gameTime);
        void Draw(List<EntityComponent> components, Guid entityId, SpriteBatch spriteBatch);
    }
}
