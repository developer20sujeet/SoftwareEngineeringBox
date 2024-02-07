
using System;

partial class  Solution
{
    // Method to print a square of '*' of size n x n
    public void printRectangle(int n)
    {
        // outer loop = for Row - how many row 
        for (int i = 0; i < n; i++)
        {
            // inner loop == for column that is somehow connected to row
            for (int j = 0; j < n; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine(); // Move to the next line after each row
        }
    }

}

/*
 Output
    * * * * * 
    * * * * * 
    * * * * * 
    * * * * * 
    * * * * * 
*/