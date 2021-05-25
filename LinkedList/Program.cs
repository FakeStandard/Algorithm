using System;
using static System.Console;

namespace LinkedList
{
    /// <summary>
    /// 鏈結串列再雜湊
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 建立資料
            CreateData();

            // 列印資料
            PrintData();

            // 雜湊表建立節點物件
            for (int i = 0; i < INDEX; i++)
                hashTable[i] = new Node(-1);

            // 雜湊表內容
            PrintHashTable();

            // 開始建立雜湊表
            for (int i = 0; i < MAX; i++)
            {
                CreateHashTable(data[i]);
                PrintHashTable();
            }

            WriteLine();

            // 完成雜湊表
            WriteLine("完成雜湊表");

            ReadLine();
        }

        static int INDEX = 5;
        static int MAX = 20;

        // 建立資料雜湊最大元素
        static Node[] hashTable = new Node[INDEX];

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
                data[i] = r.Next(30) + 1;
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
            Node head;
            int i;

            WriteLine("雜湊索引值-[value]");

            for (i = 0; i < hashTable.Length; i++)
            {
                // 起始指標
                head = hashTable[i].next;

                Write($"{i}：");

                while (head != null)
                {
                    Write($"[{head.val}]-");
                    head = head.next;
                }

                WriteLine("\b ");
            }
        }

        /// <summary>
        /// 使用鏈結串列建立雜湊表
        /// </summary>
        static void CreateHashTable(int num)
        {
            Node newNode = new Node(num);

            int hash;
            hash = num % INDEX;

            Node current = hashTable[hash];

            if (current.next == null)
                hashTable[hash].next = newNode;
            else
                while (current.next != null)
                    current = current.next;

            current.next = newNode;
        }
    }

    /// <summary>
    /// 節點類別
    /// </summary>
    class Node
    {
        public int val;
        public Node next;
        public Node(int val)
        {
            this.val = val;
            this.next = null;
        }
    }
}
