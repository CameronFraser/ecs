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
            var x = 0;
            var y = 0;
            
            if (kState.IsKeyDown(Keys.Left))
            {
                x = -1;
            }
            if (kState.IsKeyDown(Keys.Right))
            {
                x = 1;
            }
            if (kState.IsKeyDown(Keys.Up))
            {
                y = -1;
            }
            if (kState.IsKeyDown(Keys.Down))
            {
                y = 1;
            }

            foreach (var component in entityComponents)
            {
                if (component.Name == "velocity")
                {
                    if (x == 0 && y == 0)
                    {
                        (component as Velocity).IsMoving = false;
                    }
                    else
                    {
                        (component as Velocity).Directions = new Vector2(x, y);
                        (component as Velocity).IsMoving = true;
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
