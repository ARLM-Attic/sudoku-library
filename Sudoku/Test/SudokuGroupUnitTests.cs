using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuLibrary.Test
{
    [TestClass]
    public class SudokuGroupUnitTests
    {
        [TestMethod]
        public void GroupIsSolvedFalse()
        {
            Group group = new Group();
            for (int i = 1; i < 10; i++)
            {
                Assert.IsFalse(group.IsValueSolved(i));
            }
        }

        [TestMethod]
        public void GroupIsSolvedTrue()
        {
            Group row = new Group();
            for (int i = 1; i < 10; i++)
            {
                Cell cell = new Cell();
                cell.Row = row;
                cell.Column = new Group();
                cell.Square = new Group();
                row.Add(cell);
            }
            for (int i = 1; i < 10; i++)
            {
                row.Cells[i-1].Solve(i);
            }
            for (int i = 1; i < 10; i++)
            {
                Assert.IsTrue(row.IsValueSolved(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GroupIsSolvedUpperOutOfRange()
        {
            Group group = new Group();
            group.IsValueSolved(10);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GroupIsSolvedLowerOutOfRange()
        {
            Group group = new Group();
            group.IsValueSolved(0);
        }
    }
}
