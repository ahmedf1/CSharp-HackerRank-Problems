/*
Merge two sorted linked lists and return it as a new sorted list. 
The new list should be made by splicing together the nodes of the first two lists.

Example 2:

Input: l1 = [], l2 = []
Output: []
Example 3:

Input: l1 = [], l2 = [0]
Output: [0]
 

Constraints:

The number of nodes in both lists is in the range [0, 50].
-100 <= Node.val <= 100
Both l1 and l2 are sorted in non-decreasing order.


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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        // create a node that will be our false head
        ListNode nodeToReturn = new ListNode(0);
        // create a node to iterate with
        ListNode iter  = nodeToReturn;
        ListNode l1Iter = l1;
        ListNode l2Iter = l2;
        
        while(true){
            if(l1Iter == null){
                // we reached the end of list 1, attach the rest of list 2
                iter.next = l2Iter;;
                break;
            }
            if(l2Iter == null){
                // we reached the end of list 2, attach the rest of list 1
                iter.next = l1Iter;
                break;
            }
            if(l1Iter.val <= l2Iter.val){
                // if the value is less than or equal to, add that node into our new list and advance the iter
                iter.next = l1Iter;
                l1Iter = l1Iter.next;
            }
            else{
                // if l2 value is greater, insert that node and advance the iter
                iter.next = l2Iter;
                l2Iter = l2Iter.next;
            }
            iter = iter.next;
        }
        // return the node after our false head aka the real head
        return nodeToReturn.next;
        
        
        
    }
}