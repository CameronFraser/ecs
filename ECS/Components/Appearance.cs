using ECS.ECS;

namespace ECS.Components
{
    class Appearance : EntityComponent
    {
        public override string Name { get; set; }
        public string TexturePath;

        public Appearance(string texturePath)
        {
            this.Name = "appearance";
            this.TexturePath = texturePath;
        }
    }
}
