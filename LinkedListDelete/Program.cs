using System;
using static System.Console;

namespace LinkedListDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            // 建立串列並插入節點
            LinkedList list1 = new LinkedList();

            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);

            list1.Insert(node1);
            list1.Insert(node2);
            list1.Insert(node3);
            list1.Insert(node4);
            list1.Insert(node5);
            list1.Insert(node6);

            Write("原始串列: ");
            list1.Print();

            Write("刪除頂端節點: ");
            list1.Delete(list1.first);
            list1.Print();

            Write("刪除末端節點: ");
            list1.Delete(list1.last);
            list1.Print();

            Write("刪除中間節點 [4] : ");
            list1.Delete(node4);
            list1.Print();

            ReadLine();
        }
    }

    /// <summary>
    /// 節點類別
    /// </summary>
    class Node
    {
        // 資料欄
        public int data;

        // 指標欄
        public Node next;

        /// <summary>
        /// 傳入一個資料的建構子
        /// 每次建立新節點時，只帶有資料，指標為 NULL
        /// </summary>
        /// <param name="data"></param>
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
        // 頂端節點
        public Node first;

        // 尾端節點
        public Node last;

        /// <summary>
        /// 輸出當前串列
        /// </summary>
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

        /// <summary>
        /// 判斷是否為空串列
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return first == null;
        }

        /// <summary>
        /// 刪除節點方法
        /// </summary>
        /// <param name="ptr"></param>
        public void Delete(Node ptr)
        {
            Node newNode;
            Node tmp;

            if (first.data == ptr.data) // 刪除頂端節點
                first = first.next;
            else if (last.data == ptr.data) // 刪除末端節點
            {
                newNode = first;

                while (newNode.next != last)
                    newNode = newNode.next;

                //last.next 一定是 null, 直接指向 Null 即可
                //newNode.next = last.next;
                newNode.next = null;
                last = newNode;
            }
            else // 刪除中間節點
            {
                newNode = first;
                tmp = first;

                while (newNode.data != ptr.data)
                {
                    tmp = newNode;
                    newNode = newNode.next;
                }

                tmp.next = ptr.next;
            }
        }

        /// <summary>
        /// 插入新節點方法
        /// </summary>
        /// <param name="ptr"></param>
        public void Insert(Node ptr)
        {
            Node tmp;
            Node newNode;

            // 如果串列為空，將新節點設置為第一個節點
            if (this.IsEmpty())
            {
                first = ptr;
                last = ptr;

                return;
            }

            if (ptr.next == first) // 插入第一個節點
            {
                ptr.next = first;
                first = ptr;
            }
            else
            {
                if (ptr.next == null) // 插入最後一個節點
                {
                    last.next = ptr;
                    last = ptr;
                }
                else // 插入中間節點
                {
                    tmp = first;
                    newNode = first.next;

                    while (ptr.next != newNode)
                    {
                        tmp = newNode;
                        newNode = newNode.next;
                    }

                    tmp.next = ptr;
                    ptr.next = newNode;
                }
            }
        }
    }
}
