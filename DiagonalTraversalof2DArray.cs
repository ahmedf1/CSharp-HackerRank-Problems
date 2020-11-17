/*
Given a matrix of M x N elements (M rows, N columns), return all elements of the matrix in diagonal order as shown in the below image.

 
Example:

Input:
[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]

Output:  [1,2,4,7,5,3,6,8,9]

*/
public class Solution {
    public int[] FindDiagonalOrder(int[][] matrix) {
        if(matrix.Length == 0) return new int[0];
        int m = matrix[0].Length;   // dimensions of matrix
        int n = matrix.Length;
        
        // create array to return
        int[] diagTrav = new int[m * n];
        
        int index = 0, i = 0, j = 0;
        bool upward = true;
        
        while(true){
            // add matrix element and increment index
            diagTrav[index++] = matrix[i][j];
            
            // we have reached the last element, break the loop
            if(i == n -1 && j == m -1) break;
            
            // alternate the direction of the diagonal
            if(upward){
                if(j == m - 1){
                    // we have reached the last column/ end of the diagonal, flip the flag
                    upward = false;
                    // next diagnoal starts at same j, but next i
                    i++;
                }
                else{
                    // reach the first row, no more rows upward, so flip the flag
                    if(i == 0) upward = false; 
                    else{
                        i--; // move upward from bottom row to top
                    }
                    j++; // always advance j aka moving right and up    
                }
            }
            else{   // moving downward diagonal
                if(i == n - 1){
                    // reached last row, need to go upward for next diagonal
                    upward = true;
                    // next diagonal starts at same i, but next j
                    j++;
                }
                else{
                    if(j == 0){
                        // reached the first column, so time to go upward
                        upward = true;
                    }
                    else{
                        j--; // move from right to left for downward 
                    }
                    i++; // this moves downward
                }
            }
        }
        return diagTrav;        
    }
}