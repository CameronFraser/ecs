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
            try
            {
                MouseState mState = Mouse.GetState();
                MouseControlled mouseControlled = (MouseControlled)entityComponents.Where(component => component.Name == "mouse_controlled").Single();
                Position positionComponent = (Position)entityComponents.Where(component => component.Name == "position").Single();

                positionComponent.X = mState.Position.X;
                positionComponent.Y = mState.Position.Y;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }
    }
}
