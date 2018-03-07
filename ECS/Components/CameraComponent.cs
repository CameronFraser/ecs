using Microsoft.Xna.Framework;
using ECS.ECS;

namespace ECS.Components
{
    class CameraComponent : EntityComponent
    {
        public override string Name { get; set; }
        public int Zoom { get; set; }

        public CameraComponent(int zoom)
        {
            this.Name = "camera";
            this.Zoom = zoom;
        }
    }
}
