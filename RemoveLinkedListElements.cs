/*
Remove all elements from a linked list of integers that have value val.

Example:

Input:  1->2->6->3->4->5->6, val = 6
Output: 1->2->3->4->5
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
    public ListNode RemoveElements(ListNode head, int val) {
        if(head ==null){    // if the head is null, list is empty, nothing to remove
            return null;
        }
        ListNode prevIter = head;
        while(prevIter.val == val){     // if the head value matches the val to remove
            //keep advancing head       // keep removing the head while it matches the value
            head = prevIter.next;       // need this seperate loop for the head since we can't
            prevIter = head;            // keep a prevIter that points to head iter
            if(prevIter ==null){ // if we ever reach a point where our iter has become null, 
                return null;    // we have removed every item in the list
            }
        }
        prevIter = head;                // reassign our prevIter to head
        ListNode iter = prevIter.next;  // set currIter
        if(iter ==null){                // if iter is null, we have only have head in the list and it is not
            return head;                // the value we seek
        }
        while(iter.next != null){       // iterate through list, stopping at last node
            if(iter.val == val){        // if iter val matches, cut out the corresponding node
                prevIter.next = iter.next;
            }
            else{                   // only advance the prevIter if we have not cut out a node
                prevIter = iter;
            }
                                
            iter = iter.next;       // always advance the iter
        }
        if(iter.val == val){        // since we stop the loop at the last node, still have to check the last node
            prevIter.next = null;
        }
        return head;
    }
}