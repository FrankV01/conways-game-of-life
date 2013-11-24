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
    public class ExploderCellTest
    {
        [TestMethod]
        public void ExploderCellTest_correctSizeReturned()
        {
            bool[,] _result = new ExploderCell(10).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 10);
            Assert.AreEqual(_result.GetLongLength(1), 10);

            //Odd (unusual) size
            _result = new ExploderCell(47).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 47);
            Assert.AreEqual(_result.GetLongLength(1), 47);

            _result = new ExploderCell(50).ToGrid();
            Assert.AreEqual(_result.GetLongLength(0), 50);
            Assert.AreEqual(_result.GetLongLength(1), 50);
        }


        [TestMethod]
        public void ExploderCellTest_correctShape()
        {
            bool[,] expected = {
                                   {true,false,true,false,true},
                                   {true,false,false,false,true},
                                   {true,false,false,false,true},
                                   {true,false,false,false,true},
                                   {true,false,true,false,true}
                               };
            bool[,] testGrid = new ExploderCell(5, 0).ToGrid();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], testGrid[i, j]);
        }

    }
}
