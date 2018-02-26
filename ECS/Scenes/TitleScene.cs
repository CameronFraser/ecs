
namespace ECS.Scenes
{
    class TitleScene : Scene, IScene
    {
        public TitleScene(string sceneName, bool isActive)
        {
            IsActive = isActive;
            SceneName = sceneName;
        }
    }
}
