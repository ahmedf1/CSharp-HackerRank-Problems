using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

class Solution
{
    static int minAmp(int[] A, int K)
    {
        int amp = 99999999;
        // collect indices of continuous K elements
        for (int i = 0; i < A.Length - 1; i++)
        {
            int count = 0;
            string indices = "";
            for (int j = i; j < i + K && j < A.Length; j++)
            {
                if (count < K)
                {
                    indices += j;
                    count++;
                }

            }
            int max = -999999999;
            int min = 999999999;
            // get the rest of the array that does not include the K elements
            for (int j = 0; j < A.Length; j++){
                
                if (indices.Contains(j.ToString()))
                {
                    continue;
                }
                else
                {   
                    // get the max and min
                    if (A[j] > max) max = A[j];
                    if (A[j] < min) min = A[j];
                    //Console.Write(A[j] + " ");
                }
            }
            int ampNow = max - min;
            // compare the Amp of this subarray with the previously visited sub arrays
            if (ampNow < amp) amp = ampNow;
            // now need to comp min Amplitude
        }
        
        return amp;

    }


    static void Main()
    {
        int[] A1 = { 5, 3, 6, 1, 3 };
        int k1 = 2;

        int[] A2 = { 8, 8, 4, 3 };
        int k2 = 2;

        int[] A3 = { 3, 5, 1, 3, 9, 8 };
        int k3 = 4;

        Console.Write("First Test Case: \nArray: [");
        foreach(int i in A3)
        {
            Console.Write(i + ", ");
        }
        Console.Write("]  K = " + k3 + "\n");

        Console.WriteLine("The minimum amplitude is: " + minAmp(A3, k3));
    }

}