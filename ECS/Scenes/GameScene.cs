
namespace ECS.Scenes
{
    class GameScene : Scene, IScene
    {
        public GameScene(string sceneName, bool isActive)
        {
            IsActive = isActive;
            SceneName = sceneName;
        }
    }
}
