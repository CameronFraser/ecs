using ECS.ECS;

namespace ECS.Components
{
    class Velocity : IEntityComponent
    {
        public string Name { get; set; }
        public string Direction;
        public int Speed;
        public bool IsMoving;

        public Velocity(int speed, string direction)
        {
            this.Name = "velocity";
            this.IsMoving = false;
            this.Speed = speed;
            this.Direction = direction;
        }
    }
}
