/**
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrankVillasenor.Life.ProcessingEngine.Cells;

namespace FrankVillasenor.Life.ProcessingEngineUnitTests.CellTests
{
    [TestClass]
    public class TumblerCellTest
    {
        [TestMethod]
        public void TumblerCellTest_gridLargeEnough()
        {
            try
            {
                new TumblerCell(7);
                Assert.Fail("Should be 8x8 grid or larger");
            }
            catch (NotSupportedException) { }
        }

        [TestMethod]
        public void TumblerCellTest_correctSizeReturned()
        {
            bool[,] _result = new TumblerCell(11).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 11);
            Assert.AreEqual(_result.GetLongLength(1), 11);

            //Odd (unusual) size
            _result = new TumblerCell(47).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 47);
            Assert.AreEqual(_result.GetLongLength(1), 47);

            _result = new TumblerCell(50).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 50);
            Assert.AreEqual(_result.GetLongLength(1), 50);
        }


        [TestMethod]
        public void TumblerCellTest_correctShape()
        {
            bool[,] expected = {
                {false,true,true,false,true,true,false},
                {false,true,true,false,true,true,false},
                {false,false,true,false,true,false,false},
                {true,false,true,false,true,false,true},
                {true,false,true,false,true,false,true},
                {true,true,false,false,false,true,true},
                {false,false,false,false,false,false,false},
            };

            bool[,] testGrid = new TumblerCell(8, 0).ToGrid();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], testGrid[i, j]);
        }

    }
}
