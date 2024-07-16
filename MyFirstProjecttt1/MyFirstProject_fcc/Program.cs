using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace MyFirstProject_fcc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1,2,3,4,5};
            int res = sumofarray(arr);
            if (res != -1)
            {
                Console.WriteLine($"Sum of elements is {res}");
            }
            else
            {
                   Console.WriteLine("Array is empty");
            }

        }
        public static int sumofarray(params int[] arr)
        {
            int sum = 0;
            if (arr.Length == 0) { sum = -1; }
            else
            {
                foreach (int i in arr)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
