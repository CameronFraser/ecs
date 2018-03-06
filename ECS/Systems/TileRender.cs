using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ECS.Components;
using System;
using ECS.ECS;

namespace ECS.Systems
{
    class TileRender : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }
        private ContentManager Content;

        public TileRender()
        {
            this.ComponentNames = new List<string> { "tilelayer", "tile", "tilemap" };
        }

        public void Initialize(List<EntityComponent> entityComponents, Guid entityId)
        {
            Content = GameServices.GetService<ContentManager>();
        }

        public void LoadContent(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
        }

        public void Update(List<EntityComponent> entityComponents, Guid entityId, GameTime gameTime)
        {
        }

        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
        }
    }
}
