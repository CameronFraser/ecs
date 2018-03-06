using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ECS.Components;
using System;
using ECS.ECS;

namespace ECS.Systems
{
    class TileRender : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }
        public Dictionary<string, TileLayerStruct> TileLayers { get; set; }
        public Dictionary<int, TileSetStruct> TileSets { get; set; }

        private ContentManager Content;

        public struct TileLayerStruct
        {
            public double opacity;
            public bool visible;
            public List<Tuple<int, int, int>> tiles;

            public TileLayerStruct(double opacity, bool visible, List<Tuple<int, int, int>> tiles)
            {
                this.opacity = opacity;
                this.visible = visible;
                this.tiles = tiles;
            }
        }

        public struct TileSetStruct
        {
            public Texture2D texture;
            public int tileHeight;
            public int tileWidth;

            public TileSetStruct(Texture2D texture, int tileHeight, int tileWidth)
            {
                this.texture = texture;
                this.tileHeight = tileHeight;
                this.tileWidth = tileWidth;
            }

        }

        public TileRender()
        {
            this.ComponentNames = new List<string> { "tilelayer", "tileset" };
            this.TileLayers = new Dictionary<string, TileLayerStruct>();
            this.TileSets = new Dictionary<int, TileSetStruct>();
        }

        public void Initialize(List<EntityComponent> entityComponents, Guid entityId)
        {
            Content = GameServices.GetService<ContentManager>();
        }

        public void LoadContent(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            TileLayer TileLayerComponent = null;
            TileSet TileSetComponent = null;

            foreach (var component in entityComponents)
            {
                if (component.Name == "tilelayer")
                {
                    TileLayerComponent = (TileLayer)component;
                    Console.WriteLine("Tile Layer found");
                }
                if (component.Name == "tileset")
                {
                    TileSetComponent = (TileSet)component;
                    Console.WriteLine("Tile Set found");
                }
            }
            if (TileLayerComponent != null)
            {
                this.TileLayers.Add(TileLayerComponent.LayerName, new TileLayerStruct(TileLayerComponent.Opacity, TileLayerComponent.Visible, TileLayerComponent.Tiles));
            }
            if (TileSetComponent != null)
            {
                Console.WriteLine(TileSetComponent.TexturePath);
                var texture = Content.Load<Texture2D>(TileSetComponent.TexturePath);
                this.TileSets.Add(TileSetComponent.FirstGid, new TileSetStruct(texture, TileSetComponent.TileHeight, TileSetComponent.TileWidth));
            }
        }

        public void Update(List<EntityComponent> entityComponents, Guid entityId, GameTime gameTime)
        {
        }

        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            
            foreach (var layer in this.TileLayers.Values)
            {
                if (layer.visible)
                {
                    foreach (var tile in layer.tiles)
                    {
                        var gid = tile.Item1;
                        var x = tile.Item2;
                        var y = tile.Item3;
                        int tileSetKey = 1;

                        if (tileSetKey != -1)
                        {
                            TileSetStruct tileSet = this.TileSets[tileSetKey];
                            int tilesHigh = tileSet.texture.Height / tileSet.tileHeight;
                            int tilesWide = tileSet.texture.Width / tileSet.tileWidth;

                            int column = ((gid - 1) % tilesWide);
                            int row = (int)Math.Floor((double)(gid - 1) / (double)tilesWide);
                            int zoom = 1;

                            Rectangle tilesetRec = new Rectangle(tileSet.tileWidth * column, tileSet.tileHeight * row, tileSet.tileWidth, tileSet.tileHeight);
                            spriteBatch.Draw(tileSet.texture, new Vector2(x * tileSet.tileWidth, y * tileSet.tileHeight), tilesetRec, Color.White, 0.0f, new Vector2(0, 0), new Vector2(zoom, zoom), SpriteEffects.None, 0);
                        }
                    }
                }
            }
            
        }
    }
}
