using System;
using static System.Console;

namespace Linear
{
    /// <summary>
    /// 線性探測法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 建立資料
            CreateData();

            // 列印資料
            PrintData();

            // 雜湊表內容
            PrintHashTable();

            // 開始建立雜湊表
            for (int i = 0; i < MAX; i++)
            {
                CreateHashTable(data[i]);
                Write($"  {data[i]} =>");
                PrintHashTable();
            }

            // 完成雜湊表
            WriteLine("完成雜湊表");
            PrintHashTable();

            Console.ReadLine();
        }

        static int INDEX = 17;
        static int MAX = 13;

        // 建立資料雜湊最大元素
        static int?[] index = new int?[INDEX];

        // 建立陣列儲存空間
        static int[] data = new int[MAX];

        /// <summary>
        /// 亂樹建立資料
        /// </summary>
        static void CreateData()
        {
            int i;
            Random r = new Random();

            for (i = 0; i < MAX; i++)
                data[i] = r.Next(20) + 1;
        }

        /// <summary>
        /// 列印陣列方法
        /// </summary>
        static void PrintData()
        {
            int i;
            Write("\t");
            for (i = 0; i < MAX; i++)
                Write($"[{data[i]}] ");

            WriteLine();
        }

        /// <summary>
        /// 列印雜湊表
        /// </summary>
        static void PrintHashTable()
        {
            int i;
            Write("\t");
            for (i = 0; i < INDEX; i++)
                Write($"[{index[i]}] ");

            WriteLine();
        }

        /// <summary>
        /// 使用線性探測法建立雜湊表
        /// </summary>
        static void CreateHashTable(int num)
        {
            int tmp;

            // 取餘數成為雜湊值
            tmp = num % INDEX;

            while (true)
            {
                // 儲存位址為空，沒有發生碰撞，則將資料儲存
                if (index[tmp] == null)
                {
                    index[tmp] = num;
                    break;
                }
                else // 否則往後找儲存位址
                    tmp = (tmp + 1) % INDEX;
            }
        }
    }
}
