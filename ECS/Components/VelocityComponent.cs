using Microsoft.Xna.Framework;

namespace ECS.Components
{
    class VelocityComponent : EntityComponent
    {
        public Vector2 Directions;
        public int Speed;
        public bool IsMoving;

        public VelocityComponent(int speed, Vector2 directions)
        {
            this.Name = "velocity";
            this.IsMoving = false;
            this.Speed = speed;
            this.Directions = directions;
        }
    }
}
