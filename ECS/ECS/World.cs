using System;
using System.Collections.Generic;
using System.Linq;
using ECS.Components;
using ECS.Systems;
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
            foreach (var entity in Entities.Values)
            {
                var entityComponents = entity.Components.Values;
                foreach (var system in Systems)
                {
                    var components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    if (components.Count > 0)
                    {
                        system.Initialize(components, entity.Id);
                    }
                }
            }
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            foreach (var entity in this.Entities.Values)
            {
                var entityComponents = entity.Components.Values;
                foreach (var system in this.Systems)
                {
                    var components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
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

        public void AddSystems(IEnumerable<IEntitySystem> sys)
        {
            this.Systems.AddRange(sys);
        }

        public void AddEntity(Entity entity)
        {
            entity.Id = Guid.NewGuid();
            this.Entities.Add(entity.Id, entity);
        }

        public void AddEntities(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities)
                AddEntity(entity);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var entity in this.Entities.Values)
            {
                var entityComponents = entity.Components.Values;
                foreach (var system in this.Systems)
                {
                    var components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    if (components.Count > 0)
                    {
                        system.Update(components, entity.Id, gameTime);
                    } 
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in this.Entities.Values)
            {
                var entityComponents = entity.Components.Values;
                foreach (var system in this.Systems)
                {
                    var components = entityComponents.Where(component => system.ComponentNames.Contains(component.Name)).ToList();
                    if (components.Count > 0)
                    {
                        system.Draw(components, entity.Id, spriteBatch);
                    }
                }
            }
        }
    }
}
