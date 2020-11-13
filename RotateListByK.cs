/*
Given a linked list, rotate the list to the right by k places, where k is non-negative.

Example 1:

Input: 1->2->3->4->5->NULL, k = 2
Output: 4->5->1->2->3->NULL
Explanation:
rotate 1 steps to the right: 5->1->2->3->4->NULL
rotate 2 steps to the right: 4->5->1->2->3->NULL
Example 2:

Input: 0->1->2->NULL, k = 4
Output: 2->0->1->NULL
Explanation:
rotate 1 steps to the right: 2->0->1->NULL
rotate 2 steps to the right: 1->2->0->NULL
rotate 3 steps to the right: 0->1->2->NULL
rotate 4 steps to the right: 2->0->1->NULL

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
// pop tail and insert at head k times
// would need to iterate to tail k times though --> inefficient

// first do k % n --> to get number of moves
// if k % n  == 0 just return the original list
// else 
// find the n - k - 1 node (the node before the kth last node) 
// make the node before the kth last node point to null
// make the last node in the list point to the head
// and assign the new head to the kth last node
public class Solution {
    public int getSize(ListNode head){  // function to get size of List 
        ListNode iter = head;
        int count = 0;
        while(iter!=null){
            count++;
            iter = iter.next;
        }
        return count;
    }

    public ListNode RotateRight(ListNode head, int k) {
        if(head == null) return null;
        int numOfNodes = getSize(head);

        if(k % numOfNodes == 0){      // if the number of shifts is a multiple of the size of the list, the shifted List will appear the same as the original list
            return head;
        }
        else{
            int numShifts = ((k) % numOfNodes) ;  // compute number of shifts
            int counter = 0;                      // use a counter to start the slow iterator k steps after the fast
            ListNode fastiter = head;             // initialize the iterators
            ListNode slowiter = head;
            while(fastiter.next != null){         // we want to stop at the last node
                if(counter < numShifts){          // advance fast iter while counter is less than numShifts
                    fastiter = fastiter.next;
                    counter++;
                }
                else{
                    slowiter = slowiter.next;       // after creating k distance between the iters, start advancing slowiter
                    fastiter = fastiter.next;
                    counter++;
                }
                
            }            
            fastiter.next = head;           // now fastiter points to the last node in the list, assign its
            head = slowiter.next;           // slowiter points to new last node, so slowiter.next is new 1st node
            slowiter.next = null;           // set slowiter next to null, since it is now the last node 
            
            // reached the node before the kth to last element
        }
        return head;
    }
}