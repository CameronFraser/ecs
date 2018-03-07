using System.Collections.Generic;
using System;
using TiledSharp;
using ECS.ECS;

namespace ECS.Components
{
    class TileLayerComponent : EntityComponent
    {
        public override string Name { get; set; }
        public string LayerName { get; set; }
        public double? OffsetX { get; set; }
        public double? OffsetY { get; set; }
        public double Opacity { get; set; }
        public bool Visible { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Tuple<int, int, int>> Tiles { get; set; }

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

            this.Tiles = new List<Tuple<int, int, int>>();

            foreach (var tile in layer.Tiles)
            {
                this.Tiles.Add(new Tuple<int, int, int>(tile.Gid, tile.X, tile.Y));
            }
        }
    }
}
