
using System;

partial class  Solution
{
    #region  Triangle - star , number , same number 
    // Method to print a square of '*' of size n x n
    public void printTriangles_Star(int n)
    {
        // outer loop = for Row - how many row 
        for (int i = 1; i < n; i++)
        {
            // inner loop == for column that is somehow connected to row
            for (int j = 1; j <=i; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine(); // Move to the next line after each row
        }
    }

     public void printTriangleByNumber(int n)
    {
        // outer loop = for Row - how many row 
        for (int i = 1; i < n; i++)
        {
            // inner loop == for column that is somehow connected to row
            for (int j = 1; j <=i; j++)
            {
                Console.Write(j + " ");
            }

            Console.WriteLine(); // Move to the next line after each row
        }
    }

     public void printTriangleBySameNumber(int n)
    {
        // outer loop = for Row - how many row 
        for (int i = 1; i < n; i++)
        {
            // inner loop == for column that is somehow connected to row
            for (int j = 1; j <=i; j++)
            {
                Console.Write(i + " "); // just print 
            }

            Console.WriteLine(); // Move to the next line after each row
        }
    }

    #endregion

    #region Inverted  Triangle 

    public void InvertedTriangleStar(int n)
    {
        for (int i = 1; i <=n; i++)
        {
            // inner loop == for column that is somehow connected to row
            for (int j = 0; j <=n-i; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine(); // Move to the next line after each row
        }
    }


    #endregion
}

/*
 Output
    * 
    * * 
    * * * 
    * * * * 


    1 
    2 2 
    3 3 3 
    4 4 4 4 


    #InvertedTriangleStar
    * * * * * 
    * * * * 
    * * * 
    * * 
    *



*/