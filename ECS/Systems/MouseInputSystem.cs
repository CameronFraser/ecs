using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECS.Components;

namespace ECS.Systems
{
    class MouseInputSystem : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }

        public MouseInputSystem()
        {
            this.ComponentNames = new List<string> { "mouse_controlled", "position" };
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
            var mouseControlledComponent = entityComponents.FirstOrDefault(ec => ec is MouseControlledComponent) as MouseControlledComponent;
            var positionComponent = entityComponents.FirstOrDefault(ec => ec is PositionComponent) as PositionComponent;

            if (mouseControlledComponent == null || positionComponent == null) return;

            MouseState mState = Mouse.GetState();
            positionComponent.X = mState.Position.X;
            positionComponent.Y = mState.Position.Y;
        }

        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }
    }
}
