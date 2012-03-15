using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuLibrary.Test
{
    [TestClass]
    public class SudokuGroupUnitTests
    {
        [TestMethod]
        public void GroupIsSolved()
        {
            Group group = new Group();
            for (int i = 1; i < 10; i++)
            {
                Assert.IsFalse(group.IsValueSolved(i));
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
