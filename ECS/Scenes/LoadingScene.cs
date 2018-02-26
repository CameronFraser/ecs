
namespace ECS.Scenes
{
    class LoadingScene : Scene, IScene
    {
        public LoadingScene(string sceneName, bool isActive)
        {
            IsActive = isActive;
            SceneName = sceneName;
        }
    }
}
