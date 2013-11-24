using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrankVillasenor.Life.ProcessingEngine.Cells;

namespace FrankVillasenor.Life.ProcessingEngineUnitTests.CellTests
{
    [TestClass]
    public class GliderTest
    {
        [TestMethod]
        public void correctSizeReturned()
        {
            bool[,] _result = new GliderCell(25).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 25);
            Assert.AreEqual(_result.GetLongLength(1), 25);

            //Odd (unusual) size
            _result = new GliderCell(37).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 37);
            Assert.AreEqual(_result.GetLongLength(1), 37);

            _result = new GliderCell(50).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 50);
            Assert.AreEqual(_result.GetLongLength(1), 50);
        }

        [TestMethod]
        public void correctShape()
        {
            bool[,] expected = {
                                   {false,true,false},
                                   {false,false,true},
                                   {true,true,true}
                               };
            bool[,] testGrid = new GliderCell(3, 0).ToGrid();

            //Assert.AreEqual(expected, testGrid); //fails but probably because the objects are not the same reference (as opposed to contents).

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], testGrid[i, j]);
        }
    }
}
