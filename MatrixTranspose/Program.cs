using System;
using static System.Console;

namespace MatrixTranspose
{
    class Program
    {
        static void Main(string[] args)
        {
            // 宣告並建立 A 矩陣
            int[,] A = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 10,11,12} };

            // 宣告並建立 A^t 矩陣
            int[,] At = new int[A.GetLength(1), A.GetLength(0)];

            // 輸出 A 矩陣
            WriteLine("\n=======矩陣 A 元素=======\n");
            Print(ref A);

            // 轉置矩陣 A
            Matrix_Transpose(ref A, ref At);

            // 輸出 C 矩陣結果
            WriteLine("\n=======轉置矩陣 At 元素=======\n");
            Print(ref At);

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

        /// <summary>
        /// 轉置矩陣方法
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        static void Matrix_Transpose(ref int[,] A, ref int[,] At)
        {
            int i, j;

            for (i = 0; i < A.GetLength(0); i++)
            {
                for (j = 0; j < A.GetLength(1); j++)
                    At[j, i] = A[i, j];
            }
        }
    }
}
