using Output.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Cells
{
    /// <summary>
    /// Still designing this. 
    /// 
    /// The intention / thought is to have this reprsent the grid and 
    /// be able to modify the cell && take in the old grid and output the revision. 
    /// The problem I see with this is that multiple cells can be on scree at once (and in 
    /// fact divide in to multiples. And that would cause a problem. So this concept won't work (at least as is...)
    /// </summary>
    interface ICell
    {
        //I'm thinking.... 
        Grid ReviseGrid(Grid grid);

        //Although this really doesn't need to be public, technically.
        void mutate();
    }
}
