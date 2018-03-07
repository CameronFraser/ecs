using System.Collections.Generic;
using System.Linq;
using TiledSharp;

namespace ECS.Components
{
    class TileLayerComponent : EntityComponent
    {
        public string LayerName { get; set; }
        public double? OffsetX { get; set; }
        public double? OffsetY { get; set; }
        public double Opacity { get; set; }
        public bool Visible { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Tile> Tiles { get; set; }

        public TileLayerComponent(TmxLayer layer, int width, int height)
        {
            this.Name = "tilelayer";
            this.LayerName = layer.Name;
            this.OffsetX = layer.OffsetX;
            this.OffsetY = layer.OffsetY;
            this.Opacity = layer.Opacity;
            this.Visible = layer.Visible;
            this.Width = width;
            this.Height = height;

            this.Tiles = layer.Tiles.Select(t => new Tile { Gid = t.Gid, X = t.X, Y = t.Y }).ToList();
        }
    }
}
