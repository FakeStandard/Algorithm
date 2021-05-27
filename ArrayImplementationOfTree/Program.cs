using System;
using static System.Console;

namespace ArrayImplementationOfTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;

            // 原始陣列
            int[] data = { 12, 46, 10, 23, 11, 30, 7, 31 };
            int[] btree = new int[32];

            for (i = 0; i < btree.Length; i++)
                btree[i] = 0;

            Write("原始陣列: ");
            for (i = 0; i < data.Length; i++)
                Write($"[{data[i]}] ");

            // 將陣列的值轉換成完整二元樹
            for (i = 0; i < data.Length; i++)
            {
                for (j = 1; j < btree.Length;)
                {
                    if (btree[j] == 0)
                    {
                        btree[j] = data[i];
                        break;
                    }
                    else if (data[i] > btree[j])
                        j = 2 * j + 1;
                    else
                        j = 2 * j;
                }
            }

            WriteLine();

            WriteLine("完滿二元樹: ");
            for (i = 1; i < btree.Length; i++)
            {
                Write($"[{btree[i]}] ");
                if (i % 8==0)
                    WriteLine();
            }

            ReadLine();
        }
    }
}
