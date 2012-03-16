using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary
{
    public class Puzzle
    {
        List<Cell> mQueue = new List<Cell>();

        public List<Cell> Queue
        {
            get { return mQueue; }
            set { }
        }

        private List<Group> Rows = new List<Group>(9);
        private List<Group> Columns = new List<Group>(9);
        private List<Group> Squares = new List<Group>(9);
        
        private int mNumCellsSolved = 0;
        public int NumCellsSolved
        {
            get { return mNumCellsSolved; }
        }

        public Puzzle()
        {
            Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < 9; i++)
            {
                Rows.Add(new Group(i));
                Columns.Add(new Group(i));
                Squares.Add(new Group(i));
            }

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int sqr = GetSquare(row, col);
                    Cell cell = new Cell(this);
                    cell.Row = Rows[row];
                    cell.Column = Columns[col];
                    cell.Square = Squares[sqr];
                    Rows[row].Add(cell);
                    Columns[col].Add(cell);
                    Squares[sqr].Add(cell);
                }
            }
        }

        public void Run()
        {
            while (mQueue.Count > 0)
            {
                mQueue[0].UpdateRowColSqr();
                mQueue.RemoveAt(0);
            }
        }

        public void Solve(int row, int col, int value)
        {
            Solve(GetCell(row, col), value);
        }

        public void Solve(Cell cell, int value)
        {
            mNumCellsSolved++;
            cell.Solve(value);
            QueueCell(cell);
        }

        public Cell GetCell(int row, int col)
        {
            return Rows[row].Cells[col];
        }

        public Group GetRow(int row)
        {
            return Rows[row];
        }

        public Group GetColumn(int col)
        {
            return Columns[col];
        }

        public Group GetSquare(int sqr)
        {
            return Squares[sqr];
        }

        private void QueueCell(Cell cell)
        {
            mQueue.Add(cell);
        }

        /// <summary>
        /// Given a row and column, return the Square it should be apart of.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int GetSquare(int row, int col)
        {
            return 3 * (row/3) + (col/3);
        }
    }
}
