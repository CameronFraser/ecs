namespace ECS.Scenes
{
    interface IScene
    {
        bool IsActive { get; set; }
        string SceneName { get; set; }
    }
}
