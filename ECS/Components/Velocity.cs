using ECS.ECS;

namespace ECS.Components
{
    class Velocity : IEntityComponent
    {
        public string Name { get; set; }
        public enum Direction { Up, Down, Left, Right };
        public Direction? DirectionValue;
        public float Speed;

        public Velocity(float speed, Direction? direction)
        {
            this.Name = "velocity";

            this.Speed = speed;
            this.DirectionValue = direction;
        }
    }
}
