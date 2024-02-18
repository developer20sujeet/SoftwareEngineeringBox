using System;
using System.Transactions;

#region  Structure of node

// Node class representation
public class Node
{
    public int data;
    public Node? next;

    public Node(int _data)
    {
        data = _data;
        next = null;
    }
}

#endregion


public partial class LinkedList
{
    Node? head;

    #region Create LinkedLIst && Traversal
    public void MakeLinkedList(int nodeCount)
    {
        head = new Node(1);

        Node current = head;

        for (int i = 2; i <= nodeCount; i++)
        {
            Node newNode = new(i);

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

    #endregion

    #region addLast , AddFirst and AddNodeAtIndex


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

    // Time Complexity: O(1) - Because it adds the node at the beginning, the operation is constant time.</para>
    // Space Complexity: O(1) - It uses a fixed amount of space for the new node.</para>
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
        node.next = current.next; // forward from new node
        current.next = node; // forward from current node
    }

    #endregion

    #region update

    // Inside your LinkedList class
    public void UpdateNodeAtIndex(int index, int newValue)
    {
        if (head == null || index < 0)
            throw new IndexOutOfRangeException("Index out of range");

        Node current = head;
        for (int i = 0; current != null && i < index; i++)
        {
            current = current.next;
        }

        if (current == null)
            throw new IndexOutOfRangeException("Index out of range");

        current.data = newValue;
    }

    #endregion

    #region deleteLast , Delete First , DeletAtIndex , DeleteNodeByValue

    public void deleteFirst()
    {
        if (head != null)
        {
            head = head.next;
        }

        //Other way
        // Node current = head;
        // head = current.next;
    }

    public void deleteLast()
    {
        //where there is only one node in the linked list
        if (head == null || head.next == null)
        {
            head = null;
            return;
        }

        //if more than one node in linkedlist
        //Simple trik - when you use current.next in while loop then you will stop at very last node ,
        //so giving one extra .next like current.next.next will allow you to stop one node ahead of last node

        Node current = head;
        while (current.next.next != null)
        {
            current = current.next;
        }

        // the current pointer is staying at second last node
        current.next = null;
    }

    public void deleteAtIndex(int index)
    {
        if (head == null || index < 0)
            return;

        // taking 0 based index like array
        if (index == 0)
        {
            head = head.next;
            return;
        }

        Node current = head;
        for (int i = 0; current != null && i < index - 1; i++)
        {
            current = current.next;
        }

        if (current == null || current.next == null)
            return;

        // Tricks - traverse 1 less than deleting index = index-1 and skip (current.next.next) the deleting node
        current.next = current.next.next;
    }

    public void deleteNodeByValue(int value)
    {
        if (head == null)
            return;

        // First Node deleting if value match
        while (head != null && head.data == value)
        {
            head = head.next; // Move head if head node holds the value to delete
        }

        Node current = head;
        while (current != null && current.next != null)
        {
            // delete all node with target value - only only just once
            if (current.next.data == value)
            {
                // Skip over (current.next.next) the node to delete it, but don't advance current
                // This way, current.next is now the new "next node", and we'll check it in the next iteration
                current.next = current.next.next;
            }
            else
            {
                // Only advance current if we didn't delete the next node
                current = current.next;
            }

            #region  to just delete first occurance of target value not all
            // // to just delete first occurance of target value not all
            // if (current.next.data == value)
            // {
            //     // Skip over (current.next.next) the node to delete it, but don't advance current
            //     // This way, current.next is now the new "next node", and we'll check it in the next iteration
            //     current.next = current.next.next;
            //     break;
            // }

            // // Only advance current if we didn't delete the next node
            // current = current.next;
            #endregion
        }
    }

    #endregion
  
}
