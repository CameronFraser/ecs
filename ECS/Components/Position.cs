using ECS.ECS;

namespace ECS.Components
{
    class Position : IEntityComponent
    {
        public string Name { get; set; }
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            this.Name = "position";
            this.X = x;
            this.Y = y;
        }
    }
}
