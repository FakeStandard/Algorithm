using System;
using static System.Console;

namespace SequentialSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            int val = 0;
            int find = 0;

            // 建立陣列物件
            int[] data = new int[100];

            // 亂數產生值並塞入陣列
            Random r = new Random();

            for (i = 0; i < data.Length; i++)
                data[i] = ((r.Next(150)) % 150) + 1;

            // 輸出資料內容
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                    Write($"{i * 10 + j + 1}({data[i * 10 + j]}) ");

                WriteLine();
            }

            while (val != -1)
            {
                find = 0;

                Write("請輸入欲搜尋的鍵值(1-150之間)，或是輸入 -1 離開");

                val = int.Parse(Console.ReadLine());

                // 循序搜尋, 走訪陣列內所有的值
                for (i = 0; i < data.Length; i++)
                {
                    if (data[i] == val)
                    {
                        WriteLine($"在第 {i + 1} 個位置找到鍵值 {val}");
                        find++;
                    }
                }

                if (find == 0)
                    WriteLine($"沒有找到 {val} ");
            }

            ReadLine();
        }
    }
}
