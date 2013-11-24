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
using FrankVillasenor.Life.ProcessingEngine.Transitions;

namespace FrankVillasenor.Life.ProcessingEngineUnitTests.TransitionTests
{
    [TestClass]
    public class BasicTransitionTest
    {
        [TestMethod]
        public void BasicTransitionTest_SameSizeInVsOut()
        {
            bool[,] startingPoint = {
                                   {false,false,false},
                                   {false,true,false},
                                   {false,false,false}
                               };

            ICellTransition _trans = new CellTransitionImpl();
            bool[,] result = _trans.ApplyTransition(startingPoint);



            Assert.AreEqual(startingPoint.GetLongLength(0), result.GetLongLength(0));
            Assert.AreEqual(startingPoint.GetLongLength(1), result.GetLongLength(1));

            try
            {
                startingPoint.GetLongLength(2); //Should throw exception because we are not expected a new dim.
                Assert.Fail("Unexpected LongLength");
            }
            catch (Exception ex) 
            { 
                //Passes test.
            }
        }


        [TestMethod]
        public void BasicTransitionTest_SingleCellDeath()
        {
            bool[,] startingPoint = {
                                   {false,false,false},
                                   {false,true,false},
                                   {false,false,false}
                               };

            bool[,] expected = {
                                   {false,false,false},
                                   {false,false,false},
                                   {false,false,false}
                               };


            ICellTransition _trans = new CellTransitionImpl();
            bool[,] result = _trans.ApplyTransition(startingPoint);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], result[i, j]);
        }

        [TestMethod] //failing one.
        public void BasicTransitionTest_SingleCellLives()
        {
            bool[,] startingPoint = {
                                   {false,false,false},
                                   {true,true,true},
                                   {false,false,false}
                               };

            bool[,] expected = {
                                   {false,true,false},
                                   {false,true,false},
                                   {false,true,false}
                               };


            ICellTransition _trans = new CellTransitionImpl();
            bool[,] result = _trans.ApplyTransition(startingPoint);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], result[i, j]);
        }

        [TestMethod]
        public void TestSubSelectAroundCell_0x0()
        {
            bool[,] startingPoint = {
                                   {false,false,false},
                                   {true,true,true},
                                   {false,false,false}
                               };
            bool[,] expected = {
                                   {false, false, false},
                                   {false, false, false},
                                   {false, true, true}
                               };
            CellTransitionImpl _t = new CellTransitionImpl();
            bool[,] result = _t.subSelectAroundCell(0, 0, startingPoint);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], result[i, j]);
        }

        [TestMethod]
        public void TestSubSelectAroundCell_1x1()
        {
            bool[,] startingPoint = {
                                   {false,false,false},
                                   {true,true,true},
                                   {false,false,false}
                               };
            bool[,] expected = {
                                   {false,false,false},
                                   {true,true,true},
                                   {false,false,false}
                               };
            CellTransitionImpl _t = new CellTransitionImpl();
            bool[,] result = _t.subSelectAroundCell(1, 1, startingPoint);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], result[i, j]);
        }

        [TestMethod]
        public void TestSubSelectAroundCell_2x2()
        {
            bool[,] startingPoint = {
                                   {false,false,false},
                                   {true,true,true},
                                   {false,false,false}
                               };
            bool[,] expected = {
                                   {true,true,false},
                                   {false,false,false},
                                   {false,false,false}
                               };
            CellTransitionImpl _t = new CellTransitionImpl();
            bool[,] result = _t.subSelectAroundCell(2, 2, startingPoint);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], result[i, j]);
        }

        [TestMethod]
        public void TestSubSelectAroundCell_1x0()
        {
            bool[,] startingPoint = {
                                   {false,false,false},
                                   {true,true,true},
                                   {false,false,false}
                               };
            bool[,] expected = {
                                {false,false,false},   
                                {false,true,true},
                                {false,false,false}
                               };
            CellTransitionImpl _t = new CellTransitionImpl();
            bool[,] result = _t.subSelectAroundCell(1, 0, startingPoint);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], result[i, j]);
        }


        //Many more tests are needed here. This Testclass is testing the majority of the "important" logic.
    }
}
