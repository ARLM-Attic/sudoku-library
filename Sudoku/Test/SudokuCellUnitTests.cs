using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuLibrary;

namespace SudokuLibrary.Test
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
        [ExpectedException(typeof(Exception))]
        public void CellSetValueAlreadySet()
        {
            int value1 = mRand.Next(1, 9);
            int value2 = mRand.Next(1, 9);

            Cell cell = new Cell();
            cell.Row = new Group();
            cell.Column = new Group();
            cell.Square = new Group();
            cell.Solve(value1);
            cell.Solve(value2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CellSetValueUpperOutOfRange()
        {
            Cell cell = new Cell();
            cell.Solve(10);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CellSetValueLowerOutOfRange()
        {
            Cell cell = new Cell();
            cell.Solve(0);
        }

        /// <summary>
        /// Make sure the cells referenced row is updated with solved values
        /// </summary>
        [TestMethod]
        public void CellGroupReferencesAreSolved()
        {
            Group row = new Group();
            List<Cell> cells = new List<Cell>();
            for(int i=1; i<10; i++)
            {
                Cell cell = new Cell();
                cell.Row = row;
                cell.Column = new Group();
                cell.Square = new Group();
                cells.Add(cell);
                row.Add(cell);
            }

            for (int i = 1; i < 10; i++)
            {
                cells[i-1].Solve(i);
            }

            for (int i = 0; i < 9; i++)
            {
                Assert.IsTrue(cells[i].Row.IsValueSolved(i + 1));
            }
        }
    }
}
