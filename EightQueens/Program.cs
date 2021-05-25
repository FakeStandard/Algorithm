using System;
using static System.Console;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            number = 0;
            DecidePosition(0);
            ReadKey();

            Console.ReadLine();
        }

        static int TRUE = 1, FALSE = 0, EIGHT = 8;
        // 存放八個皇后的列位置
        static int[] queen = new int[EIGHT];
        // 計算共有幾組解答
        static int number = 0;

        /// <summary>
        /// 按下 Enter 鍵要執行方法
        /// </summary>
        public static void PressEnter()
        {
            char ch;
            Write("\n\n");
            Write("按下 Enter 鍵繼續...");
            ch = (char)Read();
        }

        /// <summary>
        /// 決定皇后存放的位置
        /// </summary>
        /// <param name="value"></param>
        public static void DecidePosition(int value)
        {
            int i = 0;
            while (i < EIGHT)
            {
                // 判斷是否遭受攻擊
                if (Attack(i, value) != 1)
                {
                    queen[value] = i;

                    if (value == 7)
                        PrintChessBoard();
                    else
                        DecidePosition(value + 1);
                }

                i++;
            }
        }

        /// <summary>
        /// 攻擊測試，若皇后遭受攻擊則返回值為 1，反之
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static int Attack(int row, int col)
        {
            int i = 0, atk = FALSE;
            int offsetRow = 0, offsetCol = 0;

            while ((atk != 1) && i < col)
            {
                offsetCol = Math.Abs(i - col);
                offsetRow = Math.Abs(queen[i] - row);

                // 判斷兩皇后是否在同一列或同一對角線
                if ((queen[i] == row) || (offsetRow == offsetCol))
                    atk = TRUE;
                i++;
            }

            return atk;
        }

        /// <summary>
        /// 輸出棋盤結果
        /// </summary>
        public static void PrintChessBoard()
        {
            number += 1;
            WriteLine();
            Write($"八皇后問題之第 {number} 組解\n\t");

            for (int i = 0; i < EIGHT; i++)
            {
                for (int j = 0; j < EIGHT; j++)
                    if (i == queen[j])
                        Write("[*]");
                    else
                        Write("[ ]");

                Write("\n\t");
            }

            PressEnter();
        }
    }
}
