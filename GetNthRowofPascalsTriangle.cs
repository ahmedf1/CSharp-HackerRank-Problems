/*
Given an integer rowIndex, return the rowIndexth row of the Pascal's triangle.
Notice that the row index starts from 0.


In Pascal's triangle, each number is the sum of the two numbers directly above it. 

Example 1:

Input: rowIndex = 3
Output: [1,3,3,1]
Example 2:

Input: rowIndex = 0
Output: [1]
Example 3:

Input: rowIndex = 1
Output: [1,1]
 

Constraints:

0 <= rowIndex <= 40

*/
public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var result = new List<int>() {1};   // create 0 level, which is just a 1
        
        for (int i = 0; i < rowIndex; i++) {
            var arr = new List<int>(){1}; // create a list to hold current level's values
            arr.AddRange(result.Zip(result.Skip(1), (a, b) => a + b));  // zip the result set to itself but skip the first '1', so all the numbers will derive from the previously stored result

            arr.Add(1);         // add the final '1' to the end
            result = arr;       // update the result set, carry the previous row forward
        }
        return result;
        
        
    }
}