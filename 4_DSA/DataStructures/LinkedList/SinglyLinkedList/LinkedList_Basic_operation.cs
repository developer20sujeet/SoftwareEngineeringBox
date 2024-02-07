using System;

// Basic LinkedList class representation
class Node
{
    public int data;
    public Node? next;

    public Node(int _data)
    {
        data = _data;
        next = null;
    }
}

/* Linkedlist implementation - Basic operation -

1. build linkedlist of 10 node  and print ()
2. add , update , delete , search


*/
public class LinkedList
{
    Node head;

    public void MakeLinkedList(int nodeCount)
    {
        head = new Node(1);

        Node current = head;

        for (int i = 2; i <= nodeCount; i++)
        {
            Node newNode = new Node(i);

            current.next = newNode;

            current = current.next;
        }
    }

    public void print()
    {
        Node current = head;

        while (current != null)
        {
            Console.Write(current.data);

            if (current.next != null)
            {
                Console.Write(">");
            }

            current = current.next;
        }
    }

    #region  Addd
    public void addLast(int data)
    {
        // if linkedlist is empty
        if (head == null)
        {
            Node node = new Node(data);

            head = node;

            return;
        }

        // we need to know the last node of linkedlist to add
        Node current = head;

        while (current.next != null)
        {
            current = current.next;
        }

        Node node1 = new Node(data);

        current.next = node1;
    }

    /// <summary>
    /// Adds a new node with the specified data at the beginning of the linked list.
    /// </summary>
    /// <param name="data">The data to add in the new node.</param>
    /// <remarks>
    /// <para>Time Complexity: O(1) - Because it adds the node at the beginning, the operation is constant time.</para>
    /// <para>Space Complexity: O(1) - It uses a fixed amount of space for the new node.</para>
    /// <para>Algorithm Used: Direct Link Manipulation.</para>
    /// <para>Algorithmic Code Pattern: N/A for this operation.</para>
    /// <para>Data Structure Used: Singly Linked List.</para>
    /// <para>Company Name: This pattern is common across many companies, including but not limited to Google, Amazon, Microsoft for basic data structure understanding.</para>
    /// <para>Important Tips: Always check if the list is empty (i.e., head is null) before adding the first node. This method ensures the linked list's integrity by correctly setting the next pointers.</para>
    /// <para>Lessons Learned: Understanding pointer manipulation is crucial for linked list operations.</para>
    /// </remarks>
    public void AddFirst(int data)
    {
        // Step 1: Create a new node with the given data
        Node node = new Node(data); // Create a new node object with data

        // No node present, the list is empty
        if (head == null)
        {
            // Step 2: If the list is empty, make the new node as the head
            head = node; // Point the head to the new node
        }
        else
        {
            // The list has at least one node
            // Step 3: Link the new node to the current head and update the head
            node.next = head; // Set the new node's next to the current head
            head = node; // Move the head to point to the new node
        }
        // The new node is now the first node in the list
    }

    /// <summary>
    /// Inserts a new node with the specified data at the specified index in the linked list.
    /// </summary>
    /// <param name="index">The index at which to insert the new node.</param>
    /// <param name="data">The data for the new node.</param>
    /// <remarks>
    /// <para>Time Complexity: O(n) - In the worst case, we traverse the entire list.</para>
    /// <para>Space Complexity: O(1) - We only create one new node, regardless of the list size.</para>
    /// <para>Algorithm Used: Linear Traversal.</para>
    /// <para>Data Structure Used: Singly Linked List.</para>
    /// <para>Important Tips: Always validate the index to ensure it is within the bounds of the list.</para>
    /// <para>Lessons Learned: Understanding how to manipulate pointers is key to efficiently working with linked lists.</para>
    /// </remarks>
    public void AddNodeAtIndex(int index, int data)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be non-negative.");
        }

        // Create a new node
        Node node = new Node(data);

        // Special case: adding at the head
        if (index == 0)
        {
            node.next = head;
            head = node;
            return;
        }

        Node current = head;
        int count = 0; // Use 0-based indexing to match array-like behavior

        // Traverse the list to find the insertion point
        while (count < index - 1 && current != null)
        {
            current = current.next;
            count++;
        }

        if (current == null)
        {
            // Index is out of bounds
            throw new ArgumentOutOfRangeException(
                nameof(index),
                "Index is out of the bounds of the list."
            );
        }

        // Insert the new node at the specified index
        node.next = current.next;
        current.next = node;
    }
    #endregion















}
