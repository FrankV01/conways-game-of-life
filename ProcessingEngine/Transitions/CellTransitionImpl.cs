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

namespace FrankVillasenor.Life.ProcessingEngine.Transitions
{
    /// <summary>
    /// This processes the transition logic. 
    /// This is a first attempt at implementation. lets see
    /// where we get.
    /// </summary>
    public class CellTransitionImpl : ICellTransition
    {

        public CellTransitionImpl()
        {
        }



        /// <summary>
        /// Rules. I believe the order applied does matter. (which should make multi-threading pretty easy.)
        /// 
        /// 1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        /// 2. Any live cell with two or three live neighbours lives on to the next generation.
        /// 3. Any live cell with more than three live neighbours dies, as if by overcrowding.
        /// 4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        /// 
        /// We can also unit test this...
        /// 
        /// NOTE: We only turn off the cell in question. -- Not surrounding ones.
        /// </summary>
        /// <param name="currentState"></param>
        /// <returns></returns>
        public bool[,] ApplyTransition(bool[,] currentState)
        {
            bool[,] initState = currentState.Clone() as bool[,];
            bool[,] revisedState = currentState.Clone() as bool[,];
            //First step is to iterate through and identify if a cell is dies due to under population.

            bool buf;
            for (int x1 = 0; x1 < currentState.GetLongLength(0); x1++)
            {
                for( int y1 = 0; y1 < currentState.GetLongLength(1); y1++)
                {
                    bool[,] subSet = this.subSelectAroundCell(x1, y1, initState);
                    bool isAlive = initState[x1, y1];

                    if (isAlive)
                    {
                        buf = this.IsAliveCheck(subSet); ;
                        revisedState[x1, y1] = buf;
                    }
                    else
                    {
                        buf = this.ExactlyThreeLiveNeighbours(subSet);
                        revisedState[x1, y1] = buf;
                    }
                }
            }

            //Compare initalState vs revisedState
            return revisedState;
        }

        private bool ExactlyThreeLiveNeighbours(bool[,] subSet)
        {
            int NumNeighbours = 0;

            for (int x1 = 0; x1 < subSet.GetLongLength(0); x1++)
                for (int y1 = 0; y1 < subSet.GetLongLength(1); y1++)
                    if (!(x1 == 1 && y1 == 1)) //Origin (the cell in question)
                        if (subSet[x1, y1])
                            NumNeighbours++;

            return (NumNeighbours == 3);
        }

        /// <summary>
        /// 1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        /// 2. Any live cell with two or three live neighbours lives on to the next generation.
        /// 3. Any live cell with more than three live neighbours dies, as if by overcrowding.
        /// </summary>
        /// <param name="subSet"></param>
        /// <returns> true if should stay alive, false otherwise</returns>
        private bool IsAliveCheck(bool[,] subSet)
        {
            int NumNeighbours = 0;

            for (int x1 = 0; x1 < subSet.GetLongLength(0); x1++)
                for (int y1 = 0; y1 < subSet.GetLongLength(1); y1++)
                {
                    if (!(x1 == 1 && y1 == 1)) //Origin (the cell in question)
                    {
                        if (subSet[x1, y1])
                            NumNeighbours++;
                    }
                }

            if (NumNeighbours == 2 || NumNeighbours == 3)
                return true;
            else
                return false;
        }

        ///// <summary>
        ///// 
        ///// Any live cell with more than three live neighbours dies, as if by overcrowding.
        ///// 
        ///// NOTE: This and TwoOrThreeNeighbours could easily be combined.
        ///// </summary>
        ///// <param name="subSet"></param>
        ///// <returns></returns>
        //private bool TooManyLiveNeighbours(bool[,] subSet)
        //{
        //    int NumNeighbours = 0;

        //    for (int x1 = 0; x1 < subSet.GetLongLength(0); x1++)
        //        for (int y1 = 0; y1 < subSet.GetLongLength(1); y1++)
        //            if (x1 != 1 && y1 != 1) //Origin (the cell in question)
        //                if (subSet[x1, y1])
        //                    NumNeighbours++;

        //    return (NumNeighbours > 2);
        //}

        ///// <summary>
        ///// Any live cell with two or three live neighbours lives on to the next generation.
        ///// </summary>
        ///// <param name="subSet"></param>
        ///// <returns></returns>
        //private bool TwoOrThreeNeighbours(bool[,] subSet)
        //{
        //    int NumNeighbours = 0;

        //    for (int x1 = 0; x1 < subSet.GetLongLength(0); x1++)
        //        for (int y1 = 0; y1 < subSet.GetLongLength(1); y1++)
        //            if (x1 != 1 && y1 != 1) //Origin (the cell in question)
        //                if (subSet[x1, y1])
        //                    NumNeighbours++;

        //    return (NumNeighbours == 2 || NumNeighbours == 3);
        //}

        ///// <summary>
        ///// Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        ///// </summary>
        ///// <param name="subSet"></param>
        ///// <returns></returns>
        //private bool FewerThanTwoLiveNeighbours(bool[,] subSet)
        //{
        //    bool firstAlive = false;
        //    bool secondAlive = false;

        //    for (int x1 = 0; x1 < subSet.GetLongLength(0); x1++)
        //        for (int y1 = 0; y1 < subSet.GetLongLength(1); y1++)
        //            if (x1 != 1 && y1 != 1) //Origin (the cell in question)
        //                if (subSet[x1, y1])
        //                    if (firstAlive)
        //                        secondAlive = true;
        //                    else
        //                        firstAlive = true;

        //    return !(firstAlive && secondAlive); //both need to be alive.
        //}

        /// <summary>
        /// Given x,y sub-select elements around
        /// 
        /// Note: This is supposed to be private but it's such an important method 
        /// that I exposed it to unit test on it's own.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool[,] subSelectAroundCell( int x, int y, bool[,] grid )
        {
            bool[,] subset = new bool[3, 3];

            subset[0, 0] = GetVal(x - 1, y - 1, grid); // grid[x - 1, y - 1];
            subset[1, 0] = GetVal(x, y - 1, grid); // grid[x, y - 1];
            subset[2, 0] = GetVal(x + 1, y - 1, grid);  //grid[x + 1, y - 1];

            subset[0, 1] = GetVal(x - 1, y, grid); // grid[x - 1, y];
            subset[1, 1] = GetVal(x, y, grid); // grid[x, y]; //this is fact. This is what we want.
            subset[2, 1] = GetVal(x + 1, y, grid); // grid[x - 1, y];

            subset[0, 2] = GetVal(x - 1, y + 1, grid); // grid[x - 1, y + 1];
            subset[1, 2] = GetVal(x, y + 1, grid); //grid[x, y + 1];
            subset[2, 2] = GetVal(x + 1, y + 1, grid); //grid[x + 1, y + 1];

            return subset;
        }

        private bool GetVal( int x, int y, bool[,] grid )
        {
            if (x > grid.GetUpperBound(0) || x < grid.GetLowerBound(0))
                return false;

            if (y > grid.GetUpperBound(1) || y < grid.GetLowerBound(1))
                return false;

            return grid[x, y];
        }

    }
}
