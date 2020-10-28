public class MyLinkedList 
{
    private Node head;
    int count = 0;
    
    public int Get(int index) 
    {
        // call getNode to retreive the node at index 
        var node = GetNode(index);
        return node == null ? -1 : node.val;
    }
    
    public Node GetNode(int index) 
    {
        if(index >= count) // if index is greater than count, return null, no node at index greater than count
            return null;
        var curr = head;
        for(int i = 0; i < index; i++) // advance until we reach the correct index, return the node at that index
            curr = curr.next;
        
        return curr;
    }
    
    public void AddAtHead(int val) 
    {
        // create a new node and replace the head, but set the previous head to be the new one's next node
        var newNode = new Node(val);
        newNode.next = head;
        head = newNode;
        count++;
    }
    
    public void AddAtTail(int val) 
    {
        if(head == null)
        {
            // if head is null, tail is the new head
            AddAtHead(val);
            return;
        }
        // get the 2nd to last node
        var node = GetNode(count - 1);
        // put a new node at the end
        node.next = new Node(val);
        count++;
    }
    
    public void AddAtIndex(int index, int val) 
    {
        if(index > count) // index is out of range
            return;
       if(index == 0)
       {
           // if index is 0, same as adding a new head
           AddAtHead(val);
           return;
       }
        // get the node right before the one we want to insert at
        var node = GetNode(index - 1);
        var newNode = new Node(val);
        // set the new node to point to the previous node's next pointer
        newNode.next = node.next;
        // set the previous node to point to the new node
        node.next = newNode;
        count++;
    }
    
    public void DeleteAtIndex(int index) 
    {
        if(count == 0) // list is empty, nothing to delete
            return;
        
        if(index < count && index >= 0) // index is valid
        {
            if(index == 0) // index 0 deletes the head
                head = head.next;
            else
            {
                // get the node that is prior to the index we want to delete
                var node = GetNode(index - 1);
                // set that node's next pointer to the node that is to be deleted's next pointer
                node.next = node.next.next;
            }
            
            count--;
        }
    }
}

public class Node
{
    public int val;
    public Node next;
    public Node(int n)
    {
        val = n; 
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */