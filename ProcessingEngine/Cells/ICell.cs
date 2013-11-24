using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingEngine.Cells
{

    /// <summary>
    /// Classes that implement this interface should render 1 or more cells
    /// in the grid format.
    /// </summary>
    public interface ICell
    {
        bool[,] ToGrid();
    }
}
