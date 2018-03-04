using ECS.ECS;

namespace ECS.Components
{
    class Position : IComponent
    {
        public string Name { get; set; }
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
