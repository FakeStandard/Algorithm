using System;

namespace StackArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int value;
            StackArray stack = new StackArray(10);

            Console.WriteLine("請依序輸入 10 筆資料");

            for (int i = 0; i < 10; i++)
            {
                value = int.Parse(Console.ReadLine());
                stack.Push(value);
            }

            Console.WriteLine("===========================");

            // 將堆疊內的資料陸續從頂端取出
            while (!stack.Empty())
            {
                Console.WriteLine($"堆疊資料: {stack.Pop()}");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 宣告以陣列模擬堆疊的類別
        /// </summary>
        class StackArray
        {
            // 宣告陣列
            private int[] stack;

            // 指向堆疊頂端的索引
            private int top;

            /// <summary>
            /// 建構子
            /// </summary>
            /// <param name="stack_size">堆疊大小</param>
            public StackArray(int size)
            {
                // 建立陣列
                stack = new int[size];
                top = -1;
            }

            /// <summary>
            /// 判斷堆疊是否為空
            /// </summary>
            /// <returns></returns>
            public bool Empty()
            {
                if (top == -1) return true;
                else return false;
            }

            /// <summary>
            /// 推入資料到頂端的方法
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public bool Push(int data)
            {
                // 判斷堆疊頂端的索引是否大於陣列大小
                if (top >= stack.Length)
                {
                    Console.WriteLine("堆疊已滿，無法再加入");
                    return false;
                }
                else
                {
                    // 先將堆疊指標往上移，再將資料放入堆疊
                    stack[++top] = data;
                    return true;
                }
            }

            public int Pop()
            {
                if (Empty())
                    return -1;
                else
                    return stack[top--]; // 先將資料取出，再將堆疊指標往下移
            }
        }
    }
}
