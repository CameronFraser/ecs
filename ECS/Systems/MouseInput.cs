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
            try
            {
                MouseState mState = Mouse.GetState();
                MouseControlled mouseControlled = entityComponents.SingleOrDefault(component => component.Name == "mouse_controlled") as MouseControlled;
                Position positionComponent = entityComponents.SingleOrDefault(component => component.Name == "position") as Position;
                if (positionComponent != null && mouseControlled != null)
                {
                    positionComponent.X = mState.Position.X;
                    positionComponent.Y = mState.Position.Y;
                }
            }
            catch (Exception e)
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
