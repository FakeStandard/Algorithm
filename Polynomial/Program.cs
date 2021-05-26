using System;
using static System.Console;
using System.Collections;

namespace Polynomial
{
    /// <summary>
    /// 使用兩種方法將兩個多項式相加
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 第一種方法
            WriteLine("========== Method One ==========\n");
            MethodOne();

            WriteLine();

            // 第二種方法
            WriteLine("========== Method Two ==========\n");
            MethodTwo();

            ReadLine();
        }

        /// <summary>
        /// 方法一
        /// </summary>
        static void MethodOne()
        {
            // 建立多項式
            int[] PolyA = new int[] { 4, 3, 7, 0, 6, 2 };
            int[] PolyB = new int[] { 4, 1, 5, 2, 0, 9 };

            PrintPoly(ref PolyA, ref PolyB, 1);

            int len = PolyA[0] + 1;
            int i;
            int[] result = new int[PolyA.Length];

            result[0] = PolyA[0];

            // 係數相加
            for (i = 1; i <= len; i++)
                result[i] = PolyA[i] + PolyB[i];

            Write(" 多項式(A+B) => ");
            PrintSub(ref result);
        }

        /// <summary>
        /// 方法二
        /// </summary>
        static void MethodTwo()
        {
            // 建立多項式
            int[] PolyA = new int[] { 4, 3, 4, 7, 3, 6, 1, 2, 0 };
            int[] PolyB = new int[] { 4, 1, 4, 5, 3, 2, 2, 9, 0 };

            PrintPoly(ref PolyA, ref PolyB, 2);

            int i = 1, j = 1;
            int len = PolyA.Length;

            ArrayList arr = new ArrayList();

            while (true)
            {
                // 如果係數相同
                if (PolyA[i + 1] == PolyB[j + 1])
                {
                    arr.Add(PolyA[i] + PolyB[j]);
                    arr.Add(PolyA[i + 1]);

                    i += 2;
                    j += 2;
                }
                else if (PolyA[i + 1] > PolyB[j + 1])
                {
                    arr.Add(PolyA[i]);
                    arr.Add(PolyA[i + 1]);

                    i += 2;
                }
                else
                {
                    arr.Add(PolyB[j]);
                    arr.Add(PolyB[j + 1]);

                    j += 2;
                }

                if ((i == len) && (j == len))
                    break;
            }

            int[] result = new int[arr.Count + 1];
            result[0] = arr.Count / 2;

            for (int k = 1; k < result.Length; k++)
                result[k] = (int)arr[k - 1];

            Write(" 多項式(A+B) => ");
            PrintSubTwo(ref result);
        }

        /// <summary>
        /// 輸出多項式
        /// </summary>
        static void PrintPoly(ref int[] polyA, ref int[] polyB, int num)
        {
            if (num == 1)
            {
                Write(" 多項式(A) => ");
                PrintSub(ref polyA);
                Write(" 多項式(B) => ");
                PrintSub(ref polyB);
            }
            else
            {
                Write(" 多項式(A) => ");
                PrintSubTwo(ref polyA);
                Write(" 多項式(B) => ");
                PrintSubTwo(ref polyB);
            }
        }

        /// <summary>
        /// (方法一)輸出副程式
        /// </summary>
        static void PrintSub(ref int[] poly)
        {
            int i;
            int len = poly[0] + 1; // 指數項目個數
            int exp = poly[0]; // 表示當前係數

            for (i = 1; i <= len; i++)
            {
                // 如果項目等於零就跳過
                if (poly[i] != 0)
                {
                    if (exp == 0)
                        Write($"{poly[i]}");
                    else if (exp == 1)
                        Write($"{poly[i]}x");
                    else
                        Write($"{poly[i]}x^{exp}");

                    if (exp > 0)
                        Write("+");
                }

                exp--;
            }

            WriteLine();
        }

        /// <summary>
        /// (方法二)輸出副程式
        /// </summary>
        /// <param name="poly"></param>
        static void PrintSubTwo(ref int[] poly)
        {
            int i;
            int len = poly.Length;

            // 先係數, 後指數
            for (i = 1; i < len; i = i + 2)
            {
                if (poly[i + 1] == 0)
                    Write($"{poly[i]}");
                else if (poly[i + 1] == 1)
                    Write($"{poly[i]}x");
                else
                    Write($"{poly[i]}x^{poly[i + 1]}");

                if (i != len - 2)
                    Write("+");
            }

            WriteLine();
        }
    }
}
