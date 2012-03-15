using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Campbel.Sudoku;

namespace Campbel.Sudoku.Test
{
    [TestClass]
    public class SudokuCellUnitTests
    {
        private static Random mRand;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            mRand = new Random();
        }

        [TestMethod]
        public void CellCtorSetValue()
        {
            Cell cell = new Cell();
            Assert.AreEqual(cell.Value, 0);
            Assert.IsFalse(cell.IsSolved);

            int value = mRand.Next(1, 9);
            cell = new Cell(value);
            Assert.AreEqual(cell.Value, value);
            Assert.IsTrue(cell.IsSolved);
        }

        [TestMethod]
        public void CellCanBeValue()
        {
            int value = mRand.Next(1, 9);

            Cell cell1 = new Cell();
            cell1.SetValue(value);
            for (int i = 1; i < 10; i++)
            {
                if (i == value)
                {
                    Assert.IsTrue(cell1.CanBeValue(i));
                }
                else
                {
                    Assert.IsFalse(cell1.CanBeValue(i));
                }
            }

            Cell cell2 = new Cell(value);
            for (int i = 1; i < 10; i++)
            {
                if (i == value)
                {
                    Assert.IsTrue(cell2.CanBeValue(i));
                }
                else
                {
                    Assert.IsFalse(cell2.CanBeValue(i));
                }
            }
            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CellSetValueAlreadySet()
        {
            int value1 = mRand.Next(1, 9);
            int value2 = mRand.Next(1, 9);

            Cell cell = new Cell();
            cell.SetValue(value1);
            cell.SetValue(value2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CellCtorSetValueAlreadySet()
        {
            int value1 = mRand.Next(1, 9);
            int value2 = mRand.Next(1, 9);

            Cell cell = new Cell();
            cell.SetValue(value1);
            cell.SetValue(value2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CellCtorSetValueUpperOutOfRange()
        {
            Cell cell = new Cell(10);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CellCtorSetValueLowerOutOfRange()
        {
            Cell cell = new Cell(0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CellSetValueUpperOutOfRange()
        {
            Cell cell = new Cell();
            cell.SetValue(10);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CellSetValueLowerOutOfRange()
        {
            Cell cell = new Cell();
            cell.SetValue(0);
        }
    }
}
