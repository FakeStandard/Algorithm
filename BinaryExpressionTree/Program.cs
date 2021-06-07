using System;

namespace BinaryExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] info1 = { ' ', '+', '*', '%', '6', '3', '9', '5' };
            char[] info2 = { ' ', '+', '+', '+', '*', '%', '/', '*', '1', '2', '3', '2', '6', '3', '2', '2' };

            ExpressionTree exp1 = new ExpressionTree(info1, 1);


            Console.WriteLine("=====二元運算樹 Ex1=====");

            Console.Write("前序運算式：");
            exp1.PreOrder(exp1.root);

            Console.Write("\n中序運算式：");
            exp1.InOrder(exp1.root);

            Console.Write("\n後序運算式：");
            exp1.PostOrder(exp1.root);

            ExpressionTree exp2 = new ExpressionTree(info2, 1);

            Console.WriteLine("\n=====二元運算樹 Ex2=====");

            Console.Write("前序運算式：");
            exp2.PreOrder(exp2.root);

            Console.Write("\n中序運算式：");
            exp2.InOrder(exp2.root);

            Console.Write("\n後序運算式：");
            exp2.PostOrder(exp2.root);

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 節點類別
    /// </summary>
    class TreeNode
    {
        public int val;
        public TreeNode leftNode;
        public TreeNode rightNode;
        public TreeNode(int val)
        {
            this.val = val;
            this.leftNode = null;
            this.rightNode = null;
        }
    }

    /// <summary>
    /// 二元搜尋樹類別
    /// </summary>
    class BinarySearchTree
    {
        public TreeNode root;
        public BinarySearchTree()
        {
            root = null;
        }

        public BinarySearchTree(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
                AddNode(data[i]);
        }

        public void AddNode(int val)
        {
            TreeNode newNode = new TreeNode(val);

            if (root == null)
            {
                root = newNode;
                return;
            }

            while (true)
            {
                if (val < root.val)
                {
                    if (root.leftNode == null)
                    {
                        root.leftNode = newNode;
                        return;
                    }
                    else
                    {
                        root = root.leftNode;
                    }
                }
                else
                {
                    if (root.rightNode == null)
                    {
                        root.rightNode = newNode;
                        return;
                    }
                    else
                    {
                        root = root.rightNode;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 二元運算樹類別
    /// </summary>
    class ExpressionTree : BinarySearchTree
    {
        public ExpressionTree(char[] information, int index)
        {
            root = Create(information, index);
        }

        public TreeNode Create(char[] sequence, int index)
        {
            TreeNode tempNode;

            if (index >= sequence.Length)
                return null;
            else
            {
                tempNode = new TreeNode((int)sequence[index]);

                // 建立左子樹
                tempNode.leftNode = Create(sequence, 2 * index);

                // 建立右子樹
                tempNode.rightNode = Create(sequence, 2 * index + 1);

                return tempNode;
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
                Console.Write($"{(char)node.val} ");
                PreOrder(node.leftNode);
                PreOrder(node.rightNode);
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
                InOrder(node.leftNode);
                Console.Write($"{(char)node.val} ");
                InOrder(node.rightNode);
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
                PostOrder(node.leftNode);
                PostOrder(node.rightNode);
                Console.Write($"{(char)node.val} ");
            }
        }

        public int Condition(char oprator, int num1, int num2)
        {
            switch (oprator)
            {
                case '*':
                    return (num1 * num2);
                case '/':
                    return (num1 / num2);
                case '+':
                    return (num1 + num2);
                case '-':
                    return (num1 - num2);
                case '%':
                    return (num1 % num2);

            }

            return -1;
        }

        public int Answer(TreeNode node)
        {
            int firstNum = 0;
            int secondNum = 0;

            if (node.leftNode == null && node.rightNode == null)
                return Convert.ToInt32((char)node.val) - 48;
            else
            {
                firstNum = Answer(node.leftNode);
                secondNum = Answer(node.rightNode);

                return Condition((char)node.val, firstNum, secondNum);
            }
        }
    }
}
