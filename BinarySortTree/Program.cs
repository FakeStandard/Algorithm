using System;
using static System.Console;

namespace BinarySortTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // 原始資料
            int[] data = { 12, 46, 10, 23, 11, 30, 7, 21 };

            Write("原始資料: ");
            for (int i = 0; i < data.Length; i++)
                Write($"[{data[i]}] ");
            WriteLine();

            // 建立二元樹
            BinaryTree btree = new BinaryTree(data);

            Write("排序後資料: ");
            // 走訪
            btree.PreOrder(btree.root);

            ReadLine();
        }
    }

    /// <summary>
    /// 樹節點類別
    /// </summary>
    class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int value)
        {
            this.data = value;
            this.left = null;
            this.right = null;
        }
    }

    /// <summary>
    /// 二元樹類別
    /// </summary>
    class BinaryTree
    {
        public TreeNode root;

        public BinaryTree(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                AddNode(array[i]);
        }

        /// <summary>
        /// 新增節點
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return;
            }

            TreeNode current = root;

            while (true)
            {
                if (value > current.data)
                {
                    if (current.right == null)
                    {
                        current.right = new TreeNode(value);
                        return;
                    }
                    else
                        current = current.right;
                }
                else
                {
                    if (current.left == null)
                    {
                        current.left = new TreeNode(value);
                        return;
                    }
                    else
                        current = current.left;
                }
            }
        }

        /// <summary>
        /// 前序走訪
        /// </summary>
        /// <param name="node"></param>
        public void PreOrder(TreeNode node)
        {
            if (node != null)
            {
                Write($"[{node.data}] "); // 輸出根節點
                PreOrder(node.left); // 往左子樹
                PreOrder(node.right); // 往右子樹
            }
        }
    }
}
