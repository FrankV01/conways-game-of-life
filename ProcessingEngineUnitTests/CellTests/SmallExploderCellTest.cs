using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrankVillasenor.Life.ProcessingEngine.Cells;

namespace FrankVillasenor.Life.ProcessingEngineUnitTests.CellTests
{
    [TestClass]
    public class SmallExploderCellTest
    {
        [TestMethod]
        public void SmallExploderCellTest_correctSizeReturned()
        {
            bool[,] _result = new SmallExploderCell(25).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 25);
            Assert.AreEqual(_result.GetLongLength(1), 25);

            //Odd (unusual) size
            _result = new SmallExploderCell(37).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 37);
            Assert.AreEqual(_result.GetLongLength(1), 37);

            _result = new SmallExploderCell(50).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 50);
            Assert.AreEqual(_result.GetLongLength(1), 50);
        }

        [TestMethod]
        public void SmallExploderCellTest_correctShape()
        {
            bool[,] expected = {
                                   {false,true,false},
                                   {true,true,true},
                                   {true,false,true},
                                   {false,true,false},
                               };
            bool[,] testGrid = new SmallExploderCell(4, 0).ToGrid();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], testGrid[i, j]);
        }
    }
}
