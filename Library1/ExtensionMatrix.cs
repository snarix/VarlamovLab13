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
        //фффффффф
        public static int FindNumberMaxIdentity(this Matrix<int> matrix)
        {
            int[] maxIdentitys = new int[matrix.CountColumn + 1];
            Dictionary<int, int> identitys = new Dictionary<int, int>();

            for (int j = 0; j < matrix.CountRow; j++)
            {
                for (int i = 0; i < matrix.CountColumn; i++)
                {
                    if (!identitys.ContainsKey(matrix[j, i]))
                    {
                        identitys.Add(matrix[j, i], 0);
                    }

                    identitys[matrix[j, i]]++;
                }

                maxIdentitys[j] = identitys.Values.Max();
                identitys.Clear();
            }

            int index = Array.FindLastIndex(maxIdentitys, el => el == maxIdentitys.Max());

            return index + 1;

        }
        
    }
}
