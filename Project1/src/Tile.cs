using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProject.src
{
    enum TileType
    {
        Grass,
        Soil,
    }
    internal class Tile : Component
    {
        public int Col { get; set; }
        public int Row { get; set; }

        public Rectangle Rect { get; set; }
        public TileType Type { get; set; } = TileType.Grass;

        public Tile(int index)
        {
            GridPoint point = Grid.GetGridPointFromIterator(index);
            Col = point.Col;
            Row = point.Row;
            int x = (Col - 1) * Grid.TILE_SIZE;
            int y = (Row - 1) * Grid.TILE_SIZE + 4;
            Rect = new Rectangle(x, y, Grid.TILE_SIZE, Grid.TILE_SIZE);
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.IsClick(Rect))
            {
                this.Type = this.Type == TileType.Soil ? TileType.Grass : TileType.Soil;
            }
        }

        private Texture2D GetTexture()
        {
            return Type switch
            {
                TileType.Grass => Game1.grassSprite,
                TileType.Soil => Game1.soilSprite,
                _ => null,
            };
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = GetTexture();
            spriteBatch.Draw(texture, Rect, Color.White);
        }
    }
}
