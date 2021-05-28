using System;
using static System.Console;

namespace BinaryTreeInsert
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

            while (true)
            {
                Write("\n請輸入欲插入的值: ");
                int num = int.Parse(Console.ReadLine());

                if (num == -1)
                    return;

                // 先搜尋
                bool result = btree.FindNode(btree.root, num);

                if (result)
                    WriteLine($"二元樹中已經存在 {num} 此節點！");
                else
                {
                    btree.AddNode(num);
                    WriteLine($"新增節點 {num} 成功！");

                    // 進行走訪
                    Write("\n前序走訪: ");
                    btree.PreOrder(btree.root);
                }
            }
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

        private int count = 0;

        /// <summary>
        /// 搜尋方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool FindNode(TreeNode node, int value)
        {
            // 一顆空蕩蕩的樹
            if (node == null)
                return false;

            if (node.data == value)
            {
                count++;
                WriteLine($"共搜尋 {count} 次");
                count = 0;
                return true;
            }
            else if (value > node.data)
            {
                count++;
                return FindNode(node.right, value);
            }
            else
            {
                count++;
                return FindNode(node.left, value);
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
