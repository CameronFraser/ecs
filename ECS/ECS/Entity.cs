using System;
using System.Collections.Generic;

namespace ECS.ECS
{
    class Entity
    {
        public Guid Id { get; set; }
        public Dictionary<string, IComponent> Components { get; }

        public Entity(List<IComponent> components)
        {
            foreach (var component in components)
            {
                this.Components.Add(component.Name, component);
            }
        }

        public void AddComponent(IComponent component)
        {
            this.Components.Add(component.Name, component);
        }

        public void RemoveComponent(string componentName)
        {
            this.Components.Remove(componentName);
        }
    }
}
