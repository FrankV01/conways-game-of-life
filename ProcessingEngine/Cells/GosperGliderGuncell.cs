/**
 * This file is part of "FrankVillasenor.Life"
 * A "Conway's Game of Life" Implementation - http://en.wikipedia.org/wiki/Conway's_Game_of_Life
 * Copyright (C) 2013  Frank Villasenor <frank.villasenor[at]gmail[dot]com>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *  
 * You should have received a copy of the GNU General Public License
 * along with this program as COPYING.txt.  If not, see
 * <http://www.gnu.org/licenses/>.
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FrankVillasenor.Life.ProcessingEngine.Cells
{
    /// <summary>
    /// Produces a GosperGliderGun cell-set. (Multiple cells, really). 
    /// Derived from the figure rendered at http://www.bitstorm.org/gameoflife/
    /// </summary>
    public class GosperGliderGunCell : ICell
    {
        private int _size;
        private int _startingPoint;  //An offset, if you will.

        public GosperGliderGunCell(int size)
        {
            if (size <= 40)
                throw new NotSupportedException("Grid Size must be greater than 40");

            this._size = size;
            this._startingPoint = 0;
        }
        public GosperGliderGunCell(int size, int StartingPoint)
            : this(size)
        {
            this._startingPoint = StartingPoint;
        }

        private bool[,] subShape_Square(int originX, int originY, bool[,] current)
        {

            bool[,] sh = {
                             {true,true},
                             {true,true}
                         };

            for (int i = 0; i < sh.GetLongLength(0); i++)
                for (int j = 0; j < sh.GetLongLength(1); j++)
                    current[i + originX, j + originY] = sh[i, j];

            return current;
        }

        private bool[,] subShape_Ls(int originX, int originY, bool[,] current)
        {
            bool[,] sh = {
                             {false,true,true},
                             {true, false, true},
                             {true,true,false}
                         };

            for (int i = 0; i < sh.GetLongLength(0); i++)
                for (int j = 0; j < sh.GetLongLength(1); j++)
                    current[i + originX, j + originY] = sh[i, j];

            return current;
        }

        private bool[,] subShape_VerticalScythe(int originX, int originY, bool[,] current)
        {
            bool[,] sh = {
                             {true,true,false},
                             {true, false, true},
                             {true,false,false}
                         };

            for (int i = 0; i < sh.GetLongLength(0); i++)
                for (int j = 0; j < sh.GetLongLength(1); j++)
                    current[i + originX, j + originY] = sh[i, j];

            return current;
        }

        private bool[,] subShape_HorizontalScythe(int originX, int originY, bool[,] current)
        {
            bool[,] sh = {
                             {true,true,true},
                             {true, false, false},
                             {false,true,false}
                         };

            for (int i = 0; i < sh.GetLongLength(0); i++)
                for (int j = 0; j < sh.GetLongLength(1); j++)
                    current[i + originX, j + originY] = sh[i, j];

            return current;
        }

        public bool[,] ToGrid()
        {
            bool[,] grid = new bool[this._size, this._size];

            for (int i = 0; i < this._size; i++)
            {
                for (int j = 0; j < this._size; j++)
                {
                    grid[i, j] = false;
                }
            }


            grid = this.subShape_Square(this._startingPoint + 2, this._startingPoint + 0, grid);
            grid = this.subShape_Ls(this._startingPoint + 2, this._startingPoint + 8, grid);
            grid = this.subShape_VerticalScythe(this._startingPoint + 4, this._startingPoint + 16, grid);

            grid = this.subShape_Ls(this._startingPoint + 0, this._startingPoint + 22, grid);
            grid = this.subShape_Square(this._startingPoint + 0, this._startingPoint + 21 + 13, grid);
            grid = this.subShape_VerticalScythe(this._startingPoint + 7, this._startingPoint + 21 + 14, grid);

            grid = this.subShape_HorizontalScythe(this._startingPoint + 12, this._startingPoint + 24, grid); //Gess.

            /*
            for (int i = 0; i < grid.GetLongLength(0); i++)
                for (int j = 0; j < grid.GetLongLength(1); j++)
                    grid[i + this._startingPoint, j + this._startingPoint] = grid[i, j];
            */
            return grid;
        }
    }
}
