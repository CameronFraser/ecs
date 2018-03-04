using ECS.ECS;

namespace ECS.Components
{
    class Position : IEntityComponent
    {
        public string Name { get; set; }
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.Name = "position";
            this.x = x;
            this.y = y;
        }
    }
}
