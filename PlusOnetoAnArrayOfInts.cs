/*
Given a non-empty array of decimal digits representing a non-negative integer, increment one to the integer.

The digits are stored such that the most significant digit is at the head of the list, and each element in the array contains a single digit.

You may assume the integer does not contain any leading zero, except the number 0 itself.

 

Example 1:

Input: digits = [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.
Example 2:

Input: digits = [4,3,2,1]
Output: [4,3,2,2]
Explanation: The array represents the integer 4321.
Example 3:

Input: digits = [0]
Output: [1]
 

Constraints:

1 <= digits.length <= 100
0 <= digits[i] <= 9
*/

public class Solution {
    public int[] PlusOne(int[] digits) {        
        Array.Reverse(digits);      // reverse so it is easier to count the carry
        
        int carry = 0;
        int rem = 0;
        int sum = digits[0] + carry + 1;    // compute first digit sums with plus one
        rem = sum % 10;
        carry = sum /10;
        digits[0] = rem;
        for(int i = 1; i < digits.Length; i++){
            sum = digits[i] + carry;                // continue computing, making sure to carry
            rem = sum % 10;
            carry = sum / 10;
            digits[i] = rem;
        }
        if(carry > 0){
            int[] digits2 = new int[digits.Length+1];       // create a new array that will hold an extra digit
            Array.Copy(digits,digits2, digits.Length);
            digits2[digits.Length] = carry;
            Array.Reverse(digits2);               // return to normal and return
            return digits2;
        }
        else{
            Array.Reverse(digits);
            return digits;
        }
        
        
    }
}