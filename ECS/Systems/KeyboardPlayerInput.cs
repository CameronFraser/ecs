using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECS.ECS;
using ECS.Components;

namespace ECS.Systems
{
    /// <summary>
    /// Reads player input and updates relevant components
    /// </summary>
    class KeyboardPlayerInput : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }

        public KeyboardPlayerInput()
        {
            this.ComponentNames = new List<string> { "player_controlled", "velocity" };
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
            KeyboardState kState = Keyboard.GetState();
            List<string> directions = new List<string>(); // Should support multiple directions at the same time
            
            if (kState.IsKeyDown(Keys.Left))
            {
                directions.Add("left");
            }
            if (kState.IsKeyDown(Keys.Right))
            {
                directions.Add("right");
            }
            if (kState.IsKeyDown(Keys.Up))
            {
                directions.Add("up");
            }
            if (kState.IsKeyDown(Keys.Down))
            {
                directions.Add("down");
            }

            foreach (var component in entityComponents)
            {
                if (component.Name == "velocity")
                {
                    if (directions.Count > 0)
                    {
                        (component as Velocity).Directions = directions;
                        (component as Velocity).IsMoving = true;
                    }
                    else
                    {
                        (component as Velocity).IsMoving = false;
                    }
                    
                }
            }
        }

        public void Draw(List<IEntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }
    }
}
