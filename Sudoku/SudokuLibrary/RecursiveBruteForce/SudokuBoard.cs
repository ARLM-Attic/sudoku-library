﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuLibrary.RecursiveBruteForce
{
    public class SudokuBoard
    {
        // offsets:
        // +====+====+====+====+====+====+====+====+====+
        // #  0 |  1 |  2 #  3 |  4 |  5 #  6 |  7 |  8 #
        // +----+----+----+----+----+----+----+----+----+
        // #  9 | 10 | 11 # 12 | 13 | 14 # 15 | 16 | 17 #
        // +----+----+----+----+----+----+----+----+----+
        // # 18 | 19 | 20 # 21 | 22 | 23 # 24 | 25 | 26 #
        // +====+====+====+====+====+====+====+====+====+
        // # 27 | 28 | 29 # 30 | 31 | 32 # 33 | 34 | 35 #
        // +----+----+----+----+----+----+----+----+----+
        // # 36 | 37 | 38 # 39 | 40 | 41 # 42 | 43 | 44 #
        // +----+----+----+----+----+----+----+----+----+
        // # 45 | 46 | 47 # 48 |(49)| 50 # 51 | 52 | 53 #
        // +====+====+====+====+====+====+====+====+====+
        // # 54 | 55 | 56 # 57 | 58 | 59 # 60 | 61 | 62 #
        // +----+----+----+----+----+----+----+----+----+
        // # 63 | 64 | 65 # 66 | 67 | 68 # 69 | 70 | 71 #
        // +----+----+----+----+----+----+----+----+----+
        // # 72 | 73 | 74 # 75 | 76 | 77 # 78 | 79 | 80 #
        // +====+====+====+====+====+====+====+====+====+
        // so ([column]4,[row]5) = 4 + (5 * 9) = 49

        private bool _isSolvedChecked;

        public byte[] Cell { get; set; }

        public SudokuBoard()
        {
            Cell = new byte[9 * 9];
        }

        public SudokuBoard(byte[] Cells)
        {
            Cell = Cells;
        }

        public SudokuBoard Copy()
        {
            byte[] copy = new byte[9 * 9];

            Array.Copy(Cell, copy, 9 * 9);

            return new SudokuBoard(copy);
        }

        public bool IsSolved
        {
            get
            {
                // if this board is already checked and solved, we don't have to recalculate it again. (because of recursion)
                if (_isSolvedChecked) return true;

                for (int offset = 0; offset < 9 * 9; offset++)
                    if (this.Cell[offset] == 0)
                        return false;

                _isSolvedChecked = true;

                return true;
            }
        }
    }
}
