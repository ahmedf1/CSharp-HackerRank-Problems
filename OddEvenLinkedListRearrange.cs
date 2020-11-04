/*
Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.

You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.

Example 1:

Input: 1->2->3->4->5->NULL
Output: 1->3->5->2->4->NULL
Example 2:

Input: 2->1->3->5->6->4->7->NULL
Output: 2->3->6->7->1->5->4->NULL
 

Constraints:

The relative order inside both the even and odd groups should remain as it was in the input.
The first node is considered odd, the second node even and so on ...
The length of the linked list is between [0, 10^4].
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
    public ListNode OddEvenList(ListNode head) {
        if(head == null) return null;           // if head is Null, no elements to rearrange
        ListNode odd = head;                    // head will be node #1 aka odd node
        ListNode evenStart = head.next;         // second node will be the first even one
        ListNode evenIter = head.next;          // use one as iter and one to attach to the end of odd list
        while(odd.next != null){
            odd.next = evenIter.next;           // odd will point to the one after even to get the next odd node
            if(odd.next == null){               // if evenIter.next was null, we have reached the end
                break;
            }
            evenIter.next = evenIter.next.next;     // otherwise, set even node to point to the next even node
            odd = odd.next;                 // advance the iterators
            evenIter = evenIter.next;
        }
        odd.next = evenStart;       // once we reach here, just need to attach the end of the odd list to the start of the even list
        return head;

    }
}