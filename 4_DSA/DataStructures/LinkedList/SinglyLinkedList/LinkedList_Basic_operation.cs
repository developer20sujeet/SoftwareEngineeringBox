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

}