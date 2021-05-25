using System;
using static System.Console;

namespace MergeSort
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

            // 合併排序
            MergeSort(arr, size);

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

            for (int i = 0; i < size; i++)
                arr[i] = Math.Abs(rand.Next(99)) + 1;
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
        /// 輸出陣列
        /// </summary>
        static void OutputArr(int[] arr2)
        {
            for (int i = 0; i < arr2.Length; i++)
                Write($"{arr2[i]} ");
            WriteLine();
        }

        static void MergeSort(int[] data, int size)
        {
            // 若長度 1，則不用排序
            if (size <= 1)
                return;

            // 計算左邊長度
            int Llen = size / 2;
            int[] left = new int[Llen];

            // 將原數列一一放入左邊陣列
            for (int i = 0; i < Llen; i++)
                left[i] = data[i];

            // 計算右邊長度
            int Rlen = size - Llen;
            int[] right = new int[Rlen];

            // 將原數列一一放入右邊陣列
            for (int j = 0; j < Rlen; j++)
                right[j] = data[Llen + j];

            // 遞迴到每組鍵值為1
            MergeSort(left, Llen);
            MergeSort(right, Rlen);

            // 離開遞迴後，就可進行合併排序
            Merge(data, left, right);
        }

        static void Merge(int[] data, int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int index = 0;

            // 反覆比對
            while ((leftIndex < left.Length) && (rightIndex < right.Length))
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    data[index] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    data[index] = right[rightIndex];
                    rightIndex++;
                }

                index++;
            }

            if (leftIndex < left.Length)
                while (leftIndex < right.Length)
                    data[index++] = left[leftIndex++];
            else
                while (rightIndex < left.Length)
                    data[index++] = right[rightIndex++];

            Write("處理過程：");
            OutputArr(data);
        }
    }
}
