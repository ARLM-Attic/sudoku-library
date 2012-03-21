using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuLibrary.Test
{
    /// <summary>
    /// Summary description for SudokuPuzzleUnitTests
    /// </summary>
    [TestClass]
    public class SudokuPuzzleUnitTests
    {
        [TestMethod]
        public void GetSquareTest()
        {
            Puzzle puz = new Puzzle();
            Assert.AreEqual(puz.GetSquare(0, 0), 0);
            Assert.AreEqual(puz.GetSquare(0, 8), 2);
            Assert.AreEqual(puz.GetSquare(2, 8), 2);
            Assert.AreEqual(puz.GetSquare(3, 0), 3);
            Assert.AreEqual(puz.GetSquare(3, 8), 5);
            Assert.AreEqual(puz.GetSquare(5, 8), 5);
            Assert.AreEqual(puz.GetSquare(6, 0), 6);
            Assert.AreEqual(puz.GetSquare(6, 8), 8);
            Assert.AreEqual(puz.GetSquare(8, 8), 8);
        }

        [TestMethod]
        public void PuzzleInitializeTest()
        {
            Puzzle puzzle = new Puzzle();
        }

        [TestMethod]
        public void PuzzleRunRowColSqrUpdateCorrectly()
        {
            Puzzle puzzle = new Puzzle();
            puzzle.Solve(0, 0, 1);
            puzzle.Solve(0, 1, 2);
            puzzle.Solve(1, 2, 3);
            puzzle.Solve(1, 0, 4);
            puzzle.Solve(2, 1, 5);
            puzzle.Solve(2, 2, 6);
            puzzle.Run();

            Assert.IsTrue(puzzle.GetRow(0).IsValueSolved(1));
            Assert.IsTrue(puzzle.GetRow(0).IsValueSolved(2));
            Assert.IsTrue(puzzle.GetRow(1).IsValueSolved(3));
            Assert.IsTrue(puzzle.GetRow(1).IsValueSolved(4));
            Assert.IsTrue(puzzle.GetRow(2).IsValueSolved(5));
            Assert.IsTrue(puzzle.GetRow(2).IsValueSolved(6));
            Assert.IsTrue(puzzle.GetColumn(0).IsValueSolved(1));
            Assert.IsTrue(puzzle.GetColumn(1).IsValueSolved(2));
            Assert.IsTrue(puzzle.GetColumn(2).IsValueSolved(3));
            Assert.IsTrue(puzzle.GetColumn(0).IsValueSolved(4));
            Assert.IsTrue(puzzle.GetColumn(1).IsValueSolved(5));
            Assert.IsTrue(puzzle.GetColumn(2).IsValueSolved(6));
            Assert.IsTrue(puzzle.GetSquare(0).IsValueSolved(1));
            Assert.IsTrue(puzzle.GetSquare(0).IsValueSolved(2));
            Assert.IsTrue(puzzle.GetSquare(0).IsValueSolved(3));
            Assert.IsTrue(puzzle.GetSquare(0).IsValueSolved(4));
            Assert.IsTrue(puzzle.GetSquare(0).IsValueSolved(5));
            Assert.IsTrue(puzzle.GetSquare(0).IsValueSolved(5));

        }

        [TestMethod]
        public void PuzzleRunRowColSqrSolveCorrectly()
        {
            Puzzle puzzle = new Puzzle();
            for (int i = 0; i < 9; i++)
            {
                puzzle.Solve(0, i, i + 1);
            }
            puzzle.Solve(1, 0, 4);
            puzzle.Solve(1, 1, 5);
            puzzle.Solve(1, 2, 6);
            puzzle.Solve(2, 0, 7);
            puzzle.Solve(2, 1, 8);
            puzzle.Solve(3, 0, 2);
            puzzle.Solve(4, 0, 3);
            puzzle.Solve(5, 0, 5);
            puzzle.Solve(6, 0, 6);
            puzzle.Solve(7, 0, 8);
            puzzle.Run();

            Assert.AreEqual(21,puzzle.NumCellsSolved);
            Assert.IsTrue(puzzle.GetCell(0, 8).IsSolved);
            Assert.IsTrue(puzzle.GetCell(8, 0).IsSolved);
            Assert.IsTrue(puzzle.GetCell(2, 2).IsSolved);
        }

        [TestMethod]
        public void PuzzleNumCellsSolved()
        {
            Puzzle puzzle = new Puzzle();
            for (int i = 0; i < 9; i++)
            {
                puzzle.Solve(0, i, i + 1);
            }
            Assert.AreEqual(puzzle.NumCellsSolved, 9);
        }

        /// <summary>
        /// Initialize a puzzle and solve 5 cells, check to make sure the
        /// group are updated with removed values. Make sure all cells are
        /// removed of possible values.
        /// </summary>
        [TestMethod]
        public void PuzzleSolveFive()
        {
            Puzzle puzzle = new Puzzle();
            puzzle.Solve(0, 0, 1);
            puzzle.Solve(0, 1, 2);
            puzzle.Solve(0, 2, 3);
            puzzle.Solve(0, 3, 4);
            puzzle.Solve(0, 4, 5);
            List<Cell> cells = new List<Cell>();
            cells.Add(puzzle.GetCell(0, 5));
            cells.Add(puzzle.GetCell(0, 6));
            cells.Add(puzzle.GetCell(0, 7));
            cells.Add(puzzle.GetCell(0, 8));
            puzzle.Run();
            foreach (Cell cell in cells)
            {
                for (int i = 1; i < 6; i++)
                {
                    Assert.IsFalse(cell.CanBeValue(i));
                }
                for (int i = 6; i < 10; i++)
                {
                    Assert.IsTrue(cell.CanBeValue(i));
                }
            }
            Group row = puzzle.GetRow(0);
            for (int i = 1; i < 6; i++)
            {
                Assert.IsTrue(row.IsValueSolved(i));
            }
            for (int i = 6; i < 10; i++)
            {
                Assert.IsFalse(row.IsValueSolved(i));
            }
        }
    }
}
