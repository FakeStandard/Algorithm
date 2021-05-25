using System;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // 初始資料
            int[] data = { 50, 60, 10, 30, 20, 80, 40, 70 };

            Console.Write("初始序列：");

            foreach (var item in data)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("進行掃描...");
            Console.WriteLine();

            int tmp; // 暫存資料

            // 第一次排序
            // 將資料分成四組
            for (int i = 4; i < 8; i++)
            {
                // 遍歷所有元素
                for (int j = i - 4; j >= 0; j -= 4)
                {
                    if (data[j] > data[j + 4])
                    {
                        tmp = data[j];
                        data[j] = data[j + 4];
                        data[j + 4] = tmp;
                    }
                }
            }

            Console.Write("第一次排序：　");

            foreach (var item in data)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            // 第二次排序
            // 將資料分成兩組
            for (int i = 2; i < 8; i++)
            {
                for (int j = i - 2; j >= 0; j -= 2)
                {
                    if (data[j] > data[j + 2])
                    {
                        tmp = data[j];
                        data[j] = data[j + 2];
                        data[j + 2] = tmp;
                    }
                }
            }

            Console.Write("第二次排序：　");

            foreach (var item in data)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            // 第三次排序
            // 將資料分成八組，等同於直接使用插入排序法
            for (int i = 1; i < data.Length; i++)
            {
                for (int j = i - 1; j >= 0; j -= 1)
                {
                    if (data[j] > data[j + 1])
                    {
                        tmp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = tmp;
                    }
                }
            }

            Console.Write("第三次排序：　");

            foreach (var item in data)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 封裝謝耳排序法(一)
        /// </summary>
        private static void ShellSort_A()
        {
            // 初始資料
            int[] data = { 50, 60, 10, 30, 20, 80, 40, 70 };
            int tmp;
            int count = 0;

            for (int gap = data.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < data.Length; i++)
                {
                    for (int j = i - gap; j >= 0; j -= gap)
                    {
                        // 插入排序法
                        if (data[j] > data[j + gap])
                        {
                            tmp = data[j];

                            data[j] = data[j + gap];

                            data[j + gap] = tmp;
                        }
                    }
                }
            }

            Console.WriteLine();

            foreach (var item in data)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// 封裝謝耳排序(二)
        /// </summary>
        private static void ShellSort_B()
        {
            // 初始資料
            int[] data = { 50, 60, 10, 30, 20, 80, 40, 70 };
            int i; // 掃描次數
            int j; // 以 j 來定位比較的元素
            int k = 1; // 列印計數
            int tmp; // 暫存資料
            int jmp; // 設定間距位移量
            jmp = data.Length / 2;

            while (jmp > 0)
            {
                for (i = jmp; i < data.Length; i++)
                {
                    tmp = data[i];
                    j = i - jmp;

                    while (j >= 0 && tmp < data[j])
                    {
                        // 插入排序法
                        data[j + jmp] = data[j];
                        j = j - jmp;
                    }

                    data[jmp + j] = tmp;
                }

                Console.WriteLine($"第{(k++)}次排序：");

                foreach (var item in data)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();

                jmp = jmp / 2;
            }
        }
    }
}
