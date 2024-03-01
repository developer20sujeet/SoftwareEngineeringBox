public partial class LinkedList
{
    #region  Search
    // Method to find a node by its value and return its index
    public int FindNodeByValue(int value)
    {
        Node? current = head;
        int index = 0; // To keep track of the index

        while (current != null)
        {
            if (current.data == value)
            {
                return index; // Node found, return its index
            }
            current = current.next;
            index++;
        }

        return -1; // Node not found
    }

    //Tortoise and the Hare Algo
    //use the two-pointer technique, also known as the "Tortoise and the Hare" algorithm
    //When the fast pointer reaches the end of the list, the slow pointer will be at the midpoint of the list
    //"Tortoise and the Hare" algorithm method works for both even and odd lengths of the list, with slight variations depending on whether you wish to favor second middle node in even-length lists.
    public Node? FindMiddle()
    {
        Node? slow = head; // Start slow pointer at the head
        Node? fast = head; // Start fast pointer at the head

        // Loop until fast pointer reaches the end of the list
        // This -fast != null && fast.next != null  condition makes the tortoise stop at the second middle node in Even-Length Lists:
        while (fast != null && fast.next != null)
        {
            slow = slow.next; // Move slow pointer by one
            fast = fast.next.next; // Move fast pointer by two
        }

        // When the loop completes, slow pointer will be at the middle of the list
        return slow;
    }

    /* Function to detect cycle in a linked list */
    public bool HasCycle()
    {
        Node slow = head,
            fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next; // move slow pointer one step
            fast = fast.next.next; // move fast pointer two steps

            if (slow == fast)
            {
                return true; // cycle detected
            }
        }
        return false; // no cycle found
    }

    public Node DetectCycleStart()
    {
        Node slow = head,
            fast = head;

        // Step 1: Use Floyd's Cycle Finding Algorithm to find intersection if there's a cycle
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast) // step 1 . Cycle detected
            {
                // Step 2: Find the start of the cycle
                slow = head; // Move slow to Head - reset slow tortoise
                while (slow != fast) // Move slow and fast at the same speed
                {
                    slow = slow.next;
                    fast = fast.next;
                }
                return slow; // slow is now at the start of the cycle
            }
        }
        return null; // No cycle found
    }

    #endregion


    #region Reverse

    /// <summary>
    /// Time Complexity: O(n), where n is the number of nodes in the linked list.
    /// Space Complexity: O(1), as it uses a fixed amount of space.

    /// Algorithm Used: Iterative approach.
    /// Algorithmic Code Pattern: Two-Pointer Techniq
    public Node ReverseLinkedList_iteratively()
    {
        Node prev = null;
        Node current = head;
        Node next = null;

        while (current != null)
        {
            next = current.next; // Step 1: Save next
            current.next = prev; // Step 2: Reverse the current node's pointer - mean current node next point to previous

            prev = current; // Step 3: Move pointers one step forward
            current = next; // No ready for next iteration
        }

        head = prev; // prev reached at very end of linkedlist Step 4: Change head to new head of the reversed list

        return head;
    }

    //The idea behind recursion is to solve a problem by solving smaller instances of the same problem

    /// Reverses a linked list recursively.
    /// Time Complexity: O(n), where n is the number of nodes in the linked list.
    /// Space Complexity: O(n), due to the recursion stack
    
    //the call stack frame
    //execution context
    
    public Node ReverseLinkedList(Node head)
    {
        // Base case: if list is empty or has only one node
        if (head == null || head.next == null)
        {
            return head;
        }

        // Recursive case: reverse the rest of the list
        Node newHead = ReverseLinkedList(head.next);

        // Rearrangement: point next node's next to current node
        // Example if linkedList is 1>2>3>4 then 2.next = 3 and 2.next(3).next=2 so we moved pointer from 2 > 3 to 3>2
        head.next.next = head;
        head.next = null; // Set the original head's next to null

        return newHead; // Return the new head of the reversed list
    }


    #endregion

    


}
