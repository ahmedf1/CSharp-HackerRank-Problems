/*
Given head, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Return true if there is a cycle in the linked list. Otherwise, return false.
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
    public bool HasCycle(ListNode head) {
        // collect values of nodes
        // if node has been visited
        if(head == null){
            return false;
        }
        if(head.next == null){
            return false;
        }
        // use two pointer system
        ListNode fastPtr = head;
        ListNode slowPtr = head;
        while(fastPtr != null){
            if(fastPtr.next != null && slowPtr.next != null){
                fastPtr = fastPtr.next.next;
                slowPtr = slowPtr.next;
            }
            else{
                // either of the pointers has reached null, meaning there is no cycle
                break;
            }
            if(fastPtr == slowPtr){
                // fast pointer has lapped slow Pointer, there is a cycle
                return true;
            }
        }
        return false;
        
    }
}