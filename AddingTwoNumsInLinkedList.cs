/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]
Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
 

Constraints:

The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.

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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        if(l1 == null) return l2;           // return the other list if one list is empty
        if(l2 == null) return l1;
        ListNode newHead = new ListNode(0);     // create a false head for returning at the end
        ListNode iter = newHead;                // ListNode copy for iterating through result
        
        ListNode iter1 = l1;
        ListNode iter2 = l2;
        int rem = 0;                        // set up our addition variables
        int carry = 0;
        int sum = 0;
        while(true){
            sum = iter1.val + iter2.val + carry;        // compute sum with carry over
            rem = sum % 10;
            carry = sum / 10;
            iter.next = new ListNode(rem, null);        // new node with single digit value
            iter = iter.next;
            
            iter1 = iter1.next;                     // advance iters
            iter2 = iter2.next;
            if(iter1 == null || iter2 == null) break;       // if either is null, break this loop, we have reached the end of one of the nums
            
        }
        
        // now just add the remaining the remaining digits
        if(iter1 == null && iter2 != null){
            while(iter2 != null){               // list1 is finished, iterate through list 2 
                sum = iter2.val + carry;        // make sure to include any carry left over from the the prev loop
                rem = sum % 10;
                carry = sum /10;
                iter.next = new ListNode(rem, null);
                iter = iter.next;
                iter2 = iter2.next;
            }
        }
        if(iter2 == null && iter1 != null){
            while(iter1 != null){
                sum = iter1.val + carry;
                rem = sum % 10;
                carry = sum /10;
                //Console.WriteLine(rem);
                iter.next = new ListNode(rem, null);
                iter = iter.next;
                iter1 = iter1.next;
            }
            
        }    
        if(carry > 0){                                      // if there is still any carry left, add it to the tail
                iter.next = new ListNode(carry, null);
            }
        return newHead.next;                // return the false head's next node aka the true head
    }
}