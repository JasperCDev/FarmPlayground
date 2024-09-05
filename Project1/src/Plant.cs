using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProject.src
{
    internal class Plant : GridObject
    {
        public Plant(int row, int col, int width, int height, GridPoint[] spaces) : base(row, col, width, height, GridObjectName.Plant, spaces)
        {
        }
    }
}
