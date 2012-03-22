using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuLibrary.Test
{
    /// <summary>
    /// Puzzles pulled from the "Exceptionally difficult Sudokus (hardest Sudokus)" section
    /// on the Sudoku Algorithms wikipedia page http://en.wikipedia.org/wiki/Sudoku_algorithms
    /// </summary>
    public static class HardPuzzles
    {
        //Rating Program: gsf's sudoku q1
        //Rating: 99529
        //Poster: eleven
        //Label: HardestSudokusThread-02085;Discrepancy
        public static byte[] HardestSudokusThread_02085 = 
        {
            1,2,0,4,0,0,3,0,0,
            3,0,0,0,1,0,0,5,0,
            0,0,6,0,0,0,1,0,0,
            7,0,0,0,9,0,0,0,0,
            0,4,0,6,0,3,0,0,0,
            0,0,3,0,0,2,0,0,0,
            5,0,0,0,8,0,7,0,0,
            0,0,7,0,0,0,0,0,5,
            0,0,0,0,0,0,0,9,8
        };

        //Rating Program: Nicolas Juillerat's Sudoku explainer 1.2.1
        //Rating: 11.9  (ER/EP/ED=11.9/11.9/11.3)
        //Poster: tarek
        //Label: golden nugget
        public static byte[] Golden_Nugget = 
        {
            0,0,0,0,0,0,0,3,9,
            0,0,0,0,0,1,0,0,5,
            0,0,3,0,5,0,8,0,0,
            0,0,8,0,9,0,0,0,6,
            0,7,0,0,0,2,0,0,0,
            1,0,0,4,0,0,0,0,0,
            0,0,9,0,8,0,0,5,0,
            0,2,0,0,0,0,6,0,0,
            4,0,0,7,0,0,0,0,0
        };

        //Rating Program: gsf's sudoku q2
        //Rating: 99743
        //Poster: eleven
        //Label: HardestSudokusThread-00245;Red_Dwarf
        public static byte[] HardestSudokusThread_00245 = 
        {
            1,2,0,3,0,0,0,0,4,
            3,5,0,0,0,0,1,0,0,
            0,0,4,0,0,0,0,0,0,
            0,0,5,4,0,0,2,0,0,
            6,0,0,0,7,0,0,0,0,
            0,0,0,0,0,8,0,9,0,
            0,0,3,1,0,0,5,0,0,
            0,0,0,0,0,9,0,7,0,
            0,0,0,0,6,0,0,0,8
        };

        //Rating Program: dukuso's suexrat9
        //Rating: 10364
        //Poster: eleven
        //Label: HardestSudokusThread-01418;coloin
        public static byte[] HardestSudokusThread_01418 = 
        {
            0,0,3,0,0,0,0,0,0,
            4,0,0,0,8,0,0,3,6,
            0,0,8,0,0,0,1,0,0,
            0,4,0,0,6,0,0,7,3,
            0,0,0,9,0,0,0,0,0,
            0,0,0,0,0,2,0,0,5,
            0,0,4,0,7,0,0,6,8,
            6,0,0,0,0,0,0,0,0,
            7,0,0,6,0,0,5,0,0
        };
    }
}
