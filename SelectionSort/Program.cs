using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
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

            int minIndex, tmp;
            // 掃描次數
            for (int i = 0; i < data.Length; i++)
            {
                // 最小值預設為每次要搜尋數列裡的第一個元素
                minIndex = i;

                // 找出搜尋數列中最小值
                for (int j = i; j < data.Length; j++)
                {
                    if (data[j] < data[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // 將最小值與搜尋數列中的頭一個元素對調
                tmp = data[i];
                data[i] = data[minIndex];
                data[minIndex] = tmp;

                // 打印每次掃描結果
                Console.Write($"第{i + 1}次掃描排序結果：");

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

            Console.Read();
        }
    }
}
