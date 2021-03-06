﻿/**
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
    /// Produces Cells in the shape of an Exploder as provided in http://www.bitstorm.org/gameoflife/
    /// </summary>
    public class ExploderCell : ICell
    {
        private int _size;
        private int _startingPoint;  //An offset, if you will.

        public ExploderCell(int size)
        {
            this._size = size;
            this._startingPoint = 2;
        }
        public ExploderCell(int size, int StartingPoint)
            : this(size)
        {
            this._startingPoint = StartingPoint;
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

            bool[,] shape = {
                {true,false,true,false,true},
                {true,false,false,false,true},
                {true,false,false,false,true},
                {true,false,false,false,true},
                {true,false,true,false,true}
            };

            for (int i = 0; i < shape.GetLongLength(0); i++)
                for (int j = 0; j < shape.GetLongLength(1); j++)
                    grid[i + this._startingPoint, j + this._startingPoint] = shape[i, j];

            return grid;
        }
    }
}
