using System;
using static System.Console;

namespace HeapTreeSort
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

            // 建立堆積樹
            Heap(arr, size);
            WriteLine();

            Write("排序結果：");
            OutputArr();

            Console.ReadLine();
        }

        static int size;
        static int[] arr;

        /// <summary>
        /// 隨機產生陣列
        /// </summary>
        static void InputArr()
        {
            arr = new int[size + 1];

            Random rand = new Random();

            for (int i = 1; i < size; i++)
                arr[i] = Math.Abs(rand.Next(99)) + 1;
        }

        /// <summary>
        /// 輸出陣列
        /// </summary>
        static void OutputArr()
        {
            for (int i = 1; i < size; i++)
                Write($"{arr[i]} ");
            WriteLine();
        }

        /// <summary>
        /// 堆積樹
        /// </summary>
        /// <param name="data"></param>
        /// <param name="size"></param>
        static void Heap(int[] data, int size)
        {
            // 建立堆積樹節點
            for (int i = (size / 2); i > 0; i--)
                AddHeap(data, i, size - 1);

            Write("堆積內容：");
            OutputArr();
            WriteLine();

            int tmp;

            // 堆積排序
            for (int i = (size - 2); i > 0; i--)
            {
                // 頭尾節點交換
                tmp = data[i + 1];
                data[i + 1] = data[1];
                data[1] = tmp;

                // 處理剩餘節點
                AddHeap(data, 1, i);

                Write("處理過程：");
                OutputArr();
            }
        }

        /// <summary>
        /// 堆積樹比較
        /// </summary>
        /// <param name="data"></param>
        /// <param name="i"></param>
        /// <param name="size"></param>
        static void AddHeap(int[] data, int i, int size)
        {
            int j = i * 2;
            int post = 0;
            int tmp = data[i];

            while (j <= size && post == 0)
            {
                if (j < size)
                {
                    // 找出最大節點
                    if (data[j] < data[j + 1])
                        j++;
                }

                // 若樹根較大，則結束比較
                if (tmp >= data[j])
                    post = 1;
                else // 若樹根較小，則繼續比較
                {
                    data[j / 2] = data[j];
                    j = 2 * j;
                }
            }

            // 指定樹根為父節點
            data[j / 2] = tmp;
        }
    }
}
