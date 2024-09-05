using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace FarmProject.src
{


    enum GridObjectName
    {
        Plant,
    }


    internal class GridObject : Component
    {
        int Row { get; set; }
        int Col { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        GridObjectName Name { get; set; }
        string Id { get; set; }
        GridPoint[] Spaces { get; set; }

        public GridObject(int row, int col, int width, int height, GridObjectName name, GridPoint[] spaces)
        {
            Row = row;
            Col = col;
            Width = width;
            Height = height;
            Name = name;
            Id = Grid.GetIdFromGridPoint(new GridPoint(row, col));
            Spaces = spaces;
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public override void Update(GameTime gameTime)
        {

        }
    }

    
}
