using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary
{
    public class Cell
    {
        private bool[] mValueMap;
        private int mValue;
        private bool mIsSolved;

        private Group mRow;
        private Group mCol;
        private Group mSqr;

        public Group Row
        {
            get { return mRow; }
            set { mRow = value; }
        }

        public Group Column
        {
            get { return mCol; }
            set { mCol = value; }
        }

        public Group Square
        {
            get { return mSqr; }
            set { mSqr = value; }
        }

        public int Value
        {
            get
            {
                return mValue;
            }
        }

        public bool IsSolved
        {
            get
            {
                return mIsSolved;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// Throws Exception
        public void Solve(int value)
        {
            if (value > 9 || value < 1)
            {
                throw new Exception("Cell:SetValue attempting to set cell to value out of range, must be between 1 and 9");
            }
            if (mIsSolved)
            {
                throw new Exception("Cell:SetValue value is already set");
            }
            if (!CanBeValue(value))
            {
                throw new Exception("Cell:SetValue value is not acceptable for this cell");
            }
            mValue = value;
            mIsSolved = true;
            mRow.AddSolvedValue(value);
            mCol.AddSolvedValue(value);
            mSqr.AddSolvedValue(value);
            for(int i=1; i<10; i++)
            {
                if(i != value)
                {
                    RemovePossibleValue(i);
                }
            }
            
        }

        private void RemovePossibleValue(int value)
        {
            mValueMap[value - 1] = false;
        }

        public bool CanBeValue(int value)
        {
            return mValueMap[value-1];
        }

        public Cell()
        {
            this.mValueMap = new bool[] { true, true, true, true, true, true, true, true, true };
        }
    }
}
