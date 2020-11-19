/*
Given an array of n positive integers and a positive integer s, find the minimal length of a contiguous subarray of which the sum ≥ s. If there isn't one, return 0 instead.

Example: 

Input: s = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: the subarray [4,3] has the minimal length under the problem constraint.
*/


public class Solution {
    public int MinSubArrayLen(int s, int[] numbers){
        int fast =0;
        int slow = 0;
        int sum = 0;
        int minimum = int.MaxValue;
        
        while(fast < numbers.Length){
            sum += numbers[fast];
            while(sum >= s){
                minimum = Math.Min(minimum, fast + 1 - slow);
                sum -= numbers[slow++];
            }
            fast++;
        }
        return minimum == int.MaxValue? 0 : minimum;
    }
    
    
    /* This below is an O(n^2) solution due to iterating the array twice within each other
    public int MinSubArrayLen(int s, int[] nums) {
        if(nums.Length == 0) return 0;
        int minCount = 9999;
        for(int i = 0; i < nums.Length; i++){
            int count = 0;
            int sum = nums[i];
            count++;
            if(sum == s){
                return count;
            }
            else if(sum > s){
                minCount = count;
            }
            for(int j = i+1; j < nums.Length; j++){
                if(sum + nums[j] > s){
                    count++;
                    if(count < minCount){
                        minCount = count;
                    }
                    else{
                        break;
                    }
                }
                else if(sum + nums[j] == s){
                    count++;
                    if(count < minCount) minCount = count;
                    else{
                        break;
                    }
                }
                else{
                    sum += nums[j];
                    count++;
                }
            }
        }
        if(minCount == 9999) return 0;
        return minCount;
    }
    */
}