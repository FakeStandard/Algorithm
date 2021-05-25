using System;
using static System.Console;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"請輸入陣列大小(100以下)");
            size = int.Parse(Console.ReadLine());

            // 亂數產生隨機陣列
            Input();

            Write("原始資料：　 ");
            ShowData();

            // 進行排序
            Quick(data, 0, size - 1);

            WriteLine("排序結果：");
            ShowData();

            Console.ReadLine();
        }

        static int size;
        static int[] data;
        static int count = 0;

        /// <summary>
        /// 輸入資料
        /// </summary>
        static void Input()
        {
            // 亂數輸入
            Random rand = new Random();

            data = new int[size];

            for (int i = 0; i < size; i++)
                data[i] = (Math.Abs(rand.Next(99))) + 1;

            WriteLine();
        }

        /// <summary>
        /// 輸出資料
        /// </summary>
        static void ShowData()
        {
            for (int i = 0; i < size; i++)
                Write($"{data[i]} ");

            WriteLine();
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="d"></param>
        /// <param name="size"></param>
        /// <param name="lf"></param>
        /// <param name="rg"></param>
        static void Quick(int[] data, int left, int right)
        {
            // 如果左邊大於或等於右邊，則跳出
            if (left >= right)
                return;

            // 基準數取第一個資料
            int pivot = data[left];

            // 左右代理人
            int i = left;
            int j = right;

            int tmp;

            while (i != j)
            {
                // 從右邊開始找
                while (data[j] >= pivot && i < j)
                    j--;

                // 再從左邊開始找
                while (data[i] <= pivot && i < j)
                    i++;

                // 互換值
                if (i < j)
                {
                    tmp = data[i];
                    data[i] = data[j];
                    data[j] = tmp;

                    count++;

                    Write($"第 {count} 次交換：");
                    ShowData();
                }
            }

            // 將基準點與 j 代理人交換位置
            data[left] = data[i];
            data[i] = pivot;

            count++;

            Write($"第 {count} 次交換：");
            ShowData();

            // 透過遞迴處理左半邊
            Quick(data, left, i - 1);

            // 透過遞迴處理右半邊
            Quick(data, i + 1, right);
        }
    }
}
