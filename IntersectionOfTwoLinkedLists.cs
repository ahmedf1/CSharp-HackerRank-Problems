/*
Write a program to find the node at which the intersection of two singly linked lists begins.

Example:
Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,6,1,8,4,5], skipA = 2, skipB = 3
Output: Reference of the node with value = 8
Input Explanation: The intersected node's value is 8 (note that this must not be 0 if the two lists intersect). From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,6,1,8,4,5]. There are 2 nodes before the intersected node in A; There are 3 nodes before the intersected node in B.

Example 2:
Input: intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
Output: null
Input Explanation: From the head of A, it reads as [2,6,4]. From the head of B, it reads as [1,5]. Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
Explanation: The two lists do not intersect, so return null.
*/
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

// the pointer to the shorter list will reach the end of the merged list first
// by moving that pointer to point to the head of the other longer list,
// the pointer to the shorter list will traverse the extra nodes
// causing the two nodes to catch up to each other
// the two instances when they will equal each other is either when they have met at the intersecting node
// or when they both point to null, having reached the end their respective lists
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        ListNode iterA = headA; // use two pointers, one for each head
        ListNode iterB = headB;
        while(iterA != iterB){
            if(iterA == null){ // swap the iterator once it reaches the end
                iterA = headB;
            }
            else{
                iterA = iterA.next; // otherwise advance
            }
            if(iterB == null){
                iterB = headA;
            }
            else{
                iterB = iterB.next;
            }
        }
        return iterA;
    }
}

