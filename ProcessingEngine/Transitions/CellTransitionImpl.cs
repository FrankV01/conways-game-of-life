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
        /// NOTE: Anything in a corner can die. It won't come alive. (Ignore for now, not exactly right)
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
                    if (x1 == 1 && y1 == 1)
                    {
                        System.Diagnostics.Debug.WriteLine("Check.");
                    }

                    //Still not working right.
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
                    if (x1 != 1 && y1 != 1) //Origin (the cell in question)
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
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("X1 = " + x1.ToString() + "; y1 = " + y1.ToString());
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
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="grid"></param>
        /// <returns></returns>
        private bool[,] subSelectAroundCell( int x, int y, bool[,] grid )
        {
            bool[,] subset = new bool[3, 3];

            //This logic isn't right because if we're looking for just 0,0 of a 3x3 grid ,we need to 
            // "generate" the "off" grid cells and set them to false.
            if (grid.GetLongLength(0) == 3 && grid.GetLongLength(1) == 3)
                subset = grid.Clone() as bool[,];
            else if(grid.GetLongLength(0) < 3 || grid.GetLongLength(1) < 3)
                throw new InvalidOperationException("Grids less than 3x3 are not supported");
            else
            {
                subset[0, 0] = grid[x - 1, y - 1];
                subset[1, 0] = grid[x, y - 1];
                subset[2, 0] = grid[x + 1, y - 1];

                subset[0, 1] = grid[x - 1, y];
                subset[1, 1] = grid[x, y];
                subset[2, 1] = grid[x + 1, y];

                subset[0, 2] = grid[x - 1, y + 1];
                subset[1, 2] = grid[x, y + 1];
                subset[2, 2] = grid[x + 1, y + 1];
            }
            //for(int x1 = -1; x1 < x; x1++)
            //{
            //    for(int y1 = -1; y1 < y; y1++)
            //    {
            //        try
            //        {
            //            subset[x1 + 1, y1 + 1] = grid[x + x1, y + y1];
            //        }
            //        catch (IndexOutOfRangeException ex)
            //        {
            //            //If we are out of range, then the node doesn't exist and we should assume false in those regions.
            //            subset[x1 + 1, y1 + 1] = false;
            //        }
            //    }
            //}

            return subset;
        }

    }
}
