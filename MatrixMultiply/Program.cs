using System;
using static System.Console;

namespace MatrixMultiply
{
    class Program
    {
        static void Main(string[] args)
        {
            // 宣告並建立 A.B 兩矩陣
            int[,] A = {
                { 2, 4, 6 },
                { 8, 10, 12 },
                { 14, 16, 18 }};

            int[,] B = {
                { 9, 8, 7 },
                { 6, 5, 4 },
                { 3, 2, 1 }};

            // 宣告並建立 C 矩陣
            int[,] C = new int[ROWS, COLS];

            // 輸出 A.B 矩陣
            WriteLine("\n=======矩陣 A 元素=======\n");
            Print(ref A);
            WriteLine("\n=======矩陣 B 元素=======\n");
            Print(ref B);

            // 進行矩陣相乘
            Matrix_Multiply(ref A, ref B, ref C);

            // 輸出 C 矩陣結果
            WriteLine("\n=======矩陣 C 元素=======\n");
            Print(ref C);

            ReadLine();
        }

        static int ROWS = 3;
        static int COLS = 3;

        /// <summary>
        /// 輸出矩陣
        /// </summary>
        /// <param name="matrix"></param>
        static void Print(ref int[,] matrix)
        {
            int i;
            int j;

            for (i = 0; i < ROWS; i++)
            {
                for (j = 0; j < COLS; j++)
                    Write(matrix[i, j] + "\t");
                WriteLine();
            }
        }

        /// <summary>
        /// 矩陣相乘方法
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        static void Matrix_Multiply(ref int[,] A, ref int[,] B, ref int[,] C)
        {
            int i, j, k, tmp;
            int m = 3;
            int n = 3;
            int p = 3;

            for (i = 0; i < m; i++)
            {
                for (j = 0; j < p; j++)
                {
                    tmp = 0;
                    for (k = 0; k < n; k++)
                        tmp += A[i, k] * B[k, j];
                    C[i, j] = tmp;
                }
            }
        }
    }
}
