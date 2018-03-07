using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.ECS
{
    /// <summary>
    /// Contains a list of systems and a dictionary of Guid and Entity type
    /// where the Guid is the entity ID. 
    /// </summary>
    class World
    {
        private Dictionary<Guid, Entity> Entities;
        private List<IEntitySystem> Systems;

        public World()
        {
            this.Entities = new Dictionary<Guid, Entity>();
            this.Systems = new List<IEntitySystem>();
        }
       
        public void Initialize()
        {
            List<EntityComponent> entityComponents, components;

            foreach (var entity in this.Entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.Systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    if (components.Count > 0)
                    {
                        system.Initialize(components, entity.Id);
                    }
                }
            }
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            List<EntityComponent> entityComponents, components;

            foreach (var entity in this.Entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.Systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    if (components.Count > 0)
                    {
                        system.LoadContent(components, entity.Id, spriteBatch);
                    }
                }
            }
        }

        public void AddSystem(IEntitySystem sys)
        {
            this.Systems.Add(sys);
        }

        public void AddSystems(List<IEntitySystem> sys)
        {
            this.Systems.AddRange(sys);
        }

        public void AddEntity(Entity entity)
        {
            Guid entityId = Guid.NewGuid();
            entity.Id = entityId;
            this.Entities.Add(entityId, entity);
        }

        public void AddEntities(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                Guid entityId = Guid.NewGuid();
                entity.Id = entityId;
                this.Entities.Add(entityId, entity);
            }
        }

        public void Update(GameTime gameTime)
        {
            List<EntityComponent> entityComponents, components;

            foreach (var entity in this.Entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.Systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    if (components.Count > 0)
                    {
                        system.Update(components, entity.Id, gameTime);
                    } 
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            List<EntityComponent> entityComponents, components;

            foreach (var entity in this.Entities.Values)
            {
                entityComponents = entity.Components.Values.ToList();
                foreach (var system in this.Systems)
                {
                    components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    if (components.Count > 0)
                    {
                        system.Draw(components, entity.Id, spriteBatch);
                    }
                }
            }
        }
    }
}
