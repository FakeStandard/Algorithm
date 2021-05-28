using System;
using static System.Console;

namespace BinaryTreeTraversal
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

            // 建立二元樹
            BinaryTree btree = new BinaryTree(data);

            // 進行走訪
            Write("\n前序走訪: ");
            btree.PreOrder(btree.root);

            Write("\n中序走訪: ");
            btree.InOrder(btree.root);

            Write("\n後序走訪: ");
            btree.PostOrder(btree.root);

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

        /// <summary>
        /// 中序走訪
        /// </summary>
        /// <param name="node"></param>
        public void InOrder(TreeNode node)
        {
            if (node != null)
            {
                InOrder(node.left); // 往左子樹
                Write($"[{node.data}] "); // 輸出根節點
                InOrder(node.right); // 往右子樹
            }
        }

        /// <summary>
        /// 後序走訪
        /// </summary>
        /// <param name="node"></param>
        public void PostOrder(TreeNode node)
        {
            if (node != null)
            {
                PostOrder(node.left); // 往左子樹
                PostOrder(node.right); // 往右子樹
                Write($"[{node.data}] "); // 輸出根節點
            }
        }
    }
}
