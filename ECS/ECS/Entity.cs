using System;
using System.Collections.Generic;

namespace ECS.ECS
{
    class Entity
    {
        public Guid Id { get; set; }
        public Dictionary<string, IEntityComponent> Components { get; set; }

        public Entity(List<IEntityComponent> components)
        {
            this.Components = new Dictionary<string, IEntityComponent>();
            foreach (var component in components)
            {
                this.Components.Add(component.Name, component);
            }
        }

        public void AddComponent(IEntityComponent component)
        {
            this.Components.Add(component.Name, component);
        }

        public void RemoveComponent(string componentName)
        {
            this.Components.Remove(componentName);
        }
    }
}
