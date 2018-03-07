namespace ECS.Components
{
    class AppearanceComponent : EntityComponent
    {
        public string TexturePath;

        public AppearanceComponent(string texturePath)
        {
            this.Name = "appearance";
            this.TexturePath = texturePath;
        }
    }
}
