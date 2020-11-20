/*
Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
In Pascal's triangle, each number is the sum of the two numbers directly above it.

Example:

Input: 5
Output:
[
     [1],
    [1,1],
   [1,2,1],
  [1,3,3,1],
 [1,4,6,4,1]
]

*/
public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> ans = new List<IList<int>>();
        if(numRows == 0){return ans;}
        
        // create peak of Pascal's Triangle, always starts with 1
        ans.Add(new List<int>());
        ans[0].Add(1);
        
        // starting from level 2
        for(int rowNum = 1; rowNum < numRows; rowNum++ ){
            List<int> currRow = new List<int>();
            // use the previous row to get the values for this row
            IList<int> prevRow = ans[rowNum-1];
            
            // every row starts with a 1
            currRow.Add(1);
            for(int i = 1; i < rowNum; i++){
                // add the value above and to the left to get the current value
                currRow.Add(prevRow[i-1] + prevRow[i]);
            }
            // all rows end with a 1
            currRow.Add(1);
            // add the row to the triangle
            ans.Add(currRow);
        }
        return ans;
    }
}