using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ECS.Components;
using System;
using ECS.ECS;

namespace ECS.Systems
{
    /// <summary>
    /// Renders enitities that have the appearance and position components
    /// </summary>
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
        /// <summary>
        /// Loops through a list of components and either loads a texture
        /// or reads a positional value based on the component.
        /// Adds the data to a dictionary with the entity guid as
        /// a key for lookup during update
        /// </summary>
        /// <param name="entityComponents">List of entity components associated with the current entity</param>
        /// <param name="entityId">The guid of the current entity</param>
        /// <param name="spriteBatch"></param>
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
        /// <summary>
        /// Loops through components for positional component and 
        /// saves positional data for the render cycle
        /// </summary>
        /// <param name="entityComponents">List of entity components associated with the current entity</param>
        /// <param name="entityId">The guid of the current entity</param>
        /// <param name="gameTime">Time passed since last time draw was called</param>
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
        /// <summary>
        /// Loops through all the renderables and renders them
        /// </summary>
        /// <param name="entityComponents">List of entity components associated with the current entity</param>
        /// <param name="entityId">The guid of the current entity</param>
        /// <param name="spriteBatch"></param>
        public void Draw(List<IEntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            foreach (var renderable in this.Renderables.Values)
            {
                spriteBatch.Draw(renderable.Item2, renderable.Item1, Color.White);
            }
        }
    }
}
