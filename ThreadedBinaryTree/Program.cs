using System;

namespace ThreadedBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data1 = { 0, 10, 20, 30, 100, 399, 453, 43, 237, 373, 655 };
            ThreadedBinaryTree tree1 = new ThreadedBinaryTree(data1);
            tree1.InOrder();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 引線二元樹節點類別
    /// </summary>
    public class ThreadNode
    {
        public int data;
        public int lbit;
        public int rbit;
        public ThreadNode leftNode;
        public ThreadNode rightNode;

        public ThreadNode(int data)
        {
            this.data = data;
            this.lbit = 0;
            this.rbit = 0;
            this.leftNode = null;
            this.rightNode = null;
        }
    }

    /// <summary>
    /// 引線二元樹類別
    /// </summary>
    public class ThreadedBinaryTree
    {
        public ThreadNode root;
        public ThreadedBinaryTree()
        {
            root = null;
        }

        public ThreadedBinaryTree(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
                AddNode(data[i]);
        }

        /// <summary>
        /// 將指定值加入引線二元樹
        /// </summary>
        /// <param name="val"></param>
        public void AddNode(int val)
        {
            ThreadNode newNode = new ThreadNode(val);

            if (root == null)
            {
                root = newNode;
                root.leftNode = root;
                root.rightNode = null;
                root.lbit = 0;
                root.rbit = 1;

                return;
            }

            ThreadNode current = root.rightNode;
            ThreadNode parent;
            ThreadNode previous = new ThreadNode(val);

            if (current == null)
            {
                root.rightNode = newNode;
                newNode.leftNode = root;
                newNode.rightNode = root;

                return;
            }

            parent = root;
            int pos = 0;

            while (current != null)
            {
                if (current.data > val)
                {
                    if (pos != 1)
                    {
                        pos = -1;
                        previous = parent;
                    }

                    parent = current;

                    if (current.lbit == 1)
                        current = current.leftNode;
                    else
                        current = null;
                }
                else
                {
                    if (pos != 1)
                    {
                        pos = 1;
                        previous = parent;
                    }

                    parent = current;

                    if (current.rbit == 1)
                        current = current.rightNode;
                    else
                        current = null;
                }
            }

            if (parent.data > val)
            {
                parent.lbit = 1;
                parent.leftNode = newNode;
                newNode.leftNode = previous;
                newNode.rightNode = parent;
            }
            else
            {
                parent.rbit = 1;
                parent.rightNode = newNode;
                newNode.leftNode = parent;
                newNode.rightNode = previous;
            }

            return;
        }

        public void InOrder()
        {
            ThreadNode tempNode = root;

            do
            {
                if (tempNode.rbit == 0)
                    tempNode = tempNode.rightNode;
                else
                {
                    tempNode = tempNode.rightNode;
                    while (tempNode.lbit != 0)
                        tempNode = tempNode.leftNode;
                }

                if (tempNode != root)
                    Console.WriteLine($"[{tempNode.data}]");
            } while (tempNode != root);
        }
    }
}
