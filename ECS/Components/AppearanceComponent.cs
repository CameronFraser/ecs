using ECS.ECS;

namespace ECS.Components
{
    class AppearanceComponent : EntityComponent
    {
        public override string Name { get; set; }
        public string TexturePath;

        public AppearanceComponent(string texturePath)
        {
            this.Name = "appearance";
            this.TexturePath = texturePath;
        }
    }
}
