/*
Given two binary strings a and b, return their sum as a binary string.

 

Example 1:

Input: a = "11", b = "1"
Output: "100"
Example 2:

Input: a = "1010", b = "1011"
Output: "10101"
 

Constraints:

1 <= a.length, b.length <= 104
a and b consist only of '0' or '1' characters.
Each string does not contain leading zeros except for the zero itself.
*/


public class Solution {
    public string AddBinary(string a, string b) {
        // make strings iterable by converting to char arrays
        char[] numA = a.ToCharArray();
        char[] numB = b.ToCharArray();
        // use a string builder
        StringBuilder strB = new StringBuilder();
        
        // create some indexing vars
        int indexA = numA.Length - 1;
        int indexB = numB.Length - 1;
        int carry = 0;
        
        // iterate until we have ran through one of the binary numbers
        while(indexA >= 0 && indexB  >= 0){
            if(Char.GetNumericValue(numA[indexA]) + Char.GetNumericValue(numB[indexB]) + carry == 2){
                // both are 1's and carry is 0;
                carry = 1;
                strB.Append("0");
            }
            else if(Char.GetNumericValue(numA[indexA]) + Char.GetNumericValue(numB[indexB]) + carry == 3){
                // both are 1's and carry is also 1
                carry = 1;
                strB.Append("1");
            }
            else if(Char.GetNumericValue(numA[indexA]) + Char.GetNumericValue(numB[indexB]) + carry == 0){
                // everything is 0
                carry =0;
                strB.Append("0");
            }
            else{
                // sum here is 1
                strB.Append("1");
                carry = 0;
            }
            indexA--;
            indexB--;
        }
        
        if(indexA >indexB){ // need to finish copying the rest of A over
            while(indexA >= 0){
                if(Char.GetNumericValue(numA[indexA]) + carry == 2){
                    // both are 1's and carry is 0;
                    carry = 1;
                    strB.Append("0");
                }
                else if(Char.GetNumericValue(numA[indexA]) + carry == 0){
                    // both are 0's
                    carry = 0;
                    strB.Append("0");
                }
                else{
                    // only one 1, the other is 0
                    strB.Append("1");
                    carry = 0;
                }
                indexA--;
            }
        }
        if(indexB > indexA){ // need to finish copying the rest of B over
            while(indexB >= 0){
                if(Char.GetNumericValue(numB[indexB]) + carry == 2){
                    // both are 1's and carry is 0;
                    carry = 1;
                    strB.Append("0");
                }
                else if(Char.GetNumericValue(numB[indexB]) + carry == 0){
                    // both are 0's
                    carry = 0;
                    strB.Append("0");
                }
                else{
                    // one one 1, the other is 0
                    strB.Append("1");
                    carry = 0;
                }
                indexB--;
            }
        }
        if(carry>0){
            // if there is a carry, add it the the end
            strB.Append("1");
        }
        // reverse and return 
        string ans = new string(strB.ToString().Reverse().ToArray());
        return ans;
    }
}