using System;
using static System.Console;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            int val = 0;
            int num = 0;

            // 亂數產生值並塞入陣列
            Random r = new Random();

            for (i = 0; i < data.Length; i++)
                data[i] = ((r.Next(150)) % 150) + 1;

            // 使用 C# 內建排序
            Array.Sort(data);

            // 輸出資料內容
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                    Write($"{i * 10 + j + 1}({data[i * 10 + j]}) ");

                WriteLine();
            }

            while (val != -1)
            {
                Write("請輸入欲搜尋的鍵值(1-150之間)，或是輸入 -1 離開");

                val = int.Parse(Console.ReadLine());

                if (val == -1)
                    break;

                // 二分搜尋
                num = BinarySearch(val);

                WriteLine($"找到鍵值 {val} 在陣列中第 {num} 個資料");

            }

            ReadLine();
        }

        // 建立靜態陣列物件
        static int[] data = new int[100];

        /// <summary>
        /// 二分搜尋方法
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        static int BinarySearch(int val)
        {
            int mid; // 中間值
            int left = 0; // 左邊極限
            int right = data.Length - 1; // 右邊極限

            while (left <= right)
            {
                // 取得中間值
                mid = (left + right) / 2;

                // 鍵值與中間值比較
                if (val == data[mid])
                    return mid + 1;
                else if (val < data[mid])
                    right = mid - 1;
                else if (val > data[mid])
                    left = mid + 1;
                else
                    return -1;
            }

            return -1;
        }
    }
}
