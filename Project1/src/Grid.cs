using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProject.src
{
    internal class Grid : Component
    {
        public static int COL_COUNT = 40;
        public static int ROW_COUNT = 22;
        public static int TILE_SIZE = 16;

        static int idHelper = 0;

        readonly List<Tile> Tiles = Enumerable.Range(0, Grid.COL_COUNT * Grid.ROW_COUNT)
                      .Select(i => new Tile(i))
                      .ToList();

        public Grid() {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Tiles.ForEach((t) => t.Draw(spriteBatch));
        }

        public override void Update(GameTime gameTime)
        {
            Tiles.ForEach((t) => t.Update(gameTime));
        }

        public static GridPoint GetGridPointFromIterator(int i)
        {
            int n = i + 1;
            int row = (int)Math.Ceiling((double)n / Grid.COL_COUNT);
            int col = n % Grid.COL_COUNT;
            if (col == 0)
            {
                col = Grid.COL_COUNT;
            }

            return new GridPoint(row, col);
        }

        public static string GetIdFromGridPoint(GridPoint point)
        {
            Grid.idHelper++;
            return $"{Grid.idHelper}-{point.Row:D2}-{point.Col:D2}";
        }
    }

    class GridPoint
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public GridPoint(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
