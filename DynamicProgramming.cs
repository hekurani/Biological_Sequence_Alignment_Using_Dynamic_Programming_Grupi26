using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DNA_Sequence_Alignment_Using_Dynamic_Programming_
{

    class DynamicProgramming
    {

        public static Cell[,] Intialization_Step(string Seq1, string Seq2,int Sim,int NonSimilar,int Gap)
        {
            int M = Seq1.Length;    // Length of the first sequence
            int N = Seq2.Length;    // Length of the second sequence

            Cell[,] Matrix = new Cell[N, M];

            // Initialize the first row with gap penalties
            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                Matrix[0, i] = new Cell(0, i, i*Gap);
            }

            // Initialize the first column with gap penalties
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                Matrix[i, 0] = new Cell(i, 0, i*Gap);
            }

            // Fill the scoring matrix using the Get_Max method
            for (int j = 1; j < Matrix.GetLength(0); j++)
            {
                for (int i = 1; i < Matrix.GetLength(1); i++)
                {
                    Matrix[j, i] = Get_Max(i, j, Seq1, Seq2, Matrix,Sim,NonSimilar,Gap);
                }
            }
            return Matrix;    // Return the completed scoring matrix
        }

         public static Cell Get_Max(int i, int j, string Seq1, string Seq2, Cell[,] Matrix,int Similar,int NonSimilar,int GapPenality)
         {
             Cell Temp = new Cell();
             int Sim;
             int Gap = GapPenality;

             // Determine the similarity score based on whether the characters match
             if (Seq1[i] == Seq2[j])
                 Sim = Similar;
             else
                 Sim = NonSimilar;
             
             int M1, M2, M3;
             M1 = Matrix[j - 1, i - 1].CellScore + Sim;    // Diagonal move
             M2 = Matrix[j, i - 1].CellScore + Gap;        // Left move
             M3 = Matrix[j - 1, i].CellScore + Gap;        // Above move

             // Find the maximum score
             int max = M1 >= M2 ? M1 : M2;
             int Mmax = M3 >= max ? M3 : max;

             // Assign the appropriate move and score to the cell
             if (Mmax == M1)
             { Temp = new Cell(j, i, M1, Matrix[j - 1, i - 1], Cell.PrevcellType.Diagonal); }
             else
             {
                 if (Mmax == M2)
                 { Temp = new Cell(j, i, M2, Matrix[j, i - 1], Cell.PrevcellType.Left); }
                 else
                 {
                     if (Mmax == M3)
                     { Temp = new Cell(j, i, M3, Matrix[j - 1, i], Cell.PrevcellType.Above); }
                 }
             }
        
             return Temp;
         }
        
        public static void Traceback_Step(Cell[,] Matrix, string Sq1, string Sq2, List<char> Seq1, List<char> Seq2)
        {
        
            Cell CurrentCell = Matrix[Sq2.Length - 1, Sq1.Length - 1];    // Start from the bottom-right corner
        
            // Trace back to reconstruct the alignment
            while (CurrentCell.CellPointer != null)
            {
                if (CurrentCell.Type == Cell.PrevcellType.Diagonal)
                {
                    Seq1.Add(Sq1[CurrentCell.CellColumn]);
                    Seq2.Add(Sq2[CurrentCell.CellRow]);
                }
                
                if (CurrentCell.Type == Cell.PrevcellType.Left)
                {
                    Seq1.Add(Sq1[CurrentCell.CellColumn]);    // Insert gap in the second sequence
                    Seq2.Add('-');
                }
                if (CurrentCell.Type == Cell.PrevcellType.Above)
                {
                    Seq1.Add('-');    // Insert gap in the first sequence
                    Seq2.Add(Sq2[CurrentCell.CellRow]);
                }
                
                CurrentCell = CurrentCell.CellPointer;    // Move to the next cell
                
            }     
        }
    }
}
