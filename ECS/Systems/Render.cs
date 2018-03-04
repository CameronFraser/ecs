using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ECS.Components;
using System;
using ECS.ECS;

namespace ECS.Systems
{
    class Render : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }
        private Dictionary<Guid, Tuple<Vector2, Texture2D>> renderables;
        private ContentManager content;

        public Render()
        {
            this.ComponentNames = new List<string> { "appearance", "position" };
            this.renderables = new Dictionary<Guid, Tuple<Vector2, Texture2D>>();
        }

        public void Initialize(List<IEntityComponent> entityComponents, Guid entityId)
        {
            content = GameServices.GetService<ContentManager>();
        }

        public void LoadContent(List<IEntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            Texture2D texture = null;
            Vector2 position = new Vector2();
            foreach (var component in entityComponents)
            {
                if (component.Name == "appearance")
                {
                    texture = content.Load<Texture2D>((component as Appearance).texturePath);
                }
                if (component.Name == "position")
                {
                    position.X = (component as Position).x;
                    position.Y = (component as Position).y;
                }
            }
            this.renderables.Add(entityId, new Tuple<Vector2, Texture2D>(position, texture));
        }

        public void Update(List<IEntityComponent> entityComponents, Guid entityId, GameTime gameTime)
        {

        }

        public void Draw(List<IEntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {

        }
    }
}
