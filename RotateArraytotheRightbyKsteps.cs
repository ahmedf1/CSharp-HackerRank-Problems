/*
Given an array, rotate the array to the right by k steps, where k is non-negative.

Follow up:

Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
Could you do it in-place with O(1) extra space?
 

Example 1:

Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]
Example 2:

Input: nums = [-1,-100,3,99], k = 2
Output: [3,99,-1,-100]
Explanation: 
rotate 1 steps to the right: [99,-1,-100,3]
rotate 2 steps to the right: [3,99,-1,-100]
 

Constraints:

1 <= nums.length <= 2 * 104
-231 <= nums[i] <= 231 - 1
0 <= k <= 105
*/

public class Solution {
    public void Reverse(int []nums , int start, int end){
        while(start < end){
            int temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }
    
    
    public void Rotate(int[] nums, int k) {
        if(nums.Length == 0) return;        // if nums is empty, return --> nothing to do
        if(k % nums.Length == 0) return;    // if k is a multiple of nums.Length, the shift makes no difference
        
        // reverse the entire the array
        // reverse first k nums
        // reverse last n-k nums
        k = k % nums.Length;
        Reverse(nums, 0, nums.Length-1);
        Reverse(nums, 0, k-1);
        Reverse(nums,k, nums.Length-1);
        
    }
}