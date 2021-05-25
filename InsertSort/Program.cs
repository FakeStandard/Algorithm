using System;

namespace InsertSort
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

            int i; // 掃描次數
            int j; // 定位比較的元素
            int tmp; // 用以暫存資料

            for (i = 1; i < data.Length; i++)
            {
                // 將要插入的元素放置暫存變數
                tmp = data[i];

                // 已排序資料的最末端
                j = i - 1;

                while (j >= 0 && tmp < data[j])
                {
                    // 把所有元素往後推一格
                    data[j + 1] = data[j];
                    j--;
                }


                data[j + 1] = tmp;

                // 打印每次掃描結果
                Console.Write($"第{i}次掃描排序結果：");

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

            Console.ReadLine();
        }
    }
}
