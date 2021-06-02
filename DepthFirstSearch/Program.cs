using System;

namespace DepthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // 宣告圖形邊的陣列
            int[,] data = { { 1, 2 }, { 2, 1 }, { 1, 3 }, { 3, 1 }, { 1, 4 }, { 4, 1 }, { 1, 5 }, { 5, 1 }, { 2, 4 }, { 4, 2 }, { 2, 5 }, { 5, 2 }, { 3, 5 }, { 5, 3 } };

            int i, j, num;

            // 共有 5 個頂點
            for (i = 1; i < 6; i++)
            {
                // 設置所有頂點尚未走訪
                flag[i] = 0;

                // 為所有頂點建立串列
                head[i] = new GraphLink();

                Console.Write($"頂點{i} =>");

                // 走訪所有邊
                for (j = 0; j < data.GetLength(0); j++)
                {
                    // 找到與頂點相同的起點邊
                    if (data[j, 0] == i)
                    {
                        num = data[j, 1];
                        head[i].Insert(num);
                    }
                }

                head[i].Print();
            }

            Console.WriteLine("\n深度優先走訪順序:");
            Dfs(1);

            Console.ReadLine();
        }

        // 建立走訪旗標
        static int[] flag = new int[6];

        // 建立頂點集合
        static GraphLink[] head = new GraphLink[6];

        /// <summary>
        /// 深度優先走訪方法
        /// </summary>
        /// <param name="current"></param>
        static void Dfs(int current)
        {
            // 標示成已走訪
            flag[current] = 1;

            Console.WriteLine($"[{current}] ");

            while (head[current].first != null)
            {
                // 如果頂點未走訪, 則遞迴走訪
                if (flag[head[current].first.val] == 0)
                    Dfs(head[current].first.val);

                head[current].first = head[current].first.next;
            }
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

    /// <summary>
    /// 圖的鏈結串列類別
    /// </summary>
    class GraphLink
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
                Console.Write($"[{current.val}] ");
                current = current.next;
            }

            Console.WriteLine();
        }

        public void Insert(int val)
        {
            Node newNode = new Node(val);

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
    }
}
