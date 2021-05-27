using System;
using static System.Console;

namespace LinkedListInsert
{
    /// <summary>
    /// 單向串列插入結點
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 建立鏈結串列
            LinkedList list1 = new LinkedList();

            // 建立三個節點
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);

            // 將節點依序插入到串列中, 每次都是從最後一個節點插入
            list1.Insert(node1);
            list1.Insert(node2);
            list1.Insert(node3);

            list1.Print();

            // 嘗試將節點插入到串列頂端，成為頂端節點
            Node node4 = new Node(4);
            node4.next = list1.first;
            list1.Insert(node4);

            list1.Print();

            // 嘗試將節點插入到串列的兩節點之間，成為中間節點
            Node node5 = new Node(5);
            node5.next = node3;
            list1.Insert(node5);

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
                    // 原本程式碼, 這樣插入的位置會往前挪一個, 不合乎邏輯
                    // newNode = first;

                    // while (ptr.next != newNode.next)
                    // {
                    //    ...
                    // }

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
