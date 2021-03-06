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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrankVillasenor.Life.ProcessingEngine.Cells;

namespace FrankVillasenor.Life.ProcessingEngineUnitTests.CellTests
{
    [TestClass]
    public class GosperGliderGunCellTest
    {
        [TestMethod]
        public void GosperGliderGunCellTest_gridLargeEnough()
        {
            try
            {
                new GosperGliderGunCell(40);
                Assert.Fail("Should be 41x41 grid or larger");
            }
            catch (NotSupportedException) { }
        }

        [TestMethod]
        public void GosperGliderGunCellTest_correctSizeReturned()
        {

            //Odd (unusual) size
            bool[,] _result = new GosperGliderGunCell(47).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 47);
            Assert.AreEqual(_result.GetLongLength(1), 47);

            _result = new GosperGliderGunCell(50).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 50);
            Assert.AreEqual(_result.GetLongLength(1), 50);
        }


        [TestMethod]
        public void GosperGliderGunCellTes_correctShape()
        {
            //Checking the full shape is not pratical nor maintainable. We'll spot check... 

            bool[,] testGrid = new GosperGliderGunCell(41, 0).ToGrid();

            Assert.IsTrue(testGrid[2,0]);
            Assert.IsTrue(testGrid[0, 34]);

            Assert.IsTrue(testGrid[12, 26]);
            Assert.IsTrue(testGrid[1, 35]);
            Assert.IsTrue(testGrid[2, 23]);
        }

    }
}
