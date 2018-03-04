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
        private Dictionary<Guid, Tuple<Vector2, Texture2D>> Renderables; // Dunno if tuple was the right choice, just need data holders I can make on the fly
        private ContentManager Content;

        public Render()
        {
            this.ComponentNames = new List<string> { "appearance", "position" };
            this.Renderables = new Dictionary<Guid, Tuple<Vector2, Texture2D>>();
        }

        public void Initialize(List<IEntityComponent> entityComponents, Guid entityId)
        {
            Content = GameServices.GetService<ContentManager>();
        }

        public void LoadContent(List<IEntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            Texture2D texture = null;
            Vector2 position = new Vector2();
            foreach (var component in entityComponents)
            {
                if (component.Name == "appearance")
                {
                    texture = Content.Load<Texture2D>((component as Appearance).TexturePath);
                }
                else if (component.Name == "position")
                {
                    position.X = (component as Position).X;
                    position.Y = (component as Position).Y;
                }
            }
            this.Renderables.Add(entityId, new Tuple<Vector2, Texture2D>(position, texture));
        }

        public void Update(List<IEntityComponent> entityComponents, Guid entityId, GameTime gameTime)
        {
            var renderableComponents = this.Renderables[entityId];
            Vector2 position = new Vector2();

            foreach (var component in entityComponents)
            {
                if (component.Name == "position")
                {
                    position.X = (component as Position).X;
                    position.Y = (component as Position).Y;
                }
            }

            this.Renderables[entityId] = new Tuple<Vector2, Texture2D>(position, renderableComponents.Item2);
        }

        public void Draw(List<IEntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            foreach (var renderable in this.Renderables.Values)
            {
                spriteBatch.Draw(renderable.Item2, renderable.Item1, Color.White);
            }
        }
    }
}
