using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ECS.ECS;
using System.Linq;
using ECS.Components;

namespace ECS.Systems
{
    /// <summary>
    /// Checks if entity is moving and its direction. Will adjust the entities position component values
    /// based on the velocity
    /// </summary>
    class Motion : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }

        public Motion()
        {
            this.ComponentNames = new List<string> { "velocity", "position" };
        }

        public void Initialize(List<IEntityComponent> entityComponents, Guid entityId)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }

        public void LoadContent(List<IEntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }

        public void Update(List<IEntityComponent> entityComponents, Guid entityId, GameTime gameTime)
        {
            try {
                Velocity velocityComponent = (Velocity)entityComponents.Where(component => component.Name == "velocity").Single();
                Position positionComponent = (Position)entityComponents.Where(component => component.Name == "position").Single();

                if (velocityComponent.IsMoving)
                {
                    Vector2 directions = velocityComponent.Directions;
                    // Monogame coordinate system has the (0,0) origin in the upper left hand corner
                    positionComponent.Y += (int)directions.Y * velocityComponent.Speed;
                    positionComponent.X += (int)directions.X * velocityComponent.Speed;
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }

        public void Draw(List<IEntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }
    }
}
