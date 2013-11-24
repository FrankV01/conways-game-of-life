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
            
            //First step is to iterate through and identify if a cell is dies due to under population.


            for (int x1 = 0; x1 < currentState.GetLongLength(0); x1++)
            {
                for( int y1 = 0; y1 < currentState.GetLongLength(1); y1++)
                {
                    bool[,] subSet = this.subSelectAroundCell(x1, y1, currentState);
                    if (this.FewerThanTwoLiveNeighbours(subSet))
                    {
                        currentState[x1, y1] = false;
                    }

                    //Next step, I think.
                }
            }


            return currentState;
        }

        private bool FewerThanTwoLiveNeighbours(bool[,] subSet)
        {
            bool firstAlive = false;
            bool secondAlive = false;

            for (int x1 = 0; x1 < subSet.GetLongLength(0); x1++)
                for (int y1 = 0; y1 < subSet.GetLongLength(1); y1++)
                    if (x1 != 1 && y1 != 1)
                        if (subSet[x1, y1])
                            if (firstAlive)
                                secondAlive = true;
                            else
                                firstAlive = true;

            return !(firstAlive && secondAlive); //both need to be alive.
        }

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

            for(int x1 = -1; x1 < x; x1++)
            {
                for(int y1 = -1; y1 < y; y1++)
                {
                    try
                    {
                        subset[x1 + 1, y1 + 1] = grid[x + x1, y + y1];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        //If we are out of range, then the node doesn't exist and we should assume false in those regions.
                        subset[x1 + 1, y1 + 1] = false;
                    }
                }
            }

            return subset;
        }

    }
}
