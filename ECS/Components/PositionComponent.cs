using ECS.ECS;

namespace ECS.Components
{
    class PositionComponent : EntityComponent
    {
        public override string Name { get; set; }
        public int X;
        public int Y;

        public PositionComponent(int x, int y)
        {
            this.Name = "position";
            this.X = x;
            this.Y = y;
        }
    }
}
