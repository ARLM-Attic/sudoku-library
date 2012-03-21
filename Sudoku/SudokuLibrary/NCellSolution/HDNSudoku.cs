using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuLibrary.NCellSolution
{
    /// <summary>
    /// Human Deduction Solution on an N x N Puzzle
    /// </summary>
    public class HDNSudoku
    {
        private Group[] Rows;
        private Group[] Columns;
        private Group[] Squares;
        private int N;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">N, where the board is size NxN</param>
        public HDNSudoku(int n, List<int> clues)
        {
            N = n;
            Rows = new Group[n];
            Columns = new Group[n];
            Squares = new Group[n];
            List<Cell> board = new List<Cell>();
            for (int i = 0; i < clues.Count; i++)
            {
                board.Add(new Cell(clues[i], n));
            }

            // Initialize the Groups
            for(int i=0; i < n; i++)
            {
                Rows[i] = new Group(n);
                Columns[i] = new Group(n);
                Squares[i] = new Group(n);
            }

            // Add the cells to their rows
            for(int i=0; i < board.Count; i++)
            {
                Rows[i / n].Add(board[i]);   
            }

            // Add the cells to their columns
            for(int i=0; i < board.Count; i++)
            {
                Columns[i % n].Add(board[i]);
            }

            // Add the cells to their squares
            int root = (int)Math.Sqrt(n);
            int mult = root * root * root;
            for (int i = 0; i < board.Count; i++)
            {
                int index = ((i / root) % root) + ((i / mult) * root);
                Squares[index].Add(board[i]);
            }
        }

        public void Solve()
        {
            foreach (Group group in Rows)
            {
                foreach (Cell cell in group.Cells)
                {
                    if (cell.Value != -1)
                    {
                        foreach (Cell inCell in group.Cells)
                        {
                            if (inCell.Value != cell.Value)
                            {
                                inCell.Values[cell.Value] = -1;
                            }
                        }
                    }
                }
            }
            foreach (Group group in Columns)
            {

            }
            foreach (Group group in Squares)
            {

            }
        }
    }

    public class Group
    {
        public Cell[] Cells;
        private int index = 0;
        private int N;

        public Group(int n)
        {
            N = n;
            Cells = new Cell[n];
        }

        public void Add(Cell cell)
        {
            Cells[index++] = cell;
        }
    }

    public class Cell
    {
        public int N;
        public int[] Values;
        public int Value;

        public Cell(int value, int n)
        {
            N = n;
            Value = value;
            Values = new int[n];

            //initialize all values
            for (int i = 0; i < n; i++)
            {
                if (value == i || value == 0)
                {
                    Values[i] = i;
                }
            }
        }
    }
}
