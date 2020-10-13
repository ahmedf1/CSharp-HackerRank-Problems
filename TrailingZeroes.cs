/*
Mr. Yash asks all the great programmers of the world to solve a trivial problem. He gives them an integer m and asks for the number of positive integers n, such that the factorial of n ends with exactly m zeroes. Are you among those great programmers who can solve this problem?

Input First line of input contains an integer T number of test cases. Each test case contains an integer M (1 ≤ M ≤ 100,000) — the required number of trailing zeroes in factorial.

Output First print k — the number of values of n such that the factorial of n ends with m zeroes. Then print these k integers in increasing order.
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class TrailingZeroes
{
    /// <summary>
    /// 1. determine the number of trailing zeros
    /// 2. for factorials, any number that has a 10 in its multiplication will have 1 trailing zero
    /// 3. a second trailing zero does not appear until a second 10 appears in the multiplication
    /// 4. however, we do not have to wait for 10's since, a 5 and 2 as factors make up a 10 in the multiplication
    /// 5. so finding the number of 2 and 5's present will give number of trailing 0's
    /// 6. since 2 will exist if 5 does, we can just search for 5's
    /// 7. dividing by 5 will give the number of 5's present AKA the number of trailing 0s 
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int numZeroes(int n)
    {
        int k = 0;
        while (n > 0)
        {
            k = k + (n / 5);
            n = (n / 5);
        }
        return k;
    }

    static void Main()
    {
        Console.WriteLine("Enter number of Test Cases: ");
        int numOfTestCases = Convert.ToInt16(Console.ReadLine());

        for (int i = 0; i < numOfTestCases; i++)
        {
            List<long> results = new List<long>();
            Console.WriteLine("Enter number of trailing 0's to search for: ");
            long numZero = Convert.ToInt64(Console.ReadLine());
            int count = 0;
            for (int j = 1; ; j++)
            {
                if (numZeroes(j) > numZero)
                {
                    break; // stop looping
                }
                else if (numZeroes(j) == numZero)
                {
                    count++;
                    results.Add(j);
                }
            }
            Console.WriteLine(count);
            foreach (long L in results)
            {
                Console.Write(L + " ");
            }
            Console.Write("\n");
        }
    }
}


//
