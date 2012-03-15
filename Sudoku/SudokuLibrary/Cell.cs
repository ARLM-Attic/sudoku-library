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
        public void SetValue(int value)
        {
            if (value > 9 || value < 1)
            {
                throw new Exception("Cell:SetValue attempting to set cell to value out of range, must be between 1 and 9");
            }
            if (mIsSolved)
            {
                throw new Exception("Cell:SetValue value is already set");
            }
            mValue = value;
            mIsSolved = true;
            mValueMap[value] = true;
            for(int i=0; i<10; i++)
            {
                if(i != value)
                {
                    mValueMap[i] = false;
                }
            }
        }

        public bool CanBeValue(int value)
        {
            return mValueMap[value];
        }

        public Cell(int value)
        {
            this.mValueMap = new bool[10];
            SetValue(value);
        }

        public Cell()
        {
            this.mValueMap = new bool[10];
        }
    }
}
