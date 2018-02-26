using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS
{
    interface IScene
    {
        bool IsActive { get; set; }
        string SceneName { get; set; }
    }
}
