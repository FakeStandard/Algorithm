using System;
using static System.Console;

namespace Deques
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListDeques deques = new LinkedListDeques();

            // 從末端插入資料
            deques.PushRear(1);
            deques.PushRear(2);
            deques.PushRear(3);
            deques.PushRear(4);
            deques.PushRear(5);

            deques.Print();

            // 從頂端插入資料
            deques.PushFront(6);
            deques.PushFront(7);
            deques.PushFront(8);
            deques.PushFront(9);
            deques.PushFront(10);

            deques.Print();

            deques.PopRear();
            deques.Print();

            deques.PopRear();
            deques.Print();

            deques.PopFront();
            deques.Print();

            deques.PopFront();
            deques.Print();

            ReadLine();
        }
    }

    /// <summary>
    /// 節點類別
    /// </summary>
    class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    /// <summary>
    /// 串列結構的雙向佇列
    /// </summary>
    class LinkedListDeques
    {
        // 佇列頂端指標
        public Node front;

        // 佇列末端指標
        public Node rear;

        // 建構函式
        public LinkedListDeques()
        {
            this.front = null;
            this.rear = null;
        }

        /// <summary>
        /// 判斷佇列是否為空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return front == null;
        }

        /// <summary>
        /// 由頂端開始輸出雙向佇列
        /// </summary>
        public void Print()
        {
            if (!IsEmpty())
            {
                Node current = front;

                while (current != null)
                {
                    Write($"[{current.data}] ");

                    current = current.next;
                }

                WriteLine();
            }
        }

        /// <summary>
        /// 從頂端推入資料
        /// </summary>
        /// <param name="data"></param>
        public void PushFront(int data)
        {
            Node newNode = new Node(data);

            if (IsEmpty())
            {
                rear = newNode;
                front = newNode;
            }
            else
            {
                Node current = front;

                newNode.next = current;
                front = newNode;
            }
        }

        /// <summary>
        /// 從末端推入資料
        /// </summary>
        /// <param name="data"></param>
        public void PushRear(int data)
        {
            Node newNode = new Node(data);

            if (IsEmpty())
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                Node current = front;

                while (current.next != null)
                    current = current.next;

                current.next = newNode;
                rear = newNode;
            }
        }

        /// <summary>
        /// 從頂端取出資料
        /// </summary>
        public void PopFront()
        {
            WriteLine($"從頂端取出資料: {front.data}");

            front = front.next;
        }

        /// <summary>
        /// 從末端取出資料
        /// </summary>
        public void PopRear()
        {
            Node current = front;

            while (current.next != rear)
                current = current.next;

            WriteLine($"從末端取出資料: {rear.data}");
            current.next = null;
            rear = current;
        }
    }
}
