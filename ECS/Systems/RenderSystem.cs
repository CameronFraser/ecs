using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ECS.Components;
using System;
using System.Linq;
using ECS.ECS;

namespace ECS.Systems
{
    /// <summary>
    /// Renders enitities that have the appearance and position components
    /// </summary>
    class RenderSystem : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }
        private Dictionary<Guid, Tuple<Vector2, Texture2D>> Renderables; // Dunno if tuple was the right choice, just need data holders I can make on the fly
        private ContentManager Content;

        public RenderSystem()
        {
            this.ComponentNames = new List<string> { "appearance", "position" };
            this.Renderables = new Dictionary<Guid, Tuple<Vector2, Texture2D>>();
        }

        public void Initialize(List<EntityComponent> entityComponents, Guid entityId)
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
        public void LoadContent(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            AppearanceComponent AppearanceComponent = null;
            PositionComponent PositionComponent = null;
            Texture2D texture = null;

            foreach (var component in entityComponents)
            {
                if (component.Name == "appearance")
                {
                    AppearanceComponent = (AppearanceComponent)component;
                    texture = Content.Load<Texture2D>(AppearanceComponent.TexturePath);
                }
                if (component.Name == "position")
                {
                    PositionComponent = (PositionComponent)component;
                }
            }
            if (AppearanceComponent != null && PositionComponent != null)
            {
                this.Renderables.Add(entityId, new Tuple<Vector2, Texture2D>(new Vector2(PositionComponent.X, PositionComponent.Y), texture));
            }
        }
        /// <summary>
        /// Loops through components for positional component and 
        /// saves positional data for the render cycle
        /// </summary>
        /// <param name="entityComponents">List of entity components associated with the current entity</param>
        /// <param name="entityId">The guid of the current entity</param>
        /// <param name="gameTime">Time passed since last time draw was called</param>
        public void Update(List<EntityComponent> entityComponents, Guid entityId, GameTime gameTime)
        {
            AppearanceComponent AppearanceComponent = null;
            PositionComponent PositionComponent = null;

            foreach (var component in entityComponents)
            {
                if (component.Name == "appearance")
                {
                    AppearanceComponent = (AppearanceComponent)component;
                }
                if (component.Name == "position")
                {
                    PositionComponent = (PositionComponent)component;
                }
            }

            if (PositionComponent != null && AppearanceComponent != null)
            {
                var renderableComponents = this.Renderables[entityId];
                this.Renderables[entityId] = new Tuple<Vector2, Texture2D>(new Vector2(PositionComponent.X, PositionComponent.Y), renderableComponents.Item2);
            }
        }
        /// <summary>
        /// Loops through all the renderables and renders them
        /// </summary>
        /// <param name="entityComponents">List of entity components associated with the current entity</param>
        /// <param name="entityId">The guid of the current entity</param>
        /// <param name="spriteBatch"></param>
        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            foreach (var renderable in this.Renderables.Values)
            {
                if (renderable.Item2 != null && renderable.Item2 != null)
                {
                    Vector2 position = renderable.Item1;
                    Vector2 adjustedPosition = new Vector2(position.X + renderable.Item2.Width / 2, position.Y + renderable.Item2.Height / 2);
                    spriteBatch.Draw(renderable.Item2, adjustedPosition, Color.White);
                }
            }
        }
    }
}
