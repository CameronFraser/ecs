using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    interface IScene
    {
        bool IsActive { get; set; }
        string SceneName { get; set; }
    }
}
