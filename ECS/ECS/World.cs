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
        private List<System> systems;

        public World()
        {
            this.entities = new Dictionary<Guid, Entity>();
            this.systems = new List<System>();
        }

        public void Initialize()
        {
            List<IComponent> entityComponents, components;

            foreach (var entity in this.entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    system.Initialize(components);
                }
            }
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            List<IComponent> entityComponents, components;

            foreach (var entity in this.entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    system.LoadContent(components, spriteBatch);
                }
            }
        }

        public void AddSystem(System sys)
        {
            this.systems.Add(sys);
        }

        public void AddSystems(List<System> sys)
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
            List<IComponent> entityComponents, components;

            foreach (var entity in this.entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    system.Update(components, gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            List<IComponent> entityComponents, components;

            foreach (var entity in this.entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    system.Draw(components, spriteBatch);
                }
            }
        }
    }
}
