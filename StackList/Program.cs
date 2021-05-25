using System;
using static System.Console;

namespace StackList
{
    class Program
    {
        static void Main(string[] args)
        {
            StackByLink stack = new StackByLink();

            int choice = 0;

            while (true)
            {
                Write("請輸入 [0:結束]、[1:在堆疊加入資料]、[2:取出堆疊資料]：");
                choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                    break;
                else if (choice == 1)
                {
                    Write("請輸入要加入堆疊的資料內容:");
                    choice = int.Parse(Console.ReadLine());

                    WriteLine("頂端新增資料後的堆疊內容");
                    stack.Insert(choice);

                    stack.Display();
                }
                else if (choice == 2)
                {
                    WriteLine("刪除頂端資料後的堆疊內容");
                    stack.Pop();
                    stack.Display();
                }
                else
                    WriteLine("輸入錯誤！");

                WriteLine();
            }

            ReadKey();

            Console.ReadLine();
        }

        /// <summary>
        /// 鏈結串列節點的類別
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
        /// 以串列模擬的堆疊
        /// </summary>
        class StackByLink
        {
            /// <summary>
            /// 指向堆疊頂端的指標
            /// </summary>
            public Node front;

            /// <summary>
            /// 指向堆疊末端的指標
            /// </summary>
            public Node rear;

            /// <summary>
            /// 判斷堆別是否為空的方法
            /// </summary>
            /// <returns></returns>
            public bool IsEmpty()
            {
                return front == null;
            }

            /// <summary>
            /// 輸出堆疊內容
            /// </summary>
            public void Display()
            {
                Node current = front;

                while (current != null)
                {
                    Write($"[{current.data}]");
                    current = current.next;
                }

                WriteLine();
            }

            /// <summary>
            /// 從堆疊頂端加入資料
            /// </summary>
            /// <param name="data"></param>
            public void Insert(int data)
            {
                Node newNode = new Node(data);

                if (this.IsEmpty())
                {
                    front = newNode;
                    rear = newNode;
                }
                else
                {
                    Console.WriteLine(front);
                    Console.WriteLine(rear);

                    rear.next = newNode;
                    rear = newNode;
                }
            }

            /// <summary>
            /// 從堆疊頂端刪除資料
            /// </summary>
            public void Pop()
            {
                Node newNode;

                if (this.IsEmpty())
                {
                    Write("=====目前堆疊為空=====\n");
                    return;
                }

                newNode = front;

                if (newNode == rear)
                {
                    front = null;
                    rear = null;
                    Write("=====目前堆疊為空=====\n");
                }
                else
                {
                    while (newNode.next != rear)
                        newNode = newNode.next;

                    newNode.next = rear.next;
                    rear = newNode;
                }
            }
        }
    }
}
