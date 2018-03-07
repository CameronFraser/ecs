using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ECS.Components;

namespace ECS.Systems
{
    /// <summary>
    /// Checks if entity is moving and its direction. Will adjust the entities position component values
    /// based on the velocity
    /// </summary>
    class MotionSystem : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }

        public MotionSystem()
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
            //instead of using the name == you could use 'is'
            var velocityComponent = entityComponents.FirstOrDefault(ec => ec is VelocityComponent) as VelocityComponent;
            var positionComponent = entityComponents.FirstOrDefault(ec => ec is PositionComponent) as PositionComponent;

            if (velocityComponent == null || positionComponent == null || !velocityComponent.IsMoving) return;
            var directions = velocityComponent.Directions;
            // Monogame coordinate system has the (0,0) origin in the upper left hand corner
            positionComponent.Y += (int)directions.Y * velocityComponent.Speed;
            positionComponent.X += (int)directions.X * velocityComponent.Speed;
        }

        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }
    }
}
