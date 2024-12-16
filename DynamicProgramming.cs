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
            int M = Seq1.Length;//Length+1//-AAA
            int N = Seq2.Length;//Length+1//-AAA

            Cell[,] Matrix = new Cell[N, M];

            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                Matrix[0, i] = new Cell(0, i, i*Gap);

            }

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                Matrix[i, 0] = new Cell(i, 0, i*Gap);

            }

            for (int j = 1; j < Matrix.GetLength(0); j++)
            {
                for (int i = 1; i < Matrix.GetLength(1); i++)
                {
                    Matrix[j, i] = Get_Max(i, j, Seq1, Seq2, Matrix,Sim,NonSimilar,Gap);

                }

            }

            return Matrix;

        }
  }
