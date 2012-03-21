using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuLibrary.NCellSolution;

namespace SudokuLibrary.Test
{
    [TestClass]
    public class HDNSudokuTests
    {
        [TestMethod]
        public void HDNInitializeTests()
        {
            int n = 4;
            List<int> clues = new List<int>();
            for(int i=0; i<n*n; i++)
            {
                clues.Add(0);
            }
            HDNSudoku puzzle = new HDNSudoku(n, clues);

            n = 9;
            clues = new List<int>();
            for (int i = 0; i < n * n; i++)
            {
                clues.Add(0);
            }
            puzzle = new HDNSudoku(n, clues);

            n = 16;
            clues = new List<int>();
            for (int i = 0; i < n * n; i++)
            {
                clues.Add(0);
            }
            puzzle = new HDNSudoku(n, clues);
        }
    }
}
