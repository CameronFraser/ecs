using TiledSharp;
using ECS.ECS;

namespace ECS.Components
{
    class TileSet : EntityComponent
    {
        public override string Name { get; set; }
        public string TexturePath { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int FirstGid { get; set; }

        public TileSet(TmxTileset tileSet)
        {
            this.Name = "tileset";
            this.TexturePath = tileSet.Name;
            this.TileWidth = tileSet.TileWidth;
            this.TileHeight = tileSet.TileHeight;
            this.FirstGid = tileSet.FirstGid;
        }
    }
}
