using Microsoft.Xna.Framework;
using System.Collections.Generic;
using ECS.ECS;

namespace ECS.Components
{
    class Velocity : IEntityComponent
    {
        public string Name { get; set; }
        public Vector2 Directions;
        public int Speed;
        public bool IsMoving;

        public Velocity(int speed, Vector2 directions)
        {
            this.Name = "velocity";
            this.IsMoving = false;
            this.Speed = speed;
            this.Directions = directions;
        }
    }
}
