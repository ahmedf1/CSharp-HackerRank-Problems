/*
Given an m x n matrix, return all elements of the matrix in spiral order.

Example 1:
Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

Example 2:
Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]
 

Constraints:
m == matrix.length
n == matrix[i].length
1 <= m, n <= 10
-100 <= matrix[i][j] <= 100

*/
public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        IList<int> ans = new List<int>();
        if(matrix.Length == 0) return ans; // if empty, return an empty list
        
        // creating some indexing vars
        int indexerM = 0;   
        int indexerN = 0;   
        
        // setting the boundaries of the 2d array
        int mBound = matrix.Length - 1;  
        int nBound = matrix[0].Length -1;   
        
        // while we are within the array, iterate the outer spiral
        while (indexerM <= mBound && indexerN <= nBound) {
            
            for (int n = indexerN; n <= nBound; n++) ans.Add(matrix[indexerM][n]);
            for (int m = indexerM + 1; m <= mBound; m++) ans.Add(matrix[m][nBound]);
            if (indexerM < mBound && indexerN < nBound) {
                for (int n = nBound - 1; n > indexerN; n--) ans.Add(matrix[mBound][n]);
                for (int m = mBound; m > indexerM; m--) ans.Add(matrix[m][indexerN]);
            }
            // decrease the bounds so that the spiral to iterate is closer to the center, aka not the prior/outer spiral
            indexerM++;
            mBound--;
            indexerN++;
            nBound--;
        }

        return ans;
    }
}