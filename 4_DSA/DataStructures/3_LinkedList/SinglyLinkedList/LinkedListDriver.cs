public partial class LinkedList
{
    public static void Driver()
    {
        LinkedList myList = new LinkedList();
        bool exit = false;

        // Create a default linked list with 5 nodes and print it
        Console.WriteLine("============================================");
        Console.WriteLine("Default LinkedList Creation (5 nodes)");
        Console.WriteLine("============================================");
        myList.MakeLinkedList(6);
        myList.print();
        Console.WriteLine("\n\n");

        while (!exit)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("LinkedList Operations Menu");
            Console.WriteLine("============================================");
            Console.WriteLine("1: Recreate and print LinkedList (5 nodes)");

            Console.WriteLine();
            Console.WriteLine("=============Add Operation===========================");
            Console.WriteLine("2: AddFirst and print");
            Console.WriteLine("3: AddLast and print");
            Console.WriteLine("4: AddNodeAtIndex and print");

            Console.WriteLine();
            Console.WriteLine("==============Delete Operation========================");
            Console.WriteLine("5: DeleteFirst and print");
            Console.WriteLine("6: DeleteLast and print");
            Console.WriteLine("7: DeleteAtIndex and print");
            Console.WriteLine("8: DeleteNodeByValue and print");

            Console.WriteLine();
            Console.WriteLine("==============Update Operation========================");
            Console.WriteLine("9: Update Node at a Specific Index and print");

            Console.WriteLine();
            Console.WriteLine("==============Search Operation========================");
            Console.WriteLine("10: Search Node by value");
            Console.WriteLine("11: Find Middle");
            Console.WriteLine("12: Has Cycle");
            Console.WriteLine("13: Duplicate Node in Cycle");

            Console.WriteLine();
            Console.WriteLine("99: Exit");
            Console.WriteLine("============================================");

            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine();
            int choice = int.TryParse(input, out choice) ? choice : 0;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n--- Recreating LinkedList with 5 Nodes ---");
                    myList = new LinkedList(); // Reset the list
                    myList.MakeLinkedList(5);
                    myList.print();
                    break;
                case 2:
                    Console.WriteLine("\n--- Adding Node at the Beginning ---");
                    myList = new LinkedList(); // Reset the list
                    myList.MakeLinkedList(5); // Recreate the list for consistency
                    myList.AddFirst(0);
                    myList.print();
                    break;
                case 3:
                    Console.WriteLine("\n--- Adding Node at the End ---");
                    myList.addLast(6);
                    myList.print();
                    break;
                case 4:
                    Console.WriteLine("\n--- Adding Node at a Specific Index ---");
                    Console.Write("Enter the index where you want to add the node: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the value you want to add: ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    myList.AddNodeAtIndex(index, value);
                    myList.print();
                    break;
                case 5:
                    Console.WriteLine("\n--- Deleting the First Node ---");
                    myList.deleteFirst();
                    myList.print();
                    break;
                case 6:
                    Console.WriteLine("\n--- Deleting the Last Node ---");
                    myList.deleteLast();
                    myList.print();
                    break;
                case 7:
                    Console.WriteLine("\n--- Deleting Node at a Specific Index ---");
                    Console.Write("Enter the index of the node to delete: ");
                    int indexToDelete = Convert.ToInt32(Console.ReadLine());
                    myList.deleteAtIndex(indexToDelete);
                    myList.print();
                    break;
                case 8:
                    Console.WriteLine("\n--- Deleting Node by Value ---");
                    Console.Write("Enter the value of the node to delete: ");
                    int valueToDelete = Convert.ToInt32(Console.ReadLine());
                    myList.deleteNodeByValue(valueToDelete);
                    myList.print();
                    break;
                case 9:
                    Console.WriteLine("\n--- Updating Node at a Specific Index ---");
                    Console.Write("Enter the index of the node to update: ");
                    int updateIndex = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the new value for the node: ");
                    int newValue = Convert.ToInt32(Console.ReadLine());
                    myList.UpdateNodeAtIndex(updateIndex, newValue);
                    myList.print();
                    break;

                case 10:
                    Console.WriteLine("\n--- Finding a Node by Value ---");
                    Console.Write("Enter the value of the node to find: ");
                    int searchValue = Convert.ToInt32(Console.ReadLine());
                    int foundIndex = myList.FindNodeByValue(searchValue);
                    if (foundIndex != -1)
                    {
                        Console.WriteLine(
                            $"Node with value {searchValue} found at index {foundIndex}."
                        );
                    }
                    else
                    {
                        Console.WriteLine($"Node with value {searchValue} not found.");
                    }
                    break;

                case 11:
                    Node? middle = myList.FindMiddle();
                    if (middle != null)
                    {
                        Console.WriteLine($"The middle element is: {middle.data}");
                    }
                    else
                    {
                        Console.WriteLine("The list is empty.");
                    }
                    break;

                case 12:
                    bool hasCycle = myList.HasCycle();
                    if (hasCycle)
                        Console.WriteLine("Linked List contains a cycle.");
                    else
                        Console.WriteLine("Linked List does not contain a cycle.");
                    break;

                case 13:
                    Node cycleStart = myList.DetectCycleStart();
                    if (cycleStart != null)
                        Console.WriteLine(
                            $"Cycle detected starting at node with value: {cycleStart.data}"
                        );
                    else
                        Console.WriteLine("No cycle detected.");
                    break;
                    
                case 99:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please select a valid operation.");
                    break;
            }
            Console.WriteLine("\n");
        }
    }
}
