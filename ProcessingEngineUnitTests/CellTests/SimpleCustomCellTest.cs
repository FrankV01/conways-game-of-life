using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrankVillasenor.Life.ProcessingEngine.Cells;

namespace FrankVillasenor.Life.ProcessingEngineUnitTests.CellTests
{
    [TestClass]
    public class SimpleCustomCellTest
    {
        [TestMethod]
        public void SimpleCustomCellTest_correctSizeReturned()
        {
            bool[,] _result = new SimpleCustomCell(25).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 25);
            Assert.AreEqual(_result.GetLongLength(1), 25);

            //Odd (unusual) size
            _result = new SimpleCustomCell(37).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 37);
            Assert.AreEqual(_result.GetLongLength(1), 37);

            _result = new SimpleCustomCell(50).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 50);
            Assert.AreEqual(_result.GetLongLength(1), 50);
        }

        [TestMethod]
        public void SimpleCustomCellTest_correctShape()
        {
            bool[,] expected = {
                                   {false,false,false},
                                   {true,true,true},
                                   {false,false,false}
                               };
            bool[,] testGrid = new SimpleCustomCell(3, 0).ToGrid();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], testGrid[i, j]);
        }
    }
}
