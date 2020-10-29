/* Given the head of a linked list, remove the nth node from the end of the list and return its head.

Example 1:
Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]

Example 2:
Input: head = [1], n = 1
Output: []

Example 3:
Input: head = [1,2], n = 1
Output: [1]

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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        if(head == null) return null; // if head is null, we can't remove anything 
        if(head.next == null) {head = null;return null;} // if the next is null, only removal possible is the head
        ListNode fastIter = head.next; // start fast iterator ahead of slow iterator
        ListNode slowIter = head;
        int i = 1; // start at 1 since, the head is the first node
        int count =1;
        while(fastIter != null){ // iterate to null aka the end of the list
            if(i <= n){ // only advance fastIter while counter is less than or equal to n
                fastIter = fastIter.next;
                i++;
            }
            else{// once i has reached n, we can start advancing the slow iter, that way slow iter will always be n nodes behind the fast iter
                slowIter = slowIter.next;
                fastIter = fastIter.next;
            }
            count++; // increase count to gather size of the linked list
        }

        if(slowIter.next == null){ // if slowIter.next  is null, it is still pointing to head, and size is 1
            head =null;
        }
        if(slowIter == head && n == count){ // if slowIter is pointing to head, and n is the same as the size as the list, basically means remove the head since head is the count/n nodes away from the end
            head = slowIter.next;
            return head;
        }
        // otherwise just cut out the node that is to be removed
        slowIter.next = slowIter.next.next;
        return head;
    }
}