using System;
using System.Collections.Generic;

namespace ECS.ECS
{
    class Entity
    {
        public Guid Id { get; set; }
        public Dictionary<string, EntityComponent> Components { get; set; }

        public Entity(List<EntityComponent> components)
        {
            this.Components = new Dictionary<string, EntityComponent>();
            foreach (var component in components)
            {
                this.Components.Add(component.Name, component);
            }
        }

        public void AddComponent(EntityComponent component)
        {
            this.Components.Add(component.Name, component);
        }

        public void RemoveComponent(string componentName)
        {
            this.Components.Remove(componentName);
        }
    }
}
