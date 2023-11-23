using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1
{
    class Program
    {
        public static string Compress(string inputString)
        {
            StringBuilder res = new StringBuilder();
            int count = 0;
            char prevS = inputString[0];
            for (int i = 0; i< inputString.Length; ++i)
            {
                if (prevS == inputString[i])
                {
                    ++count;
                }
                else
                {
                    if (count == 1)
                        res.Append(prevS);
                    else
                    {
                        res.Append(prevS);
                        res.Append(count.ToString());
                    }
                    prevS = inputString[i];
                    count = 1;
                }
            }
            res.Append(prevS);
            if (count > 1)
                res.Append(count);


            return res.ToString();
        }
        public static string Decompress(string compressString)
        {
            StringBuilder res = new StringBuilder();
            char symbol;
            int count;
            int i = 0;
            while (i < compressString.Length)
            {
                symbol = compressString[i++];
                if (i < compressString.Length)
                {
                    var countStr = new StringBuilder();
                    while (i < compressString.Length && Char.IsDigit(compressString[i]))
                    {
                        countStr.Insert(0, compressString[i++]);
                    }
                    count = (countStr.Length > 0) ? int.Parse(countStr.ToString()) : 1;

                    for (int k = 0; k < count; ++k)
                        res.Append(symbol);
                }
                else
                    res.Append(symbol);
            }

            return res.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Compress:");
            Console.WriteLine(Compress("aaabbcccdde"));
            Console.WriteLine(Compress("aaabbce"));
            Console.WriteLine(Compress("abcdeee"));
            Console.WriteLine(Compress("abcdeeffffffffffffffe"));
            Console.WriteLine(Compress("a"));
            Console.WriteLine();
            Console.WriteLine("Decompress:");
            Console.WriteLine(Decompress("a3b2c3d2e"));
            Console.WriteLine(Decompress("a3b2ce"));
            Console.WriteLine(Decompress("abcde3"));
            Console.WriteLine(Decompress("abcde2f14e"));
            Console.WriteLine(Decompress("a"));

        }
    }
}