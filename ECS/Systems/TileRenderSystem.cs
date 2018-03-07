using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ECS.Components;
using ECS.Services;
using System;
using ECS.ECS;

namespace ECS.Systems
{
    class TileRenderSystem : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }
        public Dictionary<string, TileLayerStruct> TileLayers { get; set; }
        public Dictionary<int, TileSetStruct> TileSets { get; set; }
        public Vector2 CameraPosition { get; set; }
        public string LastLog = "";

        private ContentManager Content;
        private GraphicsDeviceManager Graphics;

        public struct TileLayerStruct
        {
            public double opacity;
            public bool visible;
            public int width;
            public int height;
            public List<Tuple<int, int, int>> tiles;

            public TileLayerStruct(double opacity, bool visible, int width, int height, List<Tuple<int, int, int>> tiles)
            {
                this.opacity = opacity;
                this.visible = visible;
                this.tiles = tiles;
                this.width = width;
                this.height = height;
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

        public TileRenderSystem()
        {
            this.ComponentNames = new List<string> { "tilelayer", "tileset", "camera", "position" };
            this.TileLayers = new Dictionary<string, TileLayerStruct>();
            this.TileSets = new Dictionary<int, TileSetStruct>();
            this.CameraPosition = new Vector2(0, 0);
            this.LastLog = "";
        }

        public void Initialize(List<EntityComponent> entityComponents, Guid entityId)
        {
            Content = GameServices.GetService<ContentManager>();
            Graphics = GameServices.GetService<GraphicsDeviceManager>();
        }

        public void LoadContent(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            TileLayerComponent TileLayerComponent = null;
            TileSetComponent TileSetComponent = null;

            foreach (var component in entityComponents)
            {
                if (component.Name == "tilelayer")
                {
                    TileLayerComponent = (TileLayerComponent)component;
                }
                if (component.Name == "tileset")
                {
                    TileSetComponent = (TileSetComponent)component;
                }
            }
            if (TileLayerComponent != null)
            {
                this.TileLayers.Add(TileLayerComponent.LayerName, new TileLayerStruct(TileLayerComponent.Opacity, TileLayerComponent.Visible, TileLayerComponent.Width, TileLayerComponent.Height, TileLayerComponent.Tiles));
            }
            if (TileSetComponent != null)
            {
                var texture = Content.Load<Texture2D>(TileSetComponent.TexturePath);
                this.TileSets.Add(TileSetComponent.FirstGid, new TileSetStruct(texture, TileSetComponent.TileHeight, TileSetComponent.TileWidth));
            }
        }

        public void Update(List<EntityComponent> entityComponents, Guid entityId, GameTime gameTime)
        {
            CameraComponent CameraComponent = null;
            PositionComponent PositionComponent = null;
            foreach (var component in entityComponents)
            {
                if (component.Name == "position")
                {
                    PositionComponent = (PositionComponent)component;
                }
                if (component.Name == "camera")
                {
                    CameraComponent = (CameraComponent)component;
                }
            }
            if (CameraComponent != null && PositionComponent != null)
            {
                this.CameraPosition = new Vector2(PositionComponent.X, PositionComponent.Y);
            }
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

                            Rectangle tilesetRec = new Rectangle(tileSet.tileWidth * column, tileSet.tileHeight * row, tileSet.tileWidth, tileSet.tileHeight);

                            int offSetX = (int)this.CameraPosition.X + (Graphics.PreferredBackBufferWidth / 2);
                            int offSetY = (int)this.CameraPosition.Y + (Graphics.PreferredBackBufferHeight / 2);
                            offSetX = MathHelper.Clamp(offSetX, 0, 32 * layer.width - Graphics.PreferredBackBufferWidth);
                            offSetY = MathHelper.Clamp(offSetY, 0, 32 * layer.height - Graphics.PreferredBackBufferHeight);
                            int tileX = x * tileSet.tileWidth - offSetX;
                            int tileY = y * tileSet.tileHeight - offSetY;
                            
                            if (offSetX > (32 * layer.width))
                            {
                                Console.WriteLine(offSetX);
                            }
                            Rectangle destRectangle = new Rectangle(tileX, tileY, tileSet.tileWidth, tileSet.tileHeight);

                            spriteBatch.Draw(
                                tileSet.texture,
                                destRectangle,
                                tilesetRec,
                                Color.White
                            );
                        }
                    }
                }
            }
            
        }
    }
}
