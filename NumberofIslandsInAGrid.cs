/*
Given an m x n 2d grid map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

Example 1:

Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1
Example 2:

Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
 
Constraints:
m == grid.length
n == grid[i].length
1 <= m, n <= 300
grid[i][j] is '0' or '1'.

*/

public class Solution {
    public int NumIslands(char[][] grid) {     
        
        int result = 0;
        // store all possible neighbor distances (Right, Left, Up, Down)
        int[] dx = new int[] {1,-1,0,0};
        int[] dy = new int[] {0,0,1,-1};
        
       // iterate through the grid
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == '1'){
                    // we found part of an island
                    result++;
                    Queue<int[]> myQ = new Queue<int[]>();
                    
                    // add to queue to explore its neighbors
                    myQ.Enqueue(new int[] {i,j});
                    grid[i][j] = 'E'; // mark as explored
                    
                    // while we have unexplored neighbors for a visited node
                    while(myQ.Count > 0){
                        // get the earliest stored node
                        int[] currentNode = myQ.Dequeue();
                        for(int k = 0; k < 4; k++){
                            // iterate through all 4 possible neighbors
                            int newX = currentNode[0] + dx[k];
                            int newY = currentNode[1] + dy[k];
                            
                            // if the neighbors coordiantes are valid within the grid, and it is not water or an already explored node
                            if(newX > -1 && newY > -1 && newY < grid[0].Length && newX < grid.Length && grid[newX][newY] != '0' && grid[newX][newY] != 'E'){
                                // add it to our list of visited nodes with unexplored neighbors
                                myQ.Enqueue(new int[]{newX, newY});
                                grid[newX][newY] = 'E';
                            }
                            
                        }
                    }
                    // after finishing iterating all of neighboring nodes to the original node
                    // we have completed one island
                }
                
            }
        }
        return result;
    }
}