using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuLibrary.RecursiveBruteForce;
using System.Diagnostics;

namespace SudokuLibrary.Test
{
    /// <summary>
    /// Test runs of the solution for 
    /// </summary>
    [TestClass]
    public class RecursiveBruteForceTests
    {
        [TestMethod]
        public void HardestSudokusThread_02085()
        {
            SudokuBoard board = new SudokuBoard(HardPuzzles.HardestSudokusThread_02085);
            SudokuBoard solvedBoard = Sudoku.Solve(board);
            Assert.IsTrue(solvedBoard.IsSolved);
            Assert.IsTrue(solvedBoard.IsCorrect());
        }

        [TestMethod]
        public void Golden_Nugget()
        {
            SudokuBoard board = new SudokuBoard(HardPuzzles.Golden_Nugget);
            SudokuBoard solvedBoard = Sudoku.Solve(board);
            Assert.IsTrue(solvedBoard.IsSolved);
            Assert.IsTrue(solvedBoard.IsCorrect());
        }

        [TestMethod]
        public void HardestSudokusThread_00245()
        {
            SudokuBoard board = new SudokuBoard(HardPuzzles.HardestSudokusThread_00245);
            SudokuBoard solvedBoard = Sudoku.Solve(board);
            Assert.IsTrue(solvedBoard.IsSolved);
            Assert.IsTrue(solvedBoard.IsCorrect());
        }

        [TestMethod]
        public void HardestSudokusThread_01418()
        {
            SudokuBoard board = new SudokuBoard(HardPuzzles.HardestSudokusThread_01418);
            SudokuBoard solvedBoard = Sudoku.Solve(board);
            Assert.IsTrue(solvedBoard.IsSolved);
            Assert.IsTrue(solvedBoard.IsCorrect());
        }
    }
}
