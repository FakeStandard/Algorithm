using System;

namespace AdjacencyMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] data;

            // 無向圖形陣列
            Console.WriteLine("無向圖形相鄰矩陣\n");
            data = new int[,] { { 1, 2 }, { 2, 1 }, { 2, 3 }, { 3, 2 }, { 2, 4 }, { 4, 2 }, { 4, 3 }, { 3, 4 } };
            Adjacent(data);

            // 有向圖形陣列
            Console.WriteLine("\n有向圖形相鄰矩陣\n");
            data = new int[,] { { 1, 2 }, { 2, 1 }, { 2, 3 }, { 2, 4 }, { 4, 3 } };
            Adjacent(data);

            Console.ReadLine();
        }

        /// <summary>
        /// 相鄰矩陣方法
        /// </summary>
        /// <param name="data"></param>
        static void Adjacent(int[,] data)
        {
            // 宣告一矩陣
            int[,] arr = new int[5, 5];

            int i, j, tmpi, tmpj;

            // 先將矩陣所有位置注入 0
            for (i = 0; i < arr.GetLength(0); i++)
                for (j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = 0;

            // 填入矩陣資料
            for (i = 0; i < data.GetLength(0); i++)
            {
                for (j = 0; j < data.GetLength(1); j++)
                {
                    tmpi = data[i, 0];
                    tmpj = data[i, 1];

                    arr[tmpi, tmpj] = 1;
                }
            }

            // 輸出無向矩陣
            for (i = 1; i < arr.GetLength(0); i++)
            {
                for (j = 1; j < arr.GetLength(1); j++)
                    Console.Write($"[{arr[i, j]}] ");
                Console.WriteLine();
            }
        }
    }
}
