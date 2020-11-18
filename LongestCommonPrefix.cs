/*
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
 

Constraints:

0 <= strs.length <= 200
0 <= strs[i].length <= 200
strs[i] consists of only lower-case English letters.
*/

public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        // only prefixes
        // find the shortest word and compare all the letters in other words to that
        // so if none of the first letters match, return no match
        // otherwise keep going until one of the strings does not match
        // use a string builder to put together prefix
        
        // if array is empty return empty string
        if(strs.Length == 0) return new string("");
        // only one string, return it
        if(strs.Length == 1) return strs[0];  
        // if there is one empty string, then it is the shortest prefix
        if(Array.IndexOf(strs,"") > -1) return "";
        
        StringBuilder ans = new StringBuilder();
        int minLen = 201;
        int minIndex = 0;
        // go through string array and find the shortest string
        // the shortest string will have the most number of chars that can be added to a prefix
        for(int i = 0; i < strs.Length;i++){
            if(strs[i].Length < minLen){
                minLen = strs[i].Length;
                minIndex = i;
            }
        }

        string wordtoCompare = strs[minIndex];
        bool match  = true;
        int index = 0;
        // iterate throught the shortest word and compare to all the other words
        while(index < minLen){
            foreach(string str in strs){
                // if one of the letters does not match up, we have found the longestCommonPrefix
                if(str[index] != wordtoCompare[index]){
                    match = false;
                }
            }
            if(match){
                // if the letter matched in all the words, adding it to our prefix answer
                ans.Append(wordtoCompare[index]);
            }
            else{
                break;
            }
            index++;
        }
        return ans.ToString();
        
    }
}