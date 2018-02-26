using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    class Scene : IScene
    {
        public bool IsActive { get; set; }
        public string SceneName { get; set; }

        public void Print()
        {
            Console.WriteLine("==============");
            Console.WriteLine("Scene Name: " + SceneName);
            Console.WriteLine("IsActive: " + IsActive.ToString());
            Console.WriteLine("==============");
        }
    }
}
