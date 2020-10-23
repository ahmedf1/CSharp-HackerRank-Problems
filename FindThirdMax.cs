using System;
/*
Given a non-empty array of integers, return the third maximum number in this array. If it does not exist, return the maximum number. The time complexity must be in O(n).

Example 1:
Input:[3, 2, 1]

Output: 1

Explanation: The third maximum is 1.
*/

class FindThirdMax
{
    static void Main()
    {
        int[] nums = { 3, 2, 1 };
        int thirdMaxReturn = ThirdMax(nums);
        Console.WriteLine(thirdMaxReturn);
    }
    public int ThirdMax(int[] nums)
    {
        // given array, return third max
        // if doesnt exist, return max

        //cases where it wouldnt exist
        // less than 3 numbers
        // all numbers are the same

        // iterate backward from the end after sorting
        // count the number of maximums encountered
        // once we reach the third one, return that number
        // if we never reach the third one, return the last element in the ordered array


        Array.Sort(nums);

        if (nums.Length < 3)
        {
            return nums[nums.Length - 1];
        }
        int numMaximums = 1;
        int currentMaximum = nums[nums.Length - 1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] < currentMaximum)
            {
                currentMaximum = nums[i];
                numMaximums++;
            }
            if (numMaximums == 3)
            {
                return currentMaximum;
            }
        }
        if (numMaximums < 3)
        {
            return nums[nums.Length - 1];
        }
        return currentMaximum;

    }
}

