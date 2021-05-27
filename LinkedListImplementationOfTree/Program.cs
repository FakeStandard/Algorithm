using System;
using static System.Console;

namespace LinkedListImplementationOfTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // 原始陣列
            int[] data = { 12, 46, 10, 23, 11, 30, 7, 21 };

            // 建立二元樹
            BinaryTree btree = new BinaryTree(data);

            WriteLine("完成以串列方式建立二元樹！");

            ReadLine();
        }
    }

    /// <summary>
    /// 樹節點類別
    /// </summary>
    class TreeNode
    {
        // 值
        public int data;
        // 左子樹
        public TreeNode leftNode;
        // 右子樹
        public TreeNode rightNode;

        public TreeNode(int value)
        {
            this.data = value;
            leftNode = null;
            rightNode = null;
        }
    }

    /// <summary>
    /// 以串列實作二元樹類別
    /// </summary>
    class BinaryTree
    {
        // 樹根
        public TreeNode rootNode;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="array"></param>
        public BinaryTree(int[] array)
        {
            // 迭代新增
            for (int i = 0; i < array.Length; i++)
                AddNode(array[i]);
        }

        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(int value)
        {
            TreeNode currentNode = rootNode;

            // 若樹根為空
            if (rootNode == null)
            {
                rootNode = new TreeNode(value);
                WriteLine($"添加樹根: {value}");
                return;
            }

            // 若有樹根, 則開始添加結點
            while (true)
            {
                // 若資料大於節點, 往右子樹
                if (value > currentNode.data)
                {
                    // 若右子樹為空, 則添加到此節點
                    if (currentNode.rightNode == null)
                    {
                        currentNode.rightNode = new TreeNode(value);
                        WriteLine($"添加右子樹節點: {value}");
                        return;
                    }
                    else // 否則繼續找
                        currentNode = currentNode.rightNode;

                }
                else // 否則往左子樹
                {
                    if (currentNode.leftNode == null)
                    {
                        currentNode.leftNode = new TreeNode(value);
                        WriteLine($"添加左子樹節點: {value}");
                        return;
                    }
                    else
                        currentNode = currentNode.leftNode;
                }
            }
        }
    }
}
