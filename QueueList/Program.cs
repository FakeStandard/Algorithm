using System;
using static System.Console;

namespace QueueList
{
    class Program
    {
        static void Main(string[] args)
        {
            // 建立佇列物件
            QueueByLink queue = new QueueByLink();

            int tmp;

            WriteLine("以鏈結串列實作佇列");
            WriteLine("=============================");

            WriteLine("在佇列中加入資料 2");
            queue.Enqueue(2);
            WriteLine("在佇列中加入資料 4");
            queue.Enqueue(4);
            WriteLine("在佇列中加入資料 6");
            queue.Enqueue(6);
            WriteLine("在佇列中加入資料 8");
            queue.Enqueue(8);
            WriteLine("在佇列中加入資料 10");
            queue.Enqueue(10);

            WriteLine("=============================");

            while (true)
            {
                if (!(queue.front == null))
                {
                    tmp = queue.Dequeue();
                    WriteLine($"從佇列中取出資料 {tmp}");
                }
                else
                    break;
            }


            Console.ReadLine();
        }
    }

    /// <summary>
    /// 佇列節點類別
    /// </summary>
    class QueueNode
    {
        public int data;
        public QueueNode next;

        public QueueNode(int data)
        {
            this.data = data;
            next = null;
        }
    }

    /// <summary>
    /// 串列模擬佇列類別
    /// </summary>
    class QueueByLink
    {
        // 前端指標
        public QueueNode front;
        // 末端指標
        public QueueNode rear;

        public QueueByLink()
        {
            front = null;
            rear = null;
        }

        /// <summary>
        /// 加入資料到佇列
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Enqueue(int value)
        {
            // 建立新節點
            QueueNode node = new QueueNode(value);

            // 檢查是否為空佇列
            if (rear == null)
                front = node;
            else
                rear.next = node;

            rear = node;

            return true;
        }

        /// <summary>
        /// 從佇列中取出資料
        /// </summary>
        /// <returns></returns>
        public int Dequeue()
        {
            int value;

            // 檢查是否為空佇列
            if (front != null)
            {
                if (front == rear)
                    rear = null;

                // 取出資料
                value = front.data;

                // 將指標指向下一個
                front = front.next;

                return value;
            }
            else return -1;
        }
    }
}
