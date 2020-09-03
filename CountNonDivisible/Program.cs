using System;

namespace CountNonDivisible
{
    class Program
    {
        public class CountNonDivisible
        {
            static void Main(string[] args)
            {
                int[] A = { 3, 1, 2, 3, 6 };
                Console.WriteLine(solution(A));
            }

            public static string solution(int[] A)
            {
                int max = MaximumElement(A);//get max element in array
                int[] count = ElementCount(A, max);//get count of each element in array
                int length = A.Length;

                int[] res = new int[length]; //array that stores all counts of non divisors

                for (int i = 0; i < length; i++)
                {
                    int allCounts = length;
                    int j;
                    for (j = 1; j < Math.Sqrt(A[i]); j++)
                    {
                        if (A[i] % j != 0) continue; //ignore if there is no divisor
                        else
                        {
                            allCounts = allCounts - count[j];//subtract divisor count
                            allCounts = allCounts - count[A[i] / j];//subtract quotient count
                        }

                    }
                    if (j == Math.Sqrt(A[i])) //if perfect square subtract 
                        allCounts = allCounts - count[j];
                    res[i] = allCounts;//store non divisor count
                }
                var result = String.Join(",", res);
                return result;
            }
            //get max element
            public static int MaximumElement(int[] A)
            {
                int max = A[0];
                for (int i = 1; i < A.Length; i++)
                {
                    if (A[i] > max) max = A[i];
                }
                return max;
            }
            //get count of all elements
            public static int[] ElementCount(int[] A, int max)
            {
                int[] totalcount = new int[max + 1];
                for (int i = 0; i < A.Length; i++)
                {
                    totalcount[A[i]]++;
                }
                return totalcount;
            }
        }
    }
}

