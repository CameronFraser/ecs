using Microsoft.Xna.Framework;

namespace ECS
{
    class GameServices
    {
        private static GameServiceContainer container;
        public static GameServiceContainer Instance
        {
            get { return container ?? (container = new GameServiceContainer()); }
        }

        public static T GetService<T>()
        {
            return (T)Instance.GetService(typeof(T));
        }

        public static void AddService<T>(T service)
        {
            Instance.AddService(typeof(T), service);
        }

        public static void RemoveService<T>()
        {
            Instance.RemoveService(typeof(T));
        }
    }
}
