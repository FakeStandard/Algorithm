using System;
using static System.Console;

namespace RadixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("請輸入陣列大小：");
            size = int.Parse(Console.ReadLine());
            InputArr();

            Write("原始陣列：");
            OutputArr();
            WriteLine();

            // 基數排序
            Radix();

            WriteLine();
            Write("排序結果：");
            OutputArr();

            ReadLine();
        }

        static int size;
        static int[] arr;

        /// <summary>
        /// 隨機產生陣列
        /// </summary>
        static void InputArr()
        {
            arr = new int[size];

            Random rand = new Random();

            for (int i = 0; i < size; i++)
                arr[i] = Math.Abs(rand.Next(999)) + 1;
        }

        /// <summary>
        /// 輸出陣列
        /// </summary>
        static void OutputArr()
        {
            for (int i = 0; i < size; i++)
                Write($"{arr[i]} ");
            WriteLine();
        }

        /// <summary>
        /// 基數排序
        /// </summary>
        static void Radix()
        {
            int i, j, k, n, m;

            // n 為基數, 由個位數開始
            for (n = 1; n <= 100; n = n * 10)
            {
                // 設定暫存陣列 [0-9 位數, 資料個數]
                int[,] tmp = new int[10, size];

                // 比對所有資料
                for (i = 0; i < size; i++)
                {
                    // 取 n 位數的值
                    m = (arr[i] / n) % 10;

                    // 將值暫存於 tmp
                    tmp[m, i] = arr[i];
                }

                k = 0;

                // 將結果合併放到數列中
                for (i = 0; i < 10; i++)
                {
                    for (j = 0; j < size; j++)
                    {
                        if (tmp[i, j] != 0)
                        {
                            arr[k] = tmp[i, j];
                            k++;
                        }
                    }
                }

                Write($"經過 {n} 位數的排序後: ");
                OutputArr();
            }
        }
    }
}
