using System.Collections.Generic;
using ECS.ECS;

namespace ECS.Components
{
    class TileMap : EntityComponent
    {
        public override string Name { get; set; }
        public List<string> TileLayerNames;

        public TileMap(List<string> tileLayerNames)
        {
            this.Name = "tilemap";
            this.TileLayerNames = tileLayerNames;
        }
    }
}
