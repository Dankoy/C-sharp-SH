using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = new int[5, 5];
            int[,] matrix2 = new int[5, 5];
            int[,] matrixC = new int[5, 5];

            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix1[i, j] = rand.Next(1, 15);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix2[i, j] = rand.Next(1, 15);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrixC[i, j] = matrix1[i, j] * matrix2[i, j];
                    Console.Write("{0}\t", matrixC[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
