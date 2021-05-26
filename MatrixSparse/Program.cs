using System;
using static System.Console;

namespace MatrixSparse
{
    class Program
    {
        static void Main(string[] args)
        {
            // 宣告並建立稀疏矩陣
            int[,] A =
            {
                { 25, 2, 0, 32, 0, -25 },
                { 0, 33, 77, 0, 0, 0 },
                { 0, 0, 0, 55, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 101, 0, 0, 0, 0, 0 },
                { 0, 0, 38, 0, 0, 0 }
            };

            // 建立壓縮矩陣
            int[,] Compress = new int[10, 3];

            // 壓縮矩陣填入
            Compress[0, 0] = 6;
            Compress[0, 1] = 6;
            Compress[0, 2] = 9;

            int i, j, tmp = 1;

            for (i = 0; i < A.GetLength(0); i++)
            {
                for (j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] != 0)
                    {
                        Compress[tmp, 0] = i + 1;
                        Compress[tmp, 1] = j + 1;
                        Compress[tmp, 2] = A[i, j];
                        tmp++;
                    }
                }
            }

            WriteLine("\n=======稀疏矩陣 A 元素=======\n");
            Print(ref A);

            WriteLine("\n=======壓縮矩陣 Compress 元素=======\n");
            Print(ref Compress);

            ReadLine();
        }

        /// <summary>
        /// 輸出矩陣
        /// </summary>
        /// <param name="matrix"></param>
        static void Print(ref int[,] matrix)
        {
            int i;
            int j;

            for (i = 0; i < matrix.GetLength(0); i++)
            {
                for (j = 0; j < matrix.GetLength(1); j++)
                    Write(matrix[i, j] + "\t");
                WriteLine();
            }
        }
    }
}
