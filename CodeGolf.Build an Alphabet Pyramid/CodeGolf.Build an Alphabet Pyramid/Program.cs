//http://codegolf.stackexchange.com/questions/100773/build-an-alphabet-pyramid

using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGolf.Build_an_Alphabet_Pyramid
{
    public class Program
    {
        private static void Main()
        {
            foreach (string s in F(5))
                Console.WriteLine(s);

            Console.ReadKey();
        }

        private static List<string> F(int n)
        {
            int i = 0;
            var l = new List<string>();

            for (; i < n; i++)
            {
                var h = "";

                for (var c = 'A'; c < 'B' + i; c++)
                    h += " " + c;

                l.Add(new string(' ', (n - i + 1)*2) + h + " " + string.Concat(h.Remove(i*2).Reverse()));
            }

            for (i -= 2; i >= 0; i--)
                l.Add(l[i]);

            return l;
        }

        private static string[] Kaspar_Kjeldsen(int n)
        {
            int i = 0;
            var q = 2*n - 1;
            var l = new string[q];
            for (; i < n; i++)
            {
                var h = "";
                for (var c = 'A'; c < 'B' + i; c++) h += " " + c;
                l[q - i - 1] = l[i] = new string(' ', (n - i + 1)*2) + h + " " + string.Concat(h.Remove(i*2).Reverse());
            }
            return l;
        }
    }
}