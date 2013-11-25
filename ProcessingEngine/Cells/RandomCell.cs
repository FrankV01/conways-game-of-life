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

namespace FrankVillasenor.Life.ProcessingEngine.Cells
{
    /// <summary>
    /// Produces a grid with all cells False.
    /// </summary>
    public class RandomCell : ICell
    {
        private int _size;

        public RandomCell(int size)
        {
            this._size = size;
        }
        

        public bool[,] ToGrid()
        {
            bool[,] grid = new bool[this._size, this._size];

            Random r = new Random();
            
            for (int i = 0; i < this._size; i++)
            {
                for (int j = 0; j < this._size; j++)
                {
                    grid[i, j]= ((r.Next() % 2) == 0);
                }
            }

            return grid;
        }

        
    }
}
