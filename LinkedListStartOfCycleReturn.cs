/*
Given a linked list, return the node where the cycle begins. If there is no cycle, return null.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Notice that you should not modify the linked list.

*/
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        // if head is null, no cycle
        if(head == null){
            return null;
        }
        // if list has only one element, and the next is null, no cycle
        if(head.next == null){
            return null;
        }
        
        // use two pointer system
        ListNode fastPtr = head;
        ListNode slowPtr = head;
        // same two pointer logic as determining cycle
        while(fastPtr != null){
            if(fastPtr.next != null && slowPtr.next != null){
                fastPtr = fastPtr.next.next;
                slowPtr = slowPtr.next;
            }
            else{
                // either of the pointers has reached null, meaning there is no cycle
                return null;
            }
            if(fastPtr == slowPtr){
                // cycle exists
                break;
            }
        }
        if(fastPtr == null) return null;
        fastPtr = head; // reset fast Ptr to head
        /*
        To understand this solution, you just need to ask yourself these question.
        Assume the distance from head to the start of the loop is x1
        the distance from the start of the loop to the point fast and slow meet is x2
        the distance from the point fast and slow meet to the start of the loop is x3
        What is the distance fast moved? What is the distance slow moved? And their relationship?

        x1 + x2 + x3 + x2
        x1 + x2
        x1 + x2 + x3 + x2 = 2 (x1 + x2) // fast pointer
        Thus x1 = x3
            --> the distance between the start of the list and the start of the loop is the same as the distance between the node at which the two pointers meet and the start of the loop
            
            // so just wait for them to point to the same node
        */
        
        while(fastPtr != slowPtr){
            fastPtr =fastPtr.next;
            // slow Ptr is within the cycle and will continuously loop through it
            slowPtr =slowPtr.next;
        }
        return fastPtr;
        
        
    }
}