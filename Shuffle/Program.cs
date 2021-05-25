using System;
using System.Threading;

namespace Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            // 建立撲克牌陣列
            int[] card = new int[52];
            for (int i = 0; i < 52; i++)
            {
                card[i] = i;
            }

            Console.WriteLine("洗牌中, 請稍後...");
            Thread.Sleep(2000);

            // 隨機洗牌 30 次
            int k = 0;
            int tmp = 0;
            Random r = new Random();
            while (k < 30)
            {
                for (int i = 0; i < 51; i++)
                {
                    for (int j = i + 1; j < 52; j++)
                    {
                        if ((r.Next(10000) % 52) == 2)
                        {
                            tmp = card[i];
                            card[i] = card[j];
                            card[j] = tmp;
                        }
                    }
                }

                k++;
            }

            // 建立堆疊類別實例
            StackArray stack = new StackArray(52);

            // 將撲克牌的值推入堆疊中
            k = 0;
            while (k != 52)
            {
                stack.Push(card[k]);
                k++;
            }

            Console.WriteLine("逆時針發牌...");
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine("顯示各家的牌");
            Thread.Sleep(500);
            Console.WriteLine("===============================================");
            Thread.Sleep(500);
            Console.WriteLine("東家 \t 北家 \t 西家 \t 南家");
            Thread.Sleep(500);
            Console.WriteLine("===============================================");
            Thread.Sleep(500);

            // 紀錄撲克牌花色變數
            tmp = 0;
            string fourSuits = "";

            // 發牌
            while (stack.top >= 0)
            {
                tmp = card[stack.top] / 13;

                switch (tmp)
                {
                    case 0:
                        fourSuits = "梅花";
                        break;
                    case 1:
                        fourSuits = "方塊";
                        break;
                    case 2:
                        fourSuits = "紅心";
                        break;
                    case 3:
                        fourSuits = "黑桃";
                        break;
                }

                Console.Write($"[{fourSuits}{(stack.Pop()) % 13 + 1}] ");

                if ((stack.top + 1) % 4 == 0)
                    Console.WriteLine();

                Thread.Sleep(200);
            }

            Console.WriteLine("===============================================");
            Console.WriteLine();
            Console.WriteLine("發完了");

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 宣告陣列實作堆疊類別
    /// </summary>
    class StackArray
    {
        int[] stack;
        public int top = -1;
        public StackArray(int size)
        {
            stack = new int[size];
        }
        public void Push(int val)
        {
            if (top >= stack.Length)
                Console.WriteLine("堆疊已滿");
            else
                stack[++top] = val;

        }
        public int Pop()
        {
            if (top < 0)
                Console.WriteLine("堆疊已空");
            else
                top--;

            return top == -1 ? -1 : stack[top];
        }
    }
}
