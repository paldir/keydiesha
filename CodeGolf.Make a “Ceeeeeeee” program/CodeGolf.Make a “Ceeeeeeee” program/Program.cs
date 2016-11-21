//http://codegolf.stackexchange.com/questions/100486/make-a-ceeeeeeee-program

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeGolf.Make_a__Ceeeeeeee__program
{
    public class Program
    {
        private static void Main()
        {
            var linie = F("codegolf.stackexchange.com", 'e').Cast<object>().ToArray();

            foreach (var linia in linie)
                Console.WriteLine(linia);

            Console.ReadKey();
        }

        private static IEnumerable<string> F(string s, char c)
        {
            int i = 1;

            for (;;)
            {
                yield return s;

                while (i < s.Length && s[i] == c)
                    i++;

                if (i == s.Length)
                    break;

                s = s.Remove(i, 1);
            }
        }

        private static IEnumerable Psycho(string s, char c)
        {
            for (int i = 1;;)
            {
                yield return s;
                while (s[i] == c)
                {
                    if (++i == s.Length)
                        yield break;
                }
                s = s.Remove(i, 1);
            }
        }
    }
}