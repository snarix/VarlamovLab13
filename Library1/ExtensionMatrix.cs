using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public static class ExtensionMatrix
    {
        public static void CreateArray(this Matrix<int> matrix, int min = 1, int max = 10)
        {
            Random rnd = new Random();

            for (int i = 0; i < matrix.CountRow; i++)
            {
                for (int j = 0; j < matrix.CountColumn; j++)
                {
                    matrix[i, j] = rnd.Next(min, max);
                }
            }
        }

        public static int ArrayDifference(this Matrix<int> matrix)
        {
            int max = 0, kol = 0;
            int[] mas = new int[matrix.CountColumn];
            for (int i = 0; i < matrix.CountRow; i++)
            {
                for (int j = 0; j < matrix.CountColumn; j++)
                {
                    mas[j] = matrix[i,j];
                }
                kol++;
                var result = mas.Distinct();
                max = mas.Length - result.Count();
                if ()
                {
                    max = kol;
                }
            }
            
            return max;
        }

    }
}
