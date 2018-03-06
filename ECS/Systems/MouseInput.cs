using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECS.ECS;
using ECS.Components;

namespace ECS.Systems
{
    class MouseInput : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }

        public MouseInput()
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

            MouseControlled MouseControlledComponent = null;
            Position PositionComponent = null;

            foreach (var component in entityComponents)
            {
                if (component.Name == "mouse_controlled")
                {
                    MouseControlledComponent = (MouseControlled)component;
                }
                if (component.Name == "position")
                {
                    PositionComponent = (Position)(component);
                }
            }
            if (MouseControlledComponent != null && PositionComponent != null)
            {
                MouseState mState = Mouse.GetState();
                PositionComponent.X = mState.Position.X;
                PositionComponent.Y = mState.Position.Y;
            }
        }

        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }
    }
}
