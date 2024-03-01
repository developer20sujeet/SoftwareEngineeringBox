using System;

class Program
{
    static void PrintNumbers(int number)
    {
        // Base case: If the number is greater than 3, stop the recursion.
        if (number > 3)
        {
            return;
        }

        // Print the current number.
        Console.WriteLine(number);

        // Reaching toward base case
        number = number + 1;

        // Recursive case: Call the method with the next number.
        PrintNumbers(number);
    }
}
