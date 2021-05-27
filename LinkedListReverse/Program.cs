using System;
using static System.Console;

namespace LinkedListReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list1 = new LinkedList();
            list1.Insert(1);
            list1.Insert(2);
            list1.Insert(3);
            list1.Insert(4);
            list1.Insert(5);
            list1.Insert(6);

            Write("原始串列: ");
            list1.Print();

            Write("反轉後串列: ");
            list1.ReversePrint();

            Write("再反轉串列: ");
            list1.ReversePrint();

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
    /// 鏈結串列類別
    /// </summary>
    class LinkedList
    {
        public Node first;
        public Node last;

        public bool IsEmpty()
        {
            return first == null;
        }

        public void Print()
        {
            Node current = first;

            while (current != null)
            {
                Write($"[{current.data}] ");
                current = current.next;
            }

            WriteLine();
        }

        public void Insert(int data)
        {
            Node newNode = new Node(data);

            if (this.IsEmpty())
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.next = newNode;
                last = newNode;
            }
        }

        /// <summary>
        /// 反轉串列
        /// </summary>
        public void ReversePrint()
        {
            Node current = first;
            Node before = null;

            while (current != null)
            {
                last = before;
                before = current;
                current = current.next;
                before.next = last;
            }

            current = before;

            while (current != null)
            {
                Write($"[{current.data}] ");
                current = current.next;
            }

            first = before;

            WriteLine();
        }
    }
}
