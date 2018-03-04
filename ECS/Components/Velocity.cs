using ECS.ECS;

namespace ECS.Components
{
    class Velocity : IEntityComponent
    {
        public string Name { get; set; }
        public enum Direction { Up, Down, Left, Right };
        public Direction? direction;
        public float speed;

        public Velocity(float speed, Direction? direction)
        {
            this.Name = "velocity";

            this.speed = speed;
            this.direction = direction;
        }
    }
}
