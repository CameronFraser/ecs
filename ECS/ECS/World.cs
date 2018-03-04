using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.ECS
{
    class World
    {
        private Dictionary<Guid, Entity> entities;
        private List<IEntitySystem> systems;

        public World()
        {
            this.entities = new Dictionary<Guid, Entity>();
            this.systems = new List<IEntitySystem>();
        }

        public void Initialize()
        {
            List<IEntityComponent> entityComponents, components;

            foreach (var entity in this.entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    system.Initialize(components, entity.Id);
                }
            }
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            List<IEntityComponent> entityComponents, components;

            foreach (var entity in this.entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    system.LoadContent(components, entity.Id, spriteBatch);
                }
            }
        }

        public void AddSystem(IEntitySystem sys)
        {
            this.systems.Add(sys);
        }

        public void AddSystems(List<IEntitySystem> sys)
        {
            this.systems.AddRange(sys);
        }

        public void AddEntity(Entity entity)
        {
            Guid entityId = Guid.NewGuid();
            entity.Id = entityId;
            this.entities.Add(entityId, entity);
        }

        public void AddEntities(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                Guid entityId = Guid.NewGuid();
                entity.Id = entityId;
                this.entities.Add(entityId, entity);
            }
        }

        public void Update(GameTime gameTime)
        {
            List<IEntityComponent> entityComponents, components;

            foreach (var entity in this.entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    system.Update(components, entity.Id, gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            List<IEntityComponent> entityComponents, components;

            foreach (var entity in this.entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    system.Draw(components, entity.Id, spriteBatch);
                }
            }
        }
    }
}
