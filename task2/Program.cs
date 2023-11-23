using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace task2
{
    class Program
    {
        public static List<int> Traversal(int n, int m, int[,] arr)
        {
            int i = 0, j = 0;
            int[,] borders = new int[2, 2] { { 0, n - 1 }, // строки
                                            { 0, m - 1 } }; // столбцы
            int dir = 0; // 0 - down, 1 - right, 2 - up, 3 - left
            var res = new List<int>();
            for (int k = 0; k < n * m; ++k)
            {
                res.Add(arr[i, j]);
                switch (dir)
                {
                    case 0: //down
                        {
                            if (i < borders[0, 1])
                            {
                                ++i;
                            }
                            else if (i == borders[0, 1])
                            {
                                ++borders[1, 0];
                                if (j < borders[1, 1])
                                    ++j;

                                dir = 1;
                            }
                            break;
                        }
                    case 1: //right
                        {
                            if (j < borders[1, 1])
                            {
                                ++j;
                            }
                            else if (j == borders[1, 1])
                            {
                                --borders[0, 1];
                                if (i > borders[0, 0])
                                    --i;
                                dir = 2;
                            }
                            break;
                        }
                    case 2: // up
                        {
                            if (i > borders[0, 0])
                            {
                                --i;
                            }
                            else if (i == borders[0, 0])
                            {
                                --borders[1, 1];
                                if (j > borders[1, 0])
                                    --j;
                                dir = 3;
                            }
                            break;
                        }
                    case 3: //left
                        {
                            if (j > borders[1, 0])
                            {
                                --j;
                            }
                            else if (j == borders[1, 0])
                            {
                                ++borders[0, 0];
                                if (i < borders[0, 1])
                                    ++i;
                                dir = 0;
                            }
                            break;
                        }
                }
            }

            return res;
        }
        static void Main(string[] args)
        {
            Console.Write("Строк: ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("Столбцов: ");
            var m = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, m];
            Random r = new Random();
            var counter = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    //arr[i, j] = r.Next(0, n*m);
                    arr[i, j] = ++counter;
                }
            }
            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                    Console.Write(string.Format("{0, 3}", arr[i, j]));
                Console.WriteLine();
            }
            //for (int i = 0; i < n; ++i)
            //{
            //    string[] inputString = Console.ReadLine().Split();
            //    for (int j = 0; j < m; ++j)
            //        arr[i, j] = int.Parse(inputString[j]);
            //}

            //var n = 3;
            //var m = 3;
            //var arr = new int[n, m] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            //var n = 3;
            //var m = 4;
            //var arr = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };


            Console.WriteLine("Результат:");
            foreach (var item in Traversal(n, m, arr))
                Console.Write($"{item} ");
        }
    }
}