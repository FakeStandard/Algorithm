using System;

namespace BreadthFirstSearch
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
            Bfs(1);

            Console.ReadLine();
        }

        // 建立走訪旗標
        static int[] flag = new int[6];

        // 建立頂點集合
        static GraphLink[] head = new GraphLink[6];

        /// <summary>
        /// 廣度優先走訪方法
        /// </summary>
        /// <param name="current"></param>
        static void Bfs(int current)
        {
            Node tempNode;

            // 添加頂點到佇列中
            Enqueue(current);

            // 標示節點已走訪
            flag[current] = 1;

            Console.Write($"[{current}] ");

            // 判斷是否為空佇列
            while (front != rear)
            {
                // 將頂點從佇列中取出
                current = Dequeue();

                // 紀錄頂點目前位置
                tempNode = head[current].first;

                while (tempNode != null)
                {
                    if (flag[tempNode.val] == 0)
                    {
                        Enqueue(tempNode.val);

                        // 標示成已走訪
                        flag[tempNode.val] = 1;

                        Console.Write($"[{tempNode.val}] ");
                    }

                    tempNode = tempNode.next;
                }
            }
        }

        // 建立佇列陣列
        static int[] queue = new int[6];

        // 佇列頂端指標
        static int front = -1;

        // 佇列末端指標
        static int rear = -1;

        /// <summary>
        /// 佇列存入資料
        /// </summary>
        /// <param name="val"></param>
        static void Enqueue(int val)
        {
            if (rear >= 6) return;
            rear++;

            queue[rear] = val;
        }

        /// <summary>
        /// 取出佇列資料
        /// </summary>
        static int Dequeue()
        {
            if (front == rear) return -1;
            front++;

            return queue[front];
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
