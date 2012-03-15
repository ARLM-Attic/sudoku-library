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
                    Cell cell = new Cell();
                    cell.Row = Rows[row];
                    cell.Column = Columns[col];
                    cell.Square = Squares[sqr];
                    Rows[row].Add(cell);
                    Columns[col].Add(cell);
                    Squares[sqr].Add(cell);
                }
            }
        }

        public void Solve(int row, int col, int value)
        {
            Cell cell = GetCell(row, col);
            cell.Solve(value);
            QueueCell(cell);
        }

        public Cell GetCell(int row, int col)
        {
            return Rows[row].Cells[col];
        }

        private void QueueCell(Cell cell)
        {
            mQueue.Add(cell);
        }

        public int GetSquare(int row, int col)
        {
            return 3 * (row/3) + (col/3);
        }
    }
}
