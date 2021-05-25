using System;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // 原始作法
            Raw();

            Console.WriteLine();
            Console.WriteLine();

            // 改良後
            Improve();

            Console.Read();
        }

        /// <summary>
        /// 原生
        /// </summary>
        public static void Raw()
        {
            int i, j, tmp;

            // 初始序列
            int[] data = { 30, 20, 40, 50, 10 };

            Console.Write("初始序列：");

            foreach (var item in data)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("進行掃描...");
            Console.WriteLine();

            // 掃描次數
            for (i = data.Length - 1; i > 0; i--)
            {
                // 比較、交換的次數
                for (j = 0; j < i; j++)
                {
                    // 進行相鄰兩數比較
                    if (data[j] > data[j + 1])
                    {
                        tmp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = tmp;
                    }
                }

                // 打印每次掃描結果
                Console.Write($"第{data.Length - i}次掃描排序結果：");

                foreach (var item in data)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }

            // 排序後的結果
            Console.WriteLine();
            Console.Write("排序後的序列：");

            foreach (var item in data)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// 改良
        /// </summary>
        public static void Improve()
        {
            int i, j, tmp, flag;

            // 初始序列
            int[] data = { 10, 20, 40, 50, 30 };

            Console.Write("初始序列：");

            foreach (var item in data)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("進行掃描...");
            Console.WriteLine();

            // 掃描次數
            for (i = data.Length - 1; i > 0; i--)
            {
                // 用以判斷是否有交換過的動作
                flag = 0;

                // 比較、交換的次數
                for (j = 0; j < i; j++)
                {
                    // 進行相鄰兩數比較
                    if (data[j] > data[j + 1])
                    {
                        tmp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = tmp;

                        // 有執行交換就+1
                        flag++;
                    }
                }

                // 每次掃描完成判斷 flag 是否為 0，若為 0 則表示已完成排序
                // 可提前終止程式
                if (flag == 0)
                {
                    break;
                }

                // 打印每次掃描結果
                Console.Write($"第{data.Length - i}次掃描排序結果：");

                foreach (var item in data)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }

            // 排序後的結果
            Console.WriteLine();
            Console.Write("排序後的序列：");

            foreach (var item in data)
            {
                Console.Write(item + " ");
            }
        }
    }
}
