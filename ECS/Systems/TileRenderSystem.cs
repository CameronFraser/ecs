using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ECS.Components;
using System;
using System.Linq;

namespace ECS.Systems
{
    class TileRenderSystem : IEntitySystem
    {
        public List<string> ComponentNames { get; set; }
        public Dictionary<string, TileLayer> TileLayers { get; set; }
        public Dictionary<int, TileSet> TileSets { get; set; }
        public Vector2 CameraPosition { get; set; }
        public string LastLog = "";

        private ContentManager Content;
        private GraphicsDeviceManager Graphics;

        public class TileLayer
        {
            public double opacity;
            public bool visible;
            public int width;
            public int height;
            public List<Tile> tiles;

            public TileLayer(double opacity, bool visible, int width, int height, List<Tile> tiles)
            {
                this.opacity = opacity;
                this.visible = visible;
                this.tiles = tiles;
                this.width = width;
                this.height = height;
            }
        }

        public class TileSet
        {
            public Texture2D texture;
            public int tileHeight;
            public int tileWidth;

            public TileSet(Texture2D texture, int tileHeight, int tileWidth)
            {
                this.texture = texture;
                this.tileHeight = tileHeight;
                this.tileWidth = tileWidth;
            }
        }

        public TileRenderSystem()
        {
            this.ComponentNames = new List<string> { "tilelayer", "tileset", "camera", "position" };
            this.TileLayers = new Dictionary<string, TileLayer>();
            this.TileSets = new Dictionary<int, TileSet>();
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
            var tlc = entityComponents.FirstOrDefault(ec => ec is TileLayerComponent) as TileLayerComponent;
            var tsc = entityComponents.FirstOrDefault(ec => ec is TileSetComponent) as TileSetComponent;
            if (tlc != null)
            {
                // TODO: Should TileLayerComponent just replace its properties with the TileLayer object?
                TileLayers.Add(tlc.LayerName, new TileLayer(tlc.Opacity, tlc.Visible, tlc.Width, tlc.Height, tlc.Tiles));
            }
            if (tsc != null)
            {
                var texture = Content.Load<Texture2D>(tsc.TexturePath);
                TileSets.Add(tsc.FirstGid, new TileSet(texture, tsc.TileHeight, tsc.TileWidth));
            }
        }

        public void Update(List<EntityComponent> entityComponents, Guid entityId, GameTime gameTime)
        {
            var cameraComponent = entityComponents.FirstOrDefault(ec => ec is CameraComponent) as CameraComponent;
            var positionComponent = entityComponents.FirstOrDefault(ec => ec is PositionComponent) as PositionComponent;

            if (cameraComponent == null || positionComponent == null) return;

            this.CameraPosition = new Vector2(positionComponent.X, positionComponent.Y);
        }

        public void Draw(List<EntityComponent> entityComponents, Guid entityId, SpriteBatch spriteBatch)
        {
            foreach (var layer in TileLayers.Values)
                if (layer.visible)
                    foreach (var tile in layer.tiles)
                        RenderTile(spriteBatch, tile, layer);
        }

        private void RenderTile(SpriteBatch spriteBatch, Tile tile, TileLayer layer)
        {
            var gid = tile.Gid;
            var x = tile.X;
            var y = tile.Y;

            // TODO: What were you trying to do here? you set it to 1 and then check if it's not -1 (it never would be) and then use it to get the tile set of 1 and that's it?
            // There's always only one tile set and its key is always 1
            int tileSetKey = 1;
            if (tileSetKey == -1) return;
            TileSet tileSet = this.TileSets[tileSetKey];
            int tilesHigh = tileSet.texture.Height / tileSet.tileHeight;
            int tilesWide = tileSet.texture.Width / tileSet.tileWidth;

            int column = (gid - 1) % tilesWide;
            //you can add 'd' to constants to cast them to doubles...(int - double) / int => double *shrug* I just use resharper to tell me what to do with this one so don't take it personally if that went over your head
            int row = (int)Math.Floor((gid - 1d) / tilesWide); //Why Math.Floor doesn't return an int I don't know

            //new Rectangle(x,y,w,h)
            Rectangle tileSetRec = new Rectangle(tileSet.tileWidth * column, tileSet.tileHeight * row, tileSet.tileWidth, tileSet.tileHeight);

            int offSetX = (int)this.CameraPosition.X + (Graphics.PreferredBackBufferWidth / 2);
            int offSetY = (int)this.CameraPosition.Y + (Graphics.PreferredBackBufferHeight / 2);
            //TODO: Is clamp what is blocking the camera from going off the edges?
            offSetX = MathHelper.Clamp(offSetX, 0, 32 * layer.width - Graphics.PreferredBackBufferWidth);
            offSetY = MathHelper.Clamp(offSetY, 0, 32 * layer.height - Graphics.PreferredBackBufferHeight);
            int tileX = x * tileSet.tileWidth - offSetX;
            int tileY = y * tileSet.tileHeight - offSetY;

            if (offSetX > 32 * layer.width)
                Console.WriteLine(offSetX);

            Rectangle destRectangle = new Rectangle(tileX, tileY, tileSet.tileWidth, tileSet.tileHeight);

            spriteBatch.Draw(
                tileSet.texture,
                destRectangle,
                tileSetRec,
                Color.White
            );
        }
    }
}
