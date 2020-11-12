/*
You are given a doubly linked list which in addition to the next and previous pointers, it could have a child pointer, which may or may not point to a separate doubly linked list. These child lists may have one or more children of their own, and so on, to produce a multilevel data structure, as shown in the example below.

Flatten the list so that all the nodes appear in a single-level, doubly linked list. You are given the head of the first level of the list.

Example 2:

Input: head = [1,2,null,3]
Output: [1,3,2]
Explanation:

The input multilevel linked list is as follows:

  1---2---NULL
  |
  3---NULL
Example 3:

Input: head = []
Output: []
 

How multilevel linked list is represented in test case:

We use the multilevel linked list from Example 1 above:

 1---2---3---4---5---6--NULL
         |
         7---8---9---10--NULL
             |
             11--12--NULL
The serialization of each level is as follows:

[1,2,3,4,5,6,null]
[7,8,9,10,null]
[11,12,null]
To serialize all levels together we will add nulls in each level to signify no node connects to the upper node of the previous level. The serialization becomes:

[1,2,3,4,5,6,null]
[null,null,7,8,9,10,null]
[null,11,12,null]
Merging the serialization of each level and removing trailing nulls we obtain:

[1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]
 

Constraints:

Number of Nodes will not exceed 1000.
1 <= Node.val <= 10^5

*/
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}
*/

public class Solution {
    int [] vals = new int[999]; // create an array for collecting node vals in order
    int count  = 0;             // store the count of nodes to create an in order list later
    
    public Node traverse(Node head){        // traversal of the nodes recursively
        Node iter = head;
        Node childIter = null;
        while(iter != null){
            vals[count++] = iter.val;        // store the vals and increase count as we store
            if(iter.child != null){
                traverse(iter.child);        // if current node has children, iterate through those through recursive call
            }
            iter = iter.next;
        }
        return childIter;
    }
    public Node Flatten(Node head) {
        if(head == null) return head;           // if head is null, nothing to flatten
        
        Node childIter = head;
        while(childIter != null){
            childIter = traverse(childIter);        // recursively iterate through list
        }
        Node newHead = new Node(vals[0], null, null,null);      // create new Head
        Node iter = newHead;
        for(int i = 1; i < count; i++){
            iter.next = new Node(vals[i], iter, null, null);    // add all values from array, in order
            iter = iter.next;
        }
        return newHead;
    }
}