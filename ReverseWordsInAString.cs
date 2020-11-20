/*
Given an input string s, reverse the order of the words.

A word is defined as a sequence of non-space characters. The words in s will be separated by at least one space.

Return a string of the words in reverse order concatenated by a single space.

Note that s may contain leading or trailing spaces or multiple spaces between two words. The returned string should only have a single space separating the words. Do not include any extra spaces.

Constraints:

1 <= s.length <= 104
s contains English letters (upper-case and lower-case), digits, and spaces ' '.
There is at least one word in s.

*/
public class Solution {
    public string ReverseWords(string s) {
        // using a lamda expression
        // split on spaces but don't keep empty entries, and finally reverse before returning
        return string.Join(" ", s.Split(" ").Where(_ => _ != "").Reverse());
        
        /*
        // remove trailing and leading white space
        s = s.Trim();
        // remove any empty space entries in the array created by the split
        s = String.Join(" ", s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        string[] words = s.Split(" ");

        int numWords = words.Length;
        // swap the words from beginning and end, traversing towards middle 
        for(int i = 0,j=numWords-1; i < numWords/2; i++,j--){
            string temp = words[i];
            words[i] = words[j];
            words[j] = temp;
        }
        // put together the new string from the string array created by the split
        StringBuilder strB = new StringBuilder();
        int k = 0;
        foreach(string w in words){
            strB.Append(w);
            if(k != numWords-1){
                strB.Append(" ");
            }
            k++;
        }
        return new string(strB.ToString());
        */
    }
}