using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuLibrary.RecursiveBruteForce
{
    public class Sudoku
    {
        public static readonly byte[] ValidNumbers = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        private static IEnumerable<int> FindEmptyCells(SudokuBoard sudokuBoard)
        {
            // only return the empty cells
            for (int offset = 0; offset < 9 * 9; offset++)
                if (sudokuBoard.Cell[offset] == 0)
                    yield return offset;
        }

        private static byte[] CheckValidNumbers(int offset, SudokuBoard sudokuBoard)
        {
            // start with all numbers
            HashSet<byte> numbers = new HashSet<byte>(ValidNumbers);

            // converting the offset to column and row
            int column = offset % 9;
            int row = offset / 9;

            // filtering them on the rules
            CheckValidNumbersInRow(row, sudokuBoard, numbers);
            CheckValidNumbersInColumn(column, sudokuBoard, numbers);
            CheckValidNumbersInGroup(column, row, sudokuBoard, numbers);

            return numbers.ToArray();
        }

        private static void CheckValidNumbersInRow(int row, SudokuBoard sudokuBoard, HashSet<byte> numbers)
        {
            // all numbers that have been found, should be removed
            for (int columnIndex = 0; columnIndex < 9; columnIndex++)
            {
                int lookupOffset = columnIndex + (row * 9);
                // read what number is found there
                byte number = sudokuBoard.Cell[lookupOffset];
                // the number is removed from the numbers hashset if it is found
                numbers.Remove(number);
            }
        }
        private static void CheckValidNumbersInColumn(int column, SudokuBoard sudokuBoard, HashSet<byte> numbers)
        {
            // all numbers that have been found, should be removed
            for (int rowIndex = 0; rowIndex < 9; rowIndex++)
            {
                int lookupOffset = column + (rowIndex * 9);
                // read what number is found there
                byte number = sudokuBoard.Cell[lookupOffset];
                // the number is removed from the numbers hashset if it is found
                numbers.Remove(number);
            }
        }
        private static void CheckValidNumbersInGroup(int column, int row, SudokuBoard sudokuBoard, HashSet<byte> numbers)
        {
            // check in what group this column/row is:
            int groupColumn = column / 3; // integer division gives the groupcolumn index
            int groupRow = row / 3; // integer division gives the grouprow index   (like (4,5)  gives 4/3=1, 5/3 = 1 (so 4,5 is in the middle group))

            // multiply the group indices by 3 (to get the first cell (top left) within the group.
            int columnStart = groupColumn * 3;
            int rowStart = groupRow * 3;

            // check the 3x3 from there
            for (int rowIndex = rowStart; rowIndex < rowStart + 3; rowIndex++)
                for (int columnIndex = columnStart; columnIndex < columnStart + 3; columnIndex++)
                {
                    // calculate the offset on the sudoku board
                    int lookupOffset = columnIndex + (rowIndex * 9);
                    // read what number is found there
                    byte number = sudokuBoard.Cell[lookupOffset];
                    // the number is removed from the numbers hashset if it is found
                    numbers.Remove(number);
                }
        }

        public static SudokuBoard Solve(SudokuBoard sudokuBoard)
        {
            // find all empty  (0) cells
            int[] emptyCellOffsets = FindEmptyCells(sudokuBoard).ToArray();

            // is there are no empty cells this could be already done.
            if (emptyCellOffsets.Length == 0)
                return sudokuBoard;

            // select the cell with the least combinations
            var collection = from offset in emptyCellOffsets
                             // check the possible numbers valid for this cell
                             let validNumbers = CheckValidNumbers(offset, sudokuBoard)
                             let count = validNumbers.Length
                             // order them by the number of numbers (we want to bruteforce the least possible combinations, try descending the the orderby count.. :) )
                             orderby count
                             select new { offset, validNumbers };

            var first = collection.First();

            foreach (byte number in first.validNumbers)
            {
                // create a copy (because we need to preserve the previous board layout)
                SudokuBoard copy = sudokuBoard.Copy();

                // lets test this number at that offset
                copy.Cell[first.offset] = number;

                // try solving the board with the test number at the offset
                SudokuBoard result = Solve(copy);

                // is the result is solved, then we don't need to look much futher
                if (result.IsSolved)
                    return result;
            }

            return sudokuBoard;
        }
    }
}
