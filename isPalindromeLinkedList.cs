/*
Given a singly linked list, determine if it is a palindrome.

Example 1:

Input: 1->2
Output: false
Example 2:

Input: 1->2->2->1
Output: true
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */


public class Solution {
    private ListNode forward;
    private bool Iterate(ListNode backward){
        if(backward == null) return true;           // base case
        if(!Iterate(backward.next)) return false;      // if false is returned by a future comparison
        bool result = backward.val == forward.val;      // than the result variable was false, meaning there 
        forward = forward.next;                         // was a mismatch of two elements --> not a palindrome
        return result;                          // otherwise keep advancing forward, and comparing with backward
    }
    
    public bool IsPalindrome(ListNode head) {
        forward = head;
        ListNode backward = head;
        return Iterate(backward);
    }
}