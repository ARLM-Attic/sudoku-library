using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary
{
    public class Group
    {
        private bool[] solvedValues;
        private List<Cell> mCells;
        public List<Cell> Cells
        {
            get
            {
                return mCells;
            }
        }


        private int mIndex;
        public int Index
        {
            get
            {
                return mIndex;
            }
        }

        public Group()
        {
            solvedValues = new bool[9];
            mCells = new List<Cell>();
        }

        public Group(int index)
        {
            mIndex = index;
            solvedValues = new bool[9];
            mCells = new List<Cell>();
        }

        public bool IsValueSolved(int value)
        {
            if (value > 9 || value < 1)
            {
                throw new Exception("Group:IsSolved " + value + "is outside of the expected values");
            }
            return solvedValues[value-1];
        }

        public void AddSolvedValue(int value)
        {
            solvedValues[value - 1] = true;
            foreach (Cell cell in mCells)
            {
                if (!cell.IsSolved)
                {
                    cell.RemovePossibleValue(value);
                }
            }
        }

        public void Add(Cell cell)
        {
            if (cell.IsSolved)
            {
                throw new Exception("Group:Add the cell is solved before it should be");
            }
            mCells.Add(cell);
        }

        public Cell Get(int index)
        {
            return mCells[index];
        }
    }
}
