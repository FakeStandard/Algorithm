using System;
using static System.Console;

namespace FibonacciSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // 原始資料
            int[] data = { 2, 5, 17, 26, 38, 42, 59, 60, 65, 72, 87, 93 };

            int val;
            int i, j;

            WriteLine("資料內容");

            for (i = 0; i < data.Length; i++)
                Write($"{i + 1}-{data[i]} ");
            WriteLine();

            while (true)
            {
                Write("輸入欲搜尋的資料:");
                val = int.Parse(ReadLine());

                if (val == -1)
                    break;

                int node = Fibonacci_Search(data, val);

                if (node == data.Length)
                    WriteLine($"沒有找到 [{val}] ");
                else
                    WriteLine($"在第 {node + 1} 個位置找到 [{data[node]}]");
            }

            ReadLine();
        }

        /// <summary>
        /// 費氏數列遞迴方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static int Fibonacci(int value)
        {
            if (value == 0)
                return 0;
            else if (value == 1)
                return 1;
            else
                return Fibonacci(value - 1) + Fibonacci(value - 2);
        }

        /// <summary>
        /// 費氏搜尋法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SearchKey"></param>
        /// <returns></returns>
        static int Fibonacci_Search(int[] data, int SearchKey)
        {
            int index = 2;

            while (Fibonacci(index) <= data.Length)
                index++;
            index--;

            // 樹根
            int rootNode = Fibonacci(index);
            int diff1 = Fibonacci(index - 1);
            //int diff2 = Fibonacci(index - 2);
            int diff2 = rootNode - diff1;

            // 配合陣列從 0 開始儲存資料
            rootNode--;

            while (true)
            {
                if (SearchKey == data[rootNode])
                    return rootNode;
                else
                {
                    if (index == 2)
                        return data.Length;

                    if (SearchKey < data[rootNode]) // 往左子樹
                    {
                        rootNode -= diff2;
                        int tmp = diff1;
                        diff1 = diff2;
                        diff2 = tmp - diff2;
                        index--;
                    }
                    else // 往右子數
                    {
                        if (index == 3)
                            return data.Length;

                        rootNode += diff2;
                        diff1 -= diff2;
                        diff2 -= diff1;
                        index -= 2;
                    }
                }
            }
        }
    }
}
