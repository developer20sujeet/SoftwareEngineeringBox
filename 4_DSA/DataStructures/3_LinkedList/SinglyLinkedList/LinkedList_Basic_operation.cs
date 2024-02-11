using System;
using System.Transactions;

#region  Structure of node

// Node class representation
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

#endregion


public class LinkedList
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

    #region  addLast , AddFirst and AddNodeAtIndex


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


    #region  deleteLast , Delete First , DeletAtIndex , DeleteNodeByValue

    public void deleteFirst()
    {
        Node current = head;
        head = current.next;
    }

    #endregion



    public static void Driver()
    {
        LinkedList myList = new LinkedList();
        bool exit = false;

        // Create a default linked list with 5 nodes and print it
        Console.WriteLine("Creating a linked list with 5 nodes by default:");
        myList.MakeLinkedList(5);
        myList.print();
        Console.WriteLine("\n---\n");

        while (!exit)
        {
            Console.WriteLine("Select an operation to test:");
            Console.WriteLine("1: Recreate and print LinkedList (5 nodes)");


            Console.WriteLine("2: AddFirst and print");
            Console.WriteLine("3: AddLast and print");
            Console.WriteLine("4: AddNodeAtIndex and print");



            Console.WriteLine("5: Exit");





            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine();
            int choice = int.TryParse(input, out choice) ? choice : 0;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Recreating a linked list with 5 nodes:");
                    myList = new LinkedList(); // Reset the list
                    myList.MakeLinkedList(5);
                    myList.print();
                    Console.WriteLine("\n");
                    break;
                case 2:
                    Console.WriteLine("Adding 0 at the beginning:");
                    myList = new LinkedList(); // Reset the list
                    myList.MakeLinkedList(5); // Recreate the list for consistency
                    myList.AddFirst(0);
                    myList.print();
                    Console.WriteLine("\n");
                    break;
                case 3:
                    Console.WriteLine("Adding 6 at the end:");
                    myList.addLast(6);
                    myList.print();
                    Console.WriteLine("\n");
                    break;
                case 4:
                    Console.WriteLine("You have chosen to add a node at a specific index.Note : 0-based indexing");
                    Console.Write("Enter the index where you want to add the node: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the value you want to add: ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    myList.AddNodeAtIndex(index, value);
                    myList.print();
                    Console.WriteLine("\n");
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid operation.\n");
                    break;
            }
        }
    }

   
}
