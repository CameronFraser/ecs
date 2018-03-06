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

        public void Initialize(List<EntityComponent> entityComponents, Guid entityId)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }

        public void LoadContent(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }

        public void Update(List<EntityComponent> entityComponents, Guid entityId, GameTime gameTime)
        {
            Velocity VelocityComponent = null;
            Position PositionComponent = null;

            foreach (var component in entityComponents)
            {
                if (component.Name == "velocity")
                {
                    VelocityComponent = (Velocity)component;
                }
                if (component.Name == "position")
                {
                    PositionComponent = (Position)component;
                }
            }
            if (VelocityComponent != null && PositionComponent != null)
            {
                if (VelocityComponent.IsMoving)
                {
                    Vector2 directions = VelocityComponent.Directions;
                    // Monogame coordinate system has the (0,0) origin in the upper left hand corner
                    PositionComponent.Y += (int)directions.Y * VelocityComponent.Speed;
                    PositionComponent.X += (int)directions.X * VelocityComponent.Speed;
                }
            }
            


        }

        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }
    }
}
