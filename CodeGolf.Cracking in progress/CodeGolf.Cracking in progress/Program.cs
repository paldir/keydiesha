//http://codegolf.stackexchange.com/questions/100679/cracking-in-progress/100717

using System;
using System.Diagnostics;
using System.IO;

namespace CodeGolf.Cracking_in_progress
{
    public class Program
    {
        private static void Main()
        {
            F("abcde");
        }

        private static void F(string s)
        {
            int l = s.Length, t = 0;
            var w = new Stopwatch();

            w.Start();

            do
            {
                if (w.Elapsed.Seconds > t)
                    t++;

                Console.WriteLine($"{s.Substring(0, t)}{Path.GetRandomFileName().Substring(0, l - t)}");
            } while (t < l);
        }
    }
}