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
        private List<Cell> cells;

        public Group()
        {
            solvedValues = new bool[9];
            cells = new List<Cell>();
        }

        public bool IsValueSolved(int value)
        {
            if (value > 9 || value < 1)
            {
                throw new Exception("Group:IsSolved " + value + "is outside of the expected values");
            }
            return solvedValues[value-1];
        }

        private void AddSolvedValue(int value)
        {
            solvedValues[value - 1] = true;
        }

        public void Add(Cell cell)
        {
            if (cell.IsSolved)
            {
                AddSolvedValue(cell.Value);
            }
            cells.Add(cell);
        }

        public Cell Get(int index)
        {
            return cells[index];
        }
    }
}
