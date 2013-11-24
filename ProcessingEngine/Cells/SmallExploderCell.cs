using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankVillasenor.Life.ProcessingEngine.Cells
{
    public class SmallExploderCell : ICell
    {
        private int _size;
        private int _startingPoint;  //An offset, if you will.

        public SmallExploderCell(int size)
        {
            this._size = size;
            this._startingPoint = 2;
        }
        public SmallExploderCell(int size, int StartingPoint)
            : this(size)
        {
            this._startingPoint = StartingPoint;
        }

        public bool[,] ToGrid()
        {
            bool[,] grid = new bool[this._size, this._size];

            //perhaps there is a better way to do this but not worth researching right now.
            for (int i = 0; i < this._size; i++)
            {
                for (int j = 0; j < this._size; j++)
                {
                    grid[i, j] = false;
                }
            }

            grid[this._startingPoint + 0, this._startingPoint + 1] = true;

            grid[this._startingPoint + 1, this._startingPoint + 0] = true;
            grid[this._startingPoint + 1, this._startingPoint + 1] = true;
            grid[this._startingPoint + 1, this._startingPoint + 2] = true;

            grid[this._startingPoint + 2, this._startingPoint + 0] = true;
            grid[this._startingPoint + 2, this._startingPoint + 2] = true;

            grid[this._startingPoint + 3, this._startingPoint + 1] = true;

            return grid;
        }
    }
}
