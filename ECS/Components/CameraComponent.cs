namespace ECS.Components
{
    class CameraComponent : EntityComponent
    {
        public int Zoom { get; set; }

        public CameraComponent(int zoom)
        {
            this.Name = "camera";
            this.Zoom = zoom;
        }
    }
}
