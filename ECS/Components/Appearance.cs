﻿using ECS.ECS;

namespace ECS.Components
{
    class Appearance : IComponent
    {
        public string Name { get; set; }
        public string texturePath;

        public Appearance(string texturePath)
        {
            this.Name = "appearance";

            this.texturePath = texturePath;
        }
    }
}
