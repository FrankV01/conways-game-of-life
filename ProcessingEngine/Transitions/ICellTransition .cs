using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankVillasenor.Life.ProcessingEngine.Transitions
{
    /// <summary>
    /// Interface to define a CellTransition class. 
    /// Classes that implement this interface transition a
    /// a grid (the whole thing??) to it's new state. 
    /// </summary>
    public interface ICellTransition
    {
        bool[,] ApplyTransition(bool[,] currentState);
    }
}
