using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ECS.Components;
using System;
using System.Linq;

namespace ECS.Systems
{
    /// <summary>
    /// Renders enitities that have the appearance and position components
    /// </summary>
    class RenderSystem : IEntitySystem
    {
        //Use a class within a class for a quick way to handle tuples or a temporary shape that you only use for this class
        class Renderable
        {
            public Vector2 Position { get; set; }
            public Texture2D Texture { get; set; }
        }

        public List<string> ComponentNames { get; set; }
        private Dictionary<Guid, Renderable> Renderables; // Dunno if tuple was the right choice, just need data holders I can make on the fly
        private ContentManager Content;

        public RenderSystem()
        {
            this.ComponentNames = new List<string> { "appearance", "position" };
            this.Renderables = new Dictionary<Guid, Renderable>();
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
            var appearanceComponent = entityComponents.FirstOrDefault(ec => ec is AppearanceComponent) as AppearanceComponent;
            var positionComponent = entityComponents.FirstOrDefault(ec => ec is PositionComponent) as PositionComponent;
            if (appearanceComponent == null || positionComponent == null)
                return;
            // TODO: AppearanceComponent could reference Texture2D instead of string Path
            var texture = Content.Load<Texture2D>(appearanceComponent.TexturePath);

            // TODO: Why doesn't position component just reference a Vector2? This is making a new Vector2 every load instead of just passing around the vector2 reference (Is this part of loop?)
            Renderables.Add(entityId, new Renderable { Position = new Vector2(positionComponent.X, positionComponent.Y), Texture = texture });
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
            var appearanceComponent = entityComponents.FirstOrDefault(ec => ec is AppearanceComponent) as AppearanceComponent;
            var positionComponent = entityComponents.FirstOrDefault(ec => ec is PositionComponent) as PositionComponent;

            if (positionComponent == null || appearanceComponent == null) return;
            var renderable = this.Renderables[entityId];
            renderable.Position = new Vector2(positionComponent.X, positionComponent.Y);
            //I assume appearanceComponents.Textures never change?
            //renderableComponents.Texture = Content.Load<Texture2D>(appearanceComponent.TexturePath);
        }

        /// <summary>
        /// Loops through all the renderables and renders them
        /// </summary>
        /// <param name="entityComponents">List of entity components associated with the current entity</param>
        /// <param name="entityId">The guid of the current entity</param>
        /// <param name="spriteBatch"></param>
        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            foreach (var renderable in Renderables.Values)
            {
                if (renderable.Texture == null) continue;
                Vector2 position = renderable.Position;
                Vector2 adjustedPosition = new Vector2(position.X + (float)renderable.Texture.Width / 2, position.Y + (float)renderable.Texture.Height / 2);
                spriteBatch.Draw(renderable.Texture, adjustedPosition, Color.White);
            }
        }
    }
}
