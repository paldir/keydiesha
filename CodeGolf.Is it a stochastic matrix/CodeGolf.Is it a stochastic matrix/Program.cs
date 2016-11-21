//http://codegolf.stackexchange.com/questions/100277/is-it-a-stochastic-matrix/100289

using System;

namespace CodeGolf.Is_it_a_stochastic_matrix
{
    public class Program
    {
        private static void Main()
        {
            //int[,] matrix = {{100}};
            //int[,] matrix = {{42}};
            //int[,] matrix = {{100, 0}, {0, 100}};
            int[,] matrix = { { 4, 8, 15 }, { 16, 23, 42 }, { 80, 69, 43 } };
            //int[,] matrix = {{99,1}, {2,98} };
            //int[,] matrix = {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16}};

            Console.WriteLine(F(matrix));
            Console.ReadKey();
        }

        private static int F(int[,] m)
        {
            int x, i, j, r, c, e, w;
            x = m.GetLength(0);
            e = w = 1;

            for (i = 0; i < x; i++)
            {
                r = c = 0;

                for (j = 0; j < x; j++)
                {
                    r += m[i, j];
                    c += m[j, i];
                }

                if (r != 100)
                    e = 0;

                if (c != 100)
                    w = 0;
            }

            return e == 1 && w == 1 ? 3 : e == 1 ? 1 : w == 1 ? 2 : 4;
        }
    }
}