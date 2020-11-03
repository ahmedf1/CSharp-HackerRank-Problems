/*
Reverse a singly linked list.

Example:

Input: 1->2->3->4->5->NULL
Output: 5->4->3->2->1->NULL
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
// just rebuilding the list in backwards order

public class Solution {
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        ListNode curr = head;
        while(curr != null){
            // store next node as temp
            ListNode nextTemp = curr.next;
            // the next node we add is the one we have just visited
            curr.next = prev;
            // update prev
            prev = curr;
            // advance current
            curr = nextTemp;
        }
        return prev;
    }
}



