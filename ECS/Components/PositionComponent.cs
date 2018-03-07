namespace ECS.Components
{
    class PositionComponent : EntityComponent
    {
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
