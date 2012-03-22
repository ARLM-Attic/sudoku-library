using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary.HumanDeduction
{
    public class Cell
    {
        private bool[] mValueMap;
        private int mValue;
        private bool mIsSolved;
        private int mNumPossibleValues = 9;

        private Puzzle mPuzzle;
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
            for(int i=0; i<9; i++)
            {
                mValueMap[i] = false;
            }
            mValueMap[value - 1] = true;
        }

        public void UpdateRowColSqr()
        {
            mRow.AddSolvedValue(mValue);
            mCol.AddSolvedValue(mValue);
            mSqr.AddSolvedValue(mValue);
        }

        public void RemovePossibleValue(int value)
        {
            if (mValueMap[value - 1])
            {
                mNumPossibleValues--;
                mValueMap[value - 1] = false;
                if (mNumPossibleValues == 1)
                {
                    mPuzzle.Solve(this,GetOnlyPossibleValue());
                }
            }
        }

        private int GetOnlyPossibleValue()
        {
            for (int i = 0; i < 9; i++)
            {
                if (mValueMap[i])
                {
                    return i + 1;
                }
            }
            return 0;
        }

        public bool CanBeValue(int value)
        {
            return mValueMap[value-1];
        }

        public Cell(Puzzle puzzle)
        {
            mPuzzle = puzzle;
            this.mValueMap = new bool[] { true, true, true, true, true, true, true, true, true };
        }
    }
}
