using ECS.ECS;

namespace ECS.Components
{
    class Velocity : IEntityComponent
    {
        public string Name { get; set; }
        public string Direction;
        public float Speed;
        public bool IsMoving;

        public Velocity(float speed, string direction)
        {
            this.Name = "velocity";
            this.IsMoving = false;
            this.Speed = speed;
            this.Direction = direction;
        }
    }
}
