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
    class KeyboardInputSystem : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }

        public KeyboardInputSystem()
        {
            this.ComponentNames = new List<string> { "player_controlled", "velocity" };
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
            VelocityComponent VelocityComponent = null;
            PlayerControlledComponent PlayerControlledComponent = null;

            foreach (var component in entityComponents)
            {
                if (component.Name == "velocity")
                {
                    VelocityComponent = (VelocityComponent)component;
                }
                if (component.Name == "player_controlled")
                {
                    PlayerControlledComponent = (PlayerControlledComponent)(component);
                }
            }

            if (VelocityComponent != null && PlayerControlledComponent != null)
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

                if (x == 0 && y == 0)
                {
                    VelocityComponent.IsMoving = false;
                }
                else
                {
                    VelocityComponent.Directions = new Vector2(x, y);
                    VelocityComponent.IsMoving = true;
                }
            }
        }

        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            // Dont need some of these methods, maybe they should be in a class I inherit from and override?
        }
    }
}
