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

            int x = 3; int y = 3;

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
