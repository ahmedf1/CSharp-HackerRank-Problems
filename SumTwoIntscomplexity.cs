/*
 *
Problem Description

Given a series of integer pairs A and B, output the sum of A and B.

Input Format

Each line contains two integers, A and B. One input file may contain several pairs P where 0≤P≤12.

Output Format

Output a single integer per line - The sum of A and B.

Constraints

0≤A,B≤10^98
 * 
 * 
*/


using System;
using System.Text;
class Solution
{
    static void Main()
    {
        string ints = Console.ReadLine();
        while (!string.IsNullOrEmpty(ints))
        {
            string[] ints2 = ints.Split(" ");
            StringBuilder output = new StringBuilder();
            int carry = 0;
            // need to do the math manually and then convert back to a string
            for (int i = ints2[0].Length - 1, j = ints2[1].Length - 1; i >= 0 || j >= 0; i--, j--)
            {
                int digit1 = i >= 0 ? Convert.ToInt16(ints2[0][i]) - '0' : 0;
                int digit2 = j >= 0 ? Convert.ToInt16(ints2[1][j]) - '0' : 0;
                int sum = digit1 + digit2 + carry;
                output.Insert(0, (sum % 10).ToString());
                carry = sum / 10;

            }
            Console.WriteLine(output.ToString());
            ints = Console.ReadLine();
        }


    }

}